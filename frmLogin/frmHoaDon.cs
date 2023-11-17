using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLogin
{
    public partial class frmHoaDon : Form
    {
        private frmChiTietHoaDon frmHoaDon1;

        public frmHoaDon()
        {
            InitializeComponent();
            frmHoaDon1 = new frmChiTietHoaDon();
        }

        HoaDonDao hd = new HoaDonDao();
        private BindingSource bindingSource;
        private void btnTaoHoaDon_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmHoaDon1.ShowDialog();
            this.Show();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            loadDSHoaDon();
            bindingSource = new BindingSource();
            bindingSource.DataSource = dgv1.DataSource;

            // Gán BindingSource cho DataGridView
            dgv1.DataSource = bindingSource;
        }
        private void loadDSHoaDon()
        {
            dgv1.DataSource = hd.GetHoaDonList();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra điều kiện tìm kiếm
                string searchCondition = $"TenKH LIKE '%{txtTimKiem.Text}%'";

                // Áp dụng điều kiện tìm kiếm
                bindingSource.Filter = searchCondition;

                // Nếu bạn muốn xóa điều kiện tìm kiếm, hãy sử dụng:
                // bindingSource.RemoveFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
