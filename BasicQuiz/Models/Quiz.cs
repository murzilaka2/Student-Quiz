namespace BasicQuiz.Models
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new List<Question>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Question> Questions { get; set; } = null!;
    }
}
