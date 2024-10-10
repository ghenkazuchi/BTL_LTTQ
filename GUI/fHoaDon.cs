using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DTO;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class fHoaDon : Form
    {
        string idLogin;
        private Font font = new Font("Segoe UI", 12, FontStyle.Bold);
        private Font fontSub = new Font("Segoe UI", 10, FontStyle.Regular);
        private HoaDonYeuCauBLL hoaDonYeuCauBLL;
        public int CornerRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
        public float BorderThickness { get; set; } = 0.5f;
        private int rowIndex = -1;
        private Point panelPos = new Point(48, 118);
        public fHoaDon(string idLogin)
        {
            InitializeComponent();
            hoaDonYeuCauBLL = new HoaDonYeuCauBLL();

            SetupDataGridView();

            SetupDataGridViewCMS();

            ListHoaDon();

            panelChiTiet.Location = panelPos;
            panelChiTiet.Visible = false;

            cmbOrder.SelectedIndex = 0;
            this.idLogin = idLogin;
        }

        private void SetupDataGridView()
        {

            dgvHoaDon.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvHoaDon.EnableHeadersVisualStyles = false;
            dgvHoaDon.GridColor = Color.LightGray;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.BackColor = dgvHoaDon.BackColor;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.ForeColor = dgvHoaDon.ForeColor;

            dgvHoaDon.DefaultCellStyle.SelectionBackColor = dgvHoaDon.DefaultCellStyle.BackColor;
            dgvHoaDon.DefaultCellStyle.SelectionForeColor = dgvHoaDon.DefaultCellStyle.ForeColor;

            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn actionsColumn = new DataGridViewButtonColumn();
            actionsColumn.Name = "Actions";
            actionsColumn.HeaderText = "";
            actionsColumn.Text = "...";
            actionsColumn.UseColumnTextForButtonValue = true;
            dgvHoaDon.Columns.Add(actionsColumn);


            dgvHoaDon.Columns["MaBooking"].FillWeight = 13;
            dgvHoaDon.Columns["TenKH"].FillWeight = 20;
            dgvHoaDon.Columns["MaXe"].FillWeight = 12;
            dgvHoaDon.Columns["MaNV"].FillWeight = 12;
            dgvHoaDon.Columns["NgayIn"].FillWeight = 18;
            dgvHoaDon.Columns["TongTien"].FillWeight = 20;
            dgvHoaDon.Columns["Actions"].FillWeight = 5;

            dgvHoaDon.RowTemplate.Height = 60;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHoaDon.ColumnHeadersHeight = 60;

            dgvHoaDon.Rows.Clear();

            //dgvHoaDon.Rows.Add("Honda Civic", "HC123", "L01", "KH123456", "M123456", "29A-123.45", "MM01");
            //dgvHoaDon.Rows.Add("Yamaha R15", "YR456", "L02", "KH654321", "M654321", "29A-456.78", "MM02");
            //dgvHoaDon.Rows.Add("Suzuki Hayabusa", "SH789", "L01", "KH987654", "M987654", "29A-789.01", "MM03");
            //dgvHoaDon.Rows.Add("Kawasaki Ninja", "KN012", "L03", "KH111222", "M111222", "29A-012.34", "MM04");
            //dgvHoaDon.Rows.Add("BMW S1000RR", "BS345", "L01", "KH333444", "M333444", "29A-345.67", "MM05");
            //dgvHoaDon.Rows.Add("Ducati Panigale", "DP678", "L02", "KH555666", "M555666", "29A-678.90", "MM06");
            //dgvHoaDon.Rows.Add("Harley Davidson", "HD901", "L03", "KH777888", "M777888", "29A-901.12", "MM07");
            //dgvHoaDon.Rows.Add("Triumph Bonneville", "TB234", "L01", "KH999000", "M999000", "29A-234.56", "MM08");
            //dgvHoaDon.Rows.Add("Aprilia RS660", "AR567", "L02", "KH123456", "M123456", "29A-567.89", "MM09");
            //dgvHoaDon.Rows.Add("KTM RC390", "KT890", "L03", "KH789012", "M789012", "29A-890.23", "MM10");

        }

        private void SetupDataGridViewCMS()
        {

            dgvCMSHoaDon.EnableHeadersVisualStyles = false;
            dgvCMSHoaDon.GridColor = Color.LightGray;
            dgvCMSHoaDon.ColumnHeadersDefaultCellStyle.BackColor = dgvCMSHoaDon.BackColor;
            dgvCMSHoaDon.ColumnHeadersDefaultCellStyle.ForeColor = dgvCMSHoaDon.ForeColor;

            dgvCMSHoaDon.DefaultCellStyle.SelectionBackColor = dgvCMSHoaDon.DefaultCellStyle.BackColor;
            dgvCMSHoaDon.DefaultCellStyle.SelectionForeColor = dgvCMSHoaDon.DefaultCellStyle.ForeColor;

            dgvCMSHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvCMSHoaDon.Columns["PhuTung"].FillWeight = 46;
            dgvCMSHoaDon.Columns["Gia"].FillWeight = 18;
            dgvCMSHoaDon.Columns["SoLuong"].FillWeight = 18;
            dgvCMSHoaDon.Columns["ThanhTien"].FillWeight = 18;

            dgvCMSHoaDon.Columns["Gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCMSHoaDon.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCMSHoaDon.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCMSHoaDon.RowTemplate.Height = 60;
            dgvCMSHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCMSHoaDon.ColumnHeadersHeight = 60;

            dgvCMSHoaDon.Rows.Clear();

            dgvCMSHoaDon.Rows.Add("helloasdasdllasdasdad", "500000", "01", "50000000");
            dgvCMSHoaDon.Rows.Add("helloasdasdllasdasdad", "500000", "01", "500000");
            dgvCMSHoaDon.Rows.Add("helloasdasdllasdasdad", "500000", "01", "500000");
            dgvCMSHoaDon.Rows.Add("helloasdasdllasdasdad", "500000", "01", "500000");
            dgvHoaDon.Rows.Add("01", "YR456", "L02", "KH654321", "202020", "100000");
            //dgvHoaDon.Rows.Add("Suzuki Hayabusa", "SH789", "L01", "KH987654", "M987654", "29A-789.01", "MM03");
            //dgvHoaDon.Rows.Add("Kawasaki Ninja", "KN012", "L03", "KH111222", "M111222", "29A-012.34", "MM04");
            //dgvHoaDon.Rows.Add("BMW S1000RR", "BS345", "L01", "KH333444", "M333444", "29A-345.67", "MM05");
            //dgvHoaDon.Rows.Add("Ducati Panigale", "DP678", "L02", "KH555666", "M555666", "29A-678.90", "MM06");
            //dgvHoaDon.Rows.Add("Harley Davidson", "HD901", "L03", "KH777888", "M777888", "29A-901.12", "MM07");
            //dgvHoaDon.Rows.Add("Triumph Bonneville", "TB234", "L01", "KH999000", "M999000", "29A-234.56", "MM08");
            //dgvHoaDon.Rows.Add("Aprilia RS660", "AR567", "L02", "KH123456", "M123456", "29A-567.89", "MM09");
            //dgvHoaDon.Rows.Add("KTM RC390", "KT890", "L03", "KH789012", "M789012", "29A-890.23", "MM10");

        }

        private void dgvHoaDon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                string cellValue = e.Value?.ToString() ?? string.Empty;
                if (cellValue != string.Empty)
                {
                    Rectangle rect = e.CellBounds;
                    e.Graphics.DrawString(cellValue, font, Brushes.Black, rect.X, rect.Y + 15);
                }
            }
        }

        private void dgvCMSHoaDon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                string cellValue = e.Value?.ToString() ?? string.Empty;
                if (cellValue != string.Empty)
                {
                    Rectangle rect = e.CellBounds;
                    e.Graphics.DrawString(cellValue, font, Brushes.Gray, rect.X, rect.Y + 15);
                }
            }
        }

        private void yourDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHoaDon.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRectangle = dgvHoaDon.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                rowIndex = e.RowIndex;
                cmsHoaDon.Show(dgvHoaDon, cellRectangle.Left, cellRectangle.Bottom - 20);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update selected!");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete selected!");
        }


        private void DrawRoundedPanel(Panel panel, int radius, Color borderColor, float borderThickness, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);

            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                g.DrawPath(pen, path);
            }
        }

        private void btnDSHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnNhapHoaDon_Click(object sender, EventArgs e)
        {
            
        }

        private void cmsItemChiTiet_Click(object sender, EventArgs e)
        {
            panelChiTiet.Visible = true;
            panelDSHoaDon.Visible = false;

            DataGridViewRow selectedRow = dgvHoaDon.Rows[rowIndex];

            txtMaBooking.Text = selectedRow.Cells["MaBooking"].Value.ToString();
            txtTenKH.Text = selectedRow.Cells["TenKH"].Value.ToString();
            txtMaKH.Text = selectedRow.Cells["MaKhachHang"].Value.ToString();
            txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
            txtNgayIn.Text = selectedRow.Cells["NgayIn"].Value.ToString();
            lbTongTien.Text = selectedRow.Cells["TongTien"].Value.ToString();

            //lay thong tin bang rowIndex
        }

        private void cmsItemSua_Click(object sender, EventArgs e)
        {
            //lay thong tin bang rowIndex
        }

        private void cmsItemXoa_Click(object sender, EventArgs e)
        {
            //lay thong tin bang rowIndex
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            panelDSHoaDon.Visible = true;
            panelChiTiet.Visible = false;
        }

        private void btnOKHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel2, 15, BorderColor, BorderThickness, e);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel4, 15, BorderColor, BorderThickness, e);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel6, 15, BorderColor, BorderThickness, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel1, 15, BorderColor, BorderThickness, e);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel5, 15, BorderColor, BorderThickness, e);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel7, 15, BorderColor, BorderThickness, e);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel8, 15, BorderColor, BorderThickness, e);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel9, 30, BorderColor, BorderThickness, e);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel10, 15, BorderColor, BorderThickness, e);
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel12, 15, BorderColor, BorderThickness, e);
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel13, 15, BorderColor, BorderThickness, e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel3, 15, BorderColor, BorderThickness, e);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 2; // Độ dày của đường viền

            // Vẽ đường viền trên
            using (Pen pen = new Pen(Color.Black, borderWidth))
            {
                e.Graphics.DrawLine(pen, 0, 0, panel.Width, 0); // Vẽ đường từ (0,0) đến (panel.Width, 0)
            }
        }

        #region

        private void ListHoaDon()
        {
            dgvHoaDon.Rows.Clear();
            List<HoaDonYeuCauDTO> dsHoaDon = hoaDonYeuCauBLL.GetListHoaDon();
            foreach (var hoaDon in dsHoaDon)
            {
                dgvHoaDon.Rows.Add(hoaDon.MaSuaChua, hoaDon.TenKhachHang, hoaDon.MaXe,hoaDon.MaNhanVien,hoaDon.NgayIn,hoaDon.TongTien,hoaDon.MaKhachHang);
            }
        }

        #endregion
    }
}
