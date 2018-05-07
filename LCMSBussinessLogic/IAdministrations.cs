using LCMSBussinessLogic.Implemetations;
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
    public interface IAdministrations
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetMenus?roleId={roleId}&languageId={languageId}", ResponseFormat = WebMessageFormat.Json)]
        List<MenuClass> GetMenus(int roleId, int languageId);
    }
}
