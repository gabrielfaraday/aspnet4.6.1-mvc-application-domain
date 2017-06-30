using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using Microsoft.Owin.Security;

namespace MvcAppExample.Infra.CrossCutting.Identity.ViewModels.Manage
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
