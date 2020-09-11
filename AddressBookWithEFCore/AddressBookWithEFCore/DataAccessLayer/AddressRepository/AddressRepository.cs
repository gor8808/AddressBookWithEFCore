using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookWithEFCore.Models;

namespace AddressBookWithEFCore.DataAccessLayer.AddressRepository
{
    public class AddressRepository : IAddressRepository
    {
        public async Task<List<Address>> GetAllItems()
        {
            await using var db = new AddressBookContext();
            return db.Addresses.ToList();
        }

        public async Task<Address> GetItemById(int id)
        {
            await using var db = new AddressBookContext();
            return await db.Addresses.FindAsync(id);
        }

        public async Task AddNewItem(Address addressItem)
        {
            await using var db = new AddressBookContext();
            await db.Addresses.AddAsync(addressItem);
            await db.SaveChangesAsync();
        }

        public async Task EditItem(Address addressItem)
        {
            await using var db = new AddressBookContext();
            var itemToEdit = await db.Addresses.FindAsync(addressItem.Id);
            if (itemToEdit != null)
            {
                itemToEdit.FullName = addressItem.FullName;
                itemToEdit.PhoneNumber = addressItem.PhoneNumber;
                itemToEdit.Email = addressItem.Email;
                itemToEdit.PhysicalAddress = addressItem.PhysicalAddress ?? string.Empty;
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteItem(int id)
        {
            await using var db = new AddressBookContext();
            var address = new Address {Id = id};
            db.Addresses.Attach(address);
            db.Addresses.Remove(address);
            await db.SaveChangesAsync();
        }

        public async Task<List<Address>> SearchItem(SearchModel model)
        {
            if (model.Id != 0)
            {
                return new List<Address>
                {
                    await GetItemById(model.Id)
                };
            }
            await using var db = new AddressBookContext();
            return db.Addresses.
                Where(address => 
                    address.Email.Contains(model.Email) ||
                    address.FullName.Contains(model.FullName) ||
                    address.PhoneNumber.Contains(model.PhoneNumber) ||
                    address.PhysicalAddress.Contains(model.PhysicalAddress)).ToList();
        }
        public void GetAddressFromAddressItem(AddressItem addressItem, out Address address)
        {
            address = new Address
            {
                Id = addressItem.Id,
                FullName = addressItem.FullName,
                Email = addressItem.Email,
                PhoneNumber = addressItem.PhoneNumber,
                PhysicalAddress = addressItem.PhysicalAddress,
            };
        }
        public void GetAddressItemFromAddress(out AddressItem addressItem, Address address)
        {
            addressItem = new AddressItem()
            {
                Id = address.Id,
                FullName = address.FullName,
                Email = address.Email,
                PhoneNumber = address.PhoneNumber,
                PhysicalAddress = address.PhysicalAddress,
            };
        }
    }
}
