using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;



// Any thing Else
public partial class SystemSetting : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int SystemSettingId { get; set; }

    [Display(Name = "Logo")]
    public string? SystemSettingLogoImageUrl1 { get; set; }

    [Display(Name = "Logo2")]
    public string? SystemSettingLogoImageUrl2 { get; set; }

    [Display(Name = "Copyright")]
    public string SystemSettingCopyright { get; set; } = null!;

    [Display(Name = "Title")]
    public string SystemSettingWelcomeNoteTitle { get; set; } = null!;

    [Display(Name = "Breef")]
    public string SystemSettingWelcomeNoteBreef { get; set; } = null!;

    [Display(Name = "Description")]
    public string SystemSettingWelcomeNoteDesc { get; set; } = null!;




    // contact us

    [Display(Name = "Phone")]
    public string SystemSettingPhone { get; set; } = null!;

    [Display(Name = "Email")]
    public string SystemSettingEmail { get; set; } = null!;

    [Display(Name = "Welcome Note Url")]
    public string SystemSettingWelcomeNoteUrl { get; set; } = null!;
    
    [Display(Name = "Welcome Note Image")]  
    public string? SystemSettingWelcomeNoteImageUrl { get; set; }

    [Display(Name = "Map Location")]
    public string SystemSettingMapLocation { get; set; } = null!;
    [Display(Name = "Map Location Url")]    
    public string SystemSettingMapLocationUrl { get; set; } = null!;
}
