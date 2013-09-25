#region License

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

using Transformalize.Libs.NLog.Config;

namespace Transformalize.Libs.NLog.Layouts
{
    /// <summary>
    ///     A column in the CSV.
    /// </summary>
    [NLogConfigurationItem]
    [ThreadAgnostic]
    public class CsvColumn
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CsvColumn" /> class.
        /// </summary>
        public CsvColumn()
            : this(null, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CsvColumn" /> class.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <param name="layout">The layout of the column.</param>
        public CsvColumn(string name, Layout layout)
        {
            Name = name;
            Layout = layout;
        }

        /// <summary>
        ///     Gets or sets the name of the column.
        /// </summary>
        /// <docgen category='CSV Column Options' order='10' />
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the layout of the column.
        /// </summary>
        /// <docgen category='CSV Column Options' order='10' />
        [RequiredParameter]
        public Layout Layout { get; set; }
    }
}