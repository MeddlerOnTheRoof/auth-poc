using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_poc.data.Models
{
    public class Unit : BaseEntity
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public int Food { get; set; }
        public int Gold { get; set; }
        public int Stone { get; set; }
        public int Wood { get; set; }
        public int MoveSpeed { get; set; }
        public int LineOfSight { get; set; }
        public int Health { get; set; }
        public int? AttackRange { get; set; }
        public int Attack { get; set; }
        public int AttackTypeId { get; set; }
        public string AttackTypeName { get; set; }
        public int AttackSpeed { get; set; }

        // todo: add the following
        // Builders
        // Constructs
        // Unit Armor
    }
}
