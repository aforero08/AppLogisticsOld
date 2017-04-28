using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(MaritalStatusMetadata))]
    [DisplayName("Estado Civil")]
    public partial class MaritalStatus
    {
    }

    public class MaritalStatusMetadata
    {
        /// <summary>
        /// Nombre del estado civil
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(64, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;
    }
}
