using System.ComponentModel.DataAnnotations;

namespace Kata_Validation.Models
{
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
}