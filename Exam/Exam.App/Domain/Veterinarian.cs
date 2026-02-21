namespace Exam.App.Domain
{
    public class Veterinarian
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
