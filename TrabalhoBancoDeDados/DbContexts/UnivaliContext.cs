using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrabalhoBancoDeDados.api.Entities;

namespace TrabalhoBancoDeDados.api.DbContexts
{
    public class UnivaliContext : DbContext
    {

        public DbSet<Universidade> Universidades { get; set; } = null!;
        public DbSet<Bloco> Blocos { get; set; } = null!;
        public DbSet<Sala> Salas { get; set; } = null!;

        public UnivaliContext(DbContextOptions<UnivaliContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //      INSERT INTO "Universidades"("Id", "Nome")
          //VALUES(1, 'Univali');
          //      INSERT INTO "Universidades"("Id", "Nome")
          //VALUES(2, 'Uniavan');

            modelBuilder.Entity<Universidade>()
                .HasData(
                    new Universidade()
                    {
                        Id = 1,
                        Nome = "Univali"
                    },
                    new Universidade()
                    {
                        Id = 2,
                        Nome = "Uniavan"
                    }
            );

      //      INSERT INTO "Blocos"("Id", "Name", "UniversidadeId")
      //VALUES(1, 'A', 1);
      //      INSERT INTO "Blocos"("Id", "Name", "UniversidadeId")
      //VALUES(2, 'B', 1);
      //      INSERT INTO "Blocos"("Id", "Name", "UniversidadeId")
      //VALUES(3, 'C', 1);
      //      INSERT INTO "Blocos"("Id", "Name", "UniversidadeId")
      //VALUES(4, '1', 2);
      //      INSERT INTO "Blocos"("Id", "Name", "UniversidadeId")
      //VALUES(5, '2', 2);
      //      INSERT INTO "Blocos"("Id", "Name", "UniversidadeId")
      //VALUES(6, '3', 2);

            modelBuilder.Entity<Bloco>()
                .HasData(
                    new Bloco()
                    {
                        Id = 1,
                        Name = "A",
                        UniversidadeId = 1,
                    },
                     new Bloco()
                     {
                         Id = 2,
                         Name = "B",
                         UniversidadeId = 1,
                     },
                      new Bloco()
                      {
                          Id = 3,
                          Name = "C",
                          UniversidadeId = 1,
                      },
                       new Bloco()
                       {
                           Id = 4,
                           Name = "1",
                           UniversidadeId = 2,
                       },
                       new Bloco()
                       {
                           Id = 5,
                           Name = "2",
                           UniversidadeId = 2,
                       },
                       new Bloco()
                       {
                           Id = 6,
                           Name = "3",
                           UniversidadeId = 2,
                       }
            );

      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(1, 1, 101);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(2, 1, 102);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(3, 2, 201);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(4, 2, 202);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(5, 3, 301);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(6, 3, 302);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(7, 4, 401);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(8, 4, 402);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(9, 5, 501);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(10, 5, 502);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(11, 6, 601);
      //      INSERT INTO "Salas"("Id", "BlocoId", "Number")
      //VALUES(12, 6, 602);

            modelBuilder.Entity<Sala>()
                .HasData(
                new Sala()
                {
                    Id = 1,
                    Number = 101,
                    BlocoId = 1,
                },
                new Sala()
                {
                    Id = 2,
                    Number = 102,
                    BlocoId = 1,
                },
                new Sala()
                {
                    Id = 3,
                    Number = 201,
                    BlocoId = 2,
                },
                new Sala()
                {
                    Id = 4,
                    Number = 202,
                    BlocoId = 2,
                },
                new Sala()
                {
                    Id = 5,
                    Number = 301,
                    BlocoId = 3,
                },
                new Sala()
                {
                    Id = 6,
                    Number = 302,
                    BlocoId = 3,
                },
                new Sala()
                {
                    Id = 7,
                    Number = 401,
                    BlocoId = 4,
                },
                new Sala()
                {
                    Id = 8,
                    Number = 402,
                    BlocoId = 4,
                },
                new Sala()
                {
                    Id = 9,
                    Number = 501,
                    BlocoId = 5,
                },
                new Sala()
                {
                    Id = 10,
                    Number = 502,
                    BlocoId = 5,
                },
                new Sala()
                {
                    Id = 11,
                    Number = 601,
                    BlocoId = 6,
                },
                new Sala()
                {
                    Id = 12,
                    Number = 602,
                    BlocoId = 6,
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}