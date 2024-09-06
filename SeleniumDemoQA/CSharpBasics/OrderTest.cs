using Houses;

namespace CSharpBasics
{
    public class Order
    {
        private int _orderNumber;

        public Order(int orderNumber)
        {
            _orderNumber = orderNumber;
        }

        public int GetOrderNumber()
        {
            return _orderNumber;
        }

        public void SetOrderNumber(int orderNumber)
        {
            _orderNumber = orderNumber;
        }

        public int OrderNumber { get { return _orderNumber; } set { _orderNumber = value; } }
    }

    internal class OrderTest
    {
        [Test]
        public void OrderTest1()
        {
            var order1 = new Order(1);
            order1.OrderNumber = 1;
            order1.SetOrderNumber(1);
            var orderNumber = order1.GetOrderNumber();

            Assert.That(orderNumber, Is.EqualTo(1));
        }

    }
}
