using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        public RolesController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddAdminRoleToUser(string email)
        {
            // 1. Znajdź użytkownika po adresie e-mail
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                // Obsługa błędu - użytkownik nie znaleziony
                return NotFound($"Użytkownik o adresie {email} nie został znaleziony.");
            }

            // 2. Dodaj rolę "Admin" do użytkownika
            if (!await _userManager.IsInRoleAsync(user, "Admin"))
            {
                // Jeśli użytkownik nie ma jeszcze tej roli, dodaj ją
                var result = await _userManager.AddToRoleAsync(user, "Admin");

                if (result.Succeeded)
                {
                    // Pomyślnie dodano rolę
                    return Ok($"Rola 'Admin' została pomyślnie dodana do użytkownika: {email}");
                }
                else
                {
                    // Obsługa błędu podczas dodawania roli
                    return BadRequest($"Błąd podczas dodawania roli 'Admin' do użytkownika: {email}. Błędy: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            return Ok($"Użytkownik {email} już posiada rolę 'Admin'.");
        }

       
        
    }
}
