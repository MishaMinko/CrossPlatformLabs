namespace MFursenko
{
    public class LabExecutor
    {
        public void StartLab(string input, string output, int lab)
        {
            try
            {
                switch (lab)
                {
                    case 1: new Lab1().Start(input, output); break;
                    case 2: new Lab2().Start(input, output); break;
                    case 3: new Lab3().Start(input, output); break;
                    default: File.WriteAllText(output, "Chosen lab doesn't exist"); break;
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(output, ex.Message);
            }
        }
    }
}
