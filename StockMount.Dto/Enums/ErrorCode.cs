using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Enums
{
    public enum ErrorCode
    {
        [Display(Name = "Hatalı")]
        Error = 300,
        [Display(Name = "Başarılı")]
        Success = 100,
        [Display(Name = "Bilgilendirme")]
        Info = 400,
        [Display(Name = "Uyarı")]
        Warning = 200,

    }
}
