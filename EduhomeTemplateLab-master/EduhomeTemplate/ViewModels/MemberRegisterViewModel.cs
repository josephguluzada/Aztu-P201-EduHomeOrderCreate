using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.ViewModels
{
    public class MemberRegisterViewModel
    {

        [Required]
        [StringLength(maximumLength: 20)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Fullname { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password), Compare(nameof(Password))]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public string RepeatPassword { get; set; }

    }
}
