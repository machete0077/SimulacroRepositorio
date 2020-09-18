using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Simulacro.Models
{
    public enum placeType
        {
            Burtown,
            Paradize,
            LaPlaza,
            Panorama,
            Gatsby
        }
    public class Arce
    {
        [Key]
        [Range(2,9999)]
        public int ArceID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength =2)]
        public String FriendofArce { get; set; }
        [Required]
        public placeType Place { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public String Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public int Birthdate { get; set; }
    }
}