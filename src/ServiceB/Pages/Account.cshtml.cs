using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceB.Pages
{
    public class AccountModel : PageModel
    {
        private readonly ILogger<AccountModel> _logger;

        public AccountModel(ILogger<AccountModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}