using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TSVSite.Models
{
    public class ContactUsModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage="Please Enter Name")]
        public string Name { get; set;}

        [DisplayName("Mobile No")]
        [Required(ErrorMessage = "Please Enter Mobile No")]
        public string MobileNo { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "Please Enter Subject")]
        public string Subject { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please Enter Description")]
        public string BusinessMessage { get; set; }

        [DisplayName("Business Website")]
        public string BusinessWebsite { get; set; }
    }
}