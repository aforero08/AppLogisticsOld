using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(HoldingMetadata))]
    [DisplayName("Participación")]
    public partial class Holding
    {
    }

    public class HoldingMetadata
    {
        /// <summary>
        /// Id de servicio
        /// </summary>
        [Required]
        [Display(Name = "Id de servicio")]
        public int ServiceId;

        /// <summary>
        /// Id de empleado
        /// </summary>
        [Required]
        [Display(Name = "Id de empleado")]
        public int EmployeeId;

        /// <summary>
        /// Precio
        /// </summary>
        [Required]
        [Editable(false)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="0: $0.000,00")]
        [Display(Name = "Precio")]
        public int Price;
    }
}
