using Syncfusion.Maui.DataForm;

namespace ContactForm
{

    /// <summary>
    /// Represents a behavior class for contact form.
    /// </summary>
    public class ContactFormBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// Holds the data form object.
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// Holds the save button instance.
        /// </summary>
        private Button? saveButton;

        /// <inheritdoc/>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("contactForm");

            if (this.dataForm != null)
            {
                dataForm.RegisterEditor(nameof(ContactFormModel.Mobile), new NumericEditor(dataForm));
                dataForm.RegisterEditor(nameof(ContactFormModel.ZipCode), new NumericEditor(dataForm));
                dataForm.RegisterEditor(nameof(ContactFormModel.Landline), new NumericEditor(dataForm));
                dataForm.ValidateForm += this.OnDataFormValidateForm;
                dataForm.ValidateProperty += this.OnDataFormValidateProperty;
            }

            this.saveButton = bindable.FindByName<Button>("saveButton");
            if (this.saveButton != null)
            {
                this.saveButton.Clicked += OnSaveButtonClicked;
            }
        }

        /// <summary>
        /// Invokes on data form item validation.
        /// </summary>
        /// <param name="sender">The data form.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDataFormValidateProperty(object? sender, DataFormValidatePropertyEventArgs e)
        {
            if (e.PropertyName == nameof(ContactFormModel.Mobile) && !e.IsValid) 
            {
                e.ErrorMessage = e.NewValue == null || string.IsNullOrEmpty(e.NewValue.ToString()) ? "Please enter the mobile number" : "Invalid mobile number";
            }
        }

        /// <summary>
        /// Invokes on manual data form validation.
        /// </summary>
        /// <param name="sender">The data form.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnDataFormValidateForm(object? sender, DataFormValidateFormEventArgs e)
        {
            if (this.dataForm != null && App.Current?.Windows[0].Page != null)
            {
                if (e.ErrorMessage != null && e.ErrorMessage.Count > 0)
                {
                    if (e.ErrorMessage.Count == 2)
                    {
                        await DisplayAlert("", "Please enter the contact name and mobile number", "OK");
                    }
                    else
                    {
                        if (e.ErrorMessage.ContainsKey(nameof(ContactFormModel.Name)))
                        {
                            await DisplayAlert("", "Please enter the contact name", "OK");
                        }
                        else
                        {
                            await DisplayAlert("", "Please enter the mobile number", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("", "Contact saved", "OK");
                }
            }
        }

        /// <summary>
        /// Invokes on save button click.
        /// </summary>
        /// <param name="sender">The button.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            this.dataForm?.Validate();
        }

        /// <inheritdoc/>
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.dataForm != null)
            {
                this.dataForm.ValidateForm -= this.OnDataFormValidateForm;
                this.dataForm.ValidateProperty -= this.OnDataFormValidateProperty;
                this.dataForm = null;
            }

            if (this.saveButton != null)
            {
                this.saveButton.Clicked -= OnSaveButtonClicked;
                this.saveButton = null;
            }
        }

        /// <summary>
        /// Displays an alert dialog to the user.
        /// </summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="cancel">The text for the cancel button.</param>
        /// <returns>A task representing the asynchronous alert display operation.</returns>
        private Task DisplayAlert(string title, string message, string cancel)
        {
            return App.Current?.Windows?[0]?.Page!.DisplayAlert(title, message, cancel)
                   ?? Task.FromResult(false);
        }
    }

}