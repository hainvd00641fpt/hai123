using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Entity
{
    class DataAccess
    {
        public static String SQL_COMMECTION_STRING = "Filename=song1_manager.db";

        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename = song1_manager.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS SongSong (id INTEGER PRIMARY KEY, " +
                    "NAME NVARCHAR(50), THUMBNAIL NVARCHAR(50))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }
}
