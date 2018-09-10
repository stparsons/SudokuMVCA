using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SudokuValidation.Models.ViewModels;
using System.Linq;
using System.Web;

namespace SudokuValidation.Models
{
    /// <summary>
    ///     Custom Validation of puzzle text entered.
    /// </summary>
    public class NewPuzzleCustomValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid( object value, ValidationContext validationContext )
        {
            var inputData = ( NewPuzzleFormViewModel ) validationContext.ObjectInstance;

            if( inputData == null || String.IsNullOrEmpty( inputData.PuzzleData ) )
            {
                return new ValidationResult( "Must have exactly 9 Rows and 9 Columns of numbers" );
            }

            var rows = inputData.PuzzleData.Trim().Split( "\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries );
            if ( rows.Length != 9 )
            {
                return new ValidationResult( "Must have exactly 9 Rows and 9 Columns of numbers" );
            }

            foreach ( var row in rows )
            {
                var cols = row.Trim().Split( ' ' );
                if ( cols.Length != 9 )
                {
                    return new ValidationResult( "Must have exactly 9 Columns of numbers" );
                }

                foreach ( var col in cols )
                {
                    int n;
                    if ( !int.TryParse( col, out n ) )
                    {
                        return new ValidationResult( "Must be numbers only between 1 and 9" );
                    }

                    if ( ( n < 1 || n > 9 ) )
                    {
                        return new ValidationResult( "Values can only be between 1 and 9" );
                    }
                }
            }

            return ValidationResult.Success;

        }
    }
}