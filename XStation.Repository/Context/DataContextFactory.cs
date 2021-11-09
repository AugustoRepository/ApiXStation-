using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XStation.Repository.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configurarionBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurarionBuilder.AddJsonFile(path, false);

            var root = configurarionBuilder.Build();
            var connectionString = root
                .GetSection("ConnectionStrings")
                .GetSection("XStationDataBase").Value;


            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(connectionString);

            return new DataContext(builder.Options);
        }
    }
}
