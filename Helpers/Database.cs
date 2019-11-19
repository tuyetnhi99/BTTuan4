using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ProjectMVVM_Floweronline.Models;
using System.Linq;

namespace ProjectMVVM_Floweronline.Helpers
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public Database()
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder,"qlhoa.db")))
                {
                    connection.CreateTable<Loaihoa>();
                    connection.CreateTable<Hoa>();
                }
            }
            catch(SQLiteException ex)
            {
                
            }
        }
        public List<Loaihoa> GetLoaihoas()
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<Loaihoa>().ToList();
                }
            }
            catch(SQLiteException ex)
            {
                return null;
            }
        }
        public Loaihoa GetLoaihoaByid (int Maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var dsh = from lhs in connection.Table<Loaihoa>().ToList()
                              where lhs.Maloai == Maloai
                              select lhs
                              ;
                    return dsh.ToList<Loaihoa>().FirstOrDefault();
                }
            }
            catch(SQLiteException ex)
            {
                return null;
            }
        }
        public bool InsertLoaihoa(Loaihoa lh)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(lh);
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                return false;
            }
        }
        public bool UpdateLoaihoa (Loaihoa h)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Update(h);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool DeleteLoaihoa(Loaihoa h)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Delete(h);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
    }
}
