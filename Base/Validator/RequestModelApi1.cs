using System.Globalization;
using CheckValidate.App.LoudSpeaker.Model;
using FluentValidation;

namespace CheckValidate.Base.Validator
{
    public class RequestModelApi1Validator : AbstractValidator<RequestModelApi1>
    {
        public RequestModelApi1Validator()
        {
            RuleFor(x => x.NguonId).NotEmpty();
            RuleFor(x => x.CumLoaId).NotEmpty();
        }
    }
    
    
    public class RequestModelApi2Validator : AbstractValidator<RequestModelApi2>
    {
        public RequestModelApi2Validator()
        {
            RuleFor(x => x.CumLoaId).NotEmpty();
            RuleFor(x => x.DiaBanQuanLy).NotEmpty();
            RuleFor(x => x.NguonId).NotEmpty();
        }
    }
    
    
    public class RequestModelApi3Validator : AbstractValidator<RequestModelApi3>
    {
        public RequestModelApi3Validator()
        {
            RuleFor(x => x.CumLoaId).NotEmpty();
            RuleFor(x => x.NguonId).NotEmpty();
        }
    }
    
    public class RequestModelApi4Validator : AbstractValidator<RequestModelApi4>
    {
        public RequestModelApi4Validator()
        {
            RuleFor(x => x.CumLoaId).NotEmpty();
            RuleFor(x => x.NguonId).NotEmpty();
        }
    }
    
    public class RequestModelApi5Validator : AbstractValidator<RequestModelApi5>
    {
        public RequestModelApi5Validator()
        {
            RuleFor(x => x.NguonId).NotEmpty();
            RuleFor(x => x.BanTinId).NotEmpty();
            RuleFor(x => x.NgayBatDau).NotEmpty().Must(BeValidDateTime).WithMessage("Invalid DateTime (ex: 2021-12-31T00:00:00.00000 )");
            RuleFor(x => x.NgayKetThuc).NotEmpty().Must(BeValidDateTime).WithMessage("Invalid DateTime (ex: 2021-12-31T00:00:00.00000) ");
            RuleFor(x => x.LichPhat.KieuLich).InclusiveBetween(0, 3);
            RuleFor(x => x.LichPhat.ThoiDiemBatDau).NotEmpty().Must(ValidateDateTime).WithMessage("Invalid Time (ex: 09:05:58.988927)");
            RuleFor(x => x.LichPhat.ThoiDiemKetThuc).NotEmpty().Must(ValidateDateTime).WithMessage("Invalid Time (ex: 09:05:58.988927)");
            RuleFor(x => x.CheDoPhat).InclusiveBetween(0, 2);
            RuleFor(x => x.TieuDe).NotEmpty();
            RuleFor(x => x.LinhVuc).NotEmpty();
            RuleFor(x => x.NoiDungTomTat).NotEmpty();
            RuleFor(x => x.ThoiGianSanXuat).NotEmpty();
            RuleFor(x => x.ThoiGianSanXuat).NotEmpty();
            RuleFor(x => x.ThoiLuong).GreaterThanOrEqualTo(0);
            RuleFor(x => x.TacGia).NotEmpty();
            RuleFor(x => x.DiaBanTao).NotEmpty();
            RuleFor(x => x.DanhSachDiaBanNhan).NotEmpty();
            RuleFor(x => x.NoiDung.Link).NotEmpty();
        }
        private bool BeValidDateTime(string input)
        {
            if (DateTime.TryParse(input, out DateTime result))
            {
                return true;
            }
            return false;
        }
        private bool ValidateDateTime(string[] inputs)
        {
            if (inputs == null)
                return false;

            foreach (var input in inputs)
            {
                if (!DateTime.TryParseExact(input, "HH:mm:ss.ffffff", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    
    public class RequestModelApi6Validator : AbstractValidator<RequestModelApi6>
    {
        public RequestModelApi6Validator()
        {
            RuleFor(x => x.NguonId).NotEmpty();
            RuleFor(x => x.BanTinId).NotEmpty();
        }
    }
    
    public class RequestModelApi7Validator : AbstractValidator<RequestModelApi7>
    {
        public RequestModelApi7Validator()
        {
            RuleFor(x => x.NguonId).NotEmpty();
            RuleFor(x => x.BanTinId).NotEmpty();
            RuleFor(x => x.NgayBatDau).NotEmpty().Must(BeValidDateTime).WithMessage("Invalid DateTime");
            RuleFor(x => x.NgayKetThuc).NotEmpty().Must(BeValidDateTime).WithMessage("Invalid DateTime");
            RuleFor(x => x.CheDoPhat).InclusiveBetween(0, 2);
        }
        
        private bool BeValidDateTime(string input)
        {
            if (DateTime.TryParse(input, out DateTime result))
            {
                return true;
            }
            return false;
        }
    }
    
    public class RequestModelApi8Validator : AbstractValidator<RequestModelApi8>
    {
        public RequestModelApi8Validator()
        {
            RuleFor(x => x.NguonId).NotEmpty();
            RuleFor(x => x.CumLoaId).NotEmpty();
        }
    }
    
    public class RequestModelApi9Validator : AbstractValidator<RequestModelApi9>
    {
        public RequestModelApi9Validator()
        {
            RuleFor(x => x.NguonId).NotEmpty();
            RuleFor(x => x.BanTinId).NotEmpty();
            RuleFor(x => x.ThoiDiemGui).NotEmpty();
            RuleFor(x => x.LoaiNhatKy).NotEmpty();
            RuleFor(x => x.GiaTri).InclusiveBetween(0, 1);
        }
    }
    
}
