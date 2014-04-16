using System;
using System.Collections.Generic;
using System.Linq;
using Transformalize.Libs.Rhino.Etl;
using Transformalize.Libs.Rhino.Etl.Operations;

namespace Transformalize.Main.Providers.ElasticSearch
{
    public class ElasticSearchEntityOutputKeysExtract : AbstractOperation {
        private readonly AbstractConnection _connection;
        private readonly Entity _entity;
        private readonly List<AliasType> _aliasTypes = new List<AliasType>();
        private readonly string[] _sourceInclude;
        private readonly Dictionary<string, Func<object, object>> _conversionMap = Common.GetObjectConversionMap();

        private struct AliasType {
            public string Alias;
            public string AliasLower;
            public string SimpleType;
        }

        public ElasticSearchEntityOutputKeysExtract(AbstractConnection connection, Entity entity) {
            _connection = connection;
            _entity = entity;
            _aliasTypes = _entity.PrimaryKey.Select(f => new AliasType() { Alias = f.Value.Alias, AliasLower = f.Value.Alias.ToLower(), SimpleType = f.Value.SimpleType }).ToList();
            if (_entity.Version != null) {
                _aliasTypes.Add(new AliasType() { Alias = _entity.Version.Alias, AliasLower = _entity.Version.Alias.ToLower(), SimpleType = _entity.Version.SimpleType });
            }
            _sourceInclude = _aliasTypes.Select(at => at.AliasLower).ToArray();
        }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows) {
            var client = ElasticSearchClientFactory.Create(_connection, _entity);
            var result = client.Client.SearchGet(client.Index, client.Type, s => s
                .Add("q", "*:*")
                .Add("_source_include", string.Join(",", _sourceInclude))
                .Add("size", 10000000)
                );
            var hits = result.Response["hits"].hits;
            for (var i = 0; i < result.Response["hits"].total; i++) {
                var row = new Row();
                foreach (var field in _aliasTypes) {
                    var value = hits[i]["_source"][field.AliasLower];
                    row[field.Alias] = _conversionMap[field.SimpleType](value);
                }
                yield return row;
            }
        }
    }
}