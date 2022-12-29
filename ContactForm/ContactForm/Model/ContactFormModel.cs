﻿namespace ContactForm
{
    using Syncfusion.Maui.DataForm;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents the model class for contact form.
    /// </summary>
    public class ContactFormModel
    {
        [DataFormDisplayOptions(ColumnSpan = 2, ShowLabel = false)]
        public string ProfileImage { get; set; }

        [Display(Prompt = "First name")]
        [Required(ErrorMessage = "Name should not be empty")]
        public string Name { get; set; }

        [Display(Prompt = "Last name")]
        public string LastName { get; set; }

        [Display(Prompt = "Mobile")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public double? Mobile { get; set; }

        [Display(Prompt = "Landline")]
        public double? Landline { get; set; }

        [Display(Prompt = "Address")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string Address { get; set; }

        [Display(Prompt = "City")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string City { get; set; }

        [Display(Prompt = "State")]
        public string State { get; set; }

        [Display(Prompt = "Zip code")]
        [DataFormDisplayOptions(ShowLabel = false)]
        public double? ZipCode { get; set; }

        [Display(Prompt = "Email")]
        public string Email { get; set; }
    }
}