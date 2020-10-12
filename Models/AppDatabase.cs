using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Adventure.Models
{
    public class AppDatabase:DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
        }
        public DbSet<Adventures> Adventures { get; set; }
        //public static System.Collections.Specialized.NameValueCollection AppSettings { get; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //   .AddJsonFile("appsettings.json")
        //   .Build();

        //    // schoolSIMSConnection is the name of the key that
        //    // contains the has the connection string as the value
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("schoolSIMSConnection"));
        //}
    }
}
