using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogisticsModel
{
    [MetadataType(typeof(BranchOfficeMetadata))]
    [DisplayName("Sucursal")]
    public partial class BranchOffice
    {
    }

    public class BranchOfficeMetadata
    {
        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Nombre Sucursal")]
        public string Name;
    }
}
