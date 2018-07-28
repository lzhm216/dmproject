using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SPA.DocumentManager.Authorization.Roles;
using SPA.DocumentManager.Authorization.Users;
using SPA.DocumentManager.MultiTenancy;
using SPA.DocumentManager.PlanProjects;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SpecialPlans;
using SPA.DocumentManager.SubSpecialPlans;
using SPA.DocumentManager.TaskBooks;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.EntityFrameworkCore
{
    public class DocumentManagerDbContext : AbpZeroDbContext<Tenant, Role, User, DocumentManagerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanProject> PlanProjects { get; set; }
        public DbSet<SpecialPlan> SpecialPlans { get; set; }
        public DbSet<PlanProjectType> PlanProjectTypes { get; set; }
        public DbSet<SubSpecialPlan> SubSpecialPlans { get; set; }
        public DbSet<TaskBook> TaskBooks { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<UnitGroup> UnitGroups { get; set; }
        public DbSet<SpecialPlanType> SpecialPlanTypes { get; set; }

        public DocumentManagerDbContext(DbContextOptions<DocumentManagerDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>().ToTable("Plan");
            modelBuilder.Entity<PlanProject>().ToTable("PlanProject");
            modelBuilder.Entity<PlanProjectType>().ToTable("PlanProjectType");
            modelBuilder.Entity<SpecialPlan>().ToTable("SpecialPlan");
            modelBuilder.Entity<SubSpecialPlan>().ToTable("SubSpecialPlan");
            modelBuilder.Entity<TaskBook>().ToTable("TaskBook");
            modelBuilder.Entity<Attachment>().ToTable("Attachment");
            modelBuilder.Entity<UnitGroup>().ToTable("UnitGroup");
            modelBuilder.Entity<SpecialPlanType>().ToTable("SpecialPlanType");


            base.OnModelCreating(modelBuilder);
        }
    }
}
