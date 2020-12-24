using Application.Groups.CreateGroup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SmartChargingAPI.Controllers
{
    public class GroupsController : ApiController
    {
        private readonly ILogger<GroupsController> _logger;

        public GroupsController(ILogger<GroupsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateGroupCommand command)
        {
            var id = await Mediator.Send(command);

            _logger.LogInformation($"Group {id} was created.");

            return id;
        }
    }
}
