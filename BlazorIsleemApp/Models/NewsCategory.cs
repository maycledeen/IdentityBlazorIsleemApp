using System.ComponentModel.DataAnnotations;

namespace BlazorIsleemApp.Models
{
    public class NewsCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }
    }
}
