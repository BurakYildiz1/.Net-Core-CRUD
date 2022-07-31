using BkmOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BkmOdev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult List()
        {
            UrunKategoriModel model = new UrunKategoriModel();
            model.Uruns = Urunlervt.Urunler.Where(x=>x.IsDelete==false).ToList();
            model.Kategoris = Urunlervt.Kategoriler;
            return View(model);
        }
        public IActionResult ListUrun(int Id)
        {
            UrunKategoriModel model = new UrunKategoriModel();
            model.Uruns = Urunlervt.Urunler.Where(x => x.KategoriId == Id).ToList();
            model.Kategoris = Urunlervt.Kategoriler;
            return View(model);
        }
        public IActionResult ListKategoriler()
        {
            UrunKategoriModel model = new UrunKategoriModel();
            model.Uruns = Urunlervt.Urunler;
            model.Kategoris = Urunlervt.Kategoriler.Where(x => x.IsDelete == false).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Urun urun)
        {
            UrunKategoriModel model = new UrunKategoriModel();
            model.Uruns = Urunlervt.Urunler;
            model.Kategoris = Urunlervt.Kategoriler;

            var urunkontrol = Urunlervt.Urunler.FirstOrDefault(x => x.Name == urun.Name);
            if (urunkontrol == null)//yeni gelen ürün adı veri tabanında yoksa kaydını yap 
            {
                Urunlervt.Add(urun);
                ViewBag.mesaj = "Ürün ekleme başarılı";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.mesaj = "Ürün ekleme başarısız, bu ürün sistemde kayıtlı";
            }
            return View(model);
        }

        public IActionResult CreateKategori()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateKategori(Kategori kategori)
        {
            var urunkategori = Urunlervt.Urunler.FirstOrDefault(x => x.Name == kategori.Name);
            if (urunkategori == null)//yeni gelen kategori adı veri tabanında yoksa kaydını yap 
            {
                Urunlervt.AddKategori(kategori);
                ViewBag.mesajKategori = "Kategori ekleme başarılı";
                return RedirectToAction("ListKategoriler");
            }
            else
            {
                ViewBag.mesajKategori = "Kategori ekleme başarısız, bu ürün sistemde kayıtlı";
            }
            return View();
        }
        public IActionResult Delete(int Id)
        {
            var urun = Urunlervt.Urunler.FirstOrDefault(x => x.Id == Id);
            if (urun != null)
            {
                urun.IsDelete = true;
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult DeleteKategori(int Id)
        {
            var kategori = Urunlervt.Kategoriler.FirstOrDefault(x => x.Id == Id);
            if (kategori != null)
            {
                kategori.IsDelete = true;
            }
            return RedirectToAction("ListKategoriler");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var urun = Urunlervt.Urunler.FirstOrDefault(x => x.Id == Id);
            if (urun == null)
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else return View(urun);
        }
        [HttpPost]
        public IActionResult Edit(Urun urun)
        {
            Urunlervt.Edit(urun);
            var edituser = Urunlervt.Urunler.FirstOrDefault(x => x.Id == urun.Id);
            return RedirectToAction("list");//~/Admin/Edit/2
        }

        [HttpGet]
        public IActionResult EditKategori(int Id)
        {
            var kategori = Urunlervt.Kategoriler.FirstOrDefault(x => x.Id == Id);
            if (kategori == null)
            {
                return RedirectToAction("listKategoriler");
            }
            else return View(kategori);
        }
        [HttpPost]
        public IActionResult EditKategori(Kategori kategori)
        {
            Urunlervt.EditKategori(kategori);
            var kategoriuser = Urunlervt.Kategoriler.FirstOrDefault(x => x.Id == kategori.Id);
            return RedirectToAction("listKategoriler");
        }

    }
}
