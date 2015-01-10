using System.ComponentModel.DataAnnotations;

namespace Kata_Validation.Models
{
    public interface ITestModel
    {
        string Name { get; set; }
        string Email { get; set; }
        int Age { get; set; }
    }

    public class TestModelAnnotated : ITestModel
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

    }
    public class TestModelNotAnnotated : ITestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

    }
}