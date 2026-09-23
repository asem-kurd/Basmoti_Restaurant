//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Restaurant.Models;

////Data/RestaurantContext.cs


//public partial class RestaurantContext : DbContext
//{
//    public RestaurantContext()
//    {
//    }

//    public RestaurantContext(DbContextOptions<RestaurantContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; }

//    public virtual DbSet<MasterItemMenu> MasterItemMenus { get; set; }

//    public virtual DbSet<MasterMenu> MasterMenus { get; set; }

//    public virtual DbSet<MasterOffer> MasterOffers { get; set; }

//    public virtual DbSet<MasterPartner> MasterPartners { get; set; }

//    public virtual DbSet<MasterService> MasterServices { get; set; }

//    public virtual DbSet<MasterSlider> MasterSliders { get; set; }

//    public virtual DbSet<MasterSocialMedium> MasterSocialMedia { get; set; }

//    public virtual DbSet<MasterWorkingHour> MasterWorkingHours { get; set; }

//    public virtual DbSet<SystemSetting> SystemSettings { get; set; }

//    public virtual DbSet<TransactionBookTable> TransactionBookTables { get; set; }

//    public virtual DbSet<TransactionContactU> TransactionContactUs { get; set; }

//    public virtual DbSet<TransactionNewsletter> TransactionNewsletters { get; set; }








//    // newTables
//    public virtual DbSet<MasterWhatPeopleSay> MasterWhatPeopleSay { get; set; }
//    public virtual DbSet<MasterWorkingDay> MasterWorkingDay { get; set; }











//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\SQL2025;Initial Catalog=Restaurant;User ID=sa; password=123;Trust Server Certificate=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<MasterCategoryMenu>(entity =>
//        {
//            entity.Property(e => e.MasterCategoryMenuName).HasDefaultValue("");
//        });

//        modelBuilder.Entity<MasterItemMenu>(entity =>
//        {
//            entity.Property(e => e.MasterItemMenuBreef).HasDefaultValue("");
//            entity.Property(e => e.MasterItemMenuDesc).HasDefaultValue("");
//            entity.Property(e => e.MasterItemMenuImageUrl).HasDefaultValue("");
//            entity.Property(e => e.MasterItemMenuTitle).HasDefaultValue("");

//            entity.HasOne(d => d.MasterCategoryMenu).WithMany(p => p.MasterItemMenus).HasForeignKey(d => d.MasterCategoryMenuId);
//        });

//        modelBuilder.Entity<MasterMenu>(entity =>
//        {
//            entity.Property(e => e.MasterMenuName).HasDefaultValue("");
//            entity.Property(e => e.MasterMenuUrl).HasDefaultValue("");
//        });

//        modelBuilder.Entity<MasterOffer>(entity =>
//        {
//            entity.Property(e => e.MasterOfferBreef).HasDefaultValue("");
//            entity.Property(e => e.MasterOfferDesc).HasDefaultValue("");
//            entity.Property(e => e.MasterOfferImageUrl).HasDefaultValue("");
//            entity.Property(e => e.MasterOfferTitle).HasDefaultValue("");
//        });

//        modelBuilder.Entity<MasterPartner>(entity =>
//        {
//            entity.Property(e => e.MasterPartnerLogoImageUrl).HasDefaultValue("");
//            entity.Property(e => e.MasterPartnerName).HasDefaultValue("");
//            entity.Property(e => e.MasterPartnerWebsiteUrl).HasDefaultValue("");
//        });

//        modelBuilder.Entity<MasterService>(entity =>
//        {
//            entity.HasKey(e => e.MasterServicesId);

//            entity.Property(e => e.MasterServicesDesc).HasDefaultValue("");
//            entity.Property(e => e.MasterServicesImage).HasDefaultValue("");
//            entity.Property(e => e.MasterServicesTitle).HasDefaultValue("");
//        });

//        modelBuilder.Entity<MasterSlider>(entity =>
//        {
//            entity.Property(e => e.MasterSliderBreef).HasDefaultValue("");
//            entity.Property(e => e.MasterSliderDesc).HasDefaultValue("");
//            entity.Property(e => e.MasterSliderImageUrl).HasDefaultValue("");
//            entity.Property(e => e.MasterSliderTitle).HasDefaultValue("");
//        });

//        modelBuilder.Entity<MasterSocialMedium>(entity =>
//        {
//            entity.HasKey(e => e.MasterSocialMediaId);

//            entity.Property(e => e.MasterSocialMediaImageUrl).HasDefaultValue("");
//            entity.Property(e => e.MasterSocialMediaUrl).HasDefaultValue("");
//        });

//        modelBuilder.Entity<MasterWorkingHour>(entity =>
//        {
//            entity.HasKey(e => e.MasterWorkingHoursId);

//            entity.Property(e => e.MasterWorkingHoursName).HasDefaultValue("");
//            entity.Property(e => e.MasterWorkingHoursTimeFormTo).HasDefaultValue("");
//        });

//        modelBuilder.Entity<SystemSetting>(entity =>
//        {
//            entity.Property(e => e.SystemSettingCopyright).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingLogoImageUrl).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingLogoImageUrl2).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingMapLocation).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingWelcomeNoteBreef).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingWelcomeNoteDesc).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingWelcomeNoteImageUrl).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingWelcomeNoteTitle).HasDefaultValue("");
//            entity.Property(e => e.SystemSettingWelcomeNoteUrl).HasDefaultValue("");
//        });

//        modelBuilder.Entity<TransactionBookTable>(entity =>
//        {
//            entity.Property(e => e.TransactionBookTableEmail).HasDefaultValue("");
//            entity.Property(e => e.TransactionBookTableFullName).HasDefaultValue("");
//            entity.Property(e => e.TransactionBookTableMobileNumber).HasDefaultValue("");
//        });

//        modelBuilder.Entity<TransactionContactU>(entity =>
//        {
//            entity.HasKey(e => e.TransactionContactUsId);

//            entity.Property(e => e.TransactionContactUsEmail).HasDefaultValue("");
//            entity.Property(e => e.TransactionContactUsFullName).HasDefaultValue("");
//            entity.Property(e => e.TransactionContactUsMessage).HasDefaultValue("");
//            entity.Property(e => e.TransactionContactUsSubject).HasDefaultValue("");
//        });

//        modelBuilder.Entity<TransactionNewsletter>(entity =>
//        {
//            entity.Property(e => e.TransactionNewsletterEmail).HasDefaultValue("");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
