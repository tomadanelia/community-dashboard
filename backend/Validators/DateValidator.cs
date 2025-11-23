using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
namespace backend.Validators
{
    public class FutureDateAttribute :ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime dt)
           
                return dt >= DateTime.Today;
            return false;
            }
            
        }
 }

