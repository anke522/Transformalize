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

using System.Configuration;
using System.Linq;

namespace Transformalize.Configuration {
    public class ProviderElementCollection : MyConfigurationElementCollection {
        public ProviderConfigurationElement this[int index] {
            get { return BaseGet(index) as ProviderConfigurationElement; }
            set {
                if (BaseGet(index) != null) {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public override bool IsReadOnly() {
            return false;
        }

        protected override ConfigurationElement CreateNewElement() {
            return new ProviderConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((ProviderConfigurationElement)element).Name.ToLower();
        }

        public void Add(params ProviderConfigurationElement[] providers) {

            foreach (var p in providers) {
                var key = p.Name.ToLower();
                if (BaseGetAllKeys().Any(k => k.Equals(key))) {
                    BaseRemove(key);
                }
            }

            foreach (var p in providers) {
                BaseAdd(p);
            }
        }
    }
}