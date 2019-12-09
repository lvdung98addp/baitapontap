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
    public partial class formBoSung : Form
    {
        private List<SinhVien> dssv;
        public formBoSung()
        {
            InitializeComponent();
            cb2.SelectedIndex = 0;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int kt = 0;
            if (tbMSV.Text.Equals("") || tbHT.Text.Equals("") || tbGT.Text.Equals("")  || tbD1.Text.Equals("")
                || tbD2.Text.Equals("")) 
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
            else
            {
                dssv = SinhVien.GetListFromDb();
                foreach (SinhVien i in dssv)
                {
                    if (i.MaSV.Trim().ToLower().Equals(tbMSV.Text.ToLower()))
                    {
                        kt = 1;
                        MessageBox.Show("Trùng mã sinh viên");
                    }
                }
                if (kt == 0)
                {
                    var SvM = new SinhVien
                    {
                        MaSV = tbMSV.Text,
                        HoTen = tbHT.Text,
                        GioiTinh = tbGT.Text,
                        NgaySinh = dt1.Value,
                        ChuyenNganh = cb2.SelectedItem.ToString(),
                        Diem1 = float.Parse(tbD1.Text),
                        Diem2 = float.Parse(tbD2.Text),
                    };
                    if (SvM.Diem1 >= 0 && SvM.Diem1 <= 10 && SvM.Diem2 >= 0 && SvM.Diem2 <= 10)
                    {
                        SinhVien.Add(SvM);
                        MessageBox.Show("Đã thêm sinh viên " + tbHT.Text , "Thông báo");
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Điểm không hợp lệ", "Thông báo");
                }

                //this.Close();
            }

          }

     }
}

