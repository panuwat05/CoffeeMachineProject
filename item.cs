using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Machine
{
    internal class Menuitem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Dictionary<string, int> Ingredients { get; set; } = new Dictionary<string, int>();

        public double GetTotalPrice()
        {
            return Price * Quantity;
        }


        public double GetDiscount(double discountPercentage)
        {
            return GetTotalPrice() * (discountPercentage / 100);
        }

        public void UseIngredients(Dictionary<string, ingredients> availableIngredients)
        {
            if (Ingredients == null || Ingredients.Count == 0)
            {
                return; // ป้องกันการใช้ Ingredients ถ้าเป็น null หรือไม่มีข้อมูล
            }

            foreach (var ingredient in Ingredients)
            {
                if (availableIngredients.ContainsKey(ingredient.Key))
                {
                    availableIngredients[ingredient.Key].Quantity -= ingredient.Value * Quantity;
                }

            }
        }
    }
}
