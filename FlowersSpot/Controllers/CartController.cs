using FlowersSpot.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersSpot.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FlowersSpot.Controllers
{
    public class CartController : Controller
    {
        private readonly FlowersSpotContext context;

        public CartController(FlowersSpotContext context)
        {
            this.context = context;
        }

        // Get/ cart
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };
            return View(cartVM);
        }


        // get/cart/add/id
        public async Task<IActionResult> Add(int id)
        {
            Product product = await context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToAction("Index");
        }
    }
}
