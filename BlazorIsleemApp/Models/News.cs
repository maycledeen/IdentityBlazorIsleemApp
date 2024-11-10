using System.ComponentModel.DataAnnotations;

namespace BlazorIsleemApp.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public int CatId { get; set; } 
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]

        public string FullDetails { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [Required]
        public string ImagePath { get; set; } = string.Empty;
    }
}