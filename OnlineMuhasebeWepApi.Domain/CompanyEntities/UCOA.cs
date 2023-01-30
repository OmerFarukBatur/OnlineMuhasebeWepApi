using OnlineMuhasebeWepApi.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Domain.CompanyEntities
{
    public sealed class UCOA : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; } // Ana grup, Grup, Muavin
        


    }
}
