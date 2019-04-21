using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FCity.Currency.Service.Models.Models;

namespace FCity.Currency.Service.Api
{
    public class CurrencyContex : DbContext
    {
        public CurrencyContex(DbContextOptions<CurrencyContex> options) : base(options)
        {

        }
        public DbSet<CurrencyModel> Currency { get; set; }
        public DbSet<MinuteCurrencyModel> MinuteCurrency { get; set; }
        public DbSet<HourlyCurrencyModel> HourlyCurrency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyModel>()
                .HasKey(c => c.CurrencyId);
            modelBuilder.Entity<MinuteCurrencyModel>()
                .HasKey(c => c.MinuteCurrencyId);
            modelBuilder.Entity<HourlyCurrencyModel>()
                .HasKey(c => c.HourlyCurrencyId);
        }

    }
}
