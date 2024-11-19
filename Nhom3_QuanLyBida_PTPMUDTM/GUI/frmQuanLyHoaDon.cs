using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DTO;
using System.Globalization;
namespace GUI
{
    public partial class frmQuanLyHoaDon : Form
    {
        private HoaDonBLL hoaDonBLL;
        private int selectedMaHDBH = -1;
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            hoaDonBLL = new HoaDonBLL();
            LoadHoaDon();
            LoadComboBoxDatCoc();
            LoadComboBoxBan();
            LoadComboBoxNhanVien();
        }
        private void UpdateDataGridView()
        {
            string maBan = cbBan.SelectedIndex != -1 ? cbBan.SelectedValue.ToString() : null;
            string maNhanVien = cbNhanVien.SelectedIndex != -1 ? cbNhanVien.SelectedValue.ToString() : null;
            bool? datCoc = null;
            if (cbDatcoc.SelectedIndex == 0)
            {
                datCoc = true;
            }
            else if (cbDatcoc.SelectedIndex == 1)
            {
                datCoc = false;
            }
            DateTime? ngayChoi = dateNgayChoi.Checked ? (DateTime?)dateNgayChoi.Value.Date : null;
            if (maBan == null && maNhanVien == null && datCoc == null && dateNgayChoi.Checked == false)
            {
                LoadHoaDon();
                return;
            }
            var danhSachHoaDon = hoaDonBLL.LayHoaDonLoc(maBan, maNhanVien, datCoc, ngayChoi);
            dataGridViewHoaDon.DataSource = danhSachHoaDon.ToList();
        }
        private void LoadHoaDon()
        {
            var danhSachHoaDon = hoaDonBLL.LayHoaDonHienThi();
            dataGridViewHoaDon.DataSource = danhSachHoaDon.ToList();
        }
        private void LoadComboBoxBan()
        {
            var danhSachBan = hoaDonBLL.LayDanhSachBan();
            cbBan.DataSource = danhSachBan.ToList();
            cbBan.DisplayMember = "TenBan";
            cbBan.ValueMember = "MaBan";
            cbBan.SelectedIndex = -1;
            cbBan.Text = "Tên bàn";
        }
        private void LoadComboBoxNhanVien()
        {
            var danhSachNhanVien = hoaDonBLL.LayDanhSachNhanVien();
            cbNhanVien.DataSource = danhSachNhanVien.ToList();
            cbNhanVien.DisplayMember = "TenNV";
            cbNhanVien.ValueMember = "MaNV";
            cbNhanVien.SelectedIndex = -1;
            cbNhanVien.Text = "Tên nhân viên";
        }
        private void LoadComboBoxDatCoc()
        {
            var danhSachDatCoc = new List<string> { "Có đặt cọc", "Không đặt cọc" };
            cbDatcoc.DataSource = danhSachDatCoc;
            cbDatcoc.SelectedIndex = -1;
            cbDatcoc.Text = "Đặt cọc";
        }
     

        private void ExportInvoiceToPdf(int maHDBH)
        {
            List<ChiTietHoaDonDTO> chiTietHoaDon = hoaDonBLL.LayChiTietHoaDon(maHDBH);
            var hoaDon = hoaDonBLL.LayHoaDon(maHDBH);

            if (hoaDon == null)
            {
                MessageBox.Show("Không tìm thấy hoá đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Document pdfDoc = new Document(PageSize.A4, 50, 50, 25, 25);
            string filePath = "Invoice_" + maHDBH + ".pdf";
            CultureInfo vietnamCulture = new CultureInfo("vi-VN");
            try
            {
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var titleFont = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD);
                var regularFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                // Title
                pdfDoc.Add(new Paragraph("BIDA TÂN PHÚ", titleFont) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("\n"));
                // Title
                pdfDoc.Add(new Paragraph("HÓA ĐƠN", titleFont) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("\n"));

                // Invoice Info
                pdfDoc.Add(new Paragraph("ID: " + hoaDon.MaHDBH, regularFont) { Alignment = Element.ALIGN_RIGHT });
                pdfDoc.Add(new Paragraph("Ngày xuất HĐ: " + (hoaDon.NgayXuatHD.HasValue ? hoaDon.NgayXuatHD.Value.ToString("dd/MM/yyyy") : "N/A"), regularFont) { Alignment = Element.ALIGN_RIGHT });
                pdfDoc.Add(new Paragraph("\n"));
                pdfDoc.Add(new Paragraph("\n"));
                pdfDoc.Add(new Paragraph("Mã KH: " + hoaDon.MaKH, regularFont));
                pdfDoc.Add(new Paragraph("Thời gian vào: " + hoaDon.ThoiGianVao, regularFont));
                pdfDoc.Add(new Paragraph("Thời gian ra: " + hoaDon.ThoiGianRa, regularFont));
                // Tính số giờ chơi
                if (hoaDon.ThoiGianVao.HasValue && hoaDon.ThoiGianRa.HasValue)
                {
                    var soGioChoi = (hoaDon.ThoiGianRa.Value - hoaDon.ThoiGianVao.Value).TotalHours;
                    pdfDoc.Add(new Paragraph("Số giờ chơi: " + Math.Round(soGioChoi, 2) + " tiếng", regularFont));
                }
                // Kiểm tra tiền đặt cọc
                pdfDoc.Add(new Paragraph("Đặt cọc: " + (hoaDon.TienDatCoc.HasValue && hoaDon.TienDatCoc > 0 ? "Có" : "Không"), regularFont));

                pdfDoc.Add(new Paragraph(
                   "Số tiền đặt cọc: " +
                   (hoaDon.TienDatCoc.HasValue ? hoaDon.TienDatCoc.Value.ToString("#,###", vietnamCulture) + " đ" : "N/A"),
                   regularFont));

                pdfDoc.Add(new Paragraph("\n"));
                pdfDoc.Add(new Paragraph("\n"));
                // Invoice items table
                PdfPTable table = new PdfPTable(5) { WidthPercentage = 100 };
                table.SetWidths(new float[] { 10f, 40f, 20f, 20f, 20f });

                // Table headers
                AddCellToHeader(table, "ID", regularFont);
                AddCellToHeader(table, "Tên dịch vụ", regularFont);
                AddCellToHeader(table, "Giá", regularFont);
                AddCellToHeader(table, "Số lượng", regularFont);
                AddCellToHeader(table, "Thành tiền", regularFont);

                // Table rows
                foreach (ChiTietHoaDonDTO detail in chiTietHoaDon)
                {
                    AddCellToBody(table, detail.ID.ToString(), regularFont);
                    AddCellToBody(table, detail.TenDichVu, regularFont);
                    AddCellToBody(table, detail.Gia.ToString(), regularFont);
                    AddCellToBody(table, detail.SoLuong.ToString(), regularFont);
                    AddCellToBody(table, detail.ThanhTien.ToString(), regularFont);
                }

                pdfDoc.Add(table);
                pdfDoc.Add(new Paragraph("\n"));
                pdfDoc.Add(new Paragraph("\n"));


                PdfPTable summaryTable = new PdfPTable(2);
                summaryTable.WidthPercentage = 100;
                summaryTable.SetWidths(new float[] { 86f, 14f });

                // Thêm ô "Giảm giá"
                PdfPCell discountLabelCell = new PdfPCell(new Phrase("Giảm giá:", regularFont));
                discountLabelCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                discountLabelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                summaryTable.AddCell(discountLabelCell);

                PdfPCell discountValueCell = new PdfPCell(new Phrase(
                    hoaDon.GiamGia.HasValue ? hoaDon.GiamGia.Value.ToString("#,### đ", vietnamCulture) : "N/A",
                    regularFont));
                discountValueCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                discountValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                summaryTable.AddCell(discountValueCell);

                // Thêm ô "Tổng tiền"
                PdfPCell totalLabelCell = new PdfPCell(new Phrase("Tổng tiền:", regularFont));
                totalLabelCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                totalLabelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                summaryTable.AddCell(totalLabelCell);

                PdfPCell totalValueCell = new PdfPCell(new Phrase(
                    hoaDon.TongTien.HasValue ? hoaDon.TongTien.Value.ToString("#,### đ", vietnamCulture) : "N/A",
                    regularFont));
                totalValueCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                totalValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                summaryTable.AddCell(totalValueCell);

                // Thêm bảng vào tài liệu PDF
                pdfDoc.Add(summaryTable);
                MessageBox.Show("PDF Invoice created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (File.Exists(filePath))
                {
                    // Mở file PDF sau khi lưu
                    System.Diagnostics.Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("Không thể mở file PDF. File không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pdfDoc.Close();
            }
        }


        private void AddCellToHeader(PdfPTable table, string text, iTextSharp.text.Font font)
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = BaseColor.LIGHT_GRAY
            };
            table.AddCell(cell);
        }

        private void AddCellToBody(PdfPTable table, string text, iTextSharp.text.Font font)
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5
            };
            table.AddCell(cell);
        }

        private void cbNhanVien_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void cbDatcoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void cbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

     

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xuất ra PDF.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int maHDBH = int.Parse(dataGridViewHoaDon.SelectedRows[0].Cells["ID"].Value.ToString());
                ExportInvoiceToPdf(maHDBH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            cbBan.SelectedIndex = -1;
            cbNhanVien.SelectedIndex = -1;
            cbDatcoc.SelectedIndex = -1;
            cbDatcoc.Text = "Đặt cọc";
            cbNhanVien.Text = "Tên nhân viên";
            cbBan.Text = "Tên bàn";
            dateNgayChoi.Value = DateTime.Now;
            dateNgayChoi.Checked = false;
            LoadHoaDon();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedMaHDBH != -1)
            {
                var result = hoaDonBLL.XoaHoaDon(selectedMaHDBH);
                if (result)
                {
                    MessageBox.Show("Xóa hóa đơn thành công.");

                    LoadHoaDon();
                    selectedMaHDBH = -1;
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedMaHDBH != -1)
            {
                diglogChiTietHoaDon chiTietHoaDonForm = new diglogChiTietHoaDon(selectedMaHDBH);
                chiTietHoaDonForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.");
            }
        }

        private void dataGridViewHoaDon_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridViewHoaDon.SelectedRows.Count > 0)
            {

                selectedMaHDBH = Convert.ToInt32(dataGridViewHoaDon.SelectedRows[0].Cells["ID"].Value);
            }
        }

        private void dateNgayChoi_ValueChanged(object sender, EventArgs e)
        {
            //UpdateDataGridView();
        }

        private void dataGridViewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
