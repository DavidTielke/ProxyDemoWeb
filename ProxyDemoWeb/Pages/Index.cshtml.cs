using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyDemoWeb.Services;

namespace ProxyDemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonManager _manager;

        public IndexModel(ILogger<IndexModel> logger, IPersonManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        public void OnGet()
        {
            ViewData["returnValue"] = _manager.Get();
        }
    }
}
