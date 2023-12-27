using System.ComponentModel.DataAnnotations;

namespace Appointment_form.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Your name is required")]
        public string FullName { get; set; }
        [Display(Name = "Reservation Type"),
            Required(ErrorMessage = "Please select the reservation type")]
        public ReservationType ReservationType { get; set; }
        [Display(Name ="Email Addres"),
            Required(ErrorMessage = "Email address is required."),
            EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Mail { get; set; }
        [Required(ErrorMessage ="Your nationality is required")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Phone number is required"), 
            Display(Name = "Phone Number"),
            RegularExpression(@"^\+?\d{7,12}$", ErrorMessage = "Please enter a valid phone number.")]

        public string Phone { get; set; }
    }
    public enum ReservationType { Normal, VIP }
}
