using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(ActivityMetadata))]
    public partial class Activity
    {
    }

    public class ActivityMetadata
    {
        /// <summary>
        /// Nombre de la actividad
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name;
    }
}
