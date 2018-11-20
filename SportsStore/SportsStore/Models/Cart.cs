using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine thisLine = lineCollection.Where(cl => cl.Product.ProductID == product.ProductID)
                                        .FirstOrDefault();
            if (thisLine != null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                thisLine.Quantity += quantity;
            }
        }
        public virtual void RemoveAllItems()
        {
            lineCollection.RemoveAll(p => p != null);
        }
        public virtual void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }
        public virtual void RemoveItem(int productId)
        {
            lineCollection.RemoveAll(p => p.Product.ProductID == productId);
        }
        public virtual decimal TotalSum()
        {
            return lineCollection.Sum(p=>p.Product.Price * p.Quantity);
        }
        public virtual decimal TotalSumPerCategory(string category)
        {
            return lineCollection.Where(p=>p.Product.Category == category)
                                    .Sum(p=>p.Product.Price * p.Quantity);
        }
        public virtual void ClearAllItems() => lineCollection.Clear();

        public IEnumerable<CartLine> Lines => lineCollection;
    }


}
