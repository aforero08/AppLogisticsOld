using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(ClientAreaMetadata))]
    public partial class ClientArea
    {
    }

    public class ClientAreaMetadata
    {
        /// <summary>
        /// Cliente
        /// </summary>
        [Required]
        [Display(Name = "Cliente")]
        public int ClientId;

        /// <summary>
        /// Nombre del área
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;
    }
}
