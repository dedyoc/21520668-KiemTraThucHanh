using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThucHanh2.Models;
using ThucHanh2.ViewModels;
using X.PagedList;

namespace ThucHanh2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QuanLyEcommerceContext db = new QuanLyEcommerceContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);   
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(sp => sp.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);

            return View(lst);
        }

        public IActionResult SanPhamTheoLoai(string maLoai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page??1;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().Where(sp => sp.MaLoai == maLoai).OrderBy(sp => sp.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            ViewBag.maloai = maLoai;
            return View(lst);
        }

        public IActionResult ChiTietSanPham(string maSp)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(sp => sp.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(sp => sp.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }

        public IActionResult ProductDetail(string maSp)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(sp => sp.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(sp => sp.MaSp == maSp).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel
            {
                danhMucSp=sanPham,
                anhSp=anhSanPham,
            };
            return View(homeProductDetailViewModel);
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
    }
}
