/// <summary>
/// 
/// Purpose: The purpose of the program: include input,process(es), and output. 
/// 
/// The input will be what value the user enters for gravel in pounds and the choice of delivery (Y/N) 
/// 
/// The Processes calculate price per pound with the Price method, for delivery the Process are deliveryChoice with (Y/N), yesDelivery for if the user enteres yes for delivery, 
/// and deliveryCharge which gets the 3% from the total before gst. The program calculates the GST by applying a percentage to the subtotal.
/// 
/// For Output, if delivery is chosen and the weight is above 4800 lbs, the program displays "(Free Delivery!)", 
/// The program thanks the user for their purchase and asks if they want to continue shopping.
/// 
/// Author: Mobeen Choudary
/// Last modified: 2023-06-21
/// 
/// </summary>



class Program
{
    static void Main()
    {
        bool keepShopping = true;
        
        while (keepShopping)
        {
            try
            {
                Console.WriteLine("Welcome to Stoney Gravel Pit!\n");
                Console.Write("Please enter the weight of gravel required: ");
                int Gravel = Convert.ToInt32(Console.ReadLine());

                double Price = PricePerPond(Gravel);//Method call 

                Console.Write("Do you require delivery? (Y/N): ");
                string deliveryChoice = Console.ReadLine();
                bool yesDelivery = (deliveryChoice == "Y" || deliveryChoice == "y");

                Console.WriteLine("The charge for " +Gravel+ " is $" +Price);

                double deliveryCharge = yesDelivery ? Program.deliveryCharge(Gravel, Price) : 0;
                double subtotal = (Gravel * Price) + deliveryCharge;
                double gst = CalculateGST(subtotal);
                double total = subtotal + gst;

                Console.WriteLine(); // n\ puts variable to next line 
                Console.WriteLine("Subtotal: $" + subtotal);
                if (yesDelivery)
                {
                    Console.WriteLine("Delivery: $" + deliveryCharge, freeDelivery(Gravel));
                }
                Console.WriteLine("GST: $" + gst);
                Console.WriteLine();
                Console.WriteLine("Total: $" + total);
                Console.WriteLine();
                Console.WriteLine("Thank you for your purchase! We hope your day rocks.");
                Console.WriteLine("Would you like to continue shopping?");
                string choice = Console.ReadLine();
                keepShopping = (choice == "Y" || choice == "y");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.WriteLine();

            }
        }
    }

    static double PricePerPond(int weight)
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
        else //weight > 5000
        {
            return 0.10;
        }
    }

    static double deliveryCharge(int weight, double price)
    {
        if (weight > 4800)
        {
            return 0;
        }
        else
        {
            return 0.03 * weight;
        }
    }

    static double CalculateGST(double amount)
    {
        return 0.05 * amount;
    }

    static string freeDelivery(int weight)
    {
        if (weight > 4800)
        {
            return "(Free Delivery!)";
        }
        else
        {
            return string.Empty;
        }
    }
}
