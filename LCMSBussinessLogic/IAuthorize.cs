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
        [WebGet(UriTemplate = "GetRoles", ResponseFormat = WebMessageFormat.Json)]
        List<RoleClass> GetRoles();

        [OperationContract]
        [WebGet(UriTemplate = "FindUser/{pn}", ResponseFormat = WebMessageFormat.Json)]
        UserClass FindUser(string pn);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        bool AddRole(RoleClass role);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool UpdateRole(RoleClass role);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
    RequestFormat = WebMessageFormat.Json)]
        bool AddUser(UserClass user);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        bool UpdateUser(UserClass user);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool BlockUnblock(int userId, int roleId);
    }
}
