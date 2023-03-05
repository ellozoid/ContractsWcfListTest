using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ContractsService.Data.Models
{
    public class ContractEntity
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public DateTime CreateDate { get; set; }
        
        public DateTime ModifyDate { get; set; }
    }
}