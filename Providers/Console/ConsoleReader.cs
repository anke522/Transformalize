﻿using System;
using System.Collections.Generic;
using System.Linq;
using Transformalize.Context;
using Transformalize.Contracts;

namespace Transformalize.Provider.Console {
    public class ConsoleReader : IRead {

        private readonly InputContext _input;
        private readonly IRowFactory _rowFactory;
        private readonly IField _inputField;

        public ConsoleReader(InputContext input, IRowFactory rowFactory) {
            _rowFactory = rowFactory;
            _input = input;
            _inputField = input.InputFields.FirstOrDefault();
        }

        public IEnumerable<IRow> Read() {
            if (!System.Console.IsInputRedirected) {
                yield break;
            }

            if (_inputField == null) {
                _input.Error("You must have one input field for console provider input.");
                yield break;
            }

            string line;
            var lineNumber = 1;

            while ((line = System.Console.In.ReadLine()) != null) {

                if (line == string.Empty || lineNumber < _input.Connection.Start) {
                    lineNumber++;
                    continue;
                }

                if (_input.Connection.End > 0 && lineNumber > _input.Connection.End) {
                    yield break;
                }

                var row = _rowFactory.Create();
                row[_inputField] = line;
                lineNumber++;
                yield return row;
            }
        }
    }
}
