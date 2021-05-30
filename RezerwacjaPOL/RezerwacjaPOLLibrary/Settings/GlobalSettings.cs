using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Settings
{
    public class GlobalSettings : IGlobalSettings
    {
        private IHttpContextAccessor _accessor;

        public GlobalSettings(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
       
        public string GetValue(ClaimsPrincipal principal, string key)
        {
            if (principal == null) return null;

            return principal.FindFirstValue(key);
        }

        
        public string Email
        {
            get
            {
                return GetValue(_accessor.HttpContext.User, ClaimTypes.Email);
            }
        }

        
    }
}
