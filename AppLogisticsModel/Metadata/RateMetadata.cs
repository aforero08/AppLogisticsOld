using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    /// <summary>
    /// Tarifas
    /// </summary>
    [MetadataType(typeof(RateMetadata))]
    [DisplayName("Tarifa")]
    public partial class Rate
    {
    }
    
    public class RateMetadata
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        [Required]
        [Display(Name = "Cliente")]
        public int ClientId;

        /// <summary>
        /// Id de la actividad
        /// </summary>
        [Required]
        [Display(Name = "Actividad")]
        public int ActivityId;

        /// <summary>
        /// Id del tipo vehículo
        /// </summary>
        [Display(Name = "Vehículo")]
        public int? VehicleTypeId;

        /// <summary>
        /// Precio
        /// </summary>
        [Required]
        [Display(Name = "Precio")]
        public int Price;

        /// <summary>
        /// Porcentaje de costo
        /// </summary>
        [Required]
        [Display(Name = "% Costo")]
        public int PercentCost;
    }
}
