using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LCMSDataAccess;

namespace LCMSBussinessLogic
{    
    public class Authorize : IAuthorize
    {
        public List<string> GetRoles()
        {
            using (LCDBEntities model = new LCDBEntities())
            {
                return model.Roles.Select(i => i.Name).ToList();
            }
        }       
    }
}
