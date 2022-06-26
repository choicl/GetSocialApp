using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.DAL.Configurations;
using GetSocial.Domain.Aggregates.PostAggregate;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GetSocial.DAL
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostCommentConfig());
            builder.ApplyConfiguration(new PostInteractionConfig());
            builder.ApplyConfiguration(new UserProfileConfig());
            builder.ApplyConfiguration(new IdentityUserLoginConfig());
            builder.ApplyConfiguration(new IdentityUserRoleConfig());
            builder.ApplyConfiguration(new IdentityUserTokenConfig());
        }
    }
}
