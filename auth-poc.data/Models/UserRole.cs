using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_poc.data.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }
    }
}
