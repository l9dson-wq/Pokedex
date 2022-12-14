using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Pokemon> pokemones { get; set;}
        public DbSet<Region> Regions { get; set;}
        public DbSet<Pokemon_type> pokemon_type { get; set; }
        public DbSet<Pokemon_type2> pokemon_type2 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            

            //Fluent API
            var MBE_POKEMON = modelbuilder.Entity<Pokemon>();
            var MBE_REGION = modelbuilder.Entity<Region>();
            var MBE_POKEMONTYPE = modelbuilder.Entity<Pokemon_type>();
            var MBE_POKEMONTYPE2 = modelbuilder.Entity<Pokemon_type2>();

            #region tables
            MBE_POKEMON.ToTable("Pokemons");
            MBE_REGION.ToTable("Regions");
            MBE_POKEMONTYPE.ToTable("pokemon_types");
            #endregion

            #region "Primary keys"
            MBE_POKEMON.HasKey(Pokemon => Pokemon.Id);
            MBE_REGION.HasKey(Region => Region.Id);
            MBE_POKEMONTYPE.HasKey(Pokemon_type => Pokemon_type.Id);
            #endregion

            #region "Relationships"
            MBE_REGION
                .HasMany<Pokemon>(Region => Region.Pokemones)
                .WithOne(Pokemon => Pokemon.Region)
                .HasForeignKey(Pokemon => Pokemon.Region_Id)
                .OnDelete(DeleteBehavior.Cascade);

            MBE_POKEMONTYPE
                .HasMany<Pokemon>(Pokemon_type => Pokemon_type.Pokemones)
                .WithOne(p => p.Pokemon_type)
                .HasForeignKey(pokemones => pokemones.PrimaryType_Id)
                .OnDelete(DeleteBehavior.Cascade);

            MBE_POKEMONTYPE2
                .HasMany<Pokemon>(Pokemon_type2 => Pokemon_type2.Pokemones)
                .WithOne(p => p.Secundary_pokemonType)
                .HasForeignKey(pokemones => pokemones.SecundaryType_Id)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"

            #region pokemon
            MBE_POKEMON
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            MBE_POKEMON
                .Property(p => p.Imagepath)
                .IsRequired();

            MBE_POKEMON
                .Property(p => p.Region_Id)
                .IsRequired();

            MBE_POKEMON
                .Property(p => p.PrimaryType_Id)
                .IsRequired();

            MBE_POKEMON
                .Property(p => p.SecundaryType_Id)
                .IsRequired(false);
            #endregion

            #region Region
            MBE_REGION
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region Pokemon_Type
            MBE_POKEMONTYPE
                .Property(pt => pt.Name)
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region Pokemon_type2
            MBE_POKEMONTYPE2
                .Property(pt2 => pt2.Name)
                .HasMaxLength(50)
                .IsRequired(false);
            #endregion

            #endregion
        }
    }
}
