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

        string inputPath = String.Empty;
        string outputPath = String.Empty;

        if (!String.IsNullOrEmpty(InputFile))
            inputPath = InputFile;
        if (!String.IsNullOrEmpty(OutputFile))
            outputPath = OutputFile;

        if (string.IsNullOrEmpty(inputPath) || string.IsNullOrEmpty(outputPath))
        {
            string? labPathEnv = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(labPathEnv))
            {
                if (string.IsNullOrEmpty(inputPath))
                    inputPath = Path.Combine(labPathEnv, "input.txt");
                if (string.IsNullOrEmpty(outputPath))
                    outputPath = Path.Combine(labPathEnv, "output.txt");
            }
        }
        if (string.IsNullOrEmpty(inputPath) || string.IsNullOrEmpty(outputPath))
        {
            string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (string.IsNullOrEmpty(inputPath))
                inputPath = Path.Combine(homeDir, "input.txt");
            if (string.IsNullOrEmpty(outputPath))
                outputPath = Path.Combine(homeDir, "output.txt");
            //string inputPath = Path.Combine(labPath, "input.txt");
            //string outputPath = Path.Combine(labPath, "output.txt");
        }
        if (string.IsNullOrEmpty(inputPath) || !File.Exists(inputPath) || string.IsNullOrEmpty(outputPath))
        {
            Console.WriteLine($"Input file not found. Checked paths:\n" +
                $"- Command-line parameter: {InputFile}\n" +
                $"- LAB_PATH: {Environment.GetEnvironmentVariable("LAB_PATH")}\n" +
                $"- Home directory: {Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\n" +
                $"- Input path: {inputPath}\n" +
                $"- Output path: {outputPath}");
            return;
        }

        switch (ChosenLab.ToLower())
        {
            case "lab1":
                {
                    try
                    {
                        Lab1.Main main = new Lab1.Main();
                        main.Start(inputPath, outputPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                break;
            case "lab2":
                {
                    try
                    {
                        Lab2.Main main = new Lab2.Main();
                        main.Start(inputPath, outputPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                break;
            case "lab3":
                {
                    try
                    {
                        Lab3.Main main = new Lab3.Main();
                        main.Start(inputPath, outputPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                break;
            default:
                Console.WriteLine("Unknown lab");
                break;
        }
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
    [Option("-P|--path", "Path to input/output files", CommandOptionType.SingleValue)]
    public required string Path { get; set; }

    private void OnExecute()
    {
        Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
        Console.WriteLine($"LAB_PATH set to: {Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User)}");
    }
}