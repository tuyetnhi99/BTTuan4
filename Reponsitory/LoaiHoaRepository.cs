using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using ProjectMVVM_Floweronline.Models;
using ProjectMVVM_Floweronline.Helpers;
using ProjectMVVM_Floweronline.Interface;

namespace ProjectMVVM_Floweronline.Reponsitory
{
    public class LoaiHoaRepository : ILoaihoaRepository
    {
        Database db;
        public LoaiHoaRepository()
        {
            db = new Database();
        }
        public bool Delete(Loaihoa h)
        {
            return db.DeleteLoaihoa(h);
        }
        public Loaihoa GetLoaihoaById(int Maloai)
        {
            return db.GetLoaihoaByid(Maloai);
        }
        public ObservableCollection<Loaihoa> GetLoaihoas()
        {
            return new ObservableCollection<Loaihoa>(db.GetLoaihoas());
        }
        public bool Insert (Loaihoa h)
        {
            return db.InsertLoaihoa(h);
        }
        public bool Update(Loaihoa h)
        {
            return db.UpdateLoaihoa(h);
        }
        
    }
}
