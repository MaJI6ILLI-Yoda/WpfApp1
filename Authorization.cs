using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace WpfApp1
{
    internal class Authorization
    {
        public static string authorizationRole;
        public static string GetRole(string emailadress, string password)
        {
            var account = LogiClickeEntities.GetContext().Account.FirstOrDefault(a => a.EmailAdress == emailadress && a.Password == password);
            if (account != null) return authorizationRole = account.Role.name_role;
            return null;
        }
    }
}
