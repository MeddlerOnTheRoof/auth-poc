using System;

namespace auth_poc.data.Models
{
    public class BaseEntity
    {
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }
    }
}
