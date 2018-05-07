using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCMSBussinessLogic.Exceptions
{
    public class CatalogNotFoundException : Exception
    {
        public CatalogNotFoundException(string message) : base(message) { }
     
    }
}