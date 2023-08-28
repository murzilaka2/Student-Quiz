using BasicQuiz.Models;
using System.ComponentModel.DataAnnotations;

namespace BasicQuiz.ViewModels
{
    public class QuizViewModel
    {
        public QuizViewModel()
        {
            Answers = new List<string>();
        }

        public Quiz? Quiz { get; set; }
        public int? QuizId { get; set; }
        public List<string> Answers { get; set; }
        public TimeSpan? SpendTime { get; set; } 

        public int? CorrectCount { get; set; }
    }
}
