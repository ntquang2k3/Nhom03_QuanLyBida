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
    public class ExcelExport
    {
        private BangThongKeBLL bangThongKeBLL;
        public void ExportPhieuNhap(int month, ref string filename, bool isPrintPreview)
        {
            bangThongKeBLL = new BangThongKeBLL();
            List<bangthongke> tinhTongTien = bangThongKeBLL.LayBangThongKeTheoThang(month);
            int tongTien = 0;
            foreach (var item in tinhTongTien)
            {
                tongTien += item.DoanhThu.Value;
            }

            Dictionary<string, string> replacer = new Dictionary<string, string>();
            DateTime ngayhientai = new DateTime();
            string ngay = "Ngày " + ngayhientai.Day + " tháng " + ngayhientai.Month + " năm " + ngayhientai.Year;
            replacer.Add("%NgayThangNam", ngay);
            replacer.Add("%thang", month.ToString());
            replacer.Add("%tongtien", tongTien.ToString());
            string TongTienBangChu = NumberToWords(tongTien);

            replacer.Add("%bangchu", TongTienBangChu);
            using (DbConnectDataContext context = new DbConnectDataContext())
            {
               
                // Đọc file Excel mẫu
                byte[] arrByte = File.ReadAllBytes("DoanhThuThang.xlsx");
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
                       
                        List<bangthongke> thongkethang = bangThongKeBLL.LayBangThongKeTheoThang(month);
                        List<ThongKeThang> cthd = new List<ThongKeThang>();

                        int stt = 1;
                      
                        foreach (bangthongke item in thongkethang)
                        {
                            ThongKeThang thangItem = new ThongKeThang();
                            thangItem.STT = stt;
                            stt++;
                            thangItem.NgayXuatHD = item.NgayXuatHD;
                            thangItem.TongDoanhThu = item.DoanhThu;               
                            cthd.Add(thangItem);
                        }

                       
                        string viewname = "ThongKe";
                        var markProcess = worksheet.CreateTemplateMarkersProcessor();
                        markProcess.AddVariable(viewname, cthd);
                        markProcess.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

                       
                        worksheet.Columns[3].NumberFormat = "#,##0";
                        string TMP_ROW = "[TMP]";
                        IRange range = worksheet.FindFirst(TMP_ROW, ExcelFindType.Text);
                        if (range != null)
                        {
                            worksheet.DeleteRow(range.Row);
                        }

                        // Lưu file
                        string tempPath = Application.StartupPath;

                        string fileName = "ThongKe_Exported.xlsx";
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
