using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(ClientMetadata))]
    public partial class Client
    {
    }

    public class ClientMetadata
    {
        /// <summary>
        /// NIT del cliente
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "NIT")]
        [MinLength(9)]
        public long NIT;

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;

        /// <summary>
        /// Dirección del cliente
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Dirección")]
        public string Address;

        /// <summary>
        /// Sucursal del cliente
        /// </summary>
        [Required]
        [Display(Name = "Sucursal")]
        public int BranchOfficeId;

        /// <summary>
        /// Teléfono del cliente
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Phone;

        /// <summary>
        /// Contacto del cliente
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Contacto")]
        public string Contact;
    }

}
