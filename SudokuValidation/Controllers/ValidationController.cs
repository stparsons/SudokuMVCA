using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SudokuValidation.Models;
using SudukoValidator;

namespace SudokuValidation.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult Index()
        {
            List<List<int>> gridData = new List<List<int>>() {
                new List<int> {5,3,4, 6,7,8, 9,1,2},
                new List<int> {6,9,2, 1,9,5, 3,4,8},
                new List<int> {1,9,8, 3,4,2, 5,6,7},

                new List<int> {8,5,9, 7,6,1, 4,2,3},
                new List<int> {4,2,6, 8,5,3, 7,9,1},
                new List<int> {7,1,3, 9,2,4, 8,5,6},

                new List<int> {9,6,1, 5,3,7, 2,8,4},
                new List<int> {2,8,7, 4,1,9, 6,3,5},
                new List<int> {3,4,5, 2,8,6, 1,7,9}
            };

            SudokuGrid sudokuGrid = new SudokuGrid()
            {
                IndexIterator = 0,
                Grid =gridData,
                ValidatorGrid = new Validator( gridData )
            };
            
            return View(sudokuGrid);
        }
    }
}