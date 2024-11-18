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
    public partial class frmQuanLyNiemYet : Form
    {
        NiemYetBLL niemYetBLL = new NiemYetBLL();
        ChiTietNiemYetBLL chiTietNiemYetBLL = new ChiTietNiemYetBLL();
        BanBLL banBLL = new BanBLL();
        public frmQuanLyNiemYet()
        {
            InitializeComponent();
            this.Load += FrmQuanLyNiemYet_Load;
            dgvNiemYet.SelectionChanged += DgvNiemYet_SelectionChanged;
            dgvChiTietNiemYet.SelectionChanged += DgvChiTietNiemYet_SelectionChanged;

            this.btnClearNiemYet.Click += BtnClearNiemYet_Click;
            this.btnThemNiemYet.Click += BtnThemNiemYet_Click;
            this.btnXoaNiemYet.Click += BtnXoaNiemYet_Click;
            this.btnSuaNiemYet.Click += BtnSuaNiemYet_Click;
            this.btnLuuNiemYet.Click += BtnLuuNiemYet_Click;


            this.btnThemCTNY.Click += BtnThemCTNY_Click;
            this.btnClearCTNY.Click += BtnClearCTNY_Click;
            this.btnXoaCTNY.Click += BtnXoaCTNY_Click;
            this.btnSuaCTNY.Click += BtnSuaCTNY_Click;
            this.btnLuuCTNY.Click += BtnLuuCTNY_Click;
        }

        private void BtnLuuCTNY_Click(object sender, EventArgs e)
        {
            try
            {
                string maNY = txtMaNiemYet.Text;
                string maBan = cbbBan.SelectedValue.ToString(); 

                if (string.IsNullOrEmpty(maNY) || string.IsNullOrEmpty(maBan))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết Niêm Yết.");
                    return;
                }
                if (!int.TryParse(txtGiaTri.Text, out int giaTri) || giaTri <= 0)
                {
                    MessageBox.Show("Giá không hợp lệ!");
                    return;
                }

                ChiTietNiemYetBan newCTNiemYet = new ChiTietNiemYetBan
                {
                    MaNiemYet = maNY,
                    MaBan = maBan,  
                    GiaTri = giaTri
                };

         
                bool isSuccess = chiTietNiemYetBLL.UpdateChiTietNiemYet(newCTNiemYet);

                if (isSuccess)
                {
                    MessageBox.Show("Chi tiết Niêm Yết đã được cập nhật thành công!");
                    loadDSNiemYet(); 
                    btnLuuCTNY.Enabled = false;
                    cbbBan.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật chi tiết Niêm Yết. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSuaCTNY_Click(object sender, EventArgs e)
        {
            btnLuuCTNY.Enabled = true;
            cbbBan.Enabled = false;
            
        }

        private void BtnXoaCTNY_Click(object sender, EventArgs e)
        {
            try
            {
                string maBan = cbbBan.SelectedValue.ToString();
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa chi tiết Niêm Yết với mã '{maBan}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = chiTietNiemYetBLL.DeleteChiTietNiemYet(maBan);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa chi tiết Niêm Yết thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSNiemYet();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa chi tiết Niêm Yết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void BtnClearCTNY_Click(object sender, EventArgs e)
        {
            txtGiaTri.Clear();
            loadCbbBan();

        }

        private void BtnThemCTNY_Click(object sender, EventArgs e)
        {
            try
            {
                string maNY = txtMaNiemYet.Text;
                string maBan = cbbBan.SelectedValue.ToString();
                if (string.IsNullOrEmpty(maNY) || string.IsNullOrEmpty(maBan))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết Niêm Yết.");
                    return;
                }

                if (!int.TryParse(txtGiaTri.Text, out int giaTri) || giaTri <= 0)
                {
                    MessageBox.Show("Giá không không hợp lệ!");
                    return;
                }
                ChiTietNiemYetBan newCTNiemYet = new ChiTietNiemYetBan
                {
                    MaNiemYet = maNY,
                    MaBan = maBan,
                    GiaTri = giaTri
                };


                bool isSuccess = chiTietNiemYetBLL.AddChiTietNiemYet(newCTNiemYet);

                if (isSuccess)
                {
                    MessageBox.Show("Chi tiết Niêm Yết đã được thêm thành công!");
                    loadDSNiemYet();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm chi tiết Niêm Yết. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearNiemYet_Click(object sender, EventArgs e)
        {
            txtMaNiemYet.Clear();
            txtTenNiemYet.Clear();
            txtMaNiemYet.Enabled = true;
        }

        private void BtnLuuNiemYet_Click(object sender, EventArgs e)
        {
            try
            {
                string maNY = txtMaNiemYet.Text;
                string tenNY = txtTenNiemYet.Text;
                if (string.IsNullOrEmpty(maNY) || string.IsNullOrEmpty(tenNY))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Niêm Yết.");
                    return;
                }

                NiemYet newNiemYet = new NiemYet
                {
                    MaNiemYet = maNY,
                    TenNiemYet = tenNY,
                };


                bool isSuccess = niemYetBLL.UpdateNiemYet(newNiemYet);

                if (isSuccess)
                {
                    MessageBox.Show("Niêm Yết đã cập nhật thành công!");
                    loadDSNiemYet();
                    btnLuuNiemYet.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập Niêm Yết. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSuaNiemYet_Click(object sender, EventArgs e)
        {
            btnLuuNiemYet.Enabled = true;
            txtMaNiemYet.Enabled = false;
        }

        private void BtnXoaNiemYet_Click(object sender, EventArgs e)
        {
            try
            {
                string maNY = txtMaNiemYet.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa Niêm Yết với mã '{maNY}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = niemYetBLL.DeleteNiemYet(maNY);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa Niêm Yết thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSNiemYet();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa Niêm Yết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void BtnThemNiemYet_Click(object sender, EventArgs e)
        {
            try
            {
                string maNY = txtMaNiemYet.Text;
                string tenNY = txtTenNiemYet.Text;
                if (string.IsNullOrEmpty(maNY) || string.IsNullOrEmpty(tenNY))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Niêm Yết.");
                    return;
                }
               
                NiemYet newNiemYet = new NiemYet
                {
                    MaNiemYet = maNY,
                    TenNiemYet = tenNY,
                };


                bool isSuccess = niemYetBLL.AddNiemYet(newNiemYet);

                if (isSuccess)
                {
                    MessageBox.Show("Niêm Yết đã được thêm thành công!");
                    loadDSNiemYet();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Niêm Yết. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

     
        private void DgvChiTietNiemYet_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChiTietNiemYet.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvChiTietNiemYet.CurrentRow;
                txtMaNiemYet.Text = currentRow.Cells["MaNiemYet"].Value?.ToString();
                txtGiaTri.Text = currentRow.Cells["GiaTri"].Value?.ToString();
                cbbBan.SelectedValue = currentRow.Cells["MaBan"].Value?.ToString();

            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void DgvNiemYet_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNiemYet.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvNiemYet.CurrentRow;
                txtMaNiemYet.Text = currentRow.Cells["MaNiemYet"].Value?.ToString();
                txtTenNiemYet.Text = currentRow.Cells["TenNiemYet"].Value?.ToString();
                string maNY = txtMaNiemYet.Text;
                loadCTNYTheoNiemYet(maNY);

            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void loadCTNYTheoNiemYet(string maNY)
        {
            if (string.IsNullOrEmpty(maNY))
            {
                MessageBox.Show("Mã Niêm Yết không hợp lệ.");
                return;
            }
            dgvChiTietNiemYet.DataSource = null;
            try
            {
                List<ChiTietNiemYetBan> dsCTNiemYet = chiTietNiemYetBLL.GetChiTietNiemYetByMaNY(maNY);

                if (dsCTNiemYet != null && dsCTNiemYet.Count > 0)
                {
                    var dsCTNiemYetViewModel = from pn in dsCTNiemYet
                                               select new
                                               {
                                                   MaNiemYet = pn.NiemYet != null ? pn.NiemYet.MaNiemYet : string.Empty,
                                                   MaBan = pn.BAN != null ? pn.BAN.MaBan : string.Empty,
                                                   GiaTri = pn.GiaTri
                                               };
                    dgvChiTietNiemYet.DataSource = dsCTNiemYetViewModel.ToList();
                    dgvChiTietNiemYet.Columns["MaNiemYet"].Visible = false;
                    dgvChiTietNiemYet.Columns["MaBan"].HeaderText = "Mã bàn";
                    dgvChiTietNiemYet.Columns["GiaTri"].HeaderText = "Giá trị";

                    foreach (DataGridViewColumn column in dgvChiTietNiemYet.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết niêm yết nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void FrmQuanLyNiemYet_Load(object sender, EventArgs e)
        {
            loadDSNiemYet();
            loadCbbBan();
            btnLuuNiemYet.Enabled = false;
            btnLuuCTNY.Enabled = false;
        }

        private void loadCbbBan()
        {
            try
            {
                List<BAN> dsBan = banBLL.LayDanhSachBan();
                if (dsBan != null && dsBan.Count > 0)
                {
                    cbbBan.DataSource = null;
                    cbbBan.DataSource = dsBan;
                    cbbBan.ValueMember = "MaBan";
                    cbbBan.DisplayMember = "TenBan";
                }
                else
                {
                    cbbBan.DataSource = null;
                    MessageBox.Show("Không có Bàn nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Bàn: " + ex.Message);
            }
        }

        private void loadDSNiemYet()
        {
            dgvNiemYet.DataSource = null;
            try
            {
                List<NiemYet> dsNiemYet = niemYetBLL.LayDanhSachNiemYet();
                if (dsNiemYet != null && dsNiemYet.Count > 0)
                {
                  
                    dgvNiemYet.DataSource = dsNiemYet;
                    dgvNiemYet.Columns["MaNiemYet"].HeaderText = "Mã niêm yết";
                    dgvNiemYet.Columns["TenNiemYet"].HeaderText = "Tên niêm yết";

                    // Căn giữa tiêu đề cột và chỉnh font chữ
                    foreach (DataGridViewColumn column in dgvNiemYet.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Niêm Yết nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void txtGiaTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
