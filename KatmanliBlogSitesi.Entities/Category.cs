
using System.ComponentModel.DataAnnotations;



namespace KatmanliBlogSitesi.Entities
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
        public virtual List<Post>? Posts { get; set; } 
    }
}
