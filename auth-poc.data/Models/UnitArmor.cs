using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_poc.data.Models
{
    public class UnitArmor : BaseEntity
    {
        public int UnitArmorId { get; set; }
        public int UnitId { get; set; }
        public int ArmorTypeId { get; set; }
        public string ArmorTypeName { get; set; }
        public int UnitArmorValue { get; set; }
    }
}
