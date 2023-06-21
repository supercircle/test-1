using System;

class Program
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
                Console.WriteLine("The charge for " +weight+ "lb of gravel is $" +pricePerPound+ "per lb.");


                Console.WriteLine();
                Console.WriteLine("Subtotal: $" +subtotal.ToString("F2"));

                if (requireDelivery)
                {
                    Console.WriteLine("Delivery: $", deliveryCharge.ToString("F2"), GetDeliveryLabel(weight));
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

    static double CalculatePricePerPound(int weight)
    {
        if (weight < 1000)
        {
            return 0.55;
        }
        else if (weight <= 2000)
        {
            return 0.45;
        }
        else if (weight <= 3000)
        {
            return 0.35;
        }
        else if (weight <= 4000)
        {
            return 0.25;
        }
        else if (weight <= 5000)
        {
            return 0.15;
        }
        else
        {
            return 0.10;
        }
    }

    static double CalculateDeliveryCharge(int weight, double pricePerPound)
    {
        if (weight > 4800)
        {
            return 0;
        }
        else
        {
            return (weight * pricePerPound) * 0.03;
        }
    }

    static string GetDeliveryLabel(int weight)
    {
        if (weight > 4800)
        {
            return "(free delivery)";
        }
        else
        {
            return string.Empty;
        }
    }
}
