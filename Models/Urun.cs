namespace BkmOdev.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; } = false;
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
