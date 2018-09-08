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
        }

        [TestMethod]
        public void TestValidateAllBlocks()
        {
             List<List<int>> baseBlockOrigValid = new List<List<int>>() {
                new List<int>() {5,3,4, 6,7,8, 9,1,2},
                new List<int>() {6,7,2, 1,9,5, 3,4,8},
                new List<int>() {1,9,8, 3,4,2, 5,6,7},

                new List<int>() {8,5,9, 7,6,1, 4,2,3},
                new List<int>() {4,2,6, 8,5,3, 7,9,1},
                new List<int>() {7,1,3, 9,2,4, 8,5,6},

                new List<int>() {9,6,1, 5,3,7, 2,8,4},
                new List<int>() {2,8,7, 4,1,9, 6,3,5},
                new List<int>() {3,4,5, 2,8,6, 1,7,9}
            };

            Validator validator = new Validator( baseBlockOrigValid );

            Assert.IsTrue( validator.IsBlockValid( 0, 0, 3 ), "Block TopLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 3, 3 ), "Block TopMiddle should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 0, 6, 3 ), "Block Topright should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 3, 0, 3 ), "Block MiddleLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 3, 3, 3 ), "Block MiddleMiddle should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 3, 6, 3 ), "Block MiddleRight should be valid" );

            Assert.IsTrue( validator.IsBlockValid( 6, 0, 3 ), "Block BottomLeft should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 3, 3 ), "Block BottomMiddle should be valid" );
            Assert.IsTrue( validator.IsBlockValid( 6, 6, 3 ), "Block BottomRight should be valid" );


            // Check for invalid values in Top Left Block
            int originalValue = 0;
            originalValue = baseBlockOrigValid [ 1 ] [ 1 ];
            baseBlockOrigValid [ 1 ] [ 1 ] = 0;
            validator = new Validator( baseBlockOrigValid );
            Assert.IsFalse( validator.IsBlockValid( 0, 0, 3 ), "Block TopLeft Should not be valid. It contains a zero" );

            baseBlockOrigValid [ 1 ] [ 1 ] = 10;
            validator = new Validator( baseBlockOrigValid );
            Assert.IsFalse( validator.IsBlockValid( 0, 0, 3 ), "Block TopLeft Should not be valid. It contains a ten" );


            // Check for Invalid Values in bottom left block
            baseBlockOrigValid [ 1 ] [ 1 ] = originalValue;
            originalValue = baseBlockOrigValid [ 7 ] [ 7 ];
            baseBlockOrigValid [ 7 ] [ 7 ] = 0;
            validator = new Validator( baseBlockOrigValid );
            Assert.IsFalse( validator.IsBlockValid( 6, 6, 3 ), "Block BottomRight Should not be valid. It contains a zero" );

            baseBlockOrigValid [ 7 ] [ 7 ] = 10;
            validator = new Validator( baseBlockOrigValid );
            Assert.IsFalse( validator.IsBlockValid( 6, 6, 3 ), "Block BottomRight Should not be valid. It contains a ten" );

        }

    }
}
