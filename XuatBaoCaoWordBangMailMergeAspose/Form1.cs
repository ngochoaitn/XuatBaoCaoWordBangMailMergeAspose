using Aspose.Words;//Thêm thư viện này (file Dll\Aspose.Word.dll)
using Aspose.Words.Tables;
using System;
using System.Windows.Forms;
using ThuVienWinform.Report.AsposeWordExtension;//thêm thư viện này (File Lib\ReportExtentionMethod.cs)

namespace XuatBaoCaoWordBangMailMergeAspose
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            var homNay = DateTime.Now;
            //Bước 1: Nạp file mẫu
            Document baoCao = new Document("Template\\Mau_Bao_Cao.doc");

            //Bước 2: Điền các thông tin cố định
            baoCao.MailMerge.Execute(new[] { "Ngay_Thang_Nam_BC" }, new[] { string.Format("Bắc Kạn, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });
            baoCao.MailMerge.Execute(new[] { "Ho_Ten" }, new[] { txtHoTen.Text });
            baoCao.MailMerge.Execute(new[] { "Ngay_Sinh" }, new[] { dateNgaySinh.Value.ToString("dd/MM/yyyy") });
            baoCao.MailMerge.Execute(new[] { "SDT" }, new[] { txtSoDienThoai.Text });
            baoCao.MailMerge.Execute(new[] { "Que_Quan" }, new[] { txtQueQuan.Text });
            baoCao.MailMerge.Execute(new[] { "Nguoi_Yeu" }, new[] { "Sơn Tùng MTP" });
            baoCao.MailMerge.Execute(new[] { "Nguoi_Giam_Ho" }, new[] { "Nguyễn Văn A" });

            //Bước 3: Điền thông tin lên bảng
            Table bangThongTinGiaDinh = baoCao.GetChild(NodeType.Table, 1, true) as Table;//Lấy bảng thứ 2 trong file mẫu
            int hangHienTai = 1;
            bangThongTinGiaDinh.InsertRows(hangHienTai, hangHienTai, 3);
            for (int i = 1; i <= 4; i++)
            {
                bangThongTinGiaDinh.PutValue(hangHienTai, 0, i.ToString());//Cột STT
                bangThongTinGiaDinh.PutValue(hangHienTai, 1, "Nguyễn Văn A");//Cột Họ và tên
                bangThongTinGiaDinh.PutValue(hangHienTai, 2, "Bố đẻ");//Cột quan hệ
                bangThongTinGiaDinh.PutValue(hangHienTai, 3, "0123456789");//Cột Số điện thoại
                hangHienTai++;
            }

            //Bước 4: Lưu và mở file
            baoCao.SaveAndOpenFile("BaoCao.doc");
        }
    }
}
