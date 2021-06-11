using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryService.Models;
using Microsoft.AspNetCore.Authorization;

namespace InventoryService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly InventoryContext _context;

        public UserInfoesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoes
        [HttpGet]
        public IEnumerable<UserInfo> GetUserInfo()
        {
            return _context.UserInfo;
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = await _context.UserInfo.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // PUT: api/UserInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo([FromRoute] int id, [FromBody] UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfo.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserInfoes
        [HttpPost]
        public async Task<IActionResult> PostUserInfo([FromBody] UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserInfo.Add(userInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.UserId }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInfo.Remove(userInfo);
            await _context.SaveChangesAsync();

            return Ok(userInfo);
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfo.Any(e => e.UserId == id);
        }
    }
}