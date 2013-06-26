using System.Text;

namespace Transformalize.Transforms {
    public class SubstringTransform : ITransform {
        private readonly int _startIndex;
        private readonly int _length;

        public SubstringTransform(int startIndex, int length) {
            _startIndex = startIndex;
            _length = length;
        }

        public void Transform(StringBuilder sb) {
            sb.Substring(_startIndex, _length);
        }
    }
}