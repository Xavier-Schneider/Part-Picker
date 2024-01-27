namespace PartPicker.Models
{
    public class CartItem
    {
        private Part _part;
        private int _quantity;

        public CartItem(Part part)
        {
            _part = part;
            _quantity = 1;
        }

        public int Quantity { get { return _quantity; } }
        public Part Part { get { return _part; } }
        public void addQuantity(int addedQuantity) { _quantity += addedQuantity; }
        public void incrementQuantity() { _quantity++; }
        public void decrementQuantity() { if (_quantity > 1) _quantity--; }
        public double ExtendedCost { get { return Math.Round(_part.price * _quantity, 2); } }
    }
}
