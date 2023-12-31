﻿class Program
{
    static void Main()
    {
        bool continueShopping = true;

        while (continueShopping)
        {
            try
            {
                Console.WriteLine("Welcome to Stoney Gravel Pit!\n\n");
                Console.Write("Enter the weight of gravel in pounds: ");
                int weight = Convert.ToInt32(Console.ReadLine());

                double pricePerPound = CalculatePricePerPound(weight);

                Console.Write("Do you require delivery? (Y/N): ");
                string deliveryChoice = Console.ReadLine();
                bool requireDelivery = (deliveryChoice == "y");

                double deliveryCharge = requireDelivery ? CalculateDeliveryCharge(weight, pricePerPound) : 0;
                double subtotal = (weight * pricePerPound) + deliveryCharge;
                double gst = subtotal * 0.05;
                double total = subtotal + gst;

                Console.WriteLine();
                Console.WriteLine("Subtotal: $", subtotal);

                if (requireDelivery)
                {
                    Console.WriteLine("Delivery: {0:C} {1}", deliveryCharge, GetDeliveryLabel(weight));
                }

                Console.WriteLine("GST: $" + gst.ToString("F2"));
                Console.WriteLine("Total: $" + total.ToString("F2"));
                Console.WriteLine();

                Console.Write("Continue shopping? (Y/N): ");
                string choice = Console.ReadLine();

                continueShopping = (choice == "Y" || choice == "y");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}