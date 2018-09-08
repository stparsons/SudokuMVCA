using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SudukoValidator;

namespace SudokuValidation.Models
{
    public class SudokuGrid
    {
        public int IndexIterator { get; set; }
        public List<List<int>> Grid { get; set; }
        public Validator ValidatorGrid { get; set; }
    }
}