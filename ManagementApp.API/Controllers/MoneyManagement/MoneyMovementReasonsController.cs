using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementApp.API.Data;
using ManagementApp.API.Data.Models.MoneyManagement;

namespace ManagementApp.API.Controllers.MoneyManagement
{
    [Route("api/v1/money-movement-reasons")]
    [ApiController]
    public class MoneyMovementReasonsController(MainDataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyMovementReason>>> GetMoneyMovementReasons()
        {
            return await context.MoneyMovementReasons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyMovementReason>> GetMoneyMovementReason(int id)
        {
            var moneyMovementReason = await context.MoneyMovementReasons.FindAsync(id);

            if (moneyMovementReason == null)
            {
                return NotFound();
            }

            return moneyMovementReason;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoneyMovementReason(int id, MoneyMovementReason moneyMovementReason)
        {
            if (id != moneyMovementReason.Id)
            {
                return BadRequest();
            }

            context.Entry(moneyMovementReason).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyMovementReasonExists(id))
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
        public async Task<ActionResult<MoneyMovementReason>> PostMoneyMovementReason(MoneyMovementReason moneyMovementReason)
        {
            context.MoneyMovementReasons.Add(moneyMovementReason);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetMoneyMovementReason", new { id = moneyMovementReason.Id }, moneyMovementReason);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoneyMovementReason(int id)
        {
            var moneyMovementReason = await context.MoneyMovementReasons.FindAsync(id);
            if (moneyMovementReason == null)
            {
                return NotFound();
            }

            context.MoneyMovementReasons.Remove(moneyMovementReason);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoneyMovementReasonExists(int id)
        {
            return context.MoneyMovementReasons.Any(e => e.Id == id);
        }
    }
}
