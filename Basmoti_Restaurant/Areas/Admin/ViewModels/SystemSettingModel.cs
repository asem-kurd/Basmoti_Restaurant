using System.ComponentModel.DataAnnotations;


namespace Basmoti_Restaurant.Areas.Admin.ViewModels;


public class SystemSettingModel
{
    public int SystemSettingId { get; set; }

    [Display(Name = "Logo1")]
    public IFormFile? File1 { get; set; }
    [Display(Name = "Logo2")]
    public IFormFile? File2 { get; set; }
    [Display(Name = "Welcome Note Image")]
    public IFormFile? File3 { get; set; }

    public string? SystemSettingLogoImageUrl1 { get; set; }
    public string? SystemSettingLogoImageUrl2 { get; set; }
    public string? SystemSettingWelcomeNoteImageUrl { get; set; }

    [Required(ErrorMessage = "Copyright is required")]
    public string SystemSettingCopyright { get; set; } = string.Empty;

    [Required(ErrorMessage = "Title is required")]
    public string SystemSettingWelcomeNoteTitle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Brief is required")]
    public string SystemSettingWelcomeNoteBreef { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    public string SystemSettingWelcomeNoteDesc { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone is required")]
    public string SystemSettingPhone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string SystemSettingEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Url is required")]
    public string SystemSettingWelcomeNoteUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "Map location is required")]
    public string SystemSettingMapLocation { get; set; } = string.Empty;

    [Required(ErrorMessage = "Map location url is required")]
    public string SystemSettingMapLocationUrl { get; set; } = string.Empty;
}