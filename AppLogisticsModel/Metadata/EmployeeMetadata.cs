using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(EmployeeMetadata))]
    [DisplayName("Empleado")]
    public partial class Employee
    {
    }

    public class EmployeeMetadata
    {
        /// <summary>
        /// Documento del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Identificación")]
        [MinLength(5)]
        public long DocumentNumber;

        /// <summary>
        /// Nombre del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;

        /// <summary>
        /// Apellido del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string Surname;

        /// <summary>
        /// Fecha de nacimiento del empleado
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BornDate;

        /// <summary>
        /// Fecha de contratación del empleado
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Contratación")]
        public DateTime HireDate;

        /// <summary>
        /// Fecha de nacimiento del empleado
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Retiro")]
        public DateTime? RetirementDate;

        /// <summary>
        /// Ciudad del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(64, MinimumLength = 3)]
        [Display(Name = "Ciudad")]
        public string City;

        /// <summary>
        /// Dirección del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(64, MinimumLength = 3)]
        [Display(Name = "Dirección")]
        public string Address;

        /// <summary>
        /// Celular del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Celular")]
        public string MobilePhone;

        /// <summary>
        /// Fijo del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Teléfono fijo")]
        public string Phone;

        /// <summary>
        /// Correo del empleado
        /// </summary>
        [StringLength(256, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email;

        /// <summary>
        /// Contacto de emergencia del empleado
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Contacto de emergencia")]
        public string EmergencyContact;

        /// <summary>
        /// Teléfono del contacto de emergencia
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Teléfono contacto")]
        public string EmergencyContactPhone;

        /// <summary>
        /// Estado civil del empleado
        /// </summary>
        [Required]
        [Display(Name = "Estado Civil")]
        public int MaritalStatusId;

        /// <summary>
        /// AFP del empleado
        /// </summary>
        [Required]
        [Display(Name = "AFP")]
        public int AfpId;

        /// <summary>
        /// EPS del empleado
        /// </summary>
        [Required]
        [Display(Name = "EPS")]
        public int EpsId;

        /// <summary>
        /// Entrega Hoja de vida
        /// </summary>
        [Required]
        [Display(Name = "Hoja de Vida")]
        public bool CV;

        /// <summary>
        /// Entrega Copia de CC
        /// </summary>
        [Required]
        [Display(Name = "Fotocopia cédula")]
        public bool DocumentCopy;

        /// <summary>
        /// Entrega Fotos
        /// </summary>
        [Required]
        [Display(Name = "Fotos")]
        public bool Photos;

        /// <summary>
        /// Entrega copia libreta militar
        /// </summary>
        [Required]
        [Display(Name = "Fotocopia libreta militar")]
        public bool MilitaryIdCopy;

        /// <summary>
        /// Entrega Certificación laboral
        /// </summary>
        [Required]
        [Display(Name = "Certificación Laboral")]
        public bool LaborCertification;

        /// <summary>
        /// Entrega referencia personal
        /// </summary>
        [Required]
        [Display(Name = "Referencia personal")]
        public bool PersonalReference;

        /// <summary>
        /// Entrega Antecedentes disciplinarios
        /// </summary>
        [Required]
        [Display(Name = "Antecedentes disciplinarios")]
        public bool DisciplinaryBackground;

        /// <summary>
        /// Entrega prueba test conocimiento
        /// </summary>
        [Required]
        [Display(Name = "Test Conocimiento")]
        public bool KnowledgeTest;

        /// <summary>
        /// Entrega Exámen de ingreso
        /// </summary>
        [Required]
        [Display(Name = "Exámen de ingreso")]
        public bool AdmissionTest;

        /// <summary>
        /// Entrega Contrato
        /// </summary>
        [Required]
        [Display(Name = "Contrato")]
        public bool Contract;

        /// <summary>
        /// Entrega Reglamento interno
        /// </summary>
        [Required]
        [Display(Name = "Reglamento interno")]
        public bool InternalRegulations;

        /// <summary>
        /// Entrega Carta dotación
        /// </summary>
        [Required]
        [Display(Name = "Carta dotación")]
        public bool EndownmentLetter;

        /// <summary>
        /// Posición crítica
        /// </summary>
        [Required]
        [Display(Name = "Posición crítica")]
        public bool CriticalPosition;

        /// <summary>
        /// Comentarios
        /// </summary>
        [StringLength(500)]
        [Display(Name = "Comentarios")]
        public string Comments;
    }
}
