using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bluebox.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}