using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class UnitArmor
    {
        public int UnitArmorId { get; set; }
        public int UnitId { get; set; }
        public int ArmorTypeId { get; set; }
        public int UnitArmorValue { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual ArmorType ArmorType { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
