using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudukoValidator;

namespace SudokuValidation.Tests
{
    //
    // Test to verify Validator.
    //
    [TestClass]
    public class ValidatorTests
    {
        List<List<int>> _validGridOriginal = new List<List<int>>() {
                new List<int> {5,3,4, 6,7,8, 9,1,2},
                new List<int> {6,7,2, 1,9,5, 3,4,8},
                new List<int> {1,9,8, 3,4,2, 5,6,7},

                new List<int> {8,5,9, 7,6,1, 4,2,3},
                new List<int> {4,2,6, 8,5,3, 7,9,1},
                new List<int> {7,1,3, 9,2,4, 8,5,6},

                new List<int> {9,6,1, 5,3,7, 2,8,4},
                new List<int> {2,8,7, 4,1,9, 6,3,5},
                new List<int> {3,4,5, 2,8,6, 1,7,9}
            };
        List<List<int>> _notValidGridOriginal9x9Zeros = new List<List<int>>() {
                new List<int> {5,3,4, 6,7,8, 9,1,2},
                new List<int> {6,7,2, 1,9,0, 3,4,8},
                new List<int> {1,0,0, 3,4,2, 5,6,0},

                new List<int> {8,5,9, 7,6,1, 0,2,0},
                new List<int> {4,2,6, 8,5,3, 7,9,1},
                new List<int> {7,1,3, 9,2,4, 8,5,6},

                new List<int> {9,0,1, 5,3,7, 2,1,4},
                new List<int> {2,8,7, 4,1,9, 6,3,5},
                new List<int> {3,0,0, 4,8,1, 1,7,9}
            };

        List<List<int>> _notValidGridOriginalMissingRow1 = new List<List<int>>() {
                new List<int> {6,7,2, 1,9,5, 3,4,8},
                new List<int> {1,9,8, 3,4,2, 5,6,7},

                new List<int> {8,5,9, 7,6,1, 4,2,3},
                new List<int> {4,2,6, 8,5,3, 7,9,1},
                new List<int> {7,1,3, 9,2,4, 8,5,6},

                new List<int> {9,6,1, 5,3,7, 2,8,4},
                new List<int> {2,8,7, 4,1,9, 6,3,5},
                new List<int> {3,4,5, 2,8,6, 1,7,9}
            };

        List<List<int>> _notValidGridOriginalMissingCol1 = new List<List<int>>() {
                new List<int> {3,4, 6,7,8, 9,1,2},
                new List<int> {7,2, 1,9,5, 3,4,8},
                new List<int> {9,8, 3,4,2, 5,6,7},

                new List<int> {5,9, 7,6,1, 4,2,3},
                new List<int> {2,6, 8,5,3, 7,9,1},
                new List<int> {1,3, 9,2,4, 8,5,6},

                new List<int> {6,1, 5,3,7, 2,8,4},
                new List<int> {8,7, 4,1,9, 6,3,5},
                new List<int> {4,5, 2,8,6, 1,7,9}
            };

        // NOTE: THIS METHOD PROBABLY WILL NOT BE USED.
        //  ADDED LOGIC TO ROW AND COLUMN CHECKS THAT VALIDATE THE DATA.
        [TestMethod]
        public void TestAllGridDataValid()
        {
            List<List<int>> validValues1and9 = new List<List<int>>() {
                new List<int> {5,3,4, 6,7,8, 9,1,2},
                new List<int> {6,7,2, 1,9,5, 3,4,8},
                new List<int> {1,9,8, 3,4,2, 5,6,7}
            };

            List<List<int>> notValidRowContainsZero = new List<List<int>>() {
                new List<int> {3,0,0, 4,8,1, 1,7,9}
            };

            Validator validator = new Validator( validValues1and9 );
            Assert.IsTrue( validator.CheckGridValues( 1, 9 ) );

            validator = new Validator( notValidRowContainsZero );
            Assert.IsFalse( validator.CheckGridValues( 1, 9 ) );
        }

        [TestMethod]
        public void TestValidatorStringConstructor()
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

            Validator validator = new Validator( clientString );
 
            Assert.IsTrue( validator.IsGridSizeValid() );

            Assert.IsTrue( validator.IsRowValid( 0 ) );
            Assert.IsTrue( validator.IsRowValid( 1 ) );
            Assert.IsTrue( validator.IsRowValid( 2 ) );
            Assert.IsTrue( validator.IsRowValid( 3 ) );
            Assert.IsTrue( validator.IsRowValid( 4 ) );
            Assert.IsTrue( validator.IsRowValid( 5 ) );
            Assert.IsTrue( validator.IsRowValid( 6 ) );
            Assert.IsTrue( validator.IsRowValid( 7 ) );
            Assert.IsTrue( validator.IsRowValid( 8 ) );

            Assert.IsTrue( validator.IsColumnValid( 0 ) );
            Assert.IsTrue( validator.IsColumnValid( 1 ) );
            Assert.IsTrue( validator.IsColumnValid( 2 ) );
            Assert.IsTrue( validator.IsColumnValid( 3 ) );
            Assert.IsTrue( validator.IsColumnValid( 4 ) );
            Assert.IsTrue( validator.IsColumnValid( 5 ) );
            Assert.IsTrue( validator.IsColumnValid( 6 ) );
            Assert.IsTrue( validator.IsColumnValid( 7 ) );
            Assert.IsTrue( validator.IsColumnValid( 8 ) );

        }

        //
        // Check that Grid is an appropriate size
        //
        [TestMethod]
        public void TestCheckGridSize()
        {
            Validator validator = new Validator( _validGridOriginal );
            Assert.IsTrue( validator.IsGridSizeValid() );

            validator = new Validator( _notValidGridOriginal9x9Zeros );
            Assert.IsTrue( validator.IsGridSizeValid() );

            validator = new Validator( _notValidGridOriginalMissingRow1 );
            Assert.IsFalse( validator.IsGridSizeValid() );

            validator = new Validator( _notValidGridOriginalMissingCol1 );
            Assert.IsFalse( validator.IsGridSizeValid() );
        }

        //
        // Check All Rows are valid
        //
        [TestMethod]
        public void TestValideAllRows()
        {
            Validator validator = new Validator( _validGridOriginal );

            // Check each row of a valid grid
            Assert.IsTrue( validator.IsRowValid( 0 ), "Row 1 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 1 ), "Row 2 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 2 ), "Row 3 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 3 ), "Row 4 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 4 ), "Row 5 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 5 ), "Row 6 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 6 ), "Row 7 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 7 ), "Row 8 is not valid" );
            Assert.IsTrue( validator.IsRowValid( 8 ), "Row 9 is not valid" );

            // Check an invalid row, Number < 0
            validator = new Validator( _notValidGridOriginal9x9Zeros );
            Assert.IsFalse( validator.IsRowValid( 1 ), "Row 1 should be invalid." );

            List<List<int>> rowContainsAZero = new List<List<int>>() { new List<int>() { 1, 2, 3, 4, 5, 6, 0, 8, 9 } };
            List<List<int>> rowContainsATen = new List<List<int>>() { new List<int>() { 3, 2, 3, 4, 5, 6, 10, 8, 9 } };

            // Check an invalid row, Number < 0
            validator = new Validator( rowContainsAZero );
            Assert.IsFalse( validator.IsRowValid( 0 ), "A Row with value Zero must be false" );

            validator = new Validator( rowContainsATen );
            Assert.IsFalse( validator.IsRowValid( 0 ), "A Row with value Ten must be false" );
        }

        [TestMethod]
        public void TestValidateAllColumns()
        {
            Validator validator = new Validator( _validGridOriginal );
            // Check each column of a valid grid
            Assert.IsTrue( validator.IsColumnValid( 0 ), "Col 1 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 1 ), "Col 2 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 2 ), "Col 3 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 3 ), "Col 4 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 4 ), "Col 5 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 5 ), "Col 6 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 6 ), "Col 7 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 7 ), "Col 8 is not valid" );
            Assert.IsTrue( validator.IsColumnValid( 8 ), "Col 9 is not valid" );

            List<List<int>> columnContainsAZero = new List<List<int>>() { new List<int>() { 1, 0, 3, 4, 5, 6, 7, 8, 9 } };
            List<List<int>> columnContainsATen = new List<List<int>>() { new List<int>() { 1, 10, 3, 4, 5, 6, 7, 8, 9 } };

            validator = new Validator( columnContainsAZero );
            Assert.IsFalse( validator.IsColumnValid( 1 ), "Value Zero in column[1] should be false" );

            validator = new Validator( columnContainsATen );
            Assert.IsFalse( validator.IsColumnValid( 1 ), "Value Ten in column[1] should be false" );

            List<List<int>> invalidCol2 = new List<List<int>>() {
                new List<int> {5,3,4, 6,7,8, 9,1,2},
                new List<int> {6,7,2, 1,9,5, 3,4,8},
                new List<int> {1,7,8, 3,4,2, 5,6,7},

                new List<int> {8,5,9, 7,6,1, 4,2,3},
                new List<int> {4,2,6, 8,5,3, 7,9,1},
                new List<int> {7,1,3, 9,2,4, 8,5,6},

                new List<int> {9,6,1, 5,3,7, 2,8,4},
                new List<int> {2,8,7, 4,1,9, 6,3,5},
                new List<int> {3,4,5, 2,8,6, 1,7,9} };

            // Check on bad column in full size grid.
            validator = new Validator( invalidCol2 );
            bool v = validator.IsColumnValid( 1 );
            Assert.IsFalse( v );

        }

        [TestMethod]
        public void TestValidateAllBlocks()
        {


            List<List<int>> baseBlockOrigValid = new List<List<int>>() {
                new List<int>() {5,3,4, 6,7,8, 9,1,2},
                new List<int>() {6,7,2, 1,9,5, 3,4,8},
                new List<int>() {1,9,8, 3,4,2, 5,6,7},

                new List<int>() {8,5,9, 7,6,1, 4,2,3},
                new List<int>() {4,2,9, 8,5,3, 7,9,1},
                new List<int>() {7,1,3, 9,2,4, 8,5,6},

                new List<int>() {9,6,1, 5,3,7, 2,8,4},
                new List<int>() {2,8,7, 4,1,9, 6,3,5},
                new List<int>() {3,4,5, 2,8,6, 1,7,9}
            };

            Validator validator = new Validator( baseBlockOrigValid );
#region Col 1-2-3
            Assert.IsTrue( validator.IsBlockValid( 0, 0 ), "Block TopLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 1 ), "Block TopLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 2 ), "Block TopLeft should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 1, 0 ), "Block TopLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 1, 1 ), "Block TopLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 1, 2 ), "Block TopLeft should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 2, 0 ), "Block TopLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 2, 1 ), "Block TopLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 2, 2 ), "Block TopLeft should be valid" );


            Assert.IsFalse( validator.IsBlockValid( 3, 0 ), "Block MidLeft should be valid" );
            Assert.IsFalse( validator.IsBlockValid( 3, 1 ), "Block MidLeft  should be valid" );
            Assert.IsFalse( validator.IsBlockValid( 3, 2 ), "Block MidLeft  should be valid" );

            Assert.IsFalse( validator.IsBlockValid( 4, 0 ), "Block MidLeft  should be valid" );
            Assert.IsFalse( validator.IsBlockValid( 4, 1 ), "Block MidLeft  should be valid" );
            Assert.IsFalse( validator.IsBlockValid( 4, 2 ), "Block MidLeft  should be valid" );

            Assert.IsFalse( validator.IsBlockValid( 5, 0 ), "Block MidLeft  should be valid" );
            Assert.IsFalse( validator.IsBlockValid( 5, 1 ), "Block MidLeft  should be valid" );
            Assert.IsFalse( validator.IsBlockValid( 5, 2 ), "Block MidLeft  should be valid" );


            Assert.IsTrue( validator.IsBlockValid( 6, 0 ), "Block BotLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 1 ), "Block BotLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 2 ), "Block BotLeft should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 7, 0 ), "Block BotLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 7, 1 ), "Block BotLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 7, 2 ), "Block BotLeft should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 8, 0 ), "Block BotLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 8, 1 ), "Block BotLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 8, 2 ), "Block BotLeft should be valid" );
#endregion Col 1-2-3

#region Col 4-5-6
            Assert.IsTrue( validator.IsBlockValid( 0, 3 ), "Block TopMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 4 ), "Block TopMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 5 ), "Block TopMid should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 1, 3 ), "Block TopMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 1, 4 ), "Block TopMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 1, 5 ), "Block TopMid should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 2, 3 ), "Block TopMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 2, 4 ), "Block TopMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 2, 5 ), "Block TopMid should be valid" );


            Assert.IsTrue( validator.IsBlockValid( 3, 3 ), "Block MidMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 3, 4 ), "Block MidMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 3, 5 ), "Block MidMid should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 4, 3 ), "Block MidMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 4, 4 ), "Block MidMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 4, 5 ), "Block MidMid should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 5, 3 ), "Block MidMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 5, 4 ), "Block MidMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 5, 5 ), "Block MidMid should be valid" );


            Assert.IsTrue( validator.IsBlockValid( 6, 3 ), "Block BotMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 4 ), "Block BotMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 5 ), "Block BotMid should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 7, 3 ), "Block BotMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 7, 4 ), "Block BotMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 7, 5 ), "Block BotMid should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 8, 3 ), "Block BotMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 8, 4 ), "Block BotMid should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 8, 5 ), "Block BotMid should be valid" );
#endregion Col 4-5-6

#region Col 7-8-9
            Assert.IsTrue( validator.IsBlockValid( 0, 6 ), "Block TopRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 7 ), "Block TopRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 8 ), "Block TopRight should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 1, 6 ), "Block TopRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 1, 7 ), "Block TopRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 1, 8 ), "Block TopRight should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 2, 6 ), "Block TopRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 2, 7 ), "Block TopRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 2, 8 ), "Block TopRight should be valid" );


            Assert.IsTrue( validator.IsBlockValid( 3, 6 ), "Block MidRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 3, 7 ), "Block MidRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 3, 8 ), "Block MidRight should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 4, 6 ), "Block MidRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 4, 7 ), "Block MidRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 4, 8 ), "Block MidRight should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 5, 6 ), "Block MidRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 5, 7 ), "Block MidRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 5, 8 ), "Block MidRight should be valid" );


            Assert.IsTrue( validator.IsBlockValid( 6, 6 ), "Block BotRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 7 ), "Block BotRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 8 ), "Block BotRight should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 7, 6 ), "Block BotRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 7, 7 ), "Block BotRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 7, 8 ), "Block BotRight should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 8, 6 ), "Block BotRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 8, 7 ), "Block BotRight should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 8, 8 ), "Block BotRight should be valid" );
#endregion Col 7-8-9

        }

    }
}
