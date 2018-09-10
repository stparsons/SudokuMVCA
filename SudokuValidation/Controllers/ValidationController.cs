using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SudokuValidation.Models;
using SudokuValidation.Models.ViewModels;
using SudukoValidator;

namespace SudokuValidation.Controllers
{
    public class ValidationController : Controller
    {

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validate(NewPuzzleFormViewModel newPuzzle)
        {
            SudokuGrid sudokuGrid = new SudokuGrid()
            {
                IndexIterator = 0,
                ValidatorGrid = new Validator( newPuzzle.PuzzleData )
            };

            return View( sudokuGrid );
        }

        public ActionResult Index( NewPuzzleFormViewModel newPuzzle )
        {
            string clientString = @"
                5 3 4 6 7 8 9 1 2
                6 7 2 1 9 5 3 4 8
                1 9 8 3 4 2 5 6 7
                8 5 9 7 6 1 4 2 3
                4 2 6 8 5 3 7 9 1
                7 1 3 9 2 4 8 5 6
                9 6 1 5 3 7 2 8 4
                2 8 7 4 1 9 6 3 5
                3 4 5 2 8 6 1 7 9
                ";

            SudokuGrid sudokuGrid = new SudokuGrid()
            {
                IndexIterator = 0,
                ValidatorGrid = new Validator( clientString )
            };
            
            return View(sudokuGrid);
        }
    }
}