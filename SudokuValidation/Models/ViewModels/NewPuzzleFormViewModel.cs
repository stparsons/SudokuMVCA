using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SudokuValidation.Models.ViewModels
{
    public class NewPuzzleFormViewModel
    {
        [Display(Name = "New Puzzle Data")]
        public string PuzzleData { get; set; }
    }
}