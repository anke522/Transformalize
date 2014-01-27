﻿using System;
using System.Collections.Generic;
using Transformalize.Libs.EnterpriseLibrary.Validation.Validators;
using Transformalize.Libs.Rhino.Etl;
using Transformalize.Main;

namespace Transformalize.Operations.Transform {
    public class IfOperation : TflOperation {

        private readonly ComparisonOperator _op;

        private readonly KeyValuePair<string, IParameter> _left;
        private readonly KeyValuePair<string, IParameter> _right;
        private readonly KeyValuePair<string, IParameter> _then;
        private readonly KeyValuePair<string, IParameter> _else;

        private readonly bool _leftHasValue;
        private readonly bool _rightHasValue;
        private readonly bool _thenHasValue;
        private readonly bool _elseHasValue;

        private readonly object _leftValue;
        private readonly object _rightValue;
        private readonly object _thenValue;
        private readonly object _elseValue;
        private readonly Dictionary<string, Func<object, object>> _conversionMap = Common.GetObjectConversionMap();

        private readonly Dictionary<string, KeyValuePair<string, IParameter>> _builtIns = new Dictionary<string, KeyValuePair<string, IParameter>> {
            {"true", new KeyValuePair<string, IParameter>("true", new Parameter("true", true) { SimpleType = "boolean"} )},
            {"false", new KeyValuePair<string, IParameter>("false", new Parameter("false", false) { SimpleType = "boolean"} )},
            {string.Empty, new KeyValuePair<string, IParameter>(string.Empty, new Parameter(string.Empty, string.Empty))}
        };

        public IfOperation(
            IParameter leftParameter,
            ComparisonOperator op,
            IParameter rightParameter,
            IParameter thenParameter,
            IParameter elseParameter,
            string outKey,
            string outType
        )
            : base(string.Empty, outKey) {

            _op = op;

            _left = _builtIns.ContainsKey(leftParameter.Name.ToLower()) ? _builtIns[leftParameter.Name.ToLower()] : new KeyValuePair<string, IParameter>(leftParameter.Name, leftParameter);
            _right = _builtIns.ContainsKey(rightParameter.Name.ToLower()) ? _builtIns[rightParameter.Name.ToLower()] : new KeyValuePair<string, IParameter>(rightParameter.Name, rightParameter);
            _then = _builtIns.ContainsKey(thenParameter.Name.ToLower()) ? _builtIns[thenParameter.Name.ToLower()] : new KeyValuePair<string, IParameter>(thenParameter.Name, thenParameter);
            _else = _builtIns.ContainsKey(elseParameter.Name.ToLower()) ? _builtIns[elseParameter.Name.ToLower()] : new KeyValuePair<string, IParameter>(elseParameter.Name, elseParameter);

            _leftHasValue = _left.Value.HasValue();
            _rightHasValue = _right.Value.HasValue();
            _thenHasValue = _then.Value.HasValue();
            _elseHasValue = _else.Value.HasValue();

            _leftValue = _leftHasValue ? ComparableValue(_right.Value.SimpleType, _left.Value.Value) : null;
            _rightValue = _rightHasValue ? ComparableValue(_left.Value.SimpleType, _right.Value.Value) : null;
            _thenValue = _thenHasValue ? ComparableValue(outType, _then.Value.Value) : null;
            _elseValue = _elseHasValue ? ComparableValue(outType, _else.Value.Value) : null;

            if (Common.CompareMap.ContainsKey(_op))
                return;

            Error("Operator {0} is invalid.  Try equal, notequal, greaterthan, greaterthanequal, greaterthan, or greaterthanequal.");
            Environment.Exit(1);
        }

        private object ComparableValue(string otherType, object value) {
            if (value.Equals(string.Empty) && !otherType.Equals("string")) {
                return new DefaultFactory().Convert(value, otherType);
            }

            return _conversionMap[otherType](value);
        }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows) {
            foreach (var row in rows) {

                if (ShouldRun(row)) {
                    var leftValue = _leftHasValue ? _leftValue : row[_left.Key];
                    var rightValue = _rightHasValue ? _rightValue : row[_right.Key];

                    if (Common.CompareMap[_op](leftValue, rightValue)) {
                        row[OutKey] = _thenHasValue ? _thenValue : row[_then.Key];
                    } else {
                        row[OutKey] = _elseHasValue ? _elseValue : row[_else.Key];
                    }
                }

                yield return row;
            }
        }
    }
}