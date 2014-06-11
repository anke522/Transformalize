using System.Collections.Generic;

namespace Transformalize.Main.Providers.File {

    public class FileInspectionRequest {

        private Dictionary<char, string> _delimiters = new Dictionary<char, string> {
            { '\t', "tab" },
            { ',', "comma" },
            { '|', "pipe" },
            { ';', "semicolon" }
        };
        private string _defaultType = "string";
        private string _defaultLength = "1024";
        private List<string> _dataTypes = new List<string> { "boolean", "int", "long", "single", "double", "decimal", "datetime" };

        public int Top { get; set; }
        public decimal Sample { get; set; }

        public string DefaultType {
            get { return _defaultType; }
            set { _defaultType = value; }
        }

        public string DefaultLength {
            get { return _defaultLength; }
            set { _defaultLength = value; }
        }

        public List<string> DataTypes {
            get { return _dataTypes; }
            set { _dataTypes = value; }
        }

        public Dictionary<char, string> Delimiters {
            get { return _delimiters; }
            set { _delimiters = value; }
        }

    }
}