using EBS.Shared;
using System;

namespace EBS.Entities
{
    public class BaseEntity
    {
        //[DataValidation(Exclude = true)]
        //public DateTime CreateDate { get; set; }

        //[DataValidation(Exclude = true)]
        //public int CreatedBy { get; set; }

        [DataValidation(Exclude = true)]
        public DateTime UpdateDate { get; set; }

        [DataValidation(Required = true)]
        public int UpdatedBy { get; set; }
    }
}