using System.ComponentModel.DataAnnotations;

namespace EmployeeRegistration.BusinessLayer.Models
{
    /// <summary>
    /// Модель представления компании
    /// </summary>
    public class CompanyViewModel
    {
        [Required(ErrorMessage = "Не указан индентификатор компании")]
        [Display(Name = "ID")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Не указано наименование компании")]
        [Display(Name ="Наименование")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина отчества")]
        public string CompanyName { get; set; }
        [Display(Name = "Размер компании")]
        public int CompanySize { get; set; }
        [Required(ErrorMessage = "Не указана организационно-правовая форма компании")]
        [Display(Name = "Организационно-правовая форма")]
        public string LegalForm { get; set; }
        [Required(ErrorMessage = "Не указан вид деятельности компании")]
        [Display(Name = "Вид деятельности")]
        public string ActivityType { get; set; }
    }
}