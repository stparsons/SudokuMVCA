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

        /// <summary>
        ///     New Puzzle Input
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            return View();
        }

        /// <summary>
        ///     Validation post.
        /// </summary>
        /// <param name="newPuzzle"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Validate(NewPuzzleFormViewModel newPuzzle)
        {
            if ( !ModelState.IsValid )
            {
                return View( "New" );
            }

            Validator validator = new Validator( newPuzzle.PuzzleData );

            SudokuGrid sudokuGrid = new SudokuGrid()
            {
                IndexIterator = 0,
                ValidatorGrid = validator,
                Message = validator.IsAllGridValid() ? "Puzzle Is Valid!" : "Puzzle is not Valid"
            };

            return View( sudokuGrid );
        }
    }
}