using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementApp.API.Data;
using ManagementApp.API.Data.Models.MoneyManagement;

namespace ManagementApp.API.Controllers.MoneyManagement
{
    [Route("api/v1/money-movements")]
    [ApiController]
    public class MoneyMovementsController(MainDataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyMovement>>> GetMoneyMovement()
        {
            return await context.MoneyMovement.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyMovement>> GetMoneyMovement(int id)
        {
            var moneyMovement = await context.MoneyMovement.FindAsync(id);

            if (moneyMovement == null)
            {
                return NotFound();
            }

            return moneyMovement;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoneyMovement(int id, MoneyMovement moneyMovement)
        {
            if (id != moneyMovement.Id)
            {
                return BadRequest();
            }

            context.Entry(moneyMovement).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyMovementExists(id))
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
        public async Task<ActionResult<MoneyMovement>> PostMoneyMovement(MoneyMovement moneyMovement)
        {
            context.MoneyMovement.Add(moneyMovement);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetMoneyMovement", new { id = moneyMovement.Id }, moneyMovement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoneyMovement(int id)
        {
            var moneyMovement = await context.MoneyMovement.FindAsync(id);
            if (moneyMovement == null)
            {
                return NotFound();
            }

            context.MoneyMovement.Remove(moneyMovement);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoneyMovementExists(int id)
        {
            return context.MoneyMovement.Any(e => e.Id == id);
        }
    }
}
