using System.ComponentModel.DataAnnotations;

namespace Abby.Model
{
    public class Category
    {
        [Key] // Attribute/DataAnnotation that sets this as Primary Key
        public int Id { get; set; }

        [Required] // Makes Name a requirement
        public string Name { get; set; }

        [Display (Name ="Display Order")]
        public int DisplayOrder { get; set; }
    }
}
