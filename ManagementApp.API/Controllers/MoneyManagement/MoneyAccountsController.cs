using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementApp.API.Data;
using ManagementApp.API.Data.Models.MoneyManagement;

namespace ManagementApp.API.Controllers.MoneyManagement
{
    [Route("api/v1/money-accounts")]
    [ApiController]
    public class MoneyAccountsController(MainDataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyAccount>>> GetMoneyAccounts()
        {
            return await context.MoneyAccounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyAccount>> GetMoneyAccount(int id)
        {
            var moneyAccount = await context.MoneyAccounts.FindAsync(id);

            if (moneyAccount == null)
            {
                return NotFound();
            }

            return moneyAccount;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoneyAccount(int id, MoneyAccount moneyAccount)
        {
            if (id != moneyAccount.Id)
            {
                return BadRequest();
            }

            context.Entry(moneyAccount).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyAccountExists(id))
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
        public async Task<ActionResult<MoneyAccount>> PostMoneyAccount(MoneyAccount moneyAccount)
        {
            context.MoneyAccounts.Add(moneyAccount);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetMoneyAccount", new { id = moneyAccount.Id }, moneyAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoneyAccount(int id)
        {
            var moneyAccount = await context.MoneyAccounts.FindAsync(id);
            if (moneyAccount == null)
            {
                return NotFound();
            }

            context.MoneyAccounts.Remove(moneyAccount);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoneyAccountExists(int id)
        {
            return context.MoneyAccounts.Any(e => e.Id == id);
        }
    }
}
