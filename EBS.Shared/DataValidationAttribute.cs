using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Shared
{
    public class DataValidationAttribute : Attribute
    {
        public bool Exclude { get; set; }

        public bool Required { get; set; }

        public int MaxLength { get; set; }

        public int MinLength { get; set; }
    }
}
