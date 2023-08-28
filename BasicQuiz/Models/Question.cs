using System.ComponentModel.DataAnnotations;

namespace BasicQuiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Quesion { get; set; }
        public string Correct { get; set; }

        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }

        public Quiz? Quiz { get; set; }
    }
}
