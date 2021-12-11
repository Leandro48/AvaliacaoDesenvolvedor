using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoDesenvolvedor.Models;

namespace AvaliacaoDesenvolvedor.Models
{
    public class Context : DbContext
    {
        //digo para o entity que eu tenho as classes abaixo
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        //Este método configura o EntityFramework
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //aqui informo qual banco de dados vou utilizar adicionando a string de conexão
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=AvaliacaoDesenvolvedor;Integrated Security=True");
        }

        //Este método configura o EntityFramework
        public DbSet<AvaliacaoDesenvolvedor.Models.Telefone> Telefone { get; set; }
    }
}
