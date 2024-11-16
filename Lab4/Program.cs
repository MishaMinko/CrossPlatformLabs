using McMaster.Extensions.CommandLineUtils;

[Command(Name = "Lab4", Description = "Open labs app")]
[Subcommand(typeof(VersionCommand))]
class Program
{
    static int Main(string[] args)
    {
        var app = new CommandLineApplication<Program>();
        app.Conventions.UseDefaultConventions();
        app.OnExecute(() =>
        {
            app.ShowHelp();
            return 1;
        });
        app.UnrecognizedArgumentHandling = UnrecognizedArgumentHandling.StopParsingAndCollect;

        return app.Execute(args);
    }

    private void OnExecute()
    {
        Console.WriteLine("Enter command");
    }
}
//3.a
[Command(Name = "version", Description = "Displays app version and author")]
class VersionCommand
{
    private void OnExecute()
    {
        Console.WriteLine("Author: Fursenko Misha IPZ-32");
        Console.WriteLine("Version: 1.0.0");
    }
}