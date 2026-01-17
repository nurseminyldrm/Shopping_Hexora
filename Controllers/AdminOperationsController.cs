using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping_Hexora.Constants;
using Shopping_Hexora.Data;
using Shopping_Hexora.Models;
using Shopping_Hexora.Services;

namespace Shopping_Hexora.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class AdminOperationsController : Controller
    {
        private readonly IUserOrderService _userOrderService;
        private readonly IManageItemService _manageItemService; 
        public AdminOperationsController(IUserOrderService userOrderService, IManageItemService manageItemService )
        {
            _userOrderService = userOrderService;
            _manageItemService = manageItemService;
           
        }


        public async Task<IActionResult> AllOrders()
        {
            var orders = await _userOrderService.AllOrders();
            return View(orders);
        }

        
        [HttpGet]
        public async Task<IActionResult> UpdateOrderStatus(int orderId)
        {
            var order = await _userOrderService.GetOrderById(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order with id:{orderId} does not found.");
            }
            var orderStatusList = _userOrderService.GetSelectLists();
            var data = new UpdateOrderStatusModel
            {
                OrderId = orderId,
                OrderStatusId = order.OrderStatusId,
                OrderStatusList = orderStatusList
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderStatusModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    data.OrderStatusList =  _userOrderService.GetSelectLists();
                    return View(data);
                }
                await _userOrderService.ChangeOrderStatus(data);
                TempData["msg"] = "Updated successfully";
            }
            catch
            {   // catch exception here
                TempData["msg"] = "Something went wrong";
            }
            return RedirectToAction(nameof(UpdateOrderStatus), new { orderId = data.OrderId });
        }

        public async Task<IActionResult> TogglePaymentStatus(int orderId)
        {
            try
            {
                await _userOrderService.TogglePaymentStatus(orderId);
            }
            catch (Exception ex)
            {
                // log exception here
            }
            return RedirectToAction(nameof(AllOrders));
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task <IActionResult> ToggleApprovementStatus(int ItemId)
        {
            try
            {
                await _manageItemService.ToggleApprovementStatus(ItemId);
            }
            catch (Exception ex)
            {
                // log exception here
            }
            return RedirectToAction(nameof(GetAllItems));
             
        }
        public async Task <IActionResult> GetAllItems()
        {
            var items = await _manageItemService.GetAllItems();
            return View(items);
        }

        // Kategori Ekleme Sayfasını Açar
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        // Kategoriyi Veritabanına Kaydeder
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                // Burada senin kategori servisin veya DbContext'in üzerinden ekleme yapmalısın
                // Örneğin: _context.Categories.Add(model); await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetAllItems));
            }
            return View(model);
        }

        public async Task<IActionResult> CreateItem()
        {
            // Kategorileri servisten çekip listeye koyuyoruz
            var categories = await _manageItemService.GetAllCategories();
            ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(categories, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> AddProduct()
        {
            // categories listesini servisten çekiyoruz
            var categories = await _manageItemService.GetAllCategories();

            // View tarafındaki dropdown'ın beslenmesi için ViewBag kullanıyoruz
            ViewBag.CategoryList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(categories, "Id", "Name");

            return View();
        }

    }
}
