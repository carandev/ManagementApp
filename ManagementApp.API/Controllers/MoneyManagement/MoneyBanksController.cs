using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementApp.API.Data;
using ManagementApp.API.Data.Models.MoneyManagement;

namespace ManagementApp.API.Controllers.MoneyManagement
{
    [Route("api/v1/money-banks")]
    [ApiController]
    public class MoneyBanksController(MainDataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyBank>>> GetMoneyBanks()
        {
            return await context.MoneyBanks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyBank>> GetMoneyBank(int id)
        {
            var moneyBank = await context.MoneyBanks.FindAsync(id);

            if (moneyBank == null)
            {
                return NotFound();
            }

            return moneyBank;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoneyBank(int id, MoneyBank moneyBank)
        {
            if (id != moneyBank.Id)
            {
                return BadRequest();
            }

            context.Entry(moneyBank).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyBankExists(id))
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
        public async Task<ActionResult<MoneyBank>> PostMoneyBank(MoneyBank moneyBank)
        {
            context.MoneyBanks.Add(moneyBank);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetMoneyBank", new { id = moneyBank.Id }, moneyBank);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoneyBank(int id)
        {
            var moneyBank = await context.MoneyBanks.FindAsync(id);
            if (moneyBank == null)
            {
                return NotFound();
            }

            context.MoneyBanks.Remove(moneyBank);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoneyBankExists(int id)
        {
            return context.MoneyBanks.Any(e => e.Id == id);
        }
    }
}
