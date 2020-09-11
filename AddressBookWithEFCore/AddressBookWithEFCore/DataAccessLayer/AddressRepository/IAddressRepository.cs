using System.Collections.Generic;
using System.Threading.Tasks;
using AddressBookWithEFCore.Models;

namespace AddressBookWithEFCore.DataAccessLayer.AddressRepository
{
    public interface IAddressRepository
    {
        public Task<List<Address>> GetAllItems();
        public Task<Address> GetItemById(int id);
        public Task AddNewItem(Address addressItem);
        public Task EditItem(Address addressItem);
        public Task DeleteItem(int id);
        public Task<List<Address>> SearchItem(SearchModel model);
        public void GetAddressFromAddressItem(AddressItem addressItem, out Address address);
        public void GetAddressItemFromAddress(out AddressItem addressItem, Address address);

    }
}
