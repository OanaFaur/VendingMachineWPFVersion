namespace DataAccess.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int ItemsLeft { get; set; }

        public int ItemsSold { get; set; }

        public string Image { get; set; }
    }
}
