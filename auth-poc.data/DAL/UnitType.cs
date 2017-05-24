using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class UnitType
    {
        public UnitType()
        {
            Unit = new HashSet<Unit>();
        }

        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
    }
}
