using System;
using System.Collections.Generic;

namespace SudukoValidator
{
    public class Validator
    {
        private List<List<int>> grid;

        public Validator( List<List<int>> _grid)
        {
            grid = _grid;
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
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="baseRow"></param>
        /// <param name="baseCol"></param>
        /// <param name="smallSquareSize"></param>
        /// <returns></returns>
        public bool IsBlockValid( int baseRow, int baseCol, int smallSquareSize )
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
            if ( val < 1 || val > 9 )
                return false;
            else
                return true;
        }

    }
}
