using Lab5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class LabController: Controller
{
    [Authorize]
    public IActionResult Index()
    {
        
        return View(new IOModel()
        {
            SelectedLab = "Lab1"
        });
    }

    [Authorize]
    [HttpPost]
    public IActionResult Index(IOModel model)
    {
        var lines = model.Input.Split("\n").ToList();
        switch (model.SelectedLab)
        {
            case "Lab1":
                var parser = new Lab1.Util.Parser(lines);
                parser.Parse();
                if (parser.IsDataCorrect)
                {
                    var answerArray = Lab1.Program.Calculate(parser.N, parser.K);
                    var answer = answerArray.Aggregate("", (current, i) => current + (i + " "));
                    model.Output = answer;
                }
                else
                {
                    ViewBag.Message = "Invalid data in input";
                    Console.WriteLine("Invalid data in input file");
                }
                
                break;
            case "Lab2":
                
                var parser2 = new Lab2.Util.Parser(lines);
                parser2.Parse();
                if (parser2.IsDataCorrect)
                {
                    var answer = Lab2.Program.Calculate(parser2.N, parser2.Matrix);
                    model.Output = answer.ToString();
                }
                else
                {
                    ViewBag.Message = "Invalid data in input";
                    Console.WriteLine("Invalid data in input file");
                    
                }
                break;
            case "Lab3":
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                var parser3 = new Lab3.Util.Parser(lines);
                parser3.Parse();
                if (parser3.IsDataCorrect)
                {
                    var lab3 = parser3.Lab3;
                    lab3.BuildGraph();
                    var answerLines = new List<string>();
                    foreach (var query in parser3.Queries)
                    {
                        var answer = lab3.Calculate(query.X1, query.Y1, query.X2, query.Y2);
                        answerLines.Add(answer.ToString());
                    }

                    model.Output = "";
                    foreach (var line in answerLines)
                    {
                        model.Output += line + "\n";
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid data in input";
                    Console.WriteLine("Invalid data in input file");
                }
                break;
        }
        return View(model);
    }
}