
// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;//
// Assignment nr   : Practical Assessment 2
// Purpose         : Repository class that implements the IBoard interface. Provides the
//                   retrieve, find, add, change, remove and existence operations on the
//                   Board table through the database context.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class BoardRepo : IBoard
    {
        private readonly BoardContext boardContext;

        public BoardRepo(BoardContext boardContext)
        {
            //
            // Name             : BoardRepo(BoardContext boardContext)
            // Purpose          : Constructor that stores the database context supplied by dependency injection
            // Re-use           : None
            // Method Parameters: BoardContext boardContext
            //                    - the database context supplied by the framework
            // Output Type      : None
            //
            this.boardContext = boardContext;
        } // end method BoardRepo

        public IEnumerable<Board> GetBoards()
        {
            //
            // Name             : IEnumerable<Board> GetBoards()
            // Purpose          : Retrieves all the boards in the database
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IEnumerable<Board>
            //                    - the boards in the database, ordered by board code
            //
            return boardContext.Boards.OrderBy(b => b.BoardCode).ToList();
        } // end method GetBoards

        public Board Details(string boardCode)
        {
            //
            // Name             : Board Details(string boardCode)
            // Purpose          : Retrieves the board that matches the given board code
            // Re-use           : None
            // Method Parameters: string boardCode
            //                    - the board code of the board to retrieve
            // Output Type      : Board
            //                    - the matching board, or null when no board has that board code
            //
            Board? board = boardContext.Boards.FirstOrDefault(b => b.BoardCode == boardCode);
            return board!;
        } // end method Details

        public Board Create(Board board)
        {
            //
            // Name             : Board Create(Board board)
            // Purpose          : Adds a new board to the database
            // Re-use           : None
            // Method Parameters: Board board
            //                    - the board to be added
            // Output Type      : Board
            //                    - the board that was added
            //
            boardContext.Boards.Add(board);
            boardContext.SaveChanges();
            return board;
        } // end method Create

        public Board Edit(Board board)
        {
            //
            // Name             : Board Edit(Board board)
            // Purpose          : Saves the changed values of an existing board to the database
            // Re-use           : None
            // Method Parameters: Board board
            //                    - the board carrying the changed values
            // Output Type      : Board
            //                    - the board that was changed
            //
            boardContext.Boards.Update(board);
            boardContext.SaveChanges();
            return board;
        } // end method Edit

        public bool Delete(Board board)
        {
            //
            // Name             : bool Delete(Board board)
            // Purpose          : Removes the board that matches the board code of the given board
            // Re-use           : None
            // Method Parameters: Board board
            //                    - the board to be removed
            // Output Type      : bool
            //                    - true if the board was removed, false otherwise
            //
            bool isDeleted = false;
            Board? existingBoard = boardContext.Boards.FirstOrDefault(b => b.BoardCode == board.BoardCode);

            if (existingBoard != null)
            {
                boardContext.Boards.Remove(existingBoard);
                boardContext.SaveChanges();
                isDeleted = true;
            } // end if

            return isDeleted;
        } // end method Delete

        public bool IsExist(string boardCode)
        {
            //
            // Name             : bool IsExist(string boardCode)
            // Purpose          : Checks whether a board with the given board code exists
            // Re-use           : None
            // Method Parameters: string boardCode
            //                    - the board code to check for
            // Output Type      : bool
            //                    - true if a board with the board code exists, false otherwise
            //
            return boardContext.Boards.Any(b => b.BoardCode == boardCode);
        } // end method IsExist
    } // end class BoardRepo
} // end namespace BoardAppDB.Repositories
