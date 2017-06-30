using Microsoft.AspNet.Identity.EntityFramework;
using MvcAppExample.Infra.CrossCutting.Identity.Models;
using System;

namespace MvcAppExample.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
