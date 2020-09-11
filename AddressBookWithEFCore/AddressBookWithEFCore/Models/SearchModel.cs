using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AddressBookWithEFCore.DataAccessLayer;

namespace AddressBookWithEFCore.Models
{
    public class SearchModel
    {
        public int Id { get; set; }

        [StringLength(500, ErrorMessage = "Name length can't be more than 500.")]
        public string FullName { get; set; }

        public string Email { get; set; }

        [Phone(ErrorMessage = "Please enter valid phone number")]
        [StringLength(1000, ErrorMessage = "Phone number length can't be more than 1000.")]
        public string PhoneNumber { get; set; }

        public string PhysicalAddress { get; set; }

        public List<Address> Result { get; set; }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FullName)}: {FullName}, {nameof(Email)}: {Email}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(PhysicalAddress)}: {PhysicalAddress}";
        }
    }
}
