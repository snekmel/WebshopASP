namespace DalWebshop.Models
{
    public class ProductVerkoop
    {
        public int ProductId { get; private set; }
        public int Aantal { get; private set; }


        public Product Product
        {
            get { return Models.Product.Find(this.ProductId.ToString()); }
            set { }
                   
        }

        public ProductVerkoop(int productId, int aantal)
        {
            ProductId = productId;
            Aantal = aantal;
        }
    }
}