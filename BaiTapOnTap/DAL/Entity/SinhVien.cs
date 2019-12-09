using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapOnTap.DAL.Entity
{
    class SinhVien
    {
        [Key]
        public String MaSV { get; set; }
        public String HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public String GioiTinh { get; set; }
        public String ChuyenNganh { get; set; }
        public float Diem1 { get; set; }
        public float Diem2 { get; set; }
        public static List<SinhVien> GetListFromDb()
        {
            return new TestDbContext().sinhvien.ToList();
        }
        public static void Xoa(SinhVien sv)
        {
            var db = new TestDbContext();
            var objSV = db.sinhvien.Where(e => e.MaSV == sv.MaSV).FirstOrDefault();
            if (objSV != null)
            {
                db.sinhvien.Remove(objSV);
            }
            db.SaveChanges();
        }
        public static void Add(SinhVien sv)
        {
            var db = new TestDbContext();
            db.sinhvien.Add(sv);
            try {
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Chọn sinh viên để thao tác");
            }
        }
    }
}
