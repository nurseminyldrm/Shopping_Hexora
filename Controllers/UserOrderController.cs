using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Hexora.Models;
using Shopping_Hexora.Services;

namespace Shopping_Hexora.Controllers
{
    [Authorize]
    public class UserOrderController : Controller
    {
        private readonly IUserOrderService _userOrderService;
        public UserOrderController(IUserOrderService userOrderService)
        {
            _userOrderService = userOrderService;
        }
        public async Task<IActionResult> UserOrders()
        {
            var orders = await _userOrderService.UserOrders();
            return View(orders);
        }
         
        public async Task<IActionResult> GetDetail(int orderId)
        {
            var detail =await _userOrderService.GetOrderDetail(orderId);
            return View(detail);
        }
        
    }
}
