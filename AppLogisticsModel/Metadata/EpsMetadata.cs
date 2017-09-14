using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(EpsMetadata))]
    [DisplayName("EPS")]
    public partial class EPS
    {
    }
    
    public class EpsMetadata
    {
        /// <summary>
        /// Nombre de la EPS
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;

        /// <summary>
        /// NIT de la EPS
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "NIT")]
        [Range(100000000, 999999999)]
        public long NIT;
    }
}
