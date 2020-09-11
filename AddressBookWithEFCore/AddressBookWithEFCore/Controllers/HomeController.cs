using System.Diagnostics;
using System.Threading.Tasks;
using AddressBookWithEFCore.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AddressBookWithEFCore.DataAccessLayer.AddressRepository;
using AddressBookWithEFCore.Models;
using AddressBookWithEFCore.Services;

namespace AddressBookWithEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAddressRepository _addressRepository;
        public string DefaultView { get; } = nameof(ShowWithTable);

        public HomeController(ILogger<HomeController> logger, IAddressRepository addressRepository)
        {
            _logger = logger;
            _addressRepository = addressRepository;
        }

        public async Task<IActionResult> ShowWithCubes()
        {
            var addresses = await _addressRepository.GetAllItems();
            return View(addresses);
        }
        public async Task<IActionResult> ShowWithTable()
        {
            var addresses = await _addressRepository.GetAllItems();
            return View(addresses);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressItem addressItem)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _addressRepository.GetAddressFromAddressItem(addressItem, out var address);
            await _addressRepository.AddNewItem(address);
            return RedirectToAction(DefaultView);
        }

        

        public async Task<IActionResult> Edit(int id)
        {
            var address = await _addressRepository.GetItemById(id);
            _addressRepository.GetAddressItemFromAddress(out var addressItem, address);
            return View(addressItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddressItem addressItem)
        {
            if (!ModelState.IsValid)
            {
                return View(addressItem);
            }

            _addressRepository.GetAddressFromAddressItem(addressItem, out var address);
            await _addressRepository.EditItem(address);
            return RedirectToAction(DefaultView);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _addressRepository.DeleteItem(id);

            return RedirectToAction(DefaultView);
        }
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchModel searchModel)
        {
            var addresses = await _addressRepository.SearchItem(searchModel);
            searchModel.Result = addresses;
            return View(searchModel);
        }
        public async Task<IActionResult> SingleAddressItem(int id)
        {
            var addressInfo = await _addressRepository.GetItemById(id);
            ViewBag.QrCodeBase64Url =
                QrCodeGeneratorService.GenerateQrFrom(addressInfo.ToString());
            return View(addressInfo);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
