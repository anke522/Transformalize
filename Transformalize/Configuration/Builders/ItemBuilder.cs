using Transformalize.Libs.Newtonsoft.Json;

namespace Transformalize.Configuration.Builders
{
    public class ItemBuilder {
        private readonly ProcessBuilder _processBuilder;
        private readonly MapBuilder _mapBuilder;
        private readonly TflMapItem _item;

        public ItemBuilder(ProcessBuilder processBuilder, MapBuilder mapBuilder, TflMapItem item) {
            _processBuilder = processBuilder;
            _mapBuilder = mapBuilder;
            _item = item;
        }

        public ItemBuilder From(string from) {
            _item.From = from;
            return this;
        }

        public ItemBuilder To(string to) {
            _item.To = to;
            return this;
        }

        public ItemBuilder Equals() {
            _item.Operator = "equals";
            return this;
        }

        public ItemBuilder StartsWith() {
            _item.Operator = "startswith";
            return this;
        }

        public ItemBuilder EndsWith() {
            _item.Operator = "endswith";
            return this;
        }
        
        public ItemBuilder Item() {
            return _mapBuilder.Item();
        }

        public TflProcess Process() {
            return _mapBuilder.Process();
        }

        public MapBuilder Map(string name) {
            return _processBuilder.Map(name);
        }
    }
}