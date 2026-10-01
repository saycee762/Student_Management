// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Interface that defines the contract for the operations on Board objects
//                   (retrieve, view, add, change, delete and existence check).

using BoardAppDB.Models;


namespace BoardAppDB.Interfaces
{
    public interface IBoard
    {
        //
        // Name             : IEnumerable<Board> GetBoards()
        // Purpose          : Retrieves a collection of boards
        // Re-use           : None
        // Method Parameters: None
        // Output Type      : IEnumerable<Board>
        //                    - the collection of boards
        //
        IEnumerable<Board> GetBoards(); // end method GetBoards

        //
        // Name             : Board Details(string boardCode)
        // Purpose          : Retrieves the details of a board based on its board code
        // Re-use           : None
        // Method Parameters: string boardCode
        //                    - the unique board code of the board to retrieve details for
        // Output Type      : Board
        //                    - the board with the given board code
        //
        Board Details(string boardCode); // end method Details

        //
        // Name             : Board Create(Board board)
        // Purpose          : Creates a new board entry
        // Re-use           : None
        // Method Parameters: Board board
        //                    - the Board object representing the new board to be created
        // Output Type      : Board
        //                    - the board that was created
        //
        Board Create(Board board); // end method Create

        //
        // Name             : Board Edit(Board board)
        // Purpose          : Edits an existing board entry
        // Re-use           : None
        // Method Parameters: Board board
        //                    - the Board object representing the modified board
        // Output Type      : Board
        //                    - the board that was modified
        //
        Board Edit(Board board); // end method Edit

        //
        // Name             : bool Delete(Board board)
        // Purpose          : Deletes an existing board entry
        // Re-use           : None
        // Method Parameters: Board board
        //                    - the Board object representing the board to be deleted
        // Output Type      : bool
        //                    - true if the deletion was successful, false otherwise
        //
        bool Delete(Board board); // end method Delete

        //
        // Name             : bool IsExist(string boardCode)
        // Purpose          : Checks if a board with the specified board code exists
        // Re-use           : None
        // Method Parameters: string boardCode
        //                    - the board code to check for existence
        // Output Type      : bool
        //                    - true if a board with the given board code exists, false otherwise
        //
        bool IsExist(string boardCode); // end method IsExist
    } // end interface IBoard
} // end namespace BoardAppDB.Interfaces
