using System;
using System.Threading.Tasks;
using AspNetCoreTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pluto.EventBus.Abstract.Interfaces;

namespace Event
{
    public class UserEventHandler:IIntegrationEventHandler<UserEvent>
    {
        private readonly ILogger<DemoEventHandler> _logger;
        private readonly DemoDbContext _demoDbContext;

        public UserEventHandler(ILogger<DemoEventHandler> logger, DemoDbContext ctx)
        {
            _logger = logger;
            _demoDbContext= ctx;
        }



        /// <inheritdoc />
        public async Task Handle(UserEvent @event)
        {
            await Task.Yield();
            await Task.Delay(4000);
            var ad = await _demoDbContext.Blogs.FirstOrDefaultAsync();
            await _demoDbContext.Blogs.AddAsync(new Blog
            {
                Name = @event.Code,
                CreateTime = DateTime.Now
            });
            await _demoDbContext.SaveChangesAsync();
            _logger.LogInformation($"[UserEventHandler] : {@event.Code}");
        }
    }
}