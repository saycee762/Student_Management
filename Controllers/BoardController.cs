// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Controller class that handles all requests to list, view, add,
//                   change and delete Board objects. The repository is received through
//                   constructor injection.

using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoard boardRepo;

        public BoardController(IBoard boardRepo)
        {
            //
            // Name             : BoardController(IBoard boardRepo)
            // Purpose          : Constructor that stores the board repository supplied by dependency injection
            // Re-use           : None
            // Method Parameters: IBoard boardRepo
            //                    - the board repository supplied by the framework
            // Output Type      : None
            //
            this.boardRepo = boardRepo;
        } // end method BoardController

        public IActionResult Index()
        {
            //
            // Name             : IActionResult Index()
            // Purpose          : Returns the Index view with the current list of boards
            // Re-use           : GetBoards()
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the Index view with the collection of boards
            //
            return View(boardRepo.GetBoards());
        } // end method Index

        public IActionResult Details(string boardCode)
        {
            //
            // Name             : IActionResult Details(string boardCode)
            // Purpose          : Returns the Details view for the board with the given board code
            // Re-use           : Details()
            // Method Parameters: string boardCode
            //                    - the board code of the board to be displayed
            // Output Type      : IActionResult
            //                    - the Details view with the selected board
            //
            return View(boardRepo.Details(boardCode));
        } // end method Details

        [HttpGet]
        public IActionResult Create()
        {
            //
            // Name             : IActionResult Create()
            // Purpose          : Returns the empty Create view and makes the Add button visible
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the Create view
            //
            ViewBag.ShowAdd = true;
            return View();
        } // end method Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BoardCode,Make,Model,FlashKb,Price")] Board board)
        {
            //
            // Name             : IActionResult Create(Board board)
            // Purpose          : Adds the captured board to the database when it passes validation
            //                    and its board code is not already in use
            // Re-use           : IsExist(), Create()
            // Method Parameters: Board board
            //                    - the board captured on the form (only the bound properties)
            // Output Type      : IActionResult
            //                    - the Create view with the captured board
            //
            ViewBag.ShowAdd = true;

            if (ModelState.IsValid)
            {
                if (boardRepo.IsExist(board.BoardCode))
                {
                    ModelState.AddModelError("BoardCode", "A board with that board code already exists.");
                }
                else
                {
                    boardRepo.Create(board);
                    ViewBag.SuccessMessage = $"Board {board.BoardCode} was added.";
                    ViewBag.ShowAdd = false;
                } // end if
            } // end if

            return View(board);
        } // end method Create

        [HttpGet]
        public IActionResult Edit(string boardCode)
        {
            //
            // Name             : IActionResult Edit(string boardCode)
            // Purpose          : Returns the Edit view for the board with the given board code
            //                    and makes the Save button visible
            // Re-use           : Details()
            // Method Parameters: string boardCode
            //                    - the board code of the board to be changed
            // Output Type      : IActionResult
            //                    - the Edit view with the selected board
            //
            ViewBag.ShowSave = true;
            return View(boardRepo.Details(boardCode));
        } // end method Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string boardCode, [Bind("BoardCode,Make,Model,FlashKb,Price")] Board board)
        {
            //
            // Name             : IActionResult Edit(string boardCode, Board board)
            // Purpose          : Saves the changed board to the database when it passes validation
            // Re-use           : Edit()
            // Method Parameters: string boardCode
            //                    - the board code of the board that was changed
            //                    Board board
            //                    - the board carrying the changed values (only the bound properties)
            // Output Type      : IActionResult
            //                    - the Edit view with the changed board
            //
            ViewBag.ShowSave = true;

            if (ModelState.IsValid)
            {
                boardRepo.Edit(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was updated.";
                ViewBag.ShowSave = false;
            } // end if

            return View(board);
        } // end method Edit

        [HttpGet]
        public IActionResult Delete(string boardCode)
        {
            //
            // Name             : IActionResult Delete(string boardCode)
            // Purpose          : Returns the Delete view for the board with the given board code
            //                    and makes the Delete button visible
            // Re-use           : Details()
            // Method Parameters: string boardCode
            //                    - the board code of the board to be deleted
            // Output Type      : IActionResult
            //                    - the Delete view with the selected board
            //
            ViewBag.ShowDelete = true;
            return View(boardRepo.Details(boardCode));
        } // end method Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string boardCode, Board board)
        {
            //
            // Name             : IActionResult Delete(string boardCode, Board board)
            // Purpose          : Removes the board from the database, only when the board code was found
            // Re-use           : Details(), Delete()
            // Method Parameters: string boardCode
            //                    - the board code of the board to be deleted
            //                    Board board
            //                    - the posted board; its values are not used, the board is re-read
            //                      from the repository
            // Output Type      : IActionResult
            //                    - the Delete view with the deleted board
            //
            Board? existingBoard = boardRepo.Details(boardCode);
            ViewBag.ShowDelete = true;

            if (existingBoard != null && boardRepo.Delete(existingBoard))
            {
                ViewBag.SuccessMessage = $"Board {existingBoard.BoardCode} was deleted.";
                ViewBag.ShowDelete = false;
            } // end if

            return View(existingBoard);
        } // end method Delete
    } // end class BoardController
} // end namespace BoardAppDB.Controllers
