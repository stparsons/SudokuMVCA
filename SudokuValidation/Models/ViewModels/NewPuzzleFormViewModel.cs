using System.ComponentModel.DataAnnotations;

namespace SudokuValidation.Models.ViewModels
{
    /// <summary>
    ///     Class represents a view model of puzzle data and messages to display on this form
    /// </summary>
    public class NewPuzzleFormViewModel
    {
        [Required]
        [NewPuzzleCustomValidation]
        [Display( Name = "New Puzzle Data" )]
        public string PuzzleData { get; set; }

        public string Message { get; set; }
    }
}