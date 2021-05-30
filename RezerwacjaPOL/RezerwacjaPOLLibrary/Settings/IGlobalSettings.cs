using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Settings
{
    public interface IGlobalSettings
    {
        public string GetValue(ClaimsPrincipal principal, string key);
        public string Email { get; }



    }
}
