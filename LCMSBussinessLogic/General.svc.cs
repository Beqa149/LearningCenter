using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LCMSBussinessLogic.Abstractions;
using LCMSDataAccess;
using LCMSBussinessLogic.Exceptions;


namespace LCMSBussinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "General" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select General.svc or General.svc.cs at the Solution Explorer and start debugging.
    public class General : IGeneral
    {
        public bool AddNewCatalog(ICatalog catalog)
        {
            try
            {
                using (var model = new LCDBEntities())
                {
                    var newCatalog = new Catalog()
                    {
                        Name = catalog.Name,
                        ParentID = catalog.ParentId,
                        IsActive = catalog.IsActive
                    };

                    model.Catalogs.Add(newCatalog);
                    model.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCatalog(int id, string name, int? parentId)
        {
            try
            {
                using (var model = new LCDBEntities())
                {
                    var catalog = model.Catalogs.FirstOrDefault(c => c.ID == id);
                    if (catalog == null)
                        throw new CatalogNotFoundException("Catalog with this id not found in database");

                    catalog.Name = name;
                    catalog.ParentID = parentId;
                    model.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex is CatalogNotFoundException)
                    throw ex;

                return false;
            }
        }

        public List<ICatalog> GetCatalogsByParentId(int? parentID)
        {
            try
            {
                using (var model = new LCDBEntities())
                {
                    var catalogs = model.Catalogs.Where(c => c.ParentID == parentID);
                    if(catalogs == null)
                        return new List<ICatalog>();

                    var result = catalogs.Select(c => new CatalogClass
                    {
                        Id = c.ID,
                        IsActive = c.IsActive,
                        Name = c.Name,
                        ParentId = c.ParentID
                    }).ToList<ICatalog>();

                    return result;
                }
            }
            catch (Exception)
            {
                return new List<ICatalog>();    
            }
        }

        public bool SetStatusAsActive(int id, bool isActive)
        {
            try
            {
                using (var model = new LCDBEntities())
                {
                    var catalog = model.Catalogs.FirstOrDefault(c => c.ID == id);
                    if (catalog == null)
                        throw new CatalogNotFoundException("Catalog with this id not found in database");

                    catalog.IsActive = isActive;
                    model.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex is CatalogNotFoundException)
                    throw ex;

                return false;
            }
        }
    }
}
