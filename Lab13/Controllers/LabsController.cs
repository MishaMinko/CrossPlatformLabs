using Microsoft.AspNetCore.Mvc;
using Lab13.Models;
using MFursenko;
using Microsoft.AspNetCore.Authorization;

namespace Lab13.Controllers
{
    public class LabsController : Controller
    {
        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            return View(new LabViewModel());
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Index([FromBody] LabViewModel model)
        {
            if (model == null)
                return BadRequest("Invalid model data.");

            string selected = model.LabSelector;
            ViewData["SelectedLab"] = selected;

            string inputPath = Path.GetTempFileName();
            string outputPath = Path.GetTempFileName();

            LabExecutor lab = new LabExecutor();

            try
            {
                System.IO.File.WriteAllText(inputPath, model.InputText ?? string.Empty);
                switch (selected)
                {
                    case "Lab1":
                        lab.StartLab(inputPath, outputPath, 1);
                        break;
                    case "Lab2":
                        lab.StartLab(inputPath, outputPath, 2);
                        break;
                    case "Lab3":
                        lab.StartLab(inputPath, outputPath, 3);
                        break;
                    default:
                        model.OutputText = "Невідома лаба.";
                        return Json(model);
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
            return Json(model);
        }
    }
}
