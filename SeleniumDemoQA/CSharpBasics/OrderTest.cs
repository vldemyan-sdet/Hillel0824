using Houses;

namespace CSharpBasics
{
    public class Product
    {
        public int Id { get; set; }
        public Product(int productId)
        {
            Id = productId;
        }
    }
    public class Order
    {

        public int OrderNumber { get; set; }

        private List<Product> _products;
        private DateTime _orderDate;
        private string _orderDescription;

        public Order(int orderNumber)
        {
            OrderNumber = orderNumber;
        }


        public string DetDescription()
        {
            return _orderDescription;
        }
        
        public void AddDescription(string descr)
        {
            _orderDescription = descr;
        }
        
        public void AddProduct(Product product)
        {
            if (product.Id < 1)
            {
                throw new ArgumentException(nameof(product));
            }
            _products.Add(product);
        }
        


        //public int OrderNumber { get { return _orderNumber; } set { _orderNumber = value; } }
    }

    internal class OrderTest
    {
        [Test]
        public void OrderTest1()
        {
            var order1 = new Order(2);
            var on = order1.OrderNumber;
            order1.OrderNumber = 3;
            //order1.SetOrderNumber(3);
            //var orderNumber = order1.GetOrderNumber();

            //order1.AddProduct(new Product(1));
            //order1._products.Add(new Product(2));

            Assert.That(order1.OrderNumber, Is.EqualTo(3));
        }

    }
}
