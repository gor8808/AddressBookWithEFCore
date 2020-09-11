using System.ComponentModel.DataAnnotations;

namespace AddressBookWithEFCore.Models
{
    public class AddressItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(500, ErrorMessage = "Name length can't be more than 500.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter valid phone number")]
        [StringLength(1000, ErrorMessage = "Phone number length can't be more than 1000.")]
        public string PhoneNumber { get; set; }

        public string PhysicalAddress { get; set; }

        public string QrCodeBase64Url { get; set; }

        public override string ToString()
        {
            return $"{nameof(FullName)}: {FullName}, \n{nameof(Email)}: {Email}, \n{nameof(PhoneNumber)}: {PhoneNumber}, \n{nameof(PhysicalAddress)}: {PhysicalAddress}";
        }
    }
}
