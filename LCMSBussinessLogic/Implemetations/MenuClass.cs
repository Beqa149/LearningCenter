using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LCMSBussinessLogic.Implemetations
{
    [DataContract]
    public class MenuClass
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Tittle { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int? ParentID { get; set; }

        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public int OrderNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}