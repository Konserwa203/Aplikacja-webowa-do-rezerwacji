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

       

       
    }
}
