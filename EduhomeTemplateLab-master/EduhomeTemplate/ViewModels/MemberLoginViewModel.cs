using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.ViewModels
{
    public class MemberLoginViewModel
    {
        [Required]
        [StringLength(maximumLength:25)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 25)]
        public string Password { get; set; }

    }
}
