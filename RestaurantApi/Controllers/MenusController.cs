using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Menus.Commands.CreateMenu;
using Restaurant.Contracts.Menus;

namespace Restaurant.Api.Controllers
{
    [Route("api/hosts/{hostId}/menus")]  
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        public MenusController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var commant = _mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult  = await _sender.Send(commant);
           
            return createMenuResult.Match(
                createResult => Ok(_mapper.Map<MenuResponse>(createResult)),
                errors => Problem(errors));
        }
    }
}
