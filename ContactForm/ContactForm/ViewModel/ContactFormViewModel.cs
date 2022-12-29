namespace ContactForm
{
    /// <summary>
    /// Represents the view model class for data form.
    /// </summary>
    public class ContactFormViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFormViewModel" /> class.
        /// </summary>
        public ContactFormViewModel()
        {
            this.ContactFormModel = new ContactFormModel();
        }

        /// <summary>
        /// Gets or sets the contact form model.
        /// </summary>
        public ContactFormModel ContactFormModel { get; set; }
    }
}
