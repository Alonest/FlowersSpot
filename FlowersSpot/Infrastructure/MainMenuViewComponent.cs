using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersSpot.Areas.Admin.Controllers;
using FlowersSpot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowersSpot.Infrastructure
{

    public class MainMenuViewComponent : ViewComponent
    {
        private readonly FlowersSpotContext context;

        public MainMenuViewComponent(FlowersSpotContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await GetPagesAsync();
            return View(pages);
        }

        private Task<List<Page>> GetPagesAsync()
        {
            return context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }

    }
}
