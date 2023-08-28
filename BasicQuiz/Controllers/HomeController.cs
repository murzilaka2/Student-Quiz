using BasicQuiz.Models;
using BasicQuiz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BasicQuiz.Controllers
{
    public class HomeController : Controller
    {
        //Создание теста (псевдо получение из базы данных)
        List<Quiz> quizModels = new List<Quiz>()
        {
             new Quiz
             {
                 Id = 1,
                 Name = "Тест на знание языка C#",
                 Description = "Проверьте свои знания на тему - \"Абстрактные классы\"",
                 Questions = new List<Question>()
                {
                    new Question{
                        Id = 1,
                        Quesion = "Как могут инициализироваться readonly поля экземпляра класса?",
                        Correct = "При объявлении и в конструкторе",
                        AnswerOne = "Только в конструкторе",
                        AnswerTwo = "С помощью свойств",
                        AnswerThree =  "При объявлении",
                        AnswerFour =  "При объявлении и в конструкторе",
                        QuizId = 1
                    },
                    new Question{
                        Id = 2,
                        Quesion = "В какой кодировке хранятся символьные (char) переменные в C#?",
                        Correct = "UTF-16",
                        AnswerOne = "UTF-16",
                        AnswerTwo = "KOI-8",
                        AnswerThree =  "UTF-4",
                        AnswerFour =  "Win1252",
                        QuizId = 1
                    },
                    new Question{
                        Id = 3,
                        Quesion = "Какие модификаторы доступа из перечисленных по умолчанию даются классу, описанному в namespace?",
                        Correct = "internal",
                        AnswerOne = "protected",
                        AnswerTwo = "private",
                        AnswerThree =  "internal",
                        AnswerFour =  "Ни один из перечисленных",
                        QuizId = 1
                    }
                }
             }
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new QuizViewModel { Quiz = quizModels[0], QuizId = quizModels[0].Id });
        }
        [HttpPost]
        public IActionResult Index(QuizViewModel quizViewModel)
        {
            var currentQuiz = quizModels.FirstOrDefault(e => e.Id == quizViewModel.QuizId);
            if (currentQuiz != null)
            {
                if (ModelState.IsValid)
                {
                    int correctCount = 0, count = 0;
                    foreach (var question in currentQuiz.Questions)
                    {
                        //Проверка на случай, если пользователю уберет проверку на клиенте
                        if (count >= quizViewModel.Answers.Count)
                        {
                            return View("Error", question.Quesion);
                        }
                        else
                        {
                            if (question.Correct.Equals(quizViewModel.Answers[count]))
                            {
                                correctCount++;
                            }
                        }
                        count++;
                    }
                    return View("Results", new QuizViewModel
                    {
                        Quiz = currentQuiz,
                        Answers = quizViewModel.Answers,
                        SpendTime = quizViewModel.SpendTime,
                        CorrectCount = correctCount
                    });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}