using System.ComponentModel.DataAnnotations;

namespace Core_Proje_API.DAL.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
