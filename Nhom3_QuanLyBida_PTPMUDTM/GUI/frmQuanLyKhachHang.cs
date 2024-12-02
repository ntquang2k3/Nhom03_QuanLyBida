using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQuanLyKhachHang : Form
    {
        KhachHangBLL khachHangBLL = new KhachHangBLL();
        LoaiKhachHangBLL loaiKhachHangBLL = new LoaiKhachHangBLL();
        HoaDonBLL hoaDonBLL = new HoaDonBLL();
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
            this.Load += FrmQuanLyKhachHang_Load;
            dgvKhachHang.SelectionChanged += DgvKhachHang_SelectionChanged;
            this.btnLamMoi.Click += BtnLamMoi_Click;
            this.btnThem.Click += BtnThem_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnLuu.Click += BtnLuu_Click;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ComboBox đã có giá trị chưa
                if (cbbLoaiKhachHang.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn loại khách hàng.");
                    return;
                }

                string maKH = txtMaKH.Text;
                string tenKH = txtTenKH.Text;
                string maLoaiKH = cbbLoaiKhachHang.SelectedValue.ToString();
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSDT.Text;

                if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(tenKH) ||
                    string.IsNullOrEmpty(maLoaiKH) || string.IsNullOrEmpty(diaChi) ||
                    string.IsNullOrEmpty(soDienThoai) )
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.");
                    return;
                }
               

                if (!int.TryParse(txtDiemTL.Text, out int diemTL) || diemTL < 0)
                {
                    MessageBox.Show("Điểm tích lũy không hợp lệ.");
                    return;
                }

                int hoatDong = int.Parse(cbbHoatDong.SelectedValue.ToString());

                KHACHHANG newKhachHang = new KHACHHANG
                {
                    MaKH = maKH,
                    MaLKH = maLoaiKH,
                    TenKH = tenKH,
                    DiaChi = diaChi,
                    DiemTichLuy = diemTL,
                    SDT = soDienThoai,
                   // MatKhau = "123",
                    HoatDong = hoatDong
                };

                bool isSuccess = khachHangBLL.UpdateKhachHang(newKhachHang);

                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật thành công!"); 
                    btnLamMoi.Enabled = false;
                    loadDSKhachHang();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật khách hàng. Vui lòng kiểm tra dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaKH.Enabled = false;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtMaKH.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khách hàng với mã '{maKH}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = khachHangBLL.DeleteKhachHang(maKH);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên này: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtMaKH.Text;
                string tenKH = txtTenKH.Text;
                string maLoaiKH = cbbLoaiKhachHang.SelectedValue.ToString();
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSDT.Text;

               if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(maLoaiKH) ||
                    string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai) )

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.");
                    return;
                }
                if (!int.TryParse(txtDiemTL.Text, out int diemTL) || diemTL < 0)
                {
                    MessageBox.Show("Điểm tích không hợp lệ!");
                    return;
                }

                int hoatDong = int.Parse(cbbHoatDong.SelectedValue.ToString());
                
                KHACHHANG newKhacHang = new KHACHHANG

                {
                    MaKH = maKH,
                    MaLKH = maLoaiKH,
                    TenKH = tenKH,
                    DiaChi = diaChi,
                    DiemTichLuy = diemTL,
                    SDT = soDienThoai,
                    MatKhau = "123",
                    HoatDong = hoatDong

                };


                bool isSuccess = khachHangBLL.AddKhachHang(newKhacHang);

                if (isSuccess)
                {
                    MessageBox.Show("Nhân viên đã được thêm thành công!");
                    loadDSKhachHang();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm nhân viên");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiemTL.Clear();
            txtDiaChi.Clear();
            loadComboBoxLoaiKH();

            loadCbbHoatDong();
            txtMaKH.Enabled = true;
        }

        private void DgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvKhachHang.CurrentRow;
                txtMaKH.Text = currentRow.Cells["MaKH"].Value?.ToString();
                txtTenKH.Text = currentRow.Cells["TenKH"].Value?.ToString();
                cbbLoaiKhachHang.SelectedValue = currentRow.Cells["MaLKH"].Value?.ToString();
                txtDiemTL.Text = currentRow.Cells["DiemTL"].Value?.ToString();
                txtDiaChi.Text = currentRow.Cells["DiaChi"].Value?.ToString();
                txtSDT.Text = currentRow.Cells["SDT"].Value?.ToString();
                string hoatDong = currentRow.Cells["HoatDong"].Value?.ToString();
                if (hoatDong == "1")
                {
                    cbbHoatDong.SelectedValue = 1;
                }
                else
                {
                    cbbHoatDong.SelectedValue = 0;
                }
                loadDSHoaDon(txtMaKH.Text);

            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            loadDSKhachHang();
            loadCbbHoatDong();
            loadComboBoxLoaiKH();
            btnLuu.Enabled = false;
        }

        private void loadCbbHoatDong()
        {
            try
            {

                var danhSachTrangThai = new List<object>
                {
                    new { MaHoatDong = 1, TenHoatDong = "Hoạt động" },
                    new { MaHoatDong = 0, TenHoatDong = "Không hoạt động" }
                };

                cbbHoatDong.DataSource = danhSachTrangThai;
                cbbHoatDong.ValueMember = "MaHoatDong";
                cbbHoatDong.DisplayMember = "TenHoatDong";
                cbbHoatDong.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Bàn: " + ex.Message);
            }
        }

        private void loadComboBoxLoaiKH()
        {
            try
            {
                List<LOAIKH> dsLoaiKH = loaiKhachHangBLL.LayDanhSachLoaiKhachHang();
                if (dsLoaiKH != null && dsLoaiKH.Count > 0)
                {
                    cbbLoaiKhachHang.DataSource = null; 
                    cbbLoaiKhachHang.DataSource = dsLoaiKH;
                    cbbLoaiKhachHang.ValueMember = "MaLKH";
                    cbbLoaiKhachHang.DisplayMember = "TenLKH";
                }
                else
                {
                    cbbLoaiKhachHang.DataSource = null; 
                    MessageBox.Show("Không có loại khách hàng nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại khách: " + ex.Message);
            }
        }



        private void loadDSHoaDon(string maHoaDon)
        {
            dgvHoaDon.DataSource = null;
            try
            {
                List<HOADON> dsHoaDon = hoaDonBLL.GetHoaDonByMaKH(maHoaDon);

                if (dsHoaDon != null && dsHoaDon.Count > 0)
                {
                    var dsHoaDonViewModel = from pn in dsHoaDon
                                             select new
                                             {
                                                 MaHDBH = pn.MaHDBH,
                                                 MaNV = pn.NHANVIEN != null ? pn.NHANVIEN.MaNV : string.Empty,
                                                 MaBan = pn.BAN != null ? pn.BAN.MaBan : string.Empty,
                                                 NgayXuatHD = pn.NgayXuatHD,
                                                 TongTien = pn.TongTien,
                                                 DiemTL = pn.DiemTL,
                                                 GiamGia = pn.GiamGia,
                                                 MaKH = pn.KHACHHANG != null ? pn.KHACHHANG.MaKH : string.Empty,
                                                 SoTienThanhToan = pn.SoTienThanhToan,
                                                 ThoiGianVao = pn.ThoiGianVao,
                                                 ThoiGianRa = pn.ThoiGianRa,
                                                 ThoiGianDatCoc = pn.ThoiGianDatCoc,
                                                 TienDatCoc = pn.TienDatCoc,
                                                 ThoiGianKTDatCoc = pn.ThoiGianKTDatCoc,
                                                 SoPhutTreToiDa = pn.SoPhutTreToiDa,
                                             };
                    dgvHoaDon.DataSource = dsHoaDonViewModel.ToList();
                    dgvHoaDon.Columns["MaHDBH"].HeaderText = "Mã hóa đơn";
                    dgvHoaDon.Columns["MaNV"].HeaderText = "Mã nhân viên";
                    dgvHoaDon.Columns["MaBan"].HeaderText = "Mã bàn";
                    dgvHoaDon.Columns["NgayXuatHD"].HeaderText = "Ngày xuất hóa đơn";
                    dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";

                    dgvHoaDon.Columns["DiemTL"].HeaderText = "Điểm tích lũy";
                    dgvHoaDon.Columns["GiamGia"].HeaderText = "Giảm giá";
                    dgvHoaDon.Columns["SoTienThanhToan"].HeaderText = "Số tiền thanh toán";
                    dgvHoaDon.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
                    dgvHoaDon.Columns["ThoiGianRa"].HeaderText = "Thời gian ra";

                    dgvHoaDon.Columns["ThoiGianDatCoc"].HeaderText = "Thời gian đặt cọc";
                    dgvHoaDon.Columns["TienDatCoc"].HeaderText = "Tiền đặt cọc";
                    dgvHoaDon.Columns["ThoiGianKTDatCoc"].HeaderText = "Thời gian kết thúc đặt cọc";
                    dgvHoaDon.Columns["MaKH"].Visible = false;
                    dgvHoaDon.Columns["SoPhutTreToiDa"].HeaderText = "Số phút trễ tối đa";

                    foreach (DataGridViewColumn column in dgvHoaDon.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvHoaDon.RowPostPaint += dgv_RowPostPaint;
                }
                else
                {

                    MessageBox.Show("Không tìm thấy chi tiết phiếu nhập nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void loadDSKhachHang()
        {
            dgvKhachHang.DataSource = null;
            try
            {

                List<KHACHHANG> dsKhachHang = khachHangBLL.LayDanhSachKhachHang();
                if (dsKhachHang != null && dsKhachHang.Count > 0)
                {
                    var dsKhachHangViewModel = from pn in dsKhachHang
                                             select new
                                             {
                                                 MaKH = pn.MaKH,
                                                 MaLKH = pn.LOAIKH != null ? pn.LOAIKH.MaLKH : string.Empty,
                                                 TenKH = pn.TenKH,
                                                 DiaChi = pn.DiaChi,
                                                 SDT = pn.SDT,
                                                 DiemTL = pn.DiemTichLuy,
                                                 MatKhau = pn.MatKhau,
                                                 HoatDong = pn.HoatDong
                                                 
                                             };
                    dgvKhachHang.DataSource = dsKhachHangViewModel.ToList();
                    dgvKhachHang.Columns["MaKH"].HeaderText = "Mã khách hàng";
                    dgvKhachHang.Columns["MaLKH"].HeaderText = "Mã loại khách hàng";
                    dgvKhachHang.Columns["TenKH"].HeaderText = "Tên khách hàng";
                    dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvKhachHang.Columns["SDT"].HeaderText = "Số điện thoại";
                    dgvKhachHang.Columns["DiemTL"].HeaderText = "Điểm tích lũy";
                    dgvKhachHang.Columns["MatKhau"].Visible = false;

                    dgvKhachHang.Columns["HoatDong"].HeaderText = "Hoạt động";

                    // Căn giữa tiêu đề cột và chỉnh font chữ
                    foreach (DataGridViewColumn column in dgvKhachHang.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    foreach (DataGridViewRow row in dgvKhachHang.Rows)
                    {

                        var cellValue = row.Cells["HoatDong"].Value;
                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int hoatDong))
                        {
                            if (hoatDong == 0)
                            {
                                row.DefaultCellStyle.BackColor = Color.LightPink;
                            }
                        }
                    }
                    dgvKhachHang.RowPostPaint += dgv_RowPostPaint;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập nào.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();

            System.Drawing.Font rowFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            var leftFormat = new System.Drawing.StringFormat()
            {
                Alignment = System.Drawing.StringAlignment.Near,
                LineAlignment = System.Drawing.StringAlignment.Center
            };

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.Columns[0].Width, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, rowFont, System.Drawing.SystemBrushes.ControlText, headerBounds, leftFormat);
        }

        private void txtDiemTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHoatDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
