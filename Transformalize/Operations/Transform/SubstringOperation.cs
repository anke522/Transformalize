using System.Collections.Generic;
using System.Threading;
using Transformalize.Libs.Rhino.Etl;

namespace Transformalize.Operations.Transform {

    public class SubstringOperation : ShouldRunOperation {
        private readonly int _startIndex;
        private readonly int _length;

        public SubstringOperation(string inKey, string outKey, int startIndex, int length)
            : base(inKey, outKey) {
            _startIndex = startIndex;
            _length = length;
            Name = string.Format("SubstringOperation ({0})", outKey);
        }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows) {
            foreach (var row in rows) {

                if (ShouldRun(row)) {

                    var value = row[InKey].ToString();
                    if (_startIndex < value.Length) {
                        if (_length == 0) {
                            row[OutKey] = value.Substring(_startIndex);
                        } else {
                            row[OutKey] = value.Substring(_startIndex, _length);
                        }
                    }
                } else {
                    Interlocked.Increment(ref SkipCount);
                }

                yield return row;
            }
        }
    }
}