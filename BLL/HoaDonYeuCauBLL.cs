using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonYeuCauBLL
    {
        private HoaDonYeuCauDAL hoaDonYeuCauDAL;

        public HoaDonYeuCauBLL()
        {
            hoaDonYeuCauDAL = new HoaDonYeuCauDAL();
        }

        public List<HoaDonYeuCauDTO> GetListHoaDon()
        {
            return hoaDonYeuCauDAL.GetListHoaDon();
        }
    }
}
