using System;
using System.Collections.Generic;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class UGymContext : DbContext
    {
        public UGymContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<UGymContext> ();
            optionBuilder.UseSqlServer(Util.ConnectionString);
        }

        public UGymContext(DbContextOptions<UGymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ads { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<CoachesClass> CoachesClasses { get; set; } = null!;
        public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Exercice> Exercices { get; set; } = null!;
        public virtual DbSet<MembFile> MembFiles { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MembersCoachesClass> MembersCoachesClasses { get; set; } = null!;
        public virtual DbSet<MembersMembershipType> MembersMembershipTypes { get; set; } = null!;
        public virtual DbSet<MembersPaymentFrequency> MembersPaymentFrequencies { get; set; } = null!;
        public virtual DbSet<MembersRoutinesExercice> MembersRoutinesExercices { get; set; } = null!;
        public virtual DbSet<MembershipType> MembershipTypes { get; set; } = null!;
        public virtual DbSet<NutritionPlan> NutritionPlans { get; set; } = null!;
        public virtual DbSet<PaymentFrequency> PaymentFrequencies { get; set; } = null!;
        public virtual DbSet<Qrcode> Qrcodes { get; set; } = null!;
        public virtual DbSet<RepCardsEvaluation> RepCardsEvaluations { get; set; } = null!;
        public virtual DbSet<RepCardsInbody> RepCardsInbodies { get; set; } = null!;
        public virtual DbSet<RepCardsTherapy> RepCardsTherapies { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Routine> Routines { get; set; } = null!;
        public virtual DbSet<RoutinesExercice> RoutinesExercices { get; set; } = null!;
        public virtual DbSet<Space> Spaces { get; set; } = null!;
        public virtual DbSet<Template> Templates { get; set; } = null!;
        public virtual DbSet<TemplatesExercice> TemplatesExercices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.Property(e => e.MediaLink).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Ads)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ads_Employees");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admins_Roles");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.DateAttendance).HasColumnType("date");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Members");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CoachesClass>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.CoachId })
                    .HasName("PK__CoachesC__C4583A5448925A07");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.CoachesClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoachesClasses_Classes");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.CoachesClasses)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoachesClasses_Employees");
            });

            modelBuilder.Entity<EmergencyContact>(entity =>
            {
                entity.ToTable("EmergencyContact");

                entity.Property(e => e.FullName).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.Gender).HasMaxLength(15);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.HasOne(d => d.EmergencyContact)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmergencyContactId)
                    .HasConstraintName("FK_Employees_ContactoEmergencia");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Roles");
            });

            modelBuilder.Entity<Exercice>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Video).HasMaxLength(250);
            });

            modelBuilder.Entity<MembFile>(entity =>
            {
                entity.ToTable("MembFile");

                entity.Property(e => e.AlergyMeds).HasMaxLength(100);

                entity.Property(e => e.AttendanceMotivation).HasMaxLength(20);

                entity.Property(e => e.AutoReg).HasMaxLength(50);

                entity.Property(e => e.ChestPain).HasMaxLength(50);

                entity.Property(e => e.CirguriesType).HasMaxLength(100);

                entity.Property(e => e.DetailCirguries).HasMaxLength(100);

                entity.Property(e => e.FatDifLoss).HasMaxLength(50);

                entity.Property(e => e.HeartDis).HasMaxLength(100);

                entity.Property(e => e.LmonthEnergy)
                    .HasMaxLength(50)
                    .HasColumnName("LMonthEnergy");

                entity.Property(e => e.StressNutrition).HasMaxLength(25);

                entity.Property(e => e.ThreeMonthEx).HasMaxLength(5);

                entity.Property(e => e.TypeMeds).HasMaxLength(100);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.Gender).HasMaxLength(15);

                entity.Property(e => e.KnowGym).HasMaxLength(150);

                entity.Property(e => e.MobileNumber).HasMaxLength(15);

                entity.Property(e => e.Motivation).HasMaxLength(250);

                entity.Property(e => e.Ocupation).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.QrcodeId).HasColumnName("QRCodeId");

                entity.HasOne(d => d.EmergencyContact)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.EmergencyContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_EmergencyContact");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Members_Employees");

                entity.HasOne(d => d.MembFile)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.MembFileId)
                    .HasConstraintName("FK_Members_MembFile");

                entity.HasOne(d => d.Qrcode)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.QrcodeId)
                    .HasConstraintName("FK_Members_QRCode");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Roles");
            });

            modelBuilder.Entity<MembersCoachesClass>(entity =>
            {
                entity.HasKey(e => new { e.ClassesId, e.CoachId, e.MemberId })
                    .HasName("PK__MembersC__E415371EE5432705");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MembersCoachesClasses)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersCoachesClasses_Members");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.MembersCoachesClasses)
                    .HasForeignKey(d => new { d.CoachId, d.ClassesId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersCoachesClasses_Classes");
            });

            modelBuilder.Entity<MembersMembershipType>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.MembershipTypeId })
                    .HasName("PK__MembersM__83C5E8FF5E0FCAE6");

                entity.Property(e => e.DateExp).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MembersMembershipTypes)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersMembershipTypes_Members");

                entity.HasOne(d => d.MembershipType)
                    .WithMany(p => p.MembersMembershipTypes)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersMembershipTypes_MembershipTypes");
            });

            modelBuilder.Entity<MembersPaymentFrequency>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.PaymentId })
                    .HasName("PK__MembersP__95451DBB901B12E5");

                entity.ToTable("MembersPaymentFrequency");

                entity.Property(e => e.DatePayment).HasColumnType("date");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MembersPaymentFrequencies)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersPaymentFrequency_Members");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.MembersPaymentFrequencies)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersPaymentFrequency_PaymentFrequency");
            });

            modelBuilder.Entity<MembersRoutinesExercice>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.RoutineId, e.ExerciseId })
                    .HasName("PK__MembersR__983E01FA43A1D647");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MembersRoutinesExercices)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersRoutinesExercices_Members");

                entity.HasOne(d => d.RoutinesExercice)
                    .WithMany(p => p.MembersRoutinesExercices)
                    .HasForeignKey(d => new { d.RoutineId, d.ExerciseId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersRoutinesExercices_RoutinesExercices");
            });

            modelBuilder.Entity<MembershipType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<NutritionPlan>(entity =>
            {
                entity.ToTable("NutritionPlan");

                entity.Property(e => e.DateLoad).HasColumnType("date");

                entity.Property(e => e.NutritionPlan1)
                    .HasMaxLength(500)
                    .HasColumnName("NutritionPlan");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.NutritionPlans)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NutritionPlan_Employees");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.NutritionPlans)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NutritionPlan_Members");
            });

            modelBuilder.Entity<PaymentFrequency>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__PaymentF__9B556A38BD3E8835");

                entity.ToTable("PaymentFrequency");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Qrcode>(entity =>
            {
                entity.ToTable("QRCode");

                entity.Property(e => e.QrcodeId).HasColumnName("QRCodeId");

                entity.Property(e => e.LinkQr)
                    .HasMaxLength(500)
                    .HasColumnName("LinkQR");
            });

            modelBuilder.Entity<RepCardsEvaluation>(entity =>
            {
                entity.HasKey(e => e.RepCardEvaluationId)
                    .HasName("PK__RepCards__B2C9D194D5BA5DE5");

                entity.ToTable("RepCardsEvaluation");

                entity.Property(e => e.DateLoad).HasColumnType("date");

                entity.Property(e => e.LinkRepCardEvaluation).HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RepCardsEvaluations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepCardsEvaluation_Employees");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RepCardsEvaluations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepCardsEvaluation_Members");
            });

            modelBuilder.Entity<RepCardsInbody>(entity =>
            {
                entity.HasKey(e => e.InformeInbodyId)
                    .HasName("PK__RepCards__BE1896F21EA319D5");

                entity.ToTable("RepCardsInbody");

                entity.Property(e => e.DateLoad).HasColumnType("date");

                entity.Property(e => e.LinkRepCardeInbody).HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RepCardsInbodies)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepCardsInbody_Employees");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RepCardsInbodies)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepCardsInbody_Members");
            });

            modelBuilder.Entity<RepCardsTherapy>(entity =>
            {
                entity.HasKey(e => e.RepCardTherapyId)
                    .HasName("PK__RepCards__168AEDB187AAE7C5");

                entity.ToTable("RepCardsTherapy");

                entity.Property(e => e.DateLoad).HasColumnType("date");

                entity.Property(e => e.LinkRepCardTherapy).HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RepCardsTherapies)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepCardsTherapy_Employees");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RepCardsTherapies)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepCardsTherapy_Members");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ReportDate).HasColumnType("text");

                entity.Property(e => e.ReportName).HasMaxLength(1);

                entity.Property(e => e.ReportType).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reports_Employees");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.DateReservation).HasColumnType("date");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Members");

                entity.HasOne(d => d.Spaces)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.SpacesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Spaces");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolesId)
                    .HasName("PK__Roles__C4B27840B816DF4E");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Routine>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.DateCreation).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Routines)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Routines_Employees");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Routines)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK_Routines_Template");
            });

            modelBuilder.Entity<RoutinesExercice>(entity =>
            {
                entity.HasKey(e => new { e.RoutineId, e.ExerciseId })
                    .HasName("PK__Routines__4CE4AE2810A25CE1");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.RoutinesExercices)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoutinesExercices_Exercices");

                entity.HasOne(d => d.Routine)
                    .WithMany(p => p.RoutinesExercices)
                    .HasForeignKey(d => d.RoutineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoutinesExercices_Routines");
            });

            modelBuilder.Entity<Space>(entity =>
            {
                entity.HasKey(e => e.SpacesId)
                    .HasName("PK__Spaces__315A9E0EF623EB9A");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("Template");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TemplatesExercice>(entity =>
            {
                entity.HasKey(e => new { e.TemplateId, e.ExerciceId })
                    .HasName("PK__Template__E5A664CFDDAA1E20");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.TemplatesExercices)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplatesExercices_Exercices");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplatesExercices)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplatesExercices_Template");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
