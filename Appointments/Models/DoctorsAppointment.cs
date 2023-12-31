﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointments.Models
{
	public class DoctorsAppointment
	{
        [Key]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Contact Field is Required.")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Contact Field is Required.")]
        public string? LastName { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime DOB { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "This Contact Field is Required.")]
        public string? EmailAddress { get; set; }

        [DisplayName("Phone Number")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Field is Required.")]
        public string? PhoneNumber { get; set; }
    }
}

