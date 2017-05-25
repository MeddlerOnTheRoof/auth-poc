using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_poc.data.Models
{
    public class Civilization : BaseEntity
    {
        public int CivilizationId { get; set; }
        public string CivilizationName { get; set; }
        public string CivilizationDescription { get; set; }
    }
}
