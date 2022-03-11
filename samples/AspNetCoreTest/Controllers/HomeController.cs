using AspNetCoreTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreTest.Data;
using Event;
using Microsoft.EntityFrameworkCore;
using Pluto.EventBus.Abstract.Interfaces;

namespace AspNetCoreTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IEventBus _eventBus;

        private readonly DemoDbContext _context;
        public HomeController(ILogger<HomeController> logger, IEventBus eventBus, DemoDbContext ctx)
        {
            _logger = logger;
            _eventBus = eventBus;
            _context= ctx;
        }

        public async Task<IActionResult> Index()
        {
            var ddd = await _context.Blogs.FirstOrDefaultAsync();
            return View(ddd);
        }


        public IActionResult Sub()
        {
            _eventBus.Subscribe<DemoEvent, DemoEventHandler>();
            _eventBus.Subscribe<UserEvent, UserEventHandler>();
            return View("Index");
        }

        public async Task<IActionResult> Privacy()
        {
            _eventBus.Unsubscribe<UserEvent, UserEventHandler>();
            await Task.Delay(500);
            _eventBus.Unsubscribe<DemoEvent, DemoEventHandler>();
            return View("Index");
        }


        public async Task<IActionResult> Update()
        {
            _eventBus.Publish(new UserEvent
            {
                Code = "123123"
            });
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
