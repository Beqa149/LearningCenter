using LCMSBussinessLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCMSBussinessLogic
{
    public class CatalogClass : ICatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}