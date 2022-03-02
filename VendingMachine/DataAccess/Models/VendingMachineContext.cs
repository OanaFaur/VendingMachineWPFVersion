namespace DataAccess.Models
{
    using System.Data.Entity;

    public partial class VendingMachineContext : DbContext
    {
        public VendingMachineContext()
            : base("name=VendingMachineContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Moneys> Moneys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
