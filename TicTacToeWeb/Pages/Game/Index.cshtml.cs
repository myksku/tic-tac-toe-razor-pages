using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicTacToeWeb.Model;
using TicTacToeWeb.Services;
using TicTacToeWeb.VM;

namespace TicTacToeWeb.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly IGameService _gameService;

        public IndexModel(IGameService gameService)
        {
            _gameService = gameService;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public GameVM VM { get; set; }

        public IActionResult OnGet()
        {
            VM = _gameService.GetVM();
            
            return Page();
        }

        public IActionResult OnPost()
        {
            _gameService.Update(Input.X,Input.Y);

            VM = _gameService.GetVM();
            return Page();
        }

        public IActionResult OnPostInitialize(int size)
        {
            _gameService.InitializeNew(size);
            
            VM = _gameService.GetVM();
            
            return Page();
        }


        public class InputModel
        {
            public int X { get; set; }
            public int Y { get; set; }
            public char Player { get; set; }
        }

    }
}
