namespace PartPicker.Models
{
    public class Cart
    {
        private List<CartItem> _cartList;

        public Cart()
        {
            _cartList = new List<CartItem>();
        }

        public void Add(CartItem? item) //could probably use the method you linked, will come back later if I have time
        {
            if (item is null)
                throw new Exception("Attempted to add null item to cart");

            bool exists = false;
            foreach (CartItem c in _cartList)
                if (c.Part == item.Part)
                {
                    c.addQuantity(item.Quantity);
                    exists = true;
                    break;
                }

            if (!exists)
                _cartList.Add(item);
        }

        public int getQuantity(CartItem item)
        {
            int quantity = 0;
            foreach (CartItem c in _cartList)
                if (c.Part == item.Part)
                {
                    quantity = c.Quantity;
                    break;
                }
            return quantity;
        }

        public double Subtotal
        {
            get
            {
                double subtotal = 0.0;

                foreach (CartItem c in _cartList)
                    subtotal += c.ExtendedCost;

                return Math.Round(subtotal, 2);
            }
        }

        public void emptyCart()
        {
            _cartList.Clear();
        }

        public double GST { get { return Math.Round(Subtotal * 0.05, 2); } }
        public double PST { get { return Math.Round(Subtotal * 0.07, 2); } }
        public double Total { get { return Math.Round(Subtotal + GST + PST, 2); } }
        public List<CartItem> CartList { get { return _cartList; } }
    }
}
