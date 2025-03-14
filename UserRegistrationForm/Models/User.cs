﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationForm.Models
{
	public class User
	{
		[Key]
        public int Id { get; set; }

		[Required (ErrorMessage = "First name is required")]
		[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
		[Display(Name = "First Name")]
        public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

		[Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		[StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters")]
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
		[EmailAddress]
		[StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; }

		[Required(ErrorMessage = "Address is required")]
        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters")]
        [Display(Name = "Address")]
        public string Address { get; set; }

		[Required(ErrorMessage = "State is required")]
		[StringLength(50, ErrorMessage = "State cannot be longer than 50 characters")]
        public string State { get; set; }

		[Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        public string City { get; set; }

		[Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        [Display(Name = "Username")]
        public string Username { get; set; }

		[Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, ErrorMessage = "Confirm Password cannot be longer than 50 characters")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }

    }
}