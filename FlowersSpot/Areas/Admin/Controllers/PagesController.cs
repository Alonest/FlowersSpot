﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersSpot.Infrastructure;
using FlowersSpot.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowersSpot.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly FlowersSpotContext context;

        public PagesController(FlowersSpotContext context)
        {
            this.context = context;
        }

        //Metoda GET admin/pages

        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);

        }

        //Metoda GET admin/pages/details/5
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();

            }

            return View(page);

        }
        
        //Metoda GET admin/pages/create
        public IActionResult Create() => View();

    }
}
