using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class Build
    {
        public int BuildId { get; set; }
        public int BuilderId { get; set; }
        public int UnitId { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual Unit Builder { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
