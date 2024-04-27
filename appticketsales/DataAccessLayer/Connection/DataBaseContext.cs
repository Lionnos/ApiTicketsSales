using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Connection
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subsidiary> Subsidiarys { get; set; }


        public DataBaseContext()
        {
            AutoMapper.start();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Subsidiary>().ToTable("subsidiary");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subsidiary>()
                .HasMany(e => e.childUser)
                .WithOne(e => e.Subsidiary)
                .HasForeignKey(e => e.idSubsidiary)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try 
            { 
                string connectionString = "server=localhost;user=Lionos;password=1001mysql;database=dbSaleOfTickets";
                ServerVersion serverVersion = new MySqlServerVersion(new Version(8,3,0));
                //ServerVersion serverVersion = new MySqlServerVersion(new Version(8,0,36));
                optionsBuilder.UseMySql(connectionString, serverVersion);

            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
