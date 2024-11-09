using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using System.IO;
using Syncfusion.XlsIO;
using System.Windows.Forms;
using DTO;
namespace GUI.Excel
{
    public class ExcelExportMonAn
    {
        private HangHoaBLL hangHoaBLL;
        public void ExportPhieuNhap(DateTime selectedDate, ref string filename, bool isPrintPreview)
        {
            hangHoaBLL = new HangHoaBLL();
            List<ThongKeMonDTO> tinhTongTien = hangHoaBLL.LayThongKeMon(selectedDate);
            int tongTien = 0;
            foreach (var item in tinhTongTien)
            {
                tongTien += item.ThanhTien.Value;
            }

            Dictionary<string, string> replacer = new Dictionary<string, string>();
            //DateTime ngayhientai = new DateTime();
            string ngay = "Ngày " + selectedDate.Day + " tháng " + selectedDate.Month + " năm " + selectedDate.Year;
            replacer.Add("%NgayThangNam", ngay);

            replacer.Add("%tongtien", tongTien.ToString("N0"));
            string TongTienBangChu = NumberToWords(tongTien);

            replacer.Add("%bangchu", TongTienBangChu);
            using (DbConnectDataContext context = new DbConnectDataContext())
            {

                // Đọc file Excel mẫu
                byte[] arrByte = File.ReadAllBytes("BaoCaoMonAn.xlsx");
                using (MemoryStream stream = new MemoryStream(arrByte))
                {
                    using (ExcelEngine engine = new ExcelEngine())
                    {
                        IWorkbook workbook = engine.Excel.Workbooks.Open(stream);
                        IWorksheet worksheet = workbook.Worksheets[0];

                        // Thay thế dữ liệu
                        foreach (KeyValuePair<string, string> item in replacer)
                        {
                            if (item.Value != null)
                            {
                                worksheet.Replace(item.Key, item.Value);
                            }
                        }
                        List<ThongKeMonDTO> danhSachThongKeMon = hangHoaBLL.LayThongKeMon(selectedDate);

                        List<ThongKeMonDTOExcel> cthd = new List<ThongKeMonDTOExcel>();

                        int stt = 1;
                       
                        foreach (ThongKeMonDTO item in danhSachThongKeMon)
                        {
                            ThongKeMonDTOExcel monAnItem = new ThongKeMonDTOExcel();
                            monAnItem.STT = stt;
                            stt++;
                            monAnItem.IDMon = item.IDMon;
                            monAnItem.TenMon = item.TenMon;
                            monAnItem.SoLuongBanDuoc = item.SoLuongBanDuoc;
                            monAnItem.GiaTien = item.GiaTien.Value.ToString("N0");
                            monAnItem.ThanhTien = item.ThanhTien.Value.ToString("N0");
                            
                            cthd.Add(monAnItem);
                        }
                     

                        string viewname = "MonAn";
                        var markProcess = worksheet.CreateTemplateMarkersProcessor();
                        markProcess.AddVariable(viewname, cthd);
                        markProcess.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

                        worksheet.Columns[5].NumberFormat = "#,##0";
                        worksheet.Columns[6].NumberFormat = "#,##0";
                        string TMP_ROW = "[TMP]";
                        IRange range = worksheet.FindFirst(TMP_ROW, ExcelFindType.Text);
                        if (range != null)
                        {
                            worksheet.DeleteRow(range.Row);
                        }

                        // Lưu file
                        string tempPath = Application.StartupPath;

                        string fileName = "Mon_Exported.xlsx";
                        string filePath = Path.Combine(tempPath, fileName);

                        filename = filePath;
                        MessageBox.Show("File đã lưu tại: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        workbook.SaveAs(filePath);


                        System.Diagnostics.Process.Start(filePath);

                    }
                }
            }
        }
        public void ExportPhieuNhapNoDate( ref string filename, bool isPrintPreview)
        {
            hangHoaBLL = new HangHoaBLL();
            List<ThongKeMonDTO> tinhTongTien = hangHoaBLL.LayThongKeMon();
            int tongTien = 0;
            foreach (var item in tinhTongTien)
            {
                tongTien += item.ThanhTien.Value;
            }

            Dictionary<string, string> replacer = new Dictionary<string, string>();
            DateTime ngayhientai = new DateTime();
            string ngay = "Ngày " + ngayhientai.Day + " tháng " + ngayhientai.Month + " năm " + ngayhientai.Year;
            replacer.Add("%NgayThangNam", ngay);
            string tongTienChuoi =  tongTien.ToString("N0");
            replacer.Add("%tongtien", tongTienChuoi);
            string TongTienBangChu = NumberToWords(tongTien);

            replacer.Add("%bangchu", TongTienBangChu);
            using (DbConnectDataContext context = new DbConnectDataContext())
            {

                // Đọc file Excel mẫu
                byte[] arrByte = File.ReadAllBytes("BaoCaoMonAn.xlsx");
                using (MemoryStream stream = new MemoryStream(arrByte))
                {
                    using (ExcelEngine engine = new ExcelEngine())
                    {
                        IWorkbook workbook = engine.Excel.Workbooks.Open(stream);
                        IWorksheet worksheet = workbook.Worksheets[0];

                        // Thay thế dữ liệu
                        foreach (KeyValuePair<string, string> item in replacer)
                        {
                            if (item.Value != null)
                            {
                                worksheet.Replace(item.Key, item.Value);
                            }
                        }
                        List<ThongKeMonDTO> danhSachThongKeMon = hangHoaBLL.LayThongKeMon();

                        List<ThongKeMonDTOExcel> cthd = new List<ThongKeMonDTOExcel>();

                        int stt = 1;

                        foreach (ThongKeMonDTO item in danhSachThongKeMon)
                        {
                            ThongKeMonDTOExcel monAnItem = new ThongKeMonDTOExcel();
                            monAnItem.STT = stt;
                            stt++;
                            monAnItem.IDMon = item.IDMon;
                            monAnItem.TenMon = item.TenMon;
                            monAnItem.SoLuongBanDuoc = item.SoLuongBanDuoc;
                            monAnItem.GiaTien = item.GiaTien.Value.ToString("N0");
                            monAnItem.ThanhTien = item.ThanhTien.Value.ToString("N0");

                            cthd.Add(monAnItem);
                        }


                        string viewname = "MonAn";
                        var markProcess = worksheet.CreateTemplateMarkersProcessor();
                        markProcess.AddVariable(viewname, cthd);
                        markProcess.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

                        worksheet.Columns[5].NumberFormat = "#,##0"; 
                        worksheet.Columns[6].NumberFormat = "#,##0";
                        string TMP_ROW = "[TMP]";
                        IRange range = worksheet.FindFirst(TMP_ROW, ExcelFindType.Text);
                        if (range != null)
                        {
                            worksheet.DeleteRow(range.Row);
                        }

                        // Lưu file
                        string tempPath = Application.StartupPath;

                        string fileName = "Mon_Exported.xlsx";
                        string filePath = Path.Combine(tempPath, fileName);

                        filename = filePath;
                        MessageBox.Show("File đã lưu tại: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        workbook.SaveAs(filePath);


                        System.Diagnostics.Process.Start(filePath);

                    }
                }
            }
        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "không";

            string[] unitsMap = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] tensMap = { "", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

            StringBuilder words = new StringBuilder();

            if (number / 1000000 > 0)
            {
                words.Append(NumberToWords(number / 1000000) + " triệu ");
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words.Append(NumberToWords(number / 1000) + " nghìn ");
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words.Append(NumberToWords(number / 100) + " trăm ");
                number %= 100;
            }

            if (number > 0)
            {
                if (words.Length > 0)
                    words.Append("lẻ ");

                if (number < 10)
                    words.Append(unitsMap[number]);
                else
                {
                    words.Append(tensMap[number / 10]);
                    if ((number % 10) > 0)
                        words.Append(" " + unitsMap[number % 10]);
                }
            }

            return words.ToString().Trim();
        }
    }
}
