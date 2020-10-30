using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Compensation
    {
        [Key]
        public ulong id { get; set; }

        public Employee Employee { get; set; }
        public float Salary { get; set; }
        public String EffectiveDate { get; set; }
    }
}
