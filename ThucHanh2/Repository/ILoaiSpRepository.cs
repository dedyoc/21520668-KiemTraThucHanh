using ThucHanh2.Models;

namespace ThucHanh2.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp? Delete(string maLoaiSp);
        TLoaiSp? Get(string maLoaiSp);
        IEnumerable<TLoaiSp> GetAllLoaiSp();    
    }
}
