using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class AttackType
    {
        public AttackType()
        {
            Unit = new HashSet<Unit>();
        }

        public int AttackTypeId { get; set; }
        public string AttackTypeName { get; set; }
        public int ArmorTypeId { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
        public virtual ArmorType ArmorType { get; set; }
    }
}
