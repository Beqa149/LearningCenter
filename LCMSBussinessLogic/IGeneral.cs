using LCMSBussinessLogic.Abstractions;
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
    public interface IGeneral
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetCatalogByParentId?parentID={parentID}", ResponseFormat = WebMessageFormat.Json)]
        List<ICatalog> GetCatalogsByParentId(int? parentID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool AddNewCatalog(ICatalog catalog);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool EditCatalog(int id, string name, int? parentId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool SetStatusAsActive(int id, bool isActive);
    }
}
