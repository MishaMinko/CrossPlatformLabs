using Lab4;
using McMaster.Extensions.CommandLineUtils;

[Command(Name = "Lab4", Description = "Open labs app")]
[Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
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
//3.b
[Command(Name = "start", Description = "Start a specific lab")]
class RunCommand
{
    [Argument(0, "lab", "Enter lab (lab1, lab2, lab3)")]
    public string? ChosenLab { get; set; }

    [Option("-i|--input", "Input file", CommandOptionType.SingleValue)]
    public string? InputFile { get; set; }

    [Option("-o|--output", "Output file", CommandOptionType.SingleValue)]
    public string? OutputFile { get; set; }

    private void OnExecute()
    {
        if (string.IsNullOrEmpty(ChosenLab))
        {
            Console.WriteLine("Lab not specified.");
            return;
        }

        string? labPath = GetLabDir(ChosenLab);
        if (labPath == null)
        {
            Console.WriteLine($"Unknown lab '{ChosenLab}'");
            return;
        }

        string? labPathEnv = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User);
        Console.WriteLine("LAB_PATH: " + labPathEnv);
        string inputPath = InputFile ?? (string.IsNullOrEmpty(labPathEnv) ? Path.Combine(labPath, "input.txt") : Path.Combine(labPathEnv, "input.txt"));
        string outputPath = OutputFile ?? (string.IsNullOrEmpty(labPathEnv) ? Path.Combine(labPath, "output.txt") : Path.Combine(labPathEnv, "output.txt"));

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file '{inputPath}' not found.");
            return;
        }

        var runLab = new LabsConnection();

        switch (ChosenLab.ToLower())
        {
            case "lab1":
                runLab.RunLab1(inputPath, outputPath);
                break;
            case "lab2":
                runLab.RunLab2(inputPath, outputPath);
                break;
            case "lab3":
                runLab.RunLab3(inputPath, outputPath);
                break;
            default:
                Console.WriteLine("Unknown lab");
                break;
        }
        Console.WriteLine($"{ChosenLab} completed. Output saved here: {outputPath}");
    }

    private string? GetLabDir(string labName)
    {
        string projectRoot = Directory.GetCurrentDirectory();
        switch (labName.ToLower())
        {
            case "lab1": return Path.Combine(projectRoot, "Lab1");
            case "lab2": return Path.Combine(projectRoot, "Lab2");
            case "lab3": return Path.Combine(projectRoot, "Lab3");
            default: return null;
        }
    }
}
//3.c
[Command(Name = "set-path", Description = "Set input/output path")]
class SetPathCommand
{
    [Option("-p|--path", "Path to input/output files", CommandOptionType.SingleValue)]
    public required string Path { get; set; }

    private void OnExecute()
    {
        Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
        Console.WriteLine($"LAB_PATH set to: {Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User)}");
    }
}