using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LCMSDataAccess;
using System.Transactions;

namespace LCMSBussinessLogic
{

    public class Authorize : IAuthorize
    {
        #region ROLES

        public List<RoleClass> GetRoles()
        {
            using (LCDBEntities model = new LCDBEntities())
            {
                return model.Roles.Select(i =>
                new RoleClass { ID = i.ID, Name = i.Name, Description = i.Description }).ToList();
            }
        }

        public bool AddRole(RoleClass role)
        {
            try
            {
                LCDBEntities model = new LCDBEntities();
                if (model.Roles.Any(i => i.Name.Equals(role.Name)))
                    throw new Exception("This Role already exists...");

                Role r = new Role();
                r.Name = role.Name;
                r.Description = role.Description;
                model.Roles.Add(r);
                model.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRole(RoleClass role)
        {
            try
            {
                LCDBEntities model = new LCDBEntities();
                if (!model.Roles.Any(i => i.Name.Equals(role.Name)))
                    throw new Exception("This role not found...");

                Role r = model.Roles.Where(i => i.Name.Equals(role.Name)).First();
                r.Name = role.Name;
                r.Description = role.Description;
                model.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AssignNewRole(int userId, int roleId)
        {
            try
            {
                LCDBEntities model = new LCDBEntities();
                if (model.UserRoles.Any(i => i.UserID == userId && i.RoleID == roleId))
                    throw new Exception("The Role is already assigned for this User...");

                UserRole ur = new UserRole();
                ur.UserID = userId;
                ur.RoleID = roleId;
                ur.IsActive = true;

                model.UserRoles.Add(ur);
                model.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        public bool AddUser(UserClass user)
        {
            try
            {
                using (LCDBEntities model = new LCDBEntities())
                {
                    using (TransactionScope t = new TransactionScope())
                    {
                        try
                        {
                            if (model.Users.Any(i => i.PersonalNumber.Equals(user.PersonalNumber)))
                                throw new Exception("This user already exists...");

                            User u = new User();
                            u.PersonalNumber = user.PersonalNumber;
                            u.FirstName = user.FirstName;
                            u.LastName = user.LastName;
                            u.EMail = user.EMail;
                            u.Password = user.Password;
                            u.BirthDate = user.BirthDate;
                            u.NationalityID = user.NationalityID;
                            u.Avatar = user.Avatar;
                            u.Address1 = user.Address1;
                            u.Address2 = user.Address2;
                            u.PhoneNumber = user.PhoneNumber;
                            u.GenderId = user.GenderId;
                            model.Users.Add(u);

                            UserRole ur = new UserRole();
                            ur.RoleID = user.RoleId;
                            ur.UserID = u.ID;
                            ur.IsActive = true;
                            model.UserRoles.Add(ur);

                            model.SaveChanges();

                            t.Complete();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            t.Dispose();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(UserClass user)
        {
            try
            {
                using (LCDBEntities model = new LCDBEntities())
                {
                    using (TransactionScope t = new TransactionScope())
                    {
                        try
                        {
                            if (!model.Users.Any(i => i.PersonalNumber.Equals(user.PersonalNumber)))
                                throw new Exception("This user not found...");

                            User u = model.Users.Where(i => i.PersonalNumber.Equals(user.PersonalNumber)).First();
                            u.FirstName = user.FirstName;
                            u.LastName = user.LastName;
                            u.BirthDate = user.BirthDate;
                            u.NationalityID = user.NationalityID;
                            u.Avatar = user.Avatar;
                            u.Address1 = user.Address1;
                            u.Address2 = user.Address2;
                            u.PhoneNumber = user.PhoneNumber;
                            u.GenderId = user.GenderId;

                            if (!model.UserRoles.Any(i => i.UserID == u.ID))
                                throw new Exception("role not found...");

                            UserRole ur = model.UserRoles.Where(i => i.UserID == u.ID).First();
                            ur.RoleID = user.RoleId;

                            model.SaveChanges();

                            t.Complete();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            t.Dispose();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            try
            {
                LCDBEntities model = new LCDBEntities();




                model.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }

        public bool BlockUnblock(int userId, int roleId)
        {
            try
            {
                LCDBEntities model = new LCDBEntities();
                if (!model.UserRoles.Any(i => i.UserID == userId && i.RoleID == roleId))
                    throw new Exception("role not found...");

                UserRole u = model.UserRoles.Where(i => i.UserID == userId && i.RoleID == roleId).First();
                u.IsActive = !u.IsActive;
                model.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserClass FindUser(string pn)
        {
            try
            {
                LCDBEntities model = new LCDBEntities();

                if (!model.Users.Any(i => i.PersonalNumber.Equals(pn)))
                    throw new Exception("User not found...");

                var result = model.Users.Where(i => i.PersonalNumber.Equals(pn)).Select(i =>
                         new UserClass
                         {
                             Id = i.ID,
                             FirstName = i.FirstName,
                             LastName = i.LastName,
                             EMail = i.EMail,
                             BirthDate = i.BirthDate,
                             NationalityID = i.NationalityID,
                             Avatar = i.Avatar,
                             Address1 = i.Address1,
                             Address2 = i.Address2,
                             PhoneNumber = i.PhoneNumber,
                             GenderId = i.GenderId,
                             Roles = i.UserRoles.Select(k =>
                             new RoleClass
                             { ID = k.ID, Name = k.Role.Name, Description = k.Role.Description }).ToList()
                         }).First();

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
