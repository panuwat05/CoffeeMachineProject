namespace Coffee_Machine
{
    public partial class CoffeeMachine : Form
    {
        Menuitem itemWater = new Menuitem();
        Menuitem itemCoffee = new Menuitem();
        Menuitem itemMilk = new Menuitem();
        Menuitem itemChocolateMix = new Menuitem();
        Menuitem itemBlackCoffee = new Menuitem();
        Menuitem itemMocha = new Menuitem();
        Menuitem itemLatte = new Menuitem();
        Menuitem itemChocolate = new Menuitem();

        public CoffeeMachine()
        {
            InitializeComponent();

            itemWater.Name = "Water";
            itemWater.Quantity = 100000;

            itemCoffee.Name = "Coffee";
            itemCoffee.Quantity = 5000;

            itemMilk.Name = "Milk";
            itemMilk.Quantity = 50000;

            itemChocolateMix.Name = "Chocolate_Mix";
            itemChocolateMix.Quantity = 5000;

            // กำหนดค่าเริ่มต้นให้ Ingredients เพื่อป้องกัน NullReferenceException
            itemBlackCoffee.Name = "BlackCoffee";
            itemBlackCoffee.Price = 25;
            itemBlackCoffee.Quantity = 0;
            itemBlackCoffee.Ingredients = new Dictionary<string, int>();
            itemBlackCoffee.Ingredients.Add("Water", 300);
            itemBlackCoffee.Ingredients.Add("Coffee", 20);

            itemMocha.Name = "Mocha";
            itemMocha.Price = 35;
            itemMocha.Quantity = 0;
            itemMocha.Ingredients = new Dictionary<string, int>();
            itemMocha.Ingredients.Add("Water", 300);
            itemMocha.Ingredients.Add("Coffee", 20);
            itemMocha.Ingredients.Add("Chocolate_Mix", 10);

            itemLatte.Name = "Latte";
            itemLatte.Price = 35;
            itemLatte.Quantity = 0;
            itemLatte.Ingredients = new Dictionary<string, int>();
            itemLatte.Ingredients.Add("Water", 300);
            itemLatte.Ingredients.Add("Coffee", 20);
            itemLatte.Ingredients.Add("Milk", 10);

            itemChocolate.Name = "Chocolate";
            itemChocolate.Price = 35;
            itemChocolate.Quantity = 0;
            itemChocolate.Ingredients = new Dictionary<string, int>();
            itemChocolate.Ingredients.Add("Water", 300);
            itemChocolate.Ingredients.Add("Chocolate_Mix", 20);

            tbWater.Text = itemWater.Quantity.ToString();
            tbCoffee.Text = itemCoffee.Quantity.ToString();
            tbMilk.Text = itemMilk.Quantity.ToString();
            tbChocolateMix.Text = itemChocolateMix.Quantity.ToString();
            tbBlackCoffeePrice.Text = itemBlackCoffee.Price.ToString();
            tbMochaPrice.Text = itemMocha.Price.ToString();
            tbLattePrice.Text = itemLatte.Price.ToString();
            tbChocolatePrice.Text = itemChocolate.Price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dCash = double.Parse(tb_cash.Text);
                double dTotal = 0;

                Dictionary<string, ingredients> availableIngredients = new Dictionary<string, ingredients>
                {
                    { "Water", new ingredients("Water", 100000) },
                    { "Coffee", new ingredients("Coffee", 5000) },
                    { "Milk", new ingredients("Milk", 50000) },
                    { "Chocolate_Mix", new ingredients("Chocolate_Mix", 5000) }
                };

                if (chbBlackCoffee.Checked)
                {
                    itemBlackCoffee.Quantity = int.Parse(nudBlackCoffee.Text);
                    dTotal += itemBlackCoffee.GetTotalPrice();
                    itemBlackCoffee.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffee.Text = availableIngredients["Coffee"].Quantity.ToString();
                }

                if (chbMocha.Checked)
                {
                    itemMocha.Quantity = int.Parse(nudMocha.Text);
                    dTotal += itemMocha.GetTotalPrice();
                    itemMocha.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffee.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbChocolateMix.Text = availableIngredients["Chocolate_Mix"].Quantity.ToString();
                }

                if (chbLatte.Checked)
                {
                    itemLatte.Quantity = int.Parse(nudLatte.Text);
                    dTotal += itemLatte.GetTotalPrice();
                    itemLatte.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffee.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbMilk.Text = availableIngredients["Milk"].Quantity.ToString();
                }

                if (chbChocolate.Checked)
                {
                    itemChocolate.Quantity = int.Parse(nudChocolate.Text);
                    dTotal += itemChocolate.GetTotalPrice();
                    itemChocolate.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbChocolateMix.Text = availableIngredients["Chocolate_Mix"].Quantity.ToString();
                }

                if (dCash < dTotal)
                {
                    MessageBox.Show("Insufficient cash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dTotal;
                tbTotal.Text = dTotal.ToString("F2");
                tbChange.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in the numbers correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb_1000.Text = changeCount[0].ToString();
            tb_500.Text = changeCount[1].ToString();
            tb_100.Text = changeCount[2].ToString();
            tb_50.Text = changeCount[3].ToString();
            tb_20.Text = changeCount[4].ToString();
            tb_10.Text = changeCount[5].ToString();
            tb_5.Text = changeCount[6].ToString();
            tb_1.Text = changeCount[7].ToString();
            tb_050.Text = changeCount[8].ToString();
            tb_025.Text = changeCount[9].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            // ล้างค่า NumericUpDown และ CheckBox
            nudBlackCoffee.Value = 0;
            nudMocha.Value = 0;
            nudLatte.Value = 0;
            nudChocolate.Value = 0;

            chbBlackCoffee.Checked = false;
            chbMocha.Checked = false;
            chbLatte.Checked = false;
            chbChocolate.Checked = false;

            // ล้างค่าเงินที่ใส่เข้าไป
            tb_cash.Text = "";
            tbTotal.Text = "0.00";
            tbChange.Text = "0.00";

            // ล้างค่าเงินทอน
            tb_1000.Text = "0";
            tb_500.Text = "0";
            tb_100.Text = "0";
            tb_50.Text = "0";
            tb_10.Text = "0";
            tb_5.Text = "0";
            tb_1.Text = "0";
            tb_050.Text = "0";
            tb_025.Text = "0";
            tb_10.Text = "0";
            tb_5.Text = "0";
            tb_1.Text = "0";
            tb_050.Text = "0";
            tb_025.Text = "0";
        }
    }
}
