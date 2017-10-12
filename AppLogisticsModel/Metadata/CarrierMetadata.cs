using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(CarrierMetadata))]
    [DisplayName("Transportadora")]
    public partial class Carrier
    {
    }

    public class CarrierMetadata
    {
        /// <summary>
        /// Nombre de la transportadora
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;

        /// <summary>
        /// NIT de la transportadora
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "NIT")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "El NIT debe conformarse por 9 dígitos")]
        public string NIT;
    }
}
