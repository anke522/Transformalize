using System;
using System.IO;
using Orchard.ContentManagement;
using Orchard.Core.Common.Models;

namespace Transformalize.Orchard.Models {
    public class FilePart : ContentPart<FilePartRecord> {

        public string FullPath {
            get { return Record.FullPath; }
            set { Record.FullPath = value; }
        }

        public string Direction {
            get { return Record.Direction; }
            set { Record.Direction = value; }
        }

        public string FileName() {
            return Path.GetFileName(Record.FullPath);
        }

        public bool IsValid() {
            return !String.IsNullOrEmpty(FullPath);
        }

        public DateTime CreatedUtc() {
            return this.As<CommonPart>().CreatedUtc ?? DateTime.UtcNow;
        }
    }
}