using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(ProductMetadata))]
    [DisplayName("Producto")]
    public partial class Product
    {
    }

    public class ProductMetadata
    {
        /// <summary>
        /// Nombre del producto
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;
    }
}
