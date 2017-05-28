namespace DalWebshop.Models
{
    public class OrderRow
    {
        public int OrderId { get; set; }

        public int ProductId { get; private set; }

        public int Aantal { get; set; }

        public Product ProductInformatie()
        {
            return Product.Find(this.ProductId.ToString());
        }

        public OrderRow(int orderId, int productId, int aantal)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Aantal = aantal;
        }

        public OrderRow(int productId, int aantal)
        {
            this.ProductId = productId;
            this.Aantal = aantal;
        }
    }
}