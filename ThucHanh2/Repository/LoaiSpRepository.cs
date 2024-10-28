using ThucHanh2.Models;

namespace ThucHanh2.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QuanLyEcommerceContext _context;
        public LoaiSpRepository(QuanLyEcommerceContext context)
        {
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp? Delete(string maLoaiSp)
        {
            TLoaiSp? loaiSp = _context.TLoaiSps.Find(maLoaiSp);
            if (loaiSp != null)
            {
                _context.TLoaiSps.Remove(loaiSp);
                _context.SaveChanges();
            }
            return loaiSp;
        }

        public TLoaiSp? Get(string maLoaiSp)
        {
            return _context.TLoaiSps.Find(maLoaiSp);
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
