using System;
using System.Collections.Generic;

namespace auth_poc.data.DAL
{
    public partial class UserAccount
    {
        public int UserAccountId { get; set; }
        public string UserAccountName { get; set; }
        public string UserAccountPassword { get; set; }
        public int UserRoleId { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedByDate { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
