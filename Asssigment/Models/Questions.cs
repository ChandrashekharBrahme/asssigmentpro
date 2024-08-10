using System.ComponentModel.DataAnnotations;

namespace Asssigment.Models
{
    public class Questions
    {
        [Key] public int Id { get; set; }
        public required string QuestionText { get; set; }
        public required string Answer1 { get; set; }
        public required string Answer2 { get; set; }
        public required string Answer3 { get; set; }
        public required string Answer4 { get; set; }
        public required string CorrectAnswer { get; set; }
    }
}
