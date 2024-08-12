using Asssigment.Models;
using Asssigment.data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Asssigment.ViewModels;


namespace Asssigment.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<Questions> _questions;
        private static int _currentQuestionIndex = 0;
        private static Dictionary<int, string> _userAnswers = new Dictionary<int, string>();

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to display the question page
        public IActionResult Index()
        {
            if (_questions == null || _questions.Count == 0)
            {
                _questions = _context.Questions.OrderBy(q => Guid.NewGuid()).Take(10).ToList();
                _currentQuestionIndex = 0;
            }

            if (_currentQuestionIndex < _questions.Count)
            {
                var question = _questions[_currentQuestionIndex];
                return View(question);
            }
            else
            {
                return RedirectToAction("Result");
            }
        }

        [HttpPost]
        public IActionResult Index(int id, string selectedAnswer)
        {
            _userAnswers[id] = selectedAnswer;
            _currentQuestionIndex++;
            return RedirectToAction("Index");
        }

        public IActionResult Result()
        {
            var result = new List<QuestionResultViewModel>();

            foreach (var question in _questions)
            {
                var isCorrect = _userAnswers.TryGetValue(question.Id, out var userAnswer) && userAnswer == question.CorrectAnswer;
                result.Add(new QuestionResultViewModel
                {
                    Question = question.QuestionText,
                    CorrectAnswer = question.CorrectAnswer,
                    SelectedAnswer = userAnswer,
                    IsCorrect = isCorrect
                });
            }

            ViewBag.TotalMarks = result.Count(q => q.IsCorrect);
            return View(result);
        }
    }
}
