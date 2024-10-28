using Microsoft.AspNetCore.Mvc;
using ThucHanh2.Repository;

namespace ThucHanh2.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSpRepository;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSpRepository = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSps = _loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaiSps);
        }
    }
}
