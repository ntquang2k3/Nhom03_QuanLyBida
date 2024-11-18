using System;
using System.Collections.Generic;
using System.Linq;



namespace DAL
{
    public class ChiTIetNiemYetDAL
    {
        private DbConnectDataContext dbContext = new DbConnectDataContext();
        public List<ChiTietNiemYetBan> GetListChiTIetNiemYet()
        {
            return dbContext.ChiTietNiemYetBans.ToList();
        }
        public bool AddChiTietNiemYet(ChiTietNiemYetBan chiTietNY)
        {
            try
            {
                dbContext.ChiTietNiemYetBans.InsertOnSubmit(chiTietNY);
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCTNiemYet(string maBan)
        {
            try
            {
                // Tìm đối tượng HANGHOA dựa vào maHH
                var chiTietNY = dbContext.ChiTietNiemYetBans.SingleOrDefault(hh => hh.MaBan == maBan);
                if (chiTietNY != null)
                {
                    dbContext.ChiTietNiemYetBans.DeleteOnSubmit(chiTietNY);
                    dbContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết Niêm Yết: " + ex.Message);
                return false;
            }
        }
        public bool UpdateCTNiemYet(ChiTietNiemYetBan updateCTTietNY)
        {
            try
            {
                if (updateCTTietNY == null)
                {
                    return false;
                }

                // Kiểm tra xem MaBan có tồn tại trong bảng Ban khôn

                // Kiểm tra xem MaBan mới có trùng với MaBan cũ hay không (tránh vi phạm khóa chính)
                var chiTietNiemYet = dbContext.ChiTietNiemYetBans
                                              .FirstOrDefault(hh => hh.MaNiemYet == updateCTTietNY.MaNiemYet && hh.MaBan == updateCTTietNY.MaBan);

                if (chiTietNiemYet != null)
                {
                    // Cập nhật các trường cần thay đổi
                    chiTietNiemYet.GiaTri = updateCTTietNY.GiaTri; // Chỉnh sửa giá trị

                    // Lưu thay đổi vào cơ sở dữ liệu
                    dbContext.SubmitChanges();  // Dùng SaveChanges() nếu dùng Entity Framework
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy bản ghi để cập nhật.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết niêm yết: " + ex.Message);
                return false;
            }
        }




        public List<ChiTietNiemYetBan> SearchChiTietNiemYetByMaNY(string maNY)
        {
            try
            {
                if (string.IsNullOrEmpty(maNY))
                {
                    return new List<ChiTietNiemYetBan>();
                }

              
                var chiTietNY = dbContext.ChiTietNiemYetBans
                                         .Where(ct => ct.MaNiemYet == maNY)
                                         .ToList();

                return chiTietNY;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn chi tiết niêm yết: " + ex.Message);
            }
        }

    }



}

