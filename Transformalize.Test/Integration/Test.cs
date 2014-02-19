﻿#region License

// /*
// Transformalize - Replicate, Transform, and Denormalize Your Data...
// Copyright (C) 2013 Dale Newman
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */

#endregion

using NUnit.Framework;
using Transformalize.Configuration;
using Transformalize.Configuration.Builders;
using Transformalize.Libs.NLog;
using Transformalize.Libs.Rhino.Etl.Operations;
using Transformalize.Main;
using Transformalize.Test.Unit.Builders;

namespace Transformalize.Test.Integration {
    [TestFixture]
    public class Test {
        [SetUp]
        public void SetUp() {
            LogManager.Configuration.LoggingRules[0].EnableLoggingForLevel(LogLevel.Info);
            LogManager.ReconfigExistingLoggers();
        }

        [Test]
        public void Init() {
            ProcessFactory.Create("Test", new Options { Mode = "init" }).Run();
        }

        [Test]
        public void Normal() {
            ProcessFactory.Create("Test").Run();
        }

        [Test]
        public void TestMode() {
            ProcessFactory.Create("Test", new Options { Mode = "test", Top = 1, LogLevel = LogLevel.Debug }).Run();
        }

        [Test]
        public void TestBug() {

            var inventory = GetInitialInventory();
            var storageLocations = GetInitialStorageLocations();
            var warehouses = GetInitialWarehouses();
            var process = GetInitialProcess(inventory, storageLocations, warehouses);

            var logLevel = LogLevel.Info;

            //init and run
            var init = ProcessFactory.Create(process, new Options() { Mode = "init", LogLevel = logLevel });
            init.PipelineThreading = PipelineThreading.SingleThreaded;
            init.Run();

            var first = ProcessFactory.Create(process, new Options() { LogLevel = logLevel });
            first.PipelineThreading = PipelineThreading.SingleThreaded;
            first.Run();
            LogManager.Flush();

            Assert.AreEqual(3, first["Inventory"].Inserts);
            Assert.AreEqual(2, first["StorageLocation"].Inserts);
            Assert.AreEqual(2, first["Warehouse"].Inserts);

            Assert.AreEqual(0, first["Inventory"].Updates);
            Assert.AreEqual(0, first["StorageLocation"].Updates);
            Assert.AreEqual(0, first["Warehouse"].Updates);

            inventory = GetInitialInventory();
            storageLocations = GetInitialStorageLocations();
            warehouses = GetInitialWarehouses();
            process = GetInitialProcess(inventory, storageLocations, warehouses);

            //run again, no changes
            var second = ProcessFactory.Create(process, new Options() { LogLevel = logLevel });
            second.PipelineThreading = PipelineThreading.SingleThreaded;
            second.Run();
            LogManager.Flush();

            Assert.AreEqual(0, second["Inventory"].Inserts);
            Assert.AreEqual(0, second["StorageLocation"].Inserts);
            Assert.AreEqual(0, second["Warehouse"].Inserts);

            Assert.AreEqual(0, second["Inventory"].Updates);
            Assert.AreEqual(0, second["StorageLocation"].Updates);
            Assert.AreEqual(0, second["Warehouse"].Updates);

            //move Inventory 2 from Storage Location 1 to Storage Location 2
            process.Entities[0].InputOperation = new RowsBuilder()
                .Row("InventoryKey", 1)
                    .Field("Name", "Inventory 1")
                    .Field("StorageLocationKey", 1)
                .Row("InventoryKey", 2)
                    .Field("Name", "Inventory 2")
                    .Field("StorageLocationKey", 2) //here
                .Row("InventoryKey", 3)
                    .Field("Name", "Inventory 3")
                    .Field("StorageLocationKey", 2)
                .ToOperation();
            process.Entities[1].InputOperation = GetInitialStorageLocations();
            process.Entities[2].InputOperation = GetInitialWarehouses();

            //run again
            var third = ProcessFactory.Create(process, new Options() { LogLevel = logLevel });
            third.PipelineThreading = PipelineThreading.SingleThreaded;
            third.Run();
            LogManager.Flush();

            Assert.AreEqual(0, third["Inventory"].Inserts);
            Assert.AreEqual(0, third["StorageLocation"].Inserts);
            Assert.AreEqual(0, third["Warehouse"].Inserts);

            Assert.AreEqual(1, third["Inventory"].Updates);
            Assert.AreEqual(0, third["StorageLocation"].Updates);
            Assert.AreEqual(0, third["Warehouse"].Updates);
        }

        private static ProcessConfigurationElement GetInitialProcess(IOperation inventory, IOperation storageLocations, IOperation warehouses) {
            return new ProcessBuilder("Bug")
                .Connection("input").Provider("internal")
                .Connection("output").Database("Junk")
                .Entity("Inventory")
                    .Input(inventory)
                    .Version("InventoryHashCode")
                        .Field("InventoryKey").Int32().PrimaryKey()
                        .Field("Name").Alias("Inventory").Default("Default")
                        .Field("StorageLocationKey").Int32()
                        .CalculatedField("InventoryHashCode")
                            .Int32()
                            .Transform("concat").Parameter("*")
                            .Transform("gethashcode")
                .Entity("StorageLocation")
                    .Input(storageLocations)
                    .Version("StorageLocationHashCode")
                        .Field("StorageLocationKey").Int32().PrimaryKey()
                        .Field("Name").Alias("StorageLocation").Default("Default")
                        .Field("WarehouseKey").Int32()
                        .CalculatedField("StorageLocationHashCode")
                            .Int32()
                            .Transform("concat").Parameter("*")
                            .Transform("gethashcode")
                .Entity("Warehouse")
                    .Input(warehouses)
                    .Version("WarehouseHashCode")
                    .Field("WarehouseKey").Int32().PrimaryKey()
                    .Field("Name").Alias("Warehouse").Default("Default")
                    .CalculatedField("WarehouseHashCode")
                        .Int32()
                        .Transform("concat").Parameter("*")
                        .Transform("gethashcode")
                .Relationship()
                    .LeftEntity("Inventory").LeftField("StorageLocationKey")
                    .RightEntity("StorageLocation").RightField("StorageLocationKey")
                .Relationship()
                    .LeftEntity("StorageLocation").LeftField("WarehouseKey")
                    .RightEntity("Warehouse").RightField("WarehouseKey")
                .Process();
        }

        private static IOperation GetInitialWarehouses() {
            return new RowsBuilder()
                .Row("WarehouseKey", 1)
                    .Field("Name", "Warehouse 1")
                .Row("WarehouseKey", 2)
                    .Field("Name", "Warehouse 2")
                .ToOperation();
        }

        private static IOperation GetInitialStorageLocations() {
            return new RowsBuilder()
                .Row("StorageLocationKey", 1)
                    .Field("Name", "Storage Location 1")
                    .Field("WarehouseKey", 1)
                .Row("StorageLocationKey", 2)
                    .Field("Name", "Storage Location 2")
                    .Field("WarehouseKey", 2)
                .ToOperation();
        }

        private static IOperation GetInitialInventory() {
            return new RowsBuilder()
                .Row("InventoryKey", 1)
                    .Field("Name", "Inventory 1")
                    .Field("StorageLocationKey", 1)
                .Row("InventoryKey", 2)
                    .Field("Name", "Inventory 2")
                    .Field("StorageLocationKey", 1)
                .Row("InventoryKey", 3)
                    .Field("Name", "Inventory 3")
                    .Field("StorageLocationKey", 2)
                .ToOperation();
        }
    }
}