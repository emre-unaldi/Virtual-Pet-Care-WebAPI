using Microsoft.EntityFrameworkCore;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;
using VirtualPetCareWebAPI.Entity.Concretes.Responses;

namespace VirtualPetCareWebAPI.DataAccess.Concretes.EntityFramework
{
    public class PetCareDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<PetMapTraining> PetsMapTrainings { get; set; }

        public DbSet<SocialInteractions> SocialInteractions { get; set; }   
        public DbSet<PetMapSocialInteractions> PetMapSocialInteractions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PetCareDB;User ID=postgres;Password=admin38;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Navigation(user => user.Pets).AutoInclude();

            modelBuilder.Entity<HealthStatus>().Navigation(healthStatus => healthStatus.Pet).AutoInclude();
            modelBuilder.Entity<Food>().Navigation(food => food.Pet).AutoInclude();
            modelBuilder.Entity<Activity>().Navigation(activity => activity.Pet).AutoInclude();

            modelBuilder.Entity<Pet>().Navigation(pet => pet.User).AutoInclude();
            modelBuilder.Entity<Pet>().Navigation(pet => pet.HealthStatus).AutoInclude();
            modelBuilder.Entity<Pet>().Navigation(pet => pet.Foods).AutoInclude();
            modelBuilder.Entity<Pet>().Navigation(pet => pet.Activities).AutoInclude();

            modelBuilder.Entity<Pet>()
                .HasOne(pet => pet.User)  
                .WithMany(user => user.Pets)
                .HasForeignKey(pet => pet.UserId);

            modelBuilder.Entity<Pet>()
                .HasOne(pet => pet.HealthStatus)
                .WithOne(healthStatus => healthStatus.Pet)
                .HasForeignKey<HealthStatus>(healthStatus => healthStatus.PetId);

            modelBuilder.Entity<Pet>()
                .HasMany(pet => pet.Activities)
                .WithOne(activity => activity.Pet)
                .HasForeignKey(activity => activity.PetId);

            modelBuilder.Entity<Pet>()
                .HasMany(pet => pet.Foods)
                .WithOne(food => food.Pet)
                .HasForeignKey(food => food.PetId);


            modelBuilder.Entity<PetMapTraining>()
            .HasKey(pt => new { pt.PetId, pt.TrainingId });

            modelBuilder.Entity<PetMapTraining>()
                .HasOne(pt => pt.Pet)
                .WithMany(p => p.PetsMapTrainings)
                .HasForeignKey(pt => pt.PetId);

            modelBuilder.Entity<PetMapTraining>()
                .HasOne(pt => pt.Training)
                .WithMany(t => t.PetsMapTrainings)
                .HasForeignKey(pt => pt.TrainingId);
        }
    }
}
