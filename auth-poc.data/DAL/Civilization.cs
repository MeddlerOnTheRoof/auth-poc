using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class Civilization
    {
        public int CivilizationId { get; set; }
        public string CivilizationName { get; set; }
        public string CivilizationDescription { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }
    }
}
