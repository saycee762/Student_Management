// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Database context class that connects the application to the SQLite
//                   database and maps the Board entity to the Board table

using BoardAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardAppDB.Data
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options)
        {
            //
            // Name             : BoardContext(DbContextOptions<BoardContext> options)
            // Purpose          : Constructor that passes the options supplied by dependency injection
            //                    (provider and connection string) to the base class
            // Re-use           : DbContext(DbContextOptions)
            // Method Parameters: DbContextOptions<BoardContext> options
            //                    - the options supplied by the framework
            // Output Type      : None
            //
        } // end method BoardContext

        //
        // Name             : property DbSet<Board> Boards
        // Purpose          : Public property giving access to the set of boards stored in the Board table
        // Re-use           : None
        // Input Parameter  : DbSet<Board> value
        //                    - new value for the set of boards
        // Output Type      : DbSet<Board>
        //                    - the set of boards stored in the database
        //
        public DbSet<Board> Boards { get; set; } // end property Boards

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // Name             : void OnModelCreating(ModelBuilder modelBuilder)
            // Purpose          : Maps the Board entity to the Board table and stores the Price as a
            //                    double, because SQLite has no decimal type and would store text
            // Re-use           : OnModelCreating(ModelBuilder)
            // Method Parameters: ModelBuilder modelBuilder
            //                    - the builder used to configure the entity mapping
            // Output Type      : None
            //
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Board>().ToTable("Board");

            modelBuilder.Entity<Board>()
                .Property(b => b.Price)
                .HasConversion<double>();
        } // end method OnModelCreating
    } // end class BoardContext
} // end namespace BoardAppDB.Data
