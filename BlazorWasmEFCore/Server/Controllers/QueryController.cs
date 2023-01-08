using Aqua.Dynamic;

using BlazorWasmEFCore.Server.Data;
using BlazorWasmEFCore.Shared;

using Microsoft.AspNetCore.Mvc;

using Remote.Linq.EntityFrameworkCore;

namespace BlazorWasmEFCore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : ControllerBase
    {
        

        private readonly ApplicationDbContext _context;

        public QueryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public DynamicObject Query([FromBody] RemoteQuery query) => query.Expression!.ExecuteWithEntityFrameworkCore(_context)!;

    }
}