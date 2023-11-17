using System.Windows.Forms;

namespace frmLogin
{
    public partial class frmTrangChu : Form
    {

        private  ThanhVien userInfo;
        public  frmTrangChu(ThanhVien userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            TabPage tab = new TabPage();
            tab.Text = "Trang chủ";
            tab.Name = "tpTrangChu";
            tab.ImageIndex = 1;
            tab.Padding = new Padding(0, 0, 0, 0);

            Form frm = new home();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tabControl1.TabPages["tpTrangChu"];

        }


        private void frmTrangChu_Load(object sender, System.EventArgs e)
        {

        }
        private bool ExistTabPage(TabControl control, string tabPageName)
        {
            bool check = false;
            for (int i = 0; i < control.TabPages.Count; i++)
            {
                if (control.TabPages[i].Name == tabPageName)
                {
                    check = true;
                    break;
                }
            }
            return check;

        }
        private void btn_Click(object sender, System.EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Sản Phẩm";
            tab.Name = "tpQLSP";
            tab.ImageIndex = 1;
            tab.Padding = new Padding(0, 0, 0, 0);

            Form frm = new frmTaiKhoan();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            if (!ExistTabPage(tabControl1, "tpQLSP"))
            {
                tabControl1.TabPages.Add(tab);
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpQLSP"];
        }

        

        private void btn5_Click(object sender, System.EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Hóa Đơn";
            tab.Name = "tpQLHD";
            tab.ImageIndex = 1;
            tab.Padding = new Padding(0, 0, 0, 0);

            Form frm = new frmHoaDon();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            if (!ExistTabPage(tabControl1, "tpQLHD"))
            {
                tabControl1.TabPages.Add(tab);
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpQLHD"];
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Nhân Viên";
            tab.Name = "tpQLNV";
            tab.ImageIndex = 1;
            tab.Padding = new Padding(0, 0, 0, 0);

            Form frm = new frmNhanVien();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            if (!ExistTabPage(tabControl1, "tpQLNV"))
            {
                tabControl1.TabPages.Add(tab);
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpQLNV"];
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Thành Viên";
            tab.Name = "tpQLTV";
            tab.ImageIndex = 1;
            tab.Padding = new Padding(0, 0, 0, 0);

            Form frm = new frmThanhVien();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            if (!ExistTabPage(tabControl1, "tpQLTV"))
            {
                tabControl1.TabPages.Add(tab);
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpQLTV"];
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Tài Khoản";
            tab.Name = "tpQLTK";
            tab.ImageIndex = 1;
            tab.Padding = new Padding(0, 0, 0, 0);

            Form frm = new frmTaiKhoan();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            if (!ExistTabPage(tabControl1, "tpQLTK"))
            {
                tabControl1.TabPages.Add(tab);
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpQLTK"];
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            
        }

        private void btnKH_Click(object sender, System.EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Khách Hàng";
            tab.Name = "tpQLKH";
            tab.ImageIndex = 1;
            tab.Padding = new Padding(0, 0, 0, 0);

            Form frm = new frmKhachHang();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            if (!ExistTabPage(tabControl1, "tpQLKH"))
            {
                tabControl1.TabPages.Add(tab);
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpQLKH"];
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
