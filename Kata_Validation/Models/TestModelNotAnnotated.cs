namespace Kata_Validation.Models
{
    public class TestModelNotAnnotated : ITestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

    }
}