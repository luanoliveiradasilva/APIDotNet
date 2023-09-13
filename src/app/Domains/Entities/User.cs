using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.app.Domains.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}