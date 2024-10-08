﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data;

public class StoreContext : DbContext
{
    /*
     * add migration command line when apply N Tier 
     * dotnet ef migrations add <MigrationName> --project <DataAccessProject> --startup-project <StartupProject>
     */
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
}