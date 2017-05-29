using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserAccount = new HashSet<UserAccount>();
        }

        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual ICollection<UserAccount> UserAccount { get; set; }
    }
}
