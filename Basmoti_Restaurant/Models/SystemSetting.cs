using System;
using System.Collections.Generic;

namespace Restaurant.Models;



// Any thing Else
public partial class SystemSetting : BaseEntity
{
    public int SystemSettingId { get; set; }

    public string SystemSettingLogoImageUrl { get; set; } = null!;

    public string SystemSettingLogoImageUrl2 { get; set; } = null!;

    public string SystemSettingCopyright { get; set; } = null!;

    public string SystemSettingWelcomeNoteTitle { get; set; } = null!;

    public string SystemSettingWelcomeNoteBreef { get; set; } = null!;

    public string SystemSettingWelcomeNoteDesc { get; set; } = null!;




// contact us

    public string SystemSettingPhone { get; set; } = null!;
    public string SystemSettingEmail { get; set; } = null!;

    public string SystemSettingSocialMediaIcon { get; set; } = null!;
    public string SystemSettingSocialMediaIconUrl { get; set; } = null!;




    public string SystemSettingWelcomeNoteUrl { get; set; } = null!;

    public string SystemSettingWelcomeNoteImageUrl { get; set; } = null!;

    public string SystemSettingMapLocation { get; set; } = null!;
    public string SystemSettingMapLocationUrl { get; set; } = null!;
}
