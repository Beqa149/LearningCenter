using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LCMSBussinessLogic
{  
    [ServiceContract]
    public interface IAuthorize
    {
        [OperationContract]
        [WebGet(UriTemplate="GetRoles", ResponseFormat = WebMessageFormat.Json)]
        List<string> GetRoles();
    }    
}
