using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsDTO
{
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
