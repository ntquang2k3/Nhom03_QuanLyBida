using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DTO;
using BLL;
using DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class frmQuanLyLoaiHangHoa : Form
    {
        LoaiHangHoaBLL loaihhBLL = new LoaiHangHoaBLL();
    
        HangHoaBLL hangHoaBLL = new HangHoaBLL();

        public frmQuanLyLoaiHangHoa()
        {
            InitializeComponent();
            this.Load += FrmQuanLyLoaiHangHoa_Load;
            dgvLoaiHangHoa.SelectionChanged += DgvLoaiHangHoa_SelectionChanged;
            dgvHangHoa.SelectionChanged += DgvHangHoa_SelectionChanged;
            this.btnLamLoaiHH.Click += BtnLamLoaiHH_Click;
            this.btnLamMoiHH.Click += BtnLamMoiHH_Click;
            this.btnThemLoaiHang.Click += BtnThemLoaiHang_Click;
            this.btnXoaLoaiHang.Click += BtnXoaLoaiHang_Click;
            this.btnSuaLoaiHang.Click += BtnSuaLoaiHang_Click;
            this.btnLuuLoaiHang.Click += BtnLuuLoaiHang_Click;
            this.btnLamMoiHH.Click += BtnLamMoiHH_Click1;
            this.btnThemHH.Click += BtnThemHH_Click;
            this.btnXoaHH.Click += BtnXoaHH_Click;
            this.btnThemAnh.Click += BtnThemAnh_Click;
            this.btnSuaHH.Click += BtnSuaHH_Click;
            this.btnLuuHH.Click += BtnLuuHH_Click;
        }

        private void BtnLuuHH_Click(object sender, EventArgs e)
        {
            try
            {
                string maLH = txtMaLoai.Text;
                string maHH = txtMaHH.Text;
                string tenHH = txtTenHH.Text;
                string hinhAnh = txtHinhAnh.Text;


                if (string.IsNullOrEmpty(maHH) || string.IsNullOrEmpty(tenHH) || string.IsNullOrEmpty(hinhAnh))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hàng hóa.");
                    return;
                }

                if (!int.TryParse(txtGia.Text, out int giaSP) || giaSP <= 0)
                {
                    MessageBox.Show("Giá không hợp lệ!");
                    return;
                }
                HANGHOA newHangHoa = new HANGHOA

                {
                    MaHH = maHH,
                    MaLH = maLH,
                    TenHH = tenHH,
                    HinhAnh = hinhAnh,
                    GiaSP = giaSP,

                };


                bool isSuccess = hangHoaBLL.UpdateHangHoa(newHangHoa);

                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật thành công hàng hóa!");
                    loadDSHangHoaTheoLoai(maLH);
                    btnLuuHH.Enabled = false;
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

        private void BtnSuaHH_Click(object sender, EventArgs e)
        {
           btnLuuHH.Enabled = true;
           txtMaHH.Enabled = false;
        }

        private void BtnThemAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string newImageName = $"{Path.GetFileName(selectedImagePath)}";
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);
                    if (File.Exists(resourcePath))
                    {
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }

                    txtHinhAnh.Text = newImageName;
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        LoadImageToPictureBox(newImageName);
                    }
                }
            }
        }
        private bool SaveImageToResources(string imagePath, string imageName)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                string directoryPath = Path.GetDirectoryName(resourcePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.Copy(imagePath, resourcePath, true);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnXoaHH_Click(object sender, EventArgs e)
        {
            try
            {
                string maHH = txtMaHH.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa loại hàng với mã '{maHH}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = hangHoaBLL.DeleteHangHoa(maHH);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa hàng hóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSLoaiHangHoa();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa hàng hóa này: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThemHH_Click(object sender, EventArgs e)
        {
            try
            {
                string maLH = txtMaLoai.Text;
                string maHH = txtMaHH.Text;
                string tenHH = txtTenHH.Text;
                string hinhAnh = txtHinhAnh.Text;
              
                
                if (string.IsNullOrEmpty(maHH) || string.IsNullOrEmpty(tenHH) || string.IsNullOrEmpty(hinhAnh))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hàng hóa.");
                    return;
                }

                if (!int.TryParse(txtGia.Text, out int giaSP) || giaSP <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ!");
                    return;
                }
                HANGHOA newHangHoa = new HANGHOA

                {
                    MaHH = maHH,
                    MaLH = maLH,
                    TenHH = tenHH,
                    HinhAnh= hinhAnh,
                    GiaSP = giaSP,

                };


                bool isSuccess = hangHoaBLL.AddHangHoa(newHangHoa);

                if (isSuccess)
                {
                    MessageBox.Show("Hàng hóa đã được thêm thành công!");
                    loadDSHangHoaTheoLoai(maLH);
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

        private void BtnLamMoiHH_Click1(object sender, EventArgs e)
        {
            txtMaHH.Clear();
            txtTenHH.Clear();
            txtHinhAnh.Clear();
            txtGia.Clear();
            
        }

        private void BtnLuuLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                string maLH = txtMaLoai.Text;
                string tenLH = txtTenLoai.Text;
                string moTa = txtMoTa.Text;
                if (string.IsNullOrEmpty(maLH) || string.IsNullOrEmpty(tenLH) || string.IsNullOrEmpty(moTa))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại hàng.");
                    return;
                }
                LOAIHH newLoaiHH = new LOAIHH
                {
                    MaLH = maLH,
                    TenLH = tenLH,
                    MoTa = moTa,
                };
                bool isSuccess = loaihhBLL.UpdateLoaiHang(newLoaiHH);

                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật loại hàng thành công!");
                    btnLuuLoaiHang.Enabled = false;
                    loadDSLoaiHangHoa();
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

        private void BtnSuaLoaiHang_Click(object sender, EventArgs e)
        {
           btnLuuLoaiHang.Enabled = true;
           txtMaLoai.Enabled = false;
        }

        private void BtnXoaLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                string maLH = txtMaLoai.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa loại hàng với mã '{maLH}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                 
                    bool isSuccess = loaihhBLL.DeleteLoaiHang(maLH);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa loại hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSLoaiHangHoa(); 
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa loại hàng. Có thể loại hàng này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa loại hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThemLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                string maLH = txtMaLoai.Text; 
                string tenLH = txtTenLoai.Text;
                string moTa = txtMoTa.Text;
                if (string.IsNullOrEmpty(maLH) || string.IsNullOrEmpty(tenLH) || string.IsNullOrEmpty(moTa))
                 
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại hàng.");
                    return;
                }
                LOAIHH newLoaiHH = new LOAIHH
                {
                    MaLH = maLH,
                    TenLH = tenLH,
                    MoTa = moTa,
                };

           
                bool isSuccess = loaihhBLL.AddLoaiHang(newLoaiHH);

                if (isSuccess)
                {
                    MessageBox.Show("Loại hàng hóa đã được thêm thành công!");
                    loadDSLoaiHangHoa(); 
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

        private void BtnLamMoiHH_Click(object sender, EventArgs e)
        {
           txtMaHH.Clear();
           txtTenHH.Clear();
           txtGia.Clear();
           txtHinhAnh.Clear();
        }

        private void BtnLamLoaiHH_Click(object sender, EventArgs e)
        {
            txtMaLoai.Enabled = true;
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtMoTa.Clear();
            
        }

        private void DgvHangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHangHoa.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvHangHoa.CurrentRow;
                txtMaHH.Text = currentRow.Cells["MaHH"].Value?.ToString();
                txtMaLoai.Text = currentRow.Cells["MaLH"].Value?.ToString();
                txtTenHH.Text = currentRow.Cells["TenHH"].Value?.ToString();
                txtHinhAnh.Text = currentRow.Cells["HinhAnh"].Value?.ToString();
                txtGia.Text = currentRow.Cells["GiaSP"].Value?.ToString();
                string imagePath = txtHinhAnh.Text;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    LoadImageToPictureBox(imagePath);
                }
                else
                {
                    imgSanPham.Image = null;
                }
            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void LoadImageToPictureBox(string imageName)
        {
            try
            {
                // Đường dẫn đến ảnh trong thư mục Resources
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Kiểm tra nếu file ảnh tồn tại, hiển thị ảnh vào PictureBox
                if (File.Exists(resourcePath))
                {
                    imgSanPham.Image = Image.FromFile(resourcePath);
                    imgSanPham.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chọn để ảnh phù hợp với PictureBox
                }
                else
                {
                    imgSanPham.Image = Properties.Resources.logo;
                    Console.WriteLine("Ảnh không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLoaiHangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiHangHoa.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvLoaiHangHoa.CurrentRow;
                txtMaLoai.Text = currentRow.Cells["MaLH"].Value?.ToString();
                txtTenLoai.Text = currentRow.Cells["TenLH"].Value?.ToString();
                txtMoTa.Text = currentRow.Cells["MoTa"].Value?.ToString();
                loadDSHangHoaTheoLoai(txtMaLoai.Text);
                txtMaLoai.Text = currentRow.Cells["MaLH"].Value?.ToString();
            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }
        private void loadDSHangHoaTheoLoai(string maLH)
        {
            dgvHangHoa.DataSource = null;
            try
            {
                List<HANGHOA> dsHangHoa = hangHoaBLL.GetHangHoaByMaLH(maLH);

                if (dsHangHoa != null && dsHangHoa.Count > 0)
                {
                    var dsHangHoaViewModel = from pn in dsHangHoa
                                             select new
                                             {
                                                 MaHH = pn.MaHH,
                                                 TenHH = pn.TenHH,
                                                 HinhAnh = pn.HinhAnh,
                                                 GiaSP = pn.GiaSP,
                                                 MaLH = pn.LOAIHH != null ? pn.LOAIHH.MaLH : string.Empty
                                             };
                    dgvHangHoa.DataSource = dsHangHoaViewModel.ToList();
                    dgvHangHoa.Columns["MaHH"].HeaderText = "Mã hàng hóa";
                    dgvHangHoa.Columns["TenHH"].HeaderText = "Tên hàng hóa";
                    dgvHangHoa.Columns["HinhAnh"].HeaderText = "Hình ảnh";
                    dgvHangHoa.Columns["GiaSP"].HeaderText = "Giá sản phẩm";
                    dgvHangHoa.Columns["MaLH"].Visible = false;

                    foreach (DataGridViewColumn column in dgvHangHoa.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvHangHoa.RowPostPaint += dgv_RowPostPaint;
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

        private void loadDSHangHoa()
        {
            dgvHangHoa.DataSource = null;
            try
            {
                
                List<HANGHOA> dsHangHoa = hangHoaBLL.LayDanhSachHangHoa();
                if (dsHangHoa != null && dsHangHoa.Count > 0)
                {
                    var dsHangHoaViewModel = from pn in dsHangHoa
                                               select new
                                               {
                                                   MaHH = pn.MaHH,
                                                   TenHH = pn.TenHH,
                                                   HinhAnh = pn.HinhAnh,
                                                   GiaSP = pn.GiaSP,
                                                   MaLH = pn.LOAIHH != null ? pn.LOAIHH.MaLH : string.Empty
                                               };
                    dgvHangHoa.DataSource = dsHangHoaViewModel.ToList();
                    dgvHangHoa.Columns["MaHH"].HeaderText = "Mã hàng hóa";
                    dgvHangHoa.Columns["TenHH"].HeaderText = "Tên hàng hóa";
                    dgvHangHoa.Columns["HinhAnh"].HeaderText = "Hình ảnh";
                    dgvHangHoa.Columns["GiaSP"].HeaderText = "Giá sản phẩm";
                    dgvHangHoa.Columns["MaLH"].Visible = false;

                    // Căn giữa tiêu đề cột và chỉnh font chữ
                    foreach (DataGridViewColumn column in dgvLoaiHangHoa.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvLoaiHangHoa.RowPostPaint += dgv_RowPostPaint;
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

        private void FrmQuanLyLoaiHangHoa_Load(object sender, EventArgs e)
        {
            loadDSLoaiHangHoa();
            txtHinhAnh.Enabled = false;
        }

        private void loadDSLoaiHangHoa()
        {
            dgvLoaiHangHoa.DataSource = null;
            try
            {
                    List<LOAIHH> dsLoaiHH = loaihhBLL.LayDanhSachLoaiHangHoa();
                    dgvLoaiHangHoa.DataSource = dsLoaiHH;
                    dgvLoaiHangHoa.Columns["MaLH"].HeaderText = "Mã loại hàng";
                    dgvLoaiHangHoa.Columns["TenLH"].HeaderText = "Tên loại hàng";
                    dgvLoaiHangHoa.Columns["MoTa"].HeaderText = "Mô tả";
                  

                    // Căn giữa tiêu đề cột và chỉnh font chữ
                    foreach (DataGridViewColumn column in dgvLoaiHangHoa.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvLoaiHangHoa.RowPostPaint += dgv_RowPostPaint;
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


    }
}
