using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(ServiceMetadata))]
    public partial class Service
    {
    }

    public class ServiceMetadata
    {
        /// <summary>
        /// Fecha de ejecución
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Ejecución")]
        public DateTime ExecutionDate;

        /// <summary>
        /// Cliente 
        /// </summary>
        [Required]
        [Display(Name = "Cliente")]
        public int ClientId;

        /// <summary>
        /// Área interna del cliente
        /// </summary>
        [Display(Name = "Área")]
        public int? ClientAreaId;

        /// <summary>
        /// Actividad
        /// </summary>
        [Required]
        [Display(Name = "Actividad")]
        public int ActivityId;

        /// <summary>
        /// Producto
        /// </summary>
        [Display(Name = "Producto")]
        public int? ProductId;

        /// <summary>
        /// Cantidad del producto
        /// </summary>
        [Display(Name = "Cantidad")]
        public int? ProductQuantity;

        /// <summary>
        /// Tipo de vehículo
        /// </summary>
        [Display(Name = "Tipo de vehículo")]
        public int? VehicleTypeId;

        /// <summary>
        /// Placa
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Placa")]
        public string VehicleNumber;

        /// <summary>
        /// Transportadora
        /// </summary>
        [Display(Name = "Transportadora")]
        public int? CarrierId;

        /// <summary>
        /// Id de importación o exportación
        /// </summary>
        [Display(Name = "Id Impo/Expo")]
        public string ExternalId;

        /// <summary>
        /// Comentarios del servicio
        /// </summary>
        [Display(Name = "Comentarios")]
        public string Comments;

        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        [DataType(DataType.Date)]
        [Editable(false)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Creación")]
        public DateTime CreationDate;

        /// <summary>
        /// Precio total del servicio
        /// </summary>
        [Editable(false)]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio total")]
        public int FullPrice;

        /// <summary>
        /// Precio de la participación
        /// </summary>
        [Editable(false)]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio participación")]
        public int HoldingPrice;

    }
}
