using BaiTapOnTap.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapOnTap.DAL
{
    class TestDbContext : DbContext
    {
        public TestDbContext() : base("Data Source=.;Initial Catalog=SinhVienDb;Persist Security Info=True;User ID=sa;Password=123")
        {

        }
        public DbSet<SinhVien> sinhvien { get; set; }
    }
}
