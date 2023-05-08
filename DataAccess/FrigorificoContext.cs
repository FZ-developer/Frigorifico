using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FrigorificoContext : DbContext
    {

        public FrigorificoContext(DbContextOptions<FrigorificoContext> options) : base(options) { }



        public DbSet<Campo> Campos { get; set; }
        public DbSet<Frigorifico> Frigorificos { get; set; }
        public DbSet<FacturaCompra> FacturasCompra { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<FacturaVenta> FacturasVenta { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        public DbSet<Producto> Productos { get; set; }





        // ------------ FluentAPI ------------

               

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //  **********************************
            //  *           FRIGORIFICO          *
            //  **********************************

            modelBuilder.Entity<Frigorifico>()
                .HasMany(f => f.Campos)
                .WithOne(c => c.Frigorifico)
                .HasForeignKey(c => c.IdFrigorifico)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Frigorifico>()
                .HasMany(f => f.FacturasCompra)
                .WithOne(fc => fc.Frigorifico)
                .HasForeignKey(fc => fc.IdFrigorifico)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Frigorifico>()
                .HasMany(f => f.Clientes)
                .WithOne(c => c.Frigorifico)
                .HasForeignKey(c => c.IdFrigorifico)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Frigorifico>()
                .HasMany(f => f.FacturasVenta)
                .WithOne(fv => fv.Frigorifico)
                .HasForeignKey(fv => fv.IdFrigorifico)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Frigorifico>()
                .HasMany(f => f.Productos)
                .WithOne(p => p.Frigorifico)
                .HasForeignKey(p => p.IdFrigorifico)
                .OnDelete(DeleteBehavior.Restrict);


            //  **********************************
            //  *              CAMPO             *
            //  **********************************
                        
            modelBuilder.Entity<Campo>()
                .HasMany(c => c.FacturasCompra)
                .WithOne(fc => fc.Campo)
                .HasForeignKey(fc => fc.IdCampo)
                .OnDelete(DeleteBehavior.Restrict);


            //  **********************************
            //  *            CLIENTE             *
            //  **********************************


            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.FacturasVenta)
                .WithOne(fv => fv.Cliente)
                .HasForeignKey(fv => fv.IdCliente);


            //  **********************************
            //  *          FACTURAVENTA          *
            //  **********************************


            modelBuilder.Entity<FacturaVenta>()
                .HasMany(fv => fv.DetallesFactura)
                .WithOne(df => df.FacturaVenta)
                .HasForeignKey(df => df.IdFacturaVenta)
                .OnDelete(DeleteBehavior.Restrict);


            //  **********************************
            //  *         DETALLEFACTURA         *
            //  **********************************

            modelBuilder.Entity<DetalleFactura>()
                .HasOne(df => df.Producto)
                .WithMany(p => p.DetallesFactura)
                .HasForeignKey(df => df.IdProducto);






        }






    }
}
