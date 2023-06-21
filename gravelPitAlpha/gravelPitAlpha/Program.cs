
try
{
    Console.WriteLine("How much gravel you want");
    int weight = Convert.ToInt32(Console.ReadLine());

    Console.Write("Do you require delivery? (Y/N): ");
    string deliveryChoice = Console.ReadLine();
    bool requireDelivery = (deliveryChoice == "y");

    if (weight < 1000)//0.55
    {
        Console.WriteLine("The charge for less then 1000 lb is $0.55 per pound");
    }
    else if (weight >= 1000 && weight <= 2000)
    {
        Console.WriteLine("The charge for 1000 - 2000 lb is $0.45 per pound");
    }
}
catch (FormatException)
{
    Console.WriteLine("Invalid input. Please enter a valid integer.");
    Console.WriteLine();
}
