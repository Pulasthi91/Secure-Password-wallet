using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerater.PasswordData;

namespace PasswordGenerater
{
    class DataModelClass
    {
        #region z_AccountPassword
        public IEnumerable<z_AccountPassword> GetAccountPassword()
        {
            try
            {
                using (var context = new PasswordManagementEntities())
                {
                    var List = context.z_AccountPassword.ToList();
                    List.ForEach(c => context.Detach(c));
                    return List;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SaveAccountPassword(z_AccountPassword newAccountPassword)
        {
            try
            {
                using (var context = new PasswordManagementEntities())
                {
                    context.z_AccountPassword.AddObject(newAccountPassword);
                    return context.SaveChanges() == 1;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateAccountPassword(z_AccountPassword newAccountPassword)
        {
            using (var context = new PasswordManagementEntities())
            {
                try
                {
                    z_AccountPassword currentPassword = context.z_AccountPassword.FirstOrDefault(c => c.password_id == newAccountPassword.password_id);
                    currentPassword.password = newAccountPassword.password;
                    currentPassword.user_name = newAccountPassword.user_name;
                    currentPassword.account_name = newAccountPassword.account_name;
                    return context.SaveChanges() == 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteAccountPassword(z_AccountPassword newAccountPassword)
        {
            using (var context = new PasswordManagementEntities())
            {
                try
                {
                    z_AccountPassword currentPassword = context.z_AccountPassword.FirstOrDefault(c => c.password_id == newAccountPassword.password_id);
                    currentPassword.is_delete = true;
                    return context.SaveChanges() == 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion

        #region usr_User
        public IEnumerable<usr_User> GetUser()
        {
            try
            {
                using (var context = new PasswordManagementEntities())
                {
                    var List = context.usr_User.ToList();
                    List.ForEach(c => context.Detach(c));
                    return List;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SaveUser(usr_User newUser)
        {
            try
            {
                using (var context = new PasswordManagementEntities())
                {
                    context.usr_User.AddObject(newUser);
                    return context.SaveChanges() == 1;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUser(usr_User newUser)
        {
            try
            {
                using (var context = new PasswordManagementEntities())
                {
                    usr_User currentUser = context.usr_User.FirstOrDefault(c => c.user_id == newUser.user_id);
                    currentUser.user_name = newUser.user_name;
                    currentUser.password = newUser.password;
                    return context.SaveChanges() == 1;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(usr_User newUser)
        {
            using (var context = new PasswordManagementEntities())
            {
                usr_User currentUser = context.usr_User.FirstOrDefault(c => c.user_id == newUser.user_id);
                currentUser.is_delete = true;
                return context.SaveChanges() == 1;
            }
        } 
        #endregion
    }
}
