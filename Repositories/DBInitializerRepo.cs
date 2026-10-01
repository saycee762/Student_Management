// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu; 
// Assignment nr   : Practical Assessment 2
// Purpose         : Repository class that creates the SQLite database when it does not exist
//                   and seeds the Board table with the initial ten boards when it is empty.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class DBInitializerRepo : IDBInitializer
    {
        private readonly BoardContext boardContext;

        public DBInitializerRepo(BoardContext boardContext)
        {
            //
            // Name             : DBInitializerRepo(BoardContext boardContext)
            // Purpose          : Constructor that stores the database context supplied by dependency injection
            // Re-use           : None
            // Method Parameters: BoardContext boardContext
            //                    - the database context supplied by the framework
            // Output Type      : None
            //
            this.boardContext = boardContext;
        } // end method DBInitializerRepo

        public void Initialize()
        {
            //
            // Name             : void Initialize()
            // Purpose          : Creates the database if it does not exist and seeds the Board table
            //                    only when it is empty, so that restarting never duplicates the boards
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : None
            //
            boardContext.Database.EnsureCreated();

            if (!boardContext.Boards.Any())
            {
                var boards = new List<Board>()
                {
                    new Board("1001", "Espressif", "ESP32-WROOM-32", 4096, 129.00m),
                    new Board("1002", "Espressif", "ESP32-C3-MINI-1", 4096, 99.00m),
                    new Board("1003", "STMicroelectronics", "STM32F103C8T6", 64, 75.00m),
                    new Board("1004", "STMicroelectronics", "STM32F411CEU6", 512, 145.00m),
                    new Board("1005", "Microchip", "ATmega328P", 32, 89.00m),
                    new Board("1006", "Microchip", "ATmega2560", 256, 199.00m),
                    new Board("1007", "WCH", "CH32V003F4P6", 16, 29.00m),
                    new Board("1008", "Raspberry Pi", "Pico", 2048, 89.00m),
                    new Board("1009", "Espressif", "ESP-01S", 1024, 65.00m),
                    new Board("1010", "CUTfree", "CV32-BFN-01", 128, 49.00m)
                };

                boardContext.Boards.AddRange(boards);
                boardContext.SaveChanges();
            } // end if
        } // end method Initialize
    } // end class DBInitializerRepo
} // end namespace BoardAppDB.Repositories
