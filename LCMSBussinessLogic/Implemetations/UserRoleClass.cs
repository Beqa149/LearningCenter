using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LCMSBussinessLogic
{
    [DataContract]
    public class UserRoleClass
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int RoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}