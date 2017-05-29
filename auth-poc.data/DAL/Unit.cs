using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class Unit
    {
        public Unit()
        {
            BuildBuilder = new HashSet<Build>();
            BuildUnit = new HashSet<Build>();
            UnitArmor = new HashSet<UnitArmor>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int UnitTypeId { get; set; }
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
        public int AttackSpeed { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual ICollection<Build> BuildBuilder { get; set; }
        public virtual ICollection<Build> BuildUnit { get; set; }
        public virtual ICollection<UnitArmor> UnitArmor { get; set; }
        public virtual AttackType AttackType { get; set; }
        public virtual UnitType UnitType { get; set; }
    }
}
