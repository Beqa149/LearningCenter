using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCMSBussinessLogic.Exceptions
{
    public class MenuNotFoundException : Exception 
    {
        public MenuNotFoundException(string message) : base(message){}
    }
}