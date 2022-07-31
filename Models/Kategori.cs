using System.Collections.Generic;

namespace BkmOdev.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; } = false;
        public List<Urun> Urun { get; set; }//değişen

    }
}
