using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegistration.BusinessLayer.Models
{
    /// <summary>
    /// Модель представления сотрудника
    /// </summary>
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Company = new CompanyViewModel();
        }

        private DateTime _employmentDate = DateTime.Now;

        [Required]
        [Display(Name = "ID")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [Display(Name = "Фамилия")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина фамилии")]
        public string Surname {get;set;}

        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [Display(Name = "Отчество")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина отчества")]
        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата приёма на работу")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmploymentDate
        {
            get { return _employmentDate; }
            set { _employmentDate = value; }
        }

        [Required]
        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Компания")]
        public CompanyViewModel Company { get; set; }
    }
}
