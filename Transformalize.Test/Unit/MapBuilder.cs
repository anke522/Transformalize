﻿using System.Collections.Generic;

namespace Transformalize.Test.Unit {
    public class MapBuilder {
        
        private readonly MapsBuilder _mapsBuilder;
        private readonly Main.Map _map;

        public MapBuilder(ref MapsBuilder mapsBuilder, Main.Map map) {
            _map = map;
            _mapsBuilder = mapsBuilder;
        }

        public IEnumerable<Main.Map> ToMaps() {
            return _mapsBuilder.ToMaps();
        }

        public MapBuilder Equals() {
            return _mapsBuilder.Equals();
        }

        public MapBuilder StartsWith() {
            return _mapsBuilder.StartsWith();
        }

        public MapBuilder EndsWith() {
            return _mapsBuilder.EndsWith();
        }

        public MapBuilder Item(string from, object to, string parameter) {
            _map[from] = new Main.Item(parameter, to);
            return this;
        }

        public MapBuilder Item(string from, object to) {
            _map[from] = new Main.Item(to);
            return this;
        }

    }
}