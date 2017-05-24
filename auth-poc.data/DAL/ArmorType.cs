using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class ArmorType
    {
        public ArmorType()
        {
            UnitArmor = new HashSet<UnitArmor>();
        }

        public int ArmorTypeId { get; set; }
        public string ArmorTypeName { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual AttackType AttackType { get; set; }
        public virtual ICollection<UnitArmor> UnitArmor { get; set; }
    }
}
