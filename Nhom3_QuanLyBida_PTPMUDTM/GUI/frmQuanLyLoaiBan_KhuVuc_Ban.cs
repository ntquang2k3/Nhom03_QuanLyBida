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
    public partial class frmQuanLyLoaiBan_KhuVuc_Ban : Form
    {
        LoaiBanBLL loaiBanBLL = new LoaiBanBLL();
        KhuVucBLL khuVucBLL = new KhuVucBLL();
        BanBLL banBLL = new BanBLL();
        public frmQuanLyLoaiBan_KhuVuc_Ban()
        {
            InitializeComponent();
            this.Load += FrmQuanLyLoaiBan_KhuVuc_Ban_Load;
            dgvLoaiBan.SelectionChanged += DgvLoaiBan_SelectionChanged;
            dgvKhuVuc.SelectionChanged += DgvKhuVuc_SelectionChanged;
            dgvBan.SelectionChanged += DgvBan_SelectionChanged;

            this.btnClearLoai.Click += BtnClearLoai_Click;
            this.btnThemLoai.Click += BtnThemLoai_Click;
            this.btnXoaLoai.Click += BtnXoaLoai_Click;
            this.btnSuaLoai.Click += BtnSuaLoai_Click;
            this.btnLuuLoai.Click += BtnLuuLoai_Click;


            this.btnClearKhuVuc.Click += BtnClearKhuVuc_Click;
            this.btnThemKhuVuc.Click += BtnThemKhuVuc_Click;
            this.btnXoaKhuVuc.Click += BtnXoaKhuVuc_Click;
            this.btnSuaKhuVuc.Click += BtnSuaKhuVuc_Click;
            this.btnLuuKhuVuc.Click += BtnLuuKhuVuc_Click;


            this.btnClearBan.Click += BtnClearBan_Click;
            this.btnThemBan.Click += BtnThemBan_Click;
            this.btnXoaBan.Click += BtnXoaBan_Click;
            this.btnSuaBan.Click += BtnSuaBan_Click;
            this.btnLuuBan.Click += BtnLuuBan_Click;
        }

        private void BtnLuuBan_Click(object sender, EventArgs e)
        {
            try
            {
                string maBan = txtMaBan.Text;
                string tenBan = txtTenBan.Text;
                string trangThai = txtTrangThai.Text;
                string maKV = txtMaKV.Text;
                if (string.IsNullOrEmpty(maBan) || string.IsNullOrEmpty(tenBan) || string.IsNullOrEmpty(trangThai) || string.IsNullOrEmpty(maKV))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Bàn.");
                    return;
                }
                BAN newBan = new BAN
                {
                    MaBan = maBan,
                    MaKV = maKV,
                    TenBan = tenBan,
                    TrangThai = trangThai

                };
                bool isSuccess = banBLL.UpdateBan(newBan);
                if (isSuccess)
                {
                    MessageBox.Show("Bàn mới đã được thêm thành công!");
                    loadDSBanTheoKhuVuc(maKV);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Bàn. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSuaBan_Click(object sender, EventArgs e)
        {
            btnLuuBan.Enabled = true;
            txtMaBan.Enabled = false;
        }

        private void BtnXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                string maBan = txtMaBan.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa Bàn với mã '{maBan}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = banBLL.DeleteBan(maBan);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa Bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSLoaiBan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa Bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThemBan_Click(object sender, EventArgs e)
        {
            try
            {
                string maBan = txtMaBan.Text;
                string tenBan = txtTenBan.Text;
                string trangThai = txtTrangThai.Text;
                string maKV = txtMaKV.Text;
                if (string.IsNullOrEmpty(maBan) || string.IsNullOrEmpty(tenBan) || string.IsNullOrEmpty(trangThai) || string.IsNullOrEmpty(maKV))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Bàn.");
                    return;
                }
                BAN newBan = new BAN
                {
                    MaBan = maBan,
                    MaKV = maKV,
                    TenBan = tenBan,
                    TrangThai = trangThai
                    
                };
                bool isSuccess = banBLL.AddBan(newBan);
                if (isSuccess)
                {
                    MessageBox.Show("Bàn mới đã được thêm thành công!");
                    loadDSBanTheoKhuVuc(maKV);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Bàn. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearBan_Click(object sender, EventArgs e)
        {
            txtMaBan.Clear();
            txtTenBan.Clear();
            txtTrangThai.Clear();
        }

        private void DgvBan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBan.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvBan.CurrentRow;
                txtMaBan.Text = currentRow.Cells["MaBan"].Value?.ToString();
                txtTenBan.Text = currentRow.Cells["TenBan"].Value?.ToString();
                txtTrangThai.Text = currentRow.Cells["TrangThai"].Value?.ToString();
            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void loadDSBanTheoKhuVuc(string  maKhuVuc)
        {
            dgvBan.DataSource = null;
            try
            {
                List<BAN> dsBan = banBLL.GetBanByMaKhuVuc(maKhuVuc);

                if (dsBan != null && dsBan.Count > 0)
                {
                    var dsBanViewModel = from pn in dsBan
                                            select new
                                            {
                                                MaBan = pn.MaBan,
                                                TenBan = pn.TenBan,
                                                TrangThai = pn.TrangThai,
                                                MaKV = pn.KHUVUC != null ? pn.KHUVUC.MaKV : string.Empty
                                            };
                    dgvBan.DataSource = dsBanViewModel.ToList();
                    dgvBan.Columns["MaBan"].HeaderText = "Mã bàn";
                    dgvBan.Columns["TenBan"].HeaderText = "Tên bàn";
                    dgvBan.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvBan.Columns["MaKV"].Visible = false;

                    foreach (DataGridViewColumn column in dgvKhuVuc.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvKhuVuc.RowPostPaint += dgv_RowPostPaint;
                }
                else
                {

                    MessageBox.Show("Không tìm thấy khu vực nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void BtnLuuKhuVuc_Click(object sender, EventArgs e)
        {
            try
            {

                string maKV = txtMaKV.Text;
                string tenKV = txtTenKhuVuc.Text;
                string giaGioChoi = txtGiaGioChoi.Text;
                if (string.IsNullOrEmpty(maKV) || string.IsNullOrEmpty(tenKV) || string.IsNullOrEmpty(giaGioChoi))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khu vực.");
                    return;
                }
                if (!int.TryParse(txtLoaiBan.Text, out int maLoaiBan) || maLoaiBan <= 0)
                {
                    MessageBox.Show("Mã loại không hợp lệ!");
                    return;
                }
                if (!int.TryParse(txtGiaTien.Text, out int gia) || gia <= 0)
                {
                    MessageBox.Show("Giá không không hợp lệ!");
                    return;
                }
                KHUVUC newKhuVuc = new KHUVUC
                {
                    MaKV = maKV,
                    TenKV = tenKV,
                    GiaTien = gia,
                    MaLoaiBan = maLoaiBan,
                };


                bool isSuccess = khuVucBLL.UpdateKhuVuc(newKhuVuc);

                if (isSuccess)
                {
                    MessageBox.Show("Khu vực mới đã được cập nhật thành công!");
                    loadDSKhuVucTheoLoaiBan(maLoaiBan);
                    btnLuuKhuVuc.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật khu vực. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearKhuVuc_Click(object sender, EventArgs e)
        {
           txtTenKhuVuc.Clear();
            txtGiaTien.Clear();
            txtMaKV.Clear();
        }

        private void DgvKhuVuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhuVuc.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvKhuVuc.CurrentRow;
                txtMaKV.Text = currentRow.Cells["MaKV"].Value?.ToString();
                txtTenKhuVuc.Text = currentRow.Cells["TenKV"].Value?.ToString();
                txtGiaTien.Text = currentRow.Cells["GiaTien"].Value?.ToString();
                //int maLoai = int.Parse(txtLoaiBan.Text);
                loadDSBanTheoKhuVuc(txtMaKV.Text);

            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void BtnSuaKhuVuc_Click(object sender, EventArgs e)
        {
           btnLuuKhuVuc.Enabled = true;
            txtMaKV.Enabled = false;
        }

        private void BtnXoaKhuVuc_Click(object sender, EventArgs e)
        {
            try
            {
                string maKV = txtMaKV.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khu vực với mã '{maKV}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = khuVucBLL.DeleteKhuVuc(maKV);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa khu vực thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSLoaiBan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa khu vực: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThemKhuVuc_Click(object sender, EventArgs e)
        {
            try
            {

                string maKV = txtMaKV.Text;
                string tenKV = txtTenKhuVuc.Text;
                string giaGioChoi = txtGiaGioChoi.Text;
                if (string.IsNullOrEmpty(maKV) || string.IsNullOrEmpty(tenKV) || string.IsNullOrEmpty(giaGioChoi))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khu vực.");
                    return;
                }
                if (!int.TryParse(txtLoaiBan.Text, out int maLoaiBan) || maLoaiBan <= 0)
                {
                    MessageBox.Show("Mã loại không hợp lệ!");
                    return;
                }
                if (!int.TryParse(txtGiaTien.Text, out int gia) || gia <= 0)
                {
                    MessageBox.Show("Giá không không hợp lệ!");
                    return;
                }
                KHUVUC newKhuVuc = new KHUVUC
                {
                    MaKV = maKV,
                    TenKV = tenKV,
                    GiaTien = gia,
                    MaLoaiBan = maLoaiBan,
                };


                bool isSuccess = khuVucBLL.AddKhuVuc(newKhuVuc);

                if (isSuccess)
                {
                    MessageBox.Show("Khu vực mới đã được thêm thành công!");
                    loadDSKhuVucTheoLoaiBan(maLoaiBan);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm khu vực. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnLuuLoai_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = txtLoaiBan.Text;
                string tenLoai = txtTenLoai.Text;
                string giaGioChoi = txtGiaGioChoi.Text;
                if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(tenLoai) || string.IsNullOrEmpty(giaGioChoi))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại hàng.");
                    return;
                }
                if (!int.TryParse(txtLoaiBan.Text, out int maLoaiBan) || maLoaiBan <= 0)
                {
                    MessageBox.Show("Mã loại không hợp lệ!");
                    return;
                }
                if (!int.TryParse(txtGiaGioChoi.Text, out int gia) || gia <= 0)
                {
                    MessageBox.Show("Giá không hợp lệ!");
                    return;
                }
                LoaiBan newLoaiBan = new LoaiBan
                {
                    maban = maLoaiBan,
                    tenloaiban = tenLoai,
                    GiaGioChoi = gia,
                };


                bool isSuccess = loaiBanBLL.UpdateLoaiBan(newLoaiBan);

                if (isSuccess)
                {
                    MessageBox.Show("Loại hàng hóa đã được thêm thành công!");
                    loadDSLoaiBan();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Loại hàng hóa. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSuaLoai_Click(object sender, EventArgs e)
        {
            txtLoaiBan.Enabled = false;
            btnLuuLoai.Enabled = true;
        }

        private void BtnXoaLoai_Click(object sender, EventArgs e)
        {
            try
            {
                int maLoai = int.Parse(txtLoaiBan.Text.ToString());
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa loại bàn với mã '{maLoai}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = loaiBanBLL.DeleteLoaiBan(maLoai);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa loại bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSLoaiBan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa loại bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThemLoai_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = txtLoaiBan.Text;
                string tenLoai = txtTenLoai.Text;
                string giaGioChoi = txtGiaGioChoi.Text;
                if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(tenLoai) || string.IsNullOrEmpty(giaGioChoi))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại hàng.");
                    return;
                }
                if (!int.TryParse(txtLoaiBan.Text, out int maLoaiBan) || maLoaiBan <= 0)
                {
                    MessageBox.Show("Mã loại không hợp lệ!");
                    return;
                }
                if (!int.TryParse(txtGiaGioChoi.Text, out int gia) || gia <= 0)
                {
                    MessageBox.Show("Giá không không hợp lệ!");
                    return;
                }
                LoaiBan newLoaiBan = new LoaiBan
                {
                    maban = maLoaiBan,
                    tenloaiban = tenLoai,
                    GiaGioChoi = gia,
                };
              

                bool isSuccess = loaiBanBLL.AddLoaiBan(newLoaiBan);

                if (isSuccess)
                {
                    MessageBox.Show("Loại hàng hóa đã được thêm thành công!");
                    loadDSLoaiBan();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Loại hàng hóa. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearLoai_Click(object sender, EventArgs e)
        {
           txtLoaiBan.Clear();
            txtTenLoai.Clear();
            txtGiaGioChoi.Clear();
        }

        private void DgvLoaiBan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiBan.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvLoaiBan.CurrentRow;
                txtLoaiBan.Text = currentRow.Cells["MaBan"].Value?.ToString();
                txtTenLoai.Text = currentRow.Cells["TenLoai"].Value?.ToString();
                txtGiaGioChoi.Text = currentRow.Cells["GiaGioChoi"].Value?.ToString();
                int maLoai = int.Parse(txtLoaiBan.Text);
                loadDSKhuVucTheoLoaiBan(maLoai);
               
            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }
        private void loadDSKhuVucTheoLoaiBan(int maLoai)
        {
            dgvKhuVuc.DataSource = null;
            try
            {
                List<KHUVUC> dsKhuVuc = khuVucBLL.GetKhuVucByMaLoaiBan(maLoai);

                if (dsKhuVuc != null && dsKhuVuc.Count > 0)
                {
                    var dsKhuVucViewModel = from pn in dsKhuVuc
                                            select new
                                            {
                                                MaKV = pn.MaKV,
                                                TenKV = pn.TenKV,
                                                GiaTien = pn.GiaTien,
                                                MaLoaiBan = pn.LoaiBan != null ? pn.LoaiBan.maban : 0
                                            };
                    dgvKhuVuc.DataSource = dsKhuVucViewModel.ToList();
                    dgvKhuVuc.Columns["MaKV"].HeaderText = "Mã khu vực";
                    dgvKhuVuc.Columns["TenKV"].HeaderText = "Tên khu vực";
                    dgvKhuVuc.Columns["GiaTien"].HeaderText = "Giá tiền";
                    //dgvKhuVuc.Columns["MaLoaiBan"].HeaderText = "Mã loại bàn";
                    dgvKhuVuc.Columns["MaLoaiBan"].Visible = false;

                    foreach (DataGridViewColumn column in dgvKhuVuc.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvKhuVuc.RowPostPaint += dgv_RowPostPaint;
                }
                else
                {

                    MessageBox.Show("Không tìm thấy khu vực nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void FrmQuanLyLoaiBan_KhuVuc_Ban_Load(object sender, EventArgs e)
        {
            loadDSLoaiBan();
            btnLuuLoai.Enabled = false;
            btnLuuKhuVuc.Enabled = false;
            btnLuuBan.Enabled = false;
        }

        private void loadDSLoaiBan()
        {
            dgvLoaiBan.DataSource = null;
            try
            {
                List<LoaiBan> dsLoaiBan = loaiBanBLL.LayDanhSachLoaiBan();
                if (dsLoaiBan != null && dsLoaiBan.Count > 0)
                {
                    var dsLoaiBanViewModel = from pn in dsLoaiBan
                                             select new
                                             {
                                                 MaBan = pn.maban,
                                                 TenLoai = pn.tenloaiban,
                                                 GiaGioChoi = pn.GiaGioChoi,
                                               
                                             };
                    dgvLoaiBan.DataSource = dsLoaiBanViewModel.ToList();
                    dgvLoaiBan.Columns["MaBan"].HeaderText = "Mã loại bàn";
                    dgvLoaiBan.Columns["TenLoai"].HeaderText = "Tên loại bàn";
                    dgvLoaiBan.Columns["GiaGioChoi"].HeaderText = "Giá giờ chơi";


                    // Căn giữa tiêu đề cột và chỉnh font chữ
                    foreach (DataGridViewColumn column in dgvLoaiBan.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvLoaiBan.RowPostPaint += dgv_RowPostPaint;
                }
                else {
                    MessageBox.Show("Không tìm thấy loại bàn nào.");
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhuVuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmQuanLyLoaiBan_KhuVuc_Ban_Load_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtLoaiBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaGioChoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
