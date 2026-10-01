// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Domain model class representing a microcontroller development board,
//                   together with the data annotations that define a valid board.

using System.ComponentModel.DataAnnotations;
using BoardAppDB.Infrastructure;

namespace BoardAppDB.Models
{
    public class Board
    {
        //
        // Name             : property string BoardCode
        // Purpose          : Public property giving access to the board code that identifies the board
        // Re-use           : None
        // Input Parameter  : string value
        //                    - new value for the board code
        // Output Type      : string
        //                    - the four-character code that identifies the board
        //
        [Key] // Indicates primary key
        [Required(ErrorMessage = "The board code is required.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "The board code must have a length of 4.")]
        [Display(Name = "Board code")]
        public string BoardCode { get; set; } // end property BoardCode

        //
        // Name             : property string Make
        // Purpose          : Public property giving access to the manufacturer of the board
        // Re-use           : None
        // Input Parameter  : string value
        //                    - new value for the manufacturer
        // Output Type      : string
        //                    - the manufacturer of the board
        //
        [Required(ErrorMessage = "The board manufacturer is required.")]
        [Display(Name = "Manufacturer")]
        public string Make { get; set; } // end property Make

        //
        // Name             : property string Model
        // Purpose          : Public property giving access to the model name of the board
        // Re-use           : None
        // Input Parameter  : string value
        //                    - new value for the model
        // Output Type      : string
        //                    - the model name given to the board by the manufacturer
        //
        [Required(ErrorMessage = "The board model is required.")]
        [Display(Name = "Model")]
        public string Model { get; set; } // end property Model

        //
        // Name             : property int? FlashKb
        // Purpose          : Public property giving access to the flash size of the board in kilobytes
        // Re-use           : None
        // Input Parameter  : int? value
        //                    - new value for the flash size in kilobytes
        // Output Type      : int?
        //                    - the amount of on-board flash memory in kilobytes
        //
        [VerifyFlashSize]
        [Required(ErrorMessage = "The flash size is required.")]
        // [Range(16, 4096, ErrorMessage = "The flash size must be between 16 and 4096 inclusive.")]
        [Display(Name = "Flash (KB)")]
        public int? FlashKb { get; set; } // end property FlashKb

        //
        // Name             : property decimal? Price
        // Purpose          : Public property giving access to the unit price of the board in rand
        // Re-use           : None
        // Input Parameter  : decimal? value
        //                    - new value for the price
        // Output Type      : decimal?
        //                    - the unit price of the board in rand
        //
        [Required(ErrorMessage = "The price is required.")]
        [Range(1.00, 5000.00, ErrorMessage = "The price must be between R1.00 and R5000.00 inclusive.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Price (R)")]
        public decimal? Price { get; set; } // end property Price

        public Board()
        {
            //
            // Name             : Board()
            // Purpose          : Default constructor used by the model binder to create an empty board
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : None
            //
        } // end method Board

        public Board(string boardCode, string make, string model, int flashKb, decimal price)
        {
            //
            // Name             : Board(string boardCode, string make, string model, int flashKb, decimal price)
            // Purpose          : Constructor that initialises a board with the supplied values
            // Re-use           : None
            // Method Parameters: string boardCode
            //                    - value for the board code
            //                    string make
            //                    - value for the manufacturer
            //                    string model
            //                    - value for the model
            //                    int flashKb
            //                    - value for the flash size in kilobytes
            //                    decimal price
            //                    - value for the price in rand
            // Output Type      : None
            //
            BoardCode = boardCode;
            Make = make;
            Model = model;
            FlashKb = flashKb;
            Price = price;
        } // end method Board

        public override string ToString()
        {
            //
            // Name             : string ToString()
            // Purpose          : Returns a string describing the board
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : string
            //                    - the board code, manufacturer, model, flash size and price as one string
            //
            return $"{BoardCode}: {Make} {Model} with {FlashKb} KB flash at R{Price:0.00}";
        } // end method ToString
    } // end class Board
} // end namespace BoardApp.Models
