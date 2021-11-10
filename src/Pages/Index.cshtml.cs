﻿using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Index page is loaded on the start of the application
    /// </summary>
    public class IndexModel : PageModel
    {
        //using Ilogger to log error messages 
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Logger
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // Data middletier
        public JsonFileProductService ProductService { get; }

        //get or set for Products
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Rest Get request
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}