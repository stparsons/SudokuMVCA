﻿using System;
using System.Collections.Generic;

namespace SudukoValidator
{
    /// <summary>
    ///     Class used to validate a grid of data
    ///     Validates that data passed to constructor is vavlid
    ///     Then allows user to call helper methos to verify rows, colomns and blocks of data are 
    ///     acurate per the rules of Sudoku
    /// </summary>
    public class Validator
    {
        private const int _gridSize = 9;
        private List<List<int>> grid;

        /// <summary>
        ///     Load data with an existing grid
        /// </summary>
        /// <param name="_grid"></param>
        public Validator( List<List<int>> _grid)
        {
            grid = _grid;
        }

        /// <summary>
        ///     Load data using a string..
        ///     Validation exists in this method of the string
        ///     Is 9 x 9
        ///     Is all data numbers between 1 and 9
        /// </summary>
        /// <param name="input"></param>
        public Validator(string input)
        {
            grid = new List<List<int>>();
            var rows = input.Trim().Split( "\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries );
            if ( rows.Length == _gridSize )
            {
                foreach ( var row in rows )
                {
                    var cols = row.Trim().Split( ' ' );
                    List<int> gridRow = new List<int>();
                    if ( cols.Length == _gridSize )
                    {
                        foreach ( var col in cols )
                        {
                            int n;
                            if( int.TryParse( col, out n ) 
                                && (n >= 1 && n <= _gridSize))
                            { 
                                gridRow.Add( Convert.ToInt32( col ) );
                            }
                            else
                            {
                                throw new FormatException("Not all values are numbers between 1 and 9");
                            }
                        }
                    }
                    else
                    {
                        throw new FormatException( "Must be exactly 9 columns" );
                    }

                    grid.Add( gridRow );
                }
            }
            else
                throw new FormatException( "Must be exactly 9 rows" );
        }

        /// <summary>
        ///     Add ability to get the grid.
        ///     For today I realize you can update the list in a list.
        /// </summary>
        public List<List<int>> Grid
        {
            get { return grid; }
        }

        /// <summary>
        ///     High level method that will check the entier grid
        /// </summary>
        /// <returns></returns>
        public bool IsAllGridValid()
        {
            if( IsGridSizeValid()
                && IsRowValid( 0 ) && IsRowValid( 1 ) && IsRowValid( 2 ) && IsRowValid( 3 )
                && IsRowValid( 4 ) && IsRowValid( 5 ) && IsRowValid( 6 ) && IsRowValid( 7 ) && IsRowValid( 8 )
                && IsColumnValid( 0 ) && IsColumnValid( 1 ) && IsColumnValid( 2 ) && IsColumnValid( 3 )
                && IsColumnValid( 4 ) && IsColumnValid( 5 ) && IsColumnValid( 6 ) && IsColumnValid( 7 ) && IsColumnValid( 8 )
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        ///     Check validity of a row
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool IsRowValid( int row )
        {
            int colCt = grid [ row ].Count;
            bool [] exists = new bool [ colCt ];

            for ( int col = 0; col < colCt; ++col )
            {
                int index = grid [ row ] [ col ] - 1;
                if ( !isBetween1and9( grid [ row ] [ col ] ) )
                {
                    return false;
                }
                if ( !exists [ index ] )
                {
                    exists [ index ] = true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        ///     Check taht a column is valid.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="whichCol"></param>
        /// <returns></returns>
        public bool IsColumnValid( int whichCol )
        {
            int rowCt = grid.Count;
            bool [] exists = new bool [ rowCt ];

            for ( int row = 0; row < rowCt; ++row )
            {
                int index = grid [ row ] [ whichCol ] - 1;
                if ( !isBetween1and9( grid [ row ] [ whichCol ] ) )
                {
                    return false;
                }
                if ( !exists [ index ] )
                {
                    exists [ index ] = true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        ///     Check each block
        ///     User should pass the exact row/col index they are on
        ///     This routine will check the block.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="rowIndx"></param>
        /// <param name="colIndx"></param>
        /// <param name="smallSquareSize"></param>
        /// <returns></returns>
        public bool IsBlockValid( int rowIndx, int colIndx )
        {
            // figre the grid block size
            //  Using the index figure the top corner of each block
            //  Plug into the formula
            int smallSquareSize = 3;
            int baseRow = ( rowIndx / 3 ) * 3;
            int baseCol = ( colIndx / 3 ) * 3; 

            try
            {
                bool [] exists = new bool [ grid.Count ];

                for ( int row = baseRow; row < ( baseRow + smallSquareSize ); ++row )
                {
                    for ( int col = baseCol; col < ( baseCol + smallSquareSize ); ++col )
                    {
                        int index = grid [ row ] [ col ] - 1;

                        if ( !isBetween1and9( grid [ row ] [ col ] ) )
                        {
                            return false;
                        }
                        if ( !exists [ index ] )
                        {
                            exists [ index ] = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException( "Failed on - Row: " + baseRow + " Col: " + baseCol );
            }

            return true;
        }

        /// <summary>
        ///     Check the entire Grid to confirm it is a valid size
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool IsGridSizeValid( )
        {
            int size = grid.Count;
            for ( int subArr = 0; subArr < size; subArr++ )
            {
                if ( grid [ subArr ].Count != size )
                {
                    return false;
                }
            }

            if ( Math.Sqrt( ( double ) size ) % 1 != 0 )
            {
                return false;
            }

            return true;
        }


        /// <summary>
        ///     Chec the values of the grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public bool CheckGridValues( int min, int max )
        {
            for ( int row = 0; row < grid.Count; ++row )
            {
                for ( int col = 0; col < grid [ row ].Count; ++col )
                {
                    if ( grid [ row ] [ col ] < min || grid [ row ] [ col ] > max )
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     Check if value is between 1 and 9
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private bool isBetween1and9( int val )
        {
            if ( val < 1 || val > _gridSize )
                return false;
            else
                return true;
        }

    }
}
