using System.Collections.Generic;
using System.Linq;

namespace BkmOdev.Models
{
    public static class Urunlervt
    {
        private static List<Urun> _urunlist;
        private static List<Kategori> _kategorilist;

        static Urunlervt()
        {
            _urunlist = new List<Urun>()
            {
                new Urun(){Id=1,Name="Lenovo",KategoriId=1},
                new Urun(){Id=2,Name="LenovoPc",KategoriId=2},
                new Urun(){Id=3,Name="LenovoMobil",KategoriId=3}
            };
            _kategorilist = new List<Kategori>()
            {
                new Kategori{ Id=1,Name="Laptop"},
                new Kategori{ Id=2,Name="Pc"},
                new Kategori{ Id=3,Name="Telefon"}
            };
        }
        public static List<Urun> Urunler
        {
            get { return _urunlist; }
        }

        public static List<Kategori> Kategoriler
        {
            get { return _kategorilist; }
        }
        public static void Add(Urun urun)
        {
            _urunlist.Add(urun);
        }
        public static void AddKategori(Kategori kategori)
        {
            _kategorilist.Add(kategori);
        }
        public static void Delete(Urun urun)
        {
            var urundelete = _urunlist.FirstOrDefault(x => x.Id == urun.Id);
            urundelete.IsDelete = true;
        }
        public static void DeleteKategori(Kategori kategori)
        {
            var kategoridelete = _kategorilist.FirstOrDefault(x => x.Id == kategori.Id);
            kategoridelete.IsDelete = true;
        }
        public static void Edit(Urun urun)
        {
            var urunEdit = _urunlist.FirstOrDefault(x => x.Id == urun.Id);
            urunEdit.Name = urun.Name;
            urunEdit.KategoriId = urun.KategoriId;
            urunEdit.IsDelete = urun.IsDelete;
        }
        public static void EditKategori(Kategori kategori)
        {
            var KategoriEdit = _kategorilist.FirstOrDefault(x => x.Id == kategori.Id);
            KategoriEdit.Name = kategori.Name;
            KategoriEdit.IsDelete = kategori.IsDelete;

        }
    }
}
