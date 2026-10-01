// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Custom validation attribute that restricts the flash size of a board
//                   to the list of valid flash sizes.

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BoardAppDB.Infrastructure
{
    public class VerifyFlashSizeAttribute : Attribute, IModelValidator
    {
        //
        // Name             : property bool IsRequired
        // Purpose          : Read-only property indicating that a value for the property is required
        // Re-use           : None
        // Input Parameter  : bool value
        //                    - read-only property; no value is assigned
        // Output Type      : bool
        //                    - always true
        //
        public bool IsRequired => true;

        //
        // Name             : property string ErrorMessage
        // Purpose          : Public property giving access to the message shown when the flash size is invalid
        // Re-use           : None
        // Input Parameter  : string value
        //                    - new value for the error message
        // Output Type      : string
        //                    - the message shown when the flash size is not a valid value
        //
        public string ErrorMessage { get; set; } = // end property ErrorMessage
            "Valid flash sizes in KB are: 16, 32, 64, 128, 256, 512, 1024, 2048, 4096";

        // Valid flash sizes in KB
        private readonly List<int> validFlashSizes = new List<int>
        {
            16, 32, 64, 128, 256, 512, 1024, 2048, 4096
        };

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            //
            // Name             : IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
            // Purpose          : Validates that the flash size is one of the valid flash sizes
            // Re-use           : None
            // Method Parameters: ModelValidationContext context
            //                    - the validation context carrying the value to validate
            // Output Type      : IEnumerable<ModelValidationResult>
            //                    - one validation result when the value is invalid, otherwise an empty collection
            //
            int? value = context.Model as int?;

            // Fail if null or not in the allowed set
            if (!value.HasValue || !validFlashSizes.Contains(value.Value))
            {
                return new List<ModelValidationResult>
                {
                    new ModelValidationResult("", ErrorMessage)
                };
            } // end if

            // Pass if valid
            return Enumerable.Empty<ModelValidationResult>();
        } // end method Validate
    } // end class VerifyFlashSizeAttribute
} // end namespace BoardApp.Infrastructure
