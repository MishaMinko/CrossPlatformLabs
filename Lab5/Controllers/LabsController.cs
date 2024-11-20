using Microsoft.AspNetCore.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LabViewModel());
        }

        [HttpPost]
        public IActionResult Index(LabViewModel model)
        {
            string selected = Request.Form["LabSelector"].ToString();
            ViewData["SelectedLab"] = selected;

            string inputPath = Path.GetTempFileName();
            string outputPath = Path.GetTempFileName();

            try
            {
                System.IO.File.WriteAllText(inputPath, model.InputText ?? string.Empty);
                switch (selected)
                {
                    case "Lab1":
                        new Lab1.Main().Start(inputPath, outputPath);
                        break;
                    case "Lab2":
                        new Lab2.Main().Start(inputPath, outputPath);
                        break;
                    case "Lab3":
                        new Lab3.Main().Start(inputPath, outputPath);
                        break;
                    default:
                        model.OutputText = "Невідома лаба.";
                        return View(model);
                }

                if (System.IO.File.Exists(outputPath))
                    model.OutputText = System.IO.File.ReadAllText(outputPath);
                else
                    model.OutputText = "Результат не знайдено.";
            }
            catch (Exception ex)
            {
                model.OutputText = "Помилка: " + ex.Message;
            }
            finally
            {
                if (System.IO.File.Exists(inputPath))
                    System.IO.File.Delete(inputPath);
                if (System.IO.File.Exists(outputPath))
                    System.IO.File.Delete(outputPath);
            }
            return View(model);
        }
    }
}
