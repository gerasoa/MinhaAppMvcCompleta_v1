﻿using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevIO.Data.Context
{
    public class MeuDBContext : DbContext
    {
        public MeuDBContext(DbContextOptions<MeuDBContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "Varchar(100)";
                

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDBContext).Assembly);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetForeignKeys())) 
            //    relationship.DeleteBehavior = DeleteBehavior.SetNull;
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
