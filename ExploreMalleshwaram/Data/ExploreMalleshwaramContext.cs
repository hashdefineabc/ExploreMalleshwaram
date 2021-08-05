using ExploreMalleshwaram.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Data
{
    public class ExploreMalleshwaramContext : IdentityDbContext<ApplicationUser>
    {
        public ExploreMalleshwaramContext(DbContextOptions<ExploreMalleshwaramContext> options) : base(options)
        {

        }
        public DbSet<Places> Places { get; set; }

        public DbSet<PlaceGallery> PlaceGallery { get; set; }

        public DbSet<ExploreMalleshwaram.Models.SignUpUserModel> SignUpUserModel { get; set; }

        public DbSet<ExploreMalleshwaram.Models.SignInModel> SignInModel { get; set; }
    }
}
