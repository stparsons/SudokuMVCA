using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SudukoValidator;

namespace SudokuValidation.Models
{
    public class SudokuGrid
    {
        private const int _NineCol = 9;

        private int colIterator = 0;
        private int rowIterator = 0;

        public int IndexIterator { get; set; }

        public int RowIterator 
        {
            get { return rowIterator % _NineCol; }
            set { rowIterator = value; }
        }

       public int ColIterator
        {
            get { return colIterator % _NineCol; }
            set { colIterator = value; }
        }

        public List<List<int>> Grid { get; set; }
        public Validator ValidatorGrid { get; set; }
    }
}