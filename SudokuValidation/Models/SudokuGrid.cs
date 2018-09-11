using System.Collections.Generic;
using SudukoValidator;

namespace SudokuValidation.Models
{
    /// <summary>
    ///     Model data to support a Sudoku Grid
    /// </summary>
    public class SudokuGrid
    {
        public string Message { get; set; }
        public int IndexIterator { get; set; }
        public List<List<int>> Grid { get; set; }
        public Validator ValidatorGrid { get; set; }
    }
}