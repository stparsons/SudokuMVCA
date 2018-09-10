using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SudokuValidation.Models.ViewModels
{
    public class NewPuzzleFormViewModel
    {
        [Required]
        [NewPuzzleCustomValidation]
        [Display( Name = "New Puzzle Data" )]
        public string PuzzleData { get; set; }

        public string Message { get; set; }
    }
}