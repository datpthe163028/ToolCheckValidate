namespace CheckValidate.App.LoudSpeaker.Model
{
    public class RequestModelApi1
    {
        public string NguonId { get; set; } = null!;
        public string CumLoaId { get; set; } = null!;

        public int MaXacThuc { get; set; }
    }

    public class RequestModelApi2
    {
        public string NguonId { get; set; } = null!;

        public string CumLoaId { get; set; } = null!;

        public string DiaBanQuanLy { get; set; }
    }

    public class RequestModelApi3
    {
        public string NguonId { get; set; } = null!;

        public string CumLoaId { get; set; } = null!;
    }

    public class RequestModelApi4
    {
        public string NguonId { get; set; } = null!;
        public string CumLoaId { get; set; } = null!;

        public int AmLuong { get; set; }
    }


    public class RequestModelApi5
    {
        public string NguonId { get; set; } = null!;
        public string BanTinId { get; set; } = null!;
        public string NgayBatDau { get; set; } = null!;
        public string NgayKetThuc { get; set; } = null!;
        public int CheDoPhat { get; set; }
        public LichPhatModel LichPhat { get; set; } = null!;
        public string TieuDe { get; set; } = null!;
        public string LinhVuc { get; set; } = null!;
        public string NoiDungTomTat { get; set; } = null!;
        public string ThoiGianSanXuat { get; set; } = null!;
        public int ThoiLuong { get; set; }
        public string TacGia { get; set; } = null!;
        public NoiDungModel NoiDung { get; set; }
        public string DiaBanTao { get; set; } = null!;
        public string[] DanhSachDiaBanNhan { get; set; }
    }
    
    public class RequestModelApi6
    {
        public string NguonId { get; set; } = null!;
        public string BanTinId { get; set; } = null!;
    }
    
    public class RequestModelApi7
    {
        public string NguonId { get; set; } = null!;
        public string BanTinId { get; set; } = null!;
        public string NgayBatDau { get; set; } = null!;
        public string NgayKetThuc { get; set; } = null!;
        public int CheDoPhat { get; set; }
        public LichPhatModel LichPhat { get; set; } = null!;
    }
    
    public class RequestModelApi8
    {
        public string NguonId { get; set; } = null!;
        public string CumLoaId { get; set; } = null!;
        public int TrangThaiHoatDong { get; set; } 
        public int TrangThaiKetNoi { get; set; }
        public int AmLuong { get; set; }
    }
    
    public class RequestModelApi9
    {
        public string NguonId { get; set; } = null!;
        public string BanTinId { get; set; } = null!;
        public string ThoiDiemGui { get; set; } = null!;
        public string LoaiNhatKy { get; set; } = null!;
        public int GiaTri { get; set; }
    }
    
    public class LichPhatModel
    {
        public string[] ThoiDiemBatDau { get; set; } = null!;
        public string[] ThoiDiemKetThuc { get; set; } = null!;
        public int KieuLich { get; set; }
        public int[] DanhSachNgayPhat { get; set; } = null!;
    }
    
    public class NoiDungModel
    {
        public string Link { get; set; } = null!;
        public long tanso { get; set; }
        public int thoigian { get; set; }
        public int order { get; set; } 
    }
}