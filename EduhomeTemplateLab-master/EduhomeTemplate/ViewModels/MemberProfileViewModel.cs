using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.ViewModels
{
    public class MemberProfileViewModel
    {
        [StringLength(maximumLength: 20)]
        public string Username { get; set; }
        [StringLength(maximumLength: 20)]
        public string Fullname { get; set; }
        [StringLength(maximumLength: 20)]
        public string Email { get; set; }
        [StringLength(maximumLength: 15)]
        public string PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }

        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password), Compare(nameof(NewPassword))]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public string ConfirmNewPassword { get; set; }
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public string CurrentPassword { get; set; }

    }
}
