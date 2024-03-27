using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementApp.API.Data;
using ManagementApp.API.Data.Models.MoneyManagement;

namespace ManagementApp.API.Controllers.MoneyManagement
{
    [Route("api/v1/money-borrowed")]
    [ApiController]
    public class MoneyBorrowedController(MainDataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyBorrowed>>> GetMoneyBorrowed()
        {
            return await context.MoneyBorrowed.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyBorrowed>> GetMoneyBorrowed(int id)
        {
            var moneyBorrowed = await context.MoneyBorrowed.FindAsync(id);

            if (moneyBorrowed == null)
            {
                return NotFound();
            }

            return moneyBorrowed;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoneyBorrowed(int id, MoneyBorrowed moneyBorrowed)
        {
            if (id != moneyBorrowed.Id)
            {
                return BadRequest();
            }

            context.Entry(moneyBorrowed).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyBorrowedExists(id))
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

        [HttpPost]
        public async Task<ActionResult<MoneyBorrowed>> PostMoneyBorrowed(MoneyBorrowed moneyBorrowed)
        {
            context.MoneyBorrowed.Add(moneyBorrowed);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetMoneyBorrowed", new { id = moneyBorrowed.Id }, moneyBorrowed);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoneyBorrowed(int id)
        {
            var moneyBorrowed = await context.MoneyBorrowed.FindAsync(id);
            if (moneyBorrowed == null)
            {
                return NotFound();
            }

            context.MoneyBorrowed.Remove(moneyBorrowed);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoneyBorrowedExists(int id)
        {
            return context.MoneyBorrowed.Any(e => e.Id == id);
        }
    }
}
