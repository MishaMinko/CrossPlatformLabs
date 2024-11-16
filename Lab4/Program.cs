using McMaster.Extensions.CommandLineUtils;


[Command(Name = "Lab4", Description = "Open labs app")]
class Program
{
    static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

    private void OnExecute()
    {
        Console.WriteLine("Enter command");
    }

    private void OnUnknownCommand(CommandLineApplication app)
    {
        Console.WriteLine("Unknown command. Use one of the following:");
        Console.WriteLine(" - version: Displays app version and author");
        Console.WriteLine(" - run: Run a specific lab");
        Console.WriteLine(" - set-path: Set input/output path");
    }
}
