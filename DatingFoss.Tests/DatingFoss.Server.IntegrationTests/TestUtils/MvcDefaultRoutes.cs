using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Server.IntegrationTests.TestUtils
{
    public static class MvcDefaultRoute
    {
        public static string Create(string controllerName, string actionName)
        {
            var baseName = controllerName.Replace("Controller", "");
            return $"{baseName}/{actionName}";
        }
    }
}
