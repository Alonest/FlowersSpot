using FlowersSpot.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlowersSpot.Models;

namespace FlowersSpot.Controllers
{
    public class PagesController : Controller
    {
        private readonly FlowersSpotContext context;

        public PagesController(FlowersSpotContext context)
        {
            this.context = context;
        }

        //get / or / slug
        public async Task<IActionResult> Page(string slug)
        {
            if (slug == null)
            {
                return View(await context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }

            Page page = await context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }
    }
}
