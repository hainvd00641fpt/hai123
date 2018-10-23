using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Entity
{
    class SongModel
    {
        internal static void ADD(Song song)
        {
            using(SqliteConnection db =
                new SqliteConnection(DataAccess.SQL_COMMECTION_STRING))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO SongSong(name, thumbnail) VALUES (@name, @thumbnail);";
                insertCommand.Parameters.AddWithValue("@name", song.name);
                insertCommand.Parameters.AddWithValue("@thumbnail", song.thumbnail);
                //insertCommand.ExecuteReader();
                //throw new NotImplementedException();


            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
                new SqliteConnection("Filename=song1_manager.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}
