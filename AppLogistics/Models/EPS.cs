using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppLogistics.Models
{
    public class EPS
    {

        public int Id { get; set; }

        /// <summary>
        /// Nombre de la EPS
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es obligatorio")]
        [StringLength(128, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        /// <summary>
        /// NIT de la EPS
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "NIT")]
        [MinLength(9, ErrorMessage ="La longitud minima es 9")]
        public long NIT { get; set; }

    }
}