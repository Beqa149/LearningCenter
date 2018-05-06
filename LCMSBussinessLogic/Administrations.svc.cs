using LCMSBussinessLogic.Exceptions;
using LCMSDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LCMSBussinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Administrations" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Administrations.svc or Administrations.svc.cs at the Solution Explorer and start debugging.
    public class Administrations : IAdministrations
    {
        

        public bool AddMenu(Menu menu)
        {
            try
            {
                using (LCDBEntities model = new LCDBEntities())
                {
                    Menu _menu = new Menu();

                    _menu.ID = menu.ID;
                    _menu.Name = menu.Name;
                    _menu.Description = menu.Description;
                    _menu.ParentID = menu.ParentID;
                    _menu.EventName = menu.EventName;
                    _menu.OrderNumber = menu.OrderNumber;
                    _menu.IsActive = menu.IsActive;

                    model.Menus.Add(_menu);

                    model.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false ;
            }
        }

        public bool EditMenu(Menu menu)
        {
            try
            {
                using (LCDBEntities model = new LCDBEntities())
                {
                    var _menu = model.Menus.FirstOrDefault(m => m.ID == menu.ID);
                    if (_menu == null)
                        throw new MenuNotFoundException("Menu not found with this id");

                    _menu.IsActive = menu.IsActive;
                    _menu.Name = menu.Name;
                    _menu.Description = menu.Description;
                    _menu.ParentID = menu.ParentID;
                    _menu.EventName = menu.EventName;
                    _menu.OrderNumber = menu.OrderNumber;

                    model.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ex is MenuNotFoundException)
                    throw ex;
                return false;
            }
        }

        public bool ChangeStatus(Menu menu, bool status)
        {
            try
            {
                using (LCDBEntities model = new LCDBEntities())
                {
                    var _menu = model.Menus.FirstOrDefault(o => o.ID == menu.ID);
                    if (_menu == null)
                        throw new MenuNotFoundException("Menu not found with this id");
                    _menu.IsActive = status;

                    model.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ex is MenuNotFoundException)
                    throw ex;
                return false;
            }
        }

        public bool ChangeMenuIndex(Menu menu,int ordernNUmber)
        {
            try
            {
                using (LCDBEntities model = new LCDBEntities())
                {
                    var _menu = model.Menus.FirstOrDefault(o => o.ID == menu.ID);
                    if (_menu == null)
                        throw new MenuNotFoundException("Menu not found with this id");

                    var menuItem = model.Menus.FirstOrDefault(o => o.OrderNumber == ordernNUmber);

                    if (menuItem != null)
                    {

                        //model.Menus.Skip(ordernNUmber).Select(o => { o.OrderNumber++; return true; });

                        //for (int i = ordernNUmber; i < model.Menus.Count(); i++)
                        //{
                        //    model.Menus.ToList()[i].OrderNumber++;
                        //}

                        model.Menus.Skip(ordernNUmber).ToList().ForEach(o => { o.OrderNumber = o.OrderNumber++; });

                        menu.OrderNumber = ordernNUmber;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex is MenuNotFoundException)
                    throw ex;
                return false;
            }
        }
        public void DoWork()
        {
        }


    }
}
