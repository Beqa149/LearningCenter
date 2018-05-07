using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMSBussinessLogic.Abstractions
{
   public  interface ICatalog
   {
        int Id { get; set; }
        string Name { get; set; }
        int? ParentId { get; set; }
        bool IsActive { get; set; }
    }
}
