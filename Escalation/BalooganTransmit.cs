using LinqToDB;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.MySql;
using LinqToDB.Mapping;
using System;
using System.Linq;

namespace AutoBaloogan
{
    public partial class baloogan_chatDB : LinqToDB.Data.DataConnection
    {
        private baloogan_chatDB(IDataProvider provider, string conn)
            : base(provider, conn)
        {
        }

        public static baloogan_chatDB connect()
        {
            return new baloogan_chatDB(new MySqlDataProvider(), System.IO.File.ReadAllText(@"C:\AutoBalooganConfig\autobaloogan_connectionstring.txt"));
        }
        
        public static void transmit(string channel, string message)
        {

            if (Environment.MachineName.ToUpper() != "STONEBURNER")
            {
                    try
                    {
                        using (var autobaloogan_db = AutoBaloogan.baloogan_chatDB.connect())
                        {
                            var t = new AutoBaloogan.Transmit()
                            {
                                Channel = channel,
                                Message = message
                            };
                            autobaloogan_db.Insert(t);
                        }
                    }
                    catch (Exception e)
                    {

                    }
                
            }
        }
        public static void transmit_thread(string channel, string message)
        {

        }
    }

    public partial class baloogan_chatDB : LinqToDB.Data.DataConnection
    {
        public ITable<Transmit> Transmits { get { return this.GetTable<Transmit>(); } }
    }

    [Table("Transmit")]
    public partial class Transmit
    {
        [PrimaryKey, Identity]
        public int ID { get; set; } // int(11)

        [Column, NotNull]
        public string Channel { get; set; } // text

        [Column, NotNull]
        public string Message { get; set; } // text
    }

    public static partial class TableExtensions
    {
        public static Transmit Find(this ITable<Transmit> table, int ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }
    }
}