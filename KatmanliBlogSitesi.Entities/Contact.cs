using System.ComponentModel.DataAnnotations;

namespace KatmanliBlogSitesi.Entities
{
    public class Contact : IEntity
    {
        public int Id { get ; set ; }
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage ="{0} alanı boş geçilemez!"),StringLength(50),Display(Name ="Ad")]
        public string ContactUserName { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"),StringLength(50), EmailAddress, Display(Name ="Email Adresi")]
        public string ContactMail { get; set; }

        [Display(Name ="Telefon"),StringLength(20)]
        public string ContactPhone { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(500), Display(Name = "Mesaj")]
        public string ContactMessage { get; set; }
     

    }
}
