﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;
using Transformalize.Configuration;

namespace Transformalize.Main {
    public class RelationshipsReader {

        private readonly Process _process;
        private readonly RelationshipElementCollection _elements;

        private const StringComparison IC = StringComparison.OrdinalIgnoreCase;

        public RelationshipsReader(Process process, RelationshipElementCollection elements) {
            _process = process;
            _elements = elements;
        }

        public List<Relationship> Read() {
            var relationships = new List<Relationship>();

            foreach (RelationshipConfigurationElement r in _elements) {
                Entity leftEntity;
                if (_process.Entities.Any(e => e.Alias.Equals(r.LeftEntity, IC))) {
                    leftEntity = _process.Entities.First(e => e.Alias.Equals(r.LeftEntity, IC));
                } else {
                    throw new TransformalizeException("Can't find left entity {0}.", r.LeftEntity);
                }

                Entity rightEntity;
                if (_process.Entities.Any(e => e.Alias.Equals(r.RightEntity, IC))) {
                    rightEntity = _process.Entities.First(e => e.Alias.Equals(r.RightEntity, IC));
                } else {
                    throw new TransformalizeException("Can't find right entity {0}.", r.RightEntity);
                }

                var join = GetJoins(r, leftEntity, rightEntity);
                var relationship = new Relationship {
                    LeftEntity = leftEntity,
                    RightEntity = rightEntity,
                    Index = r.Index,
                    Join = join
                };

                relationships.Add(relationship);
            }
            return relationships;
        }

        private List<Join> GetJoins(RelationshipConfigurationElement r, Entity leftEntity, Entity rightEntity) {
            if (string.IsNullOrEmpty(r.LeftField)) {
                return (
                    from JoinConfigurationElement j in r.Join
                    select GetJoin(leftEntity, j.LeftField, rightEntity, j.RightField)
                ).ToList();
            }

            // if it's a single field join, you can use leftField and rightField on the relationship element
            return new List<Join> {
                GetJoin(leftEntity, r.LeftField, rightEntity, r.RightField)
            };
        }

        private static Join GetJoin(Entity leftEntity, string leftField, Entity rightEntity, string rightField) {

            var leftFields = leftEntity.OutputFields();
            var rightFields = rightEntity.OutputFields();
            var leftHit = leftFields.Any(f => f.Alias.Equals(leftField));
            var rightHit = rightFields.Any(f => f.Alias.Equals(rightField));

            if (!leftHit && !leftFields.Find(leftField).Any()) {
                throw new TransformalizeException("The left entity {0} does not have a field named {1} for joining to the right entity {2} with field {3}.", leftEntity.Alias, leftField, rightEntity.Alias, rightField);
            }

            if (!rightHit && !rightFields.Find(rightField).Any()) {
                throw new TransformalizeException("The right entity {0} does not have a field named {1} for joining to the left entity {2} with field {3}.", rightEntity.Alias, rightField, leftEntity.Alias, leftField);
            }

            var join = new Join {
                LeftField = leftHit
                        ? leftFields.First(f => f.Alias.Equals(leftField))
                        : leftFields.Find(leftField).First(),
                RightField = rightHit
                        ? rightFields.First(f => f.Alias.Equals(rightField))
                        : rightFields.Find(rightField).First()
            };

            if (join.LeftField.FieldType.HasFlag(FieldType.MasterKey) || join.LeftField.FieldType.HasFlag(FieldType.PrimaryKey)) {
                join.LeftField.FieldType |= FieldType.ForeignKey;
            } else {
                join.LeftField.FieldType = FieldType.ForeignKey;
            }

            return join;
        }

    }
}
