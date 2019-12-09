using BaiTapOnTap.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapOnTap
{
    public partial class Form1 : Form
    {
        private List<SinhVien> ds;
        private bool press;

        public Form1()
        {
            InitializeComponent();
            ds = SinhVien.GetListFromDb();
            Load();
            tbx1.Text = ds[0].HoTen;
            tbx2.Text = ds[0].GioiTinh;
            dt2.Value = ds[0].NgaySinh;
            lbl1.Text = ((ds[0].Diem1 + ds[0].Diem2) / 2).ToString();
            this.Text += " - LÊ VĂN DŨNG";
            foreach (TabPage tab in tcl1.TabPages)
            {
                if (ds[0].ChuyenNganh.Equals(tab.Text))
                {
                    tcl1.SelectedTab = tab;
                    if (tab.Text.Equals("Văn"))
                    {
                        dv1.Text = ds[0].Diem1.ToString();
                        dv2.Text = ds[0].Diem2.ToString();
                    }
                    if (tab.Text.Equals("Vật lý"))
                    {
                        dl1.Text = ds[0].Diem1.ToString();
                        dl2.Text = ds[0].Diem2.ToString();
                    }
                    if (tab.Text.Equals("CNTT"))
                    {
                        dc1.Text = ds[0].Diem1.ToString();
                        dc2.Text = ds[0].Diem2.ToString();
                    }
                }
            }



        }

        public new void Load(string k = "")
        {
            clb1.Items.Clear();
            ds = SinhVien.GetListFromDb();
            foreach (SinhVien s in ds)
            {
                String key;
                if (s.GioiTinh.ToString().Equals("Nữ"))
                    key = "Chị " + s.HoTen;
                else
                    key = "Anh " + s.HoTen;
                if (key.Trim().ToLower().Contains(k.ToLower()))
                {
                    if (s.GioiTinh.ToString().Equals("Nữ"))
                    {
                        clb1.Items.Add("Chị: " + s.HoTen);
                    }
                    else
                    {
                        clb1.Items.Add("Anh: " + s.HoTen);
                    }
                    
                }
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            SinhVien sve = new SinhVien();
            if (clb1.SelectedIndices != null)
            {
                foreach (int i in clb1.SelectedIndices)
                {
                    String msv = ds[i].MaSV;
                    String cn = ds[i].ChuyenNganh;
                    sve.MaSV = msv;
                    sve.HoTen = tbx1.Text;
                    sve.GioiTinh = tbx2.Text;
                    sve.NgaySinh = dt2.Value;
                    sve.ChuyenNganh = cn;
                    try
                    {
                        if (!dv1.Text.Equals("") && !dv2.Text.Equals(""))
                        {
                            sve.Diem1 = float.Parse(dv1.Text);
                            sve.Diem2 = float.Parse(dv2.Text);
                            dl1.Text = "";
                            dl2.Text = "";
                            dc1.Text = "";
                            dc2.Text = "";
                        }
                        else if (!dl1.Text.Equals("") && !dl2.Text.Equals(""))
                        {
                            sve.Diem1 = float.Parse(dl1.Text);
                            sve.Diem2 = float.Parse(dl2.Text);
                            dv1.Text = "";
                            dv2.Text = "";
                            dc1.Text = "";
                            dc2.Text = "";
                        }
                        else
                        {
                            sve.Diem1 = float.Parse(dc1.Text);
                            sve.Diem2 = float.Parse(dc2.Text);
                            dl1.Text = "";
                            dl2.Text = "";
                            dv1.Text = "";
                            dv2.Text = "";
                        }
                        if (sve.Diem1 >= 0 && sve.Diem1 <= 10 && sve.Diem2 >= 0 && sve.Diem2 <= 10)
                        {
                            SinhVien.Xoa(ds[i]);
                            SinhVien.Add(sve);
                            lbl1.Text = ((sve.Diem1 + sve.Diem2) / 2).ToString();
                        }
                        else
                            MessageBox.Show("Điểm không hợp lệ", "Thông báo");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Điểm không hợp lệ", "Thông báo");
                    }
                }
            }
            txtdl.Text = "";
            Load();
            MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                List<SinhVien> toRemove = new List<SinhVien>();
                foreach (int index in clb1.CheckedIndices)
                {
                    SinhVien.Xoa(ds[index]);
                }
                Load();
                MessageBox.Show("Đã xóa!", "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Clb1_SelectedIndexChanged(object sender, EventArgs e)
        {

            dv1.Text = "";
            dv2.Text = "";
            dl1.Text = "";
            dl2.Text = "";
            dc1.Text = "";
            dc2.Text = "";
            foreach (int i in clb1.SelectedIndices)
            {
                tbx1.Text = ds[i].HoTen.ToString();
                tbx2.Text = ds[i].GioiTinh.ToString();
                dt2.Value = ds[i].NgaySinh;
                lbl1.Text = ((ds[i].Diem1 + ds[i].Diem2) / 2).ToString();
                foreach (TabPage tab in tcl1.TabPages)
                {
                    if (ds[i].ChuyenNganh.Equals(tab.Text))
                    {
                        tcl1.SelectedTab = tab;
                        if (tab.Text.Equals("Văn"))
                        {
                            dv1.Text = ds[i].Diem1.ToString();
                            dv2.Text = ds[i].Diem2.ToString();
                        }
                        if (tab.Text.Equals("Vật lý"))
                        {
                            dl1.Text = ds[i].Diem1.ToString();
                            dl2.Text = ds[i].Diem2.ToString();
                        }
                        if (tab.Text.Equals("CNTT"))
                        {
                            dc1.Text = ds[i].Diem1.ToString();
                            dc2.Text = ds[i].Diem2.ToString();
                        }
                    }
                }
            }
            if (!txtdl.Text.Equals(""))
            {
                String s = clb1.SelectedItem.ToString();
                s = s.Substring(4);
                foreach (SinhVien i in ds)
                {
                    if (i.HoTen.Trim().Equals(s.Trim()))
                    {
                        tbx1.Text = i.HoTen.ToString();
                        tbx2.Text = i.GioiTinh;
                        dt2.Value = i.NgaySinh;
                        lbl1.Text = ((i.Diem1 + i.Diem2) / 2).ToString();
                        foreach (TabPage tab in tcl1.TabPages)
                        {
                            if (i.ChuyenNganh.Equals(tab.Text))
                            {
                                tcl1.SelectedTab = tab;
                                if (tab.Text.Equals("Văn"))
                                {
                                    dv1.Text = i.Diem1.ToString();
                                    dv2.Text = i.Diem2.ToString();
                                }
                                if (tab.Text.Equals("Vật lý"))
                                {
                                    dl1.Text = i.Diem1.ToString();
                                    dl2.Text = i.Diem2.ToString();
                                }
                                if (tab.Text.Equals("CNTT"))
                                {
                                    dc1.Text = i.Diem1.ToString();
                                    dc2.Text = i.Diem2.ToString();
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private void Txtdl_KeyPress(object sender, KeyPressEventArgs e)
        {
            press = true;
        }

        private void ToolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            var f = new formBoSung();
            f.ShowDialog();
            txtdl.Text = "";
            Load();
        }

        private void Txtdl_TextChanged(object sender, EventArgs e)
        {
            Load(txtdl.Text);
        }

        private void Dc1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
