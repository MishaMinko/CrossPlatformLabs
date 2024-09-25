using Labs.Lab1;

while (true)
{
    Console.WriteLine("If you want to leave enter lab number 0");
    Console.Write("Enter lab number: ");
    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        return;

    if (!int.TryParse(input, out int n))
    {
        Console.WriteLine("Invalid input.");
        return;
    }

    switch (n)
    {
        case 1: new Lab1().Start(); break;

        default: return;
    }
}