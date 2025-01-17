using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicTacToeWeb.Services;
using TicTacToeWeb.Utilities;

namespace TicTacToeWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGameService _gameService;

        public IndexModel(ILogger<IndexModel> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

    }
}