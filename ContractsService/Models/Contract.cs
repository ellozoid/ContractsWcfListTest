using System;
using System.Runtime.Serialization;

namespace ContractsService.Models
{
    [DataContract]
    public class Contract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Number { get; set; }
        
        [DataMember]
        public DateTime CreateDate { get; set; }
        
        [DataMember]
        public DateTime ModifyDate { get; set; }
    }
}