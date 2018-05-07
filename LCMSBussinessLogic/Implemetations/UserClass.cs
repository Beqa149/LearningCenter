using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LCMSBussinessLogic
{
    [DataContract]
    public class UserClass
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string EMail { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PersonalNumber { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public int NationalityID { get; set; }

        [DataMember]
        public byte[] Avatar { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public int GenderId { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        public List<RoleClass> Roles { get; set; }
    }
}