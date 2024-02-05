using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SparkleAir.Infa.EFModel.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<AirBookSeat> AirBookSeats { get; set; }
        public virtual DbSet<AirCabinRule> AirCabinRules { get; set; }
        public virtual DbSet<AirCabin> AirCabins { get; set; }
        public virtual DbSet<AirCabinSeat> AirCabinSeats { get; set; }
        public virtual DbSet<AirFlightManagement> AirFlightManagements { get; set; }
        public virtual DbSet<AirFlight> AirFlights { get; set; }
        public virtual DbSet<AirFlightSaleStatus> AirFlightSaleStatuses { get; set; }
        public virtual DbSet<AirFlightSeat> AirFlightSeats { get; set; }
        public virtual DbSet<AirFlightStatus> AirFlightStatuses { get; set; }
        public virtual DbSet<AirMeal> AirMeals { get; set; }
        public virtual DbSet<AirOwn> AirOwns { get; set; }
        public virtual DbSet<AirPort> AirPorts { get; set; }
        public virtual DbSet<AirTakeOffStatus> AirTakeOffStatuses { get; set; }
        public virtual DbSet<AirType> AirTypes { get; set; }
        public virtual DbSet<AriTicketPrice> AriTicketPrices { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampaignsCouponAirFlight> CampaignsCouponAirFlights { get; set; }
        public virtual DbSet<CampaignsCouponMember> CampaignsCouponMembers { get; set; }
        public virtual DbSet<CampaignsCoupon> CampaignsCoupons { get; set; }
        public virtual DbSet<CampaignsDiscountMember> CampaignsDiscountMembers { get; set; }
        public virtual DbSet<CampaignsDiscount> CampaignsDiscounts { get; set; }
        public virtual DbSet<CampaignsDiscountStatusNotification> CampaignsDiscountStatusNotifications { get; set; }
        public virtual DbSet<CampaignsDiscountTFItem> CampaignsDiscountTFItems { get; set; }
        public virtual DbSet<CampaignsFlightCouponsUsageHistory> CampaignsFlightCouponsUsageHistories { get; set; }
        public virtual DbSet<CampaignsTFDiscountUsageHistory> CampaignsTFDiscountUsageHistories { get; set; }
        public virtual DbSet<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual DbSet<CompanyJob> CompanyJobs { get; set; }
        public virtual DbSet<CompanyStaffLoginLog> CompanyStaffLoginLogs { get; set; }
        public virtual DbSet<CompanyStaff> CompanyStaffs { get; set; }
        public virtual DbSet<CompanyStaffsChangePasswordLog> CompanyStaffsChangePasswordLogs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<LuggageOrder> LuggageOrders { get; set; }
        public virtual DbSet<Luggage> Luggages { get; set; }
        public virtual DbSet<MemberClass> MemberClasses { get; set; }
        public virtual DbSet<MemberLoginLog> MemberLoginLogs { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MessageBox> MessageBoxes { get; set; }
        public virtual DbSet<MileageDetail> MileageDetails { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }
        public virtual DbSet<PermissionGroupsAddStaff> PermissionGroupsAddStaffs { get; set; }
        public virtual DbSet<PermissionPageInfo> PermissionPageInfos { get; set; }
        public virtual DbSet<PermissionSetting> PermissionSettings { get; set; }
        public virtual DbSet<SeatArea> SeatAreas { get; set; }
        public virtual DbSet<SeatGroup> SeatGroups { get; set; }
        public virtual DbSet<TFCategory> TFCategories { get; set; }
        public virtual DbSet<TFItem> TFItems { get; set; }
        public virtual DbSet<TFOrderlist> TFOrderlists { get; set; }
        public virtual DbSet<TFOrderStatus> TFOrderStatuses { get; set; }
        public virtual DbSet<TFReservelist> TFReservelists { get; set; }
        public virtual DbSet<TFReserve> TFReserves { get; set; }
        public virtual DbSet<TFWishlist> TFWishlists { get; set; }
        public virtual DbSet<TicketCancel> TicketCancels { get; set; }
        public virtual DbSet<TicketCancelStatus> TicketCancelStatuses { get; set; }
        public virtual DbSet<TicketDetail> TicketDetails { get; set; }
        public virtual DbSet<TicketInvoicingDetail> TicketInvoicingDetails { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TransferMethod> TransferMethods { get; set; }
        public virtual DbSet<TransferPayment> TransferPayments { get; set; }
        public virtual DbSet<TransferRefund> TransferRefunds { get; set; }
        public virtual DbSet<TypeofPassenger> TypeofPassengers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirCabinRule>()
                .HasMany(e => e.AriTicketPrices)
                .WithRequired(e => e.AirCabinRule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirCabinRule>()
                .HasMany(e => e.TicketDetails)
                .WithRequired(e => e.AirCabinRule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirCabin>()
                .HasMany(e => e.AirCabinRules)
                .WithRequired(e => e.AirCabin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirCabin>()
                .HasMany(e => e.AirCabinSeats)
                .WithRequired(e => e.AirCabin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirCabin>()
                .HasMany(e => e.AirFlightSeats)
                .WithRequired(e => e.AirCabin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirCabin>()
                .HasMany(e => e.AirMeals)
                .WithRequired(e => e.AirCabin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlightManagement>()
                .HasMany(e => e.AirFlights)
                .WithRequired(e => e.AirFlightManagement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlightManagement>()
                .HasMany(e => e.AriTicketPrices)
                .WithRequired(e => e.AirFlightManagement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlightManagement>()
                .HasMany(e => e.Luggages)
                .WithRequired(e => e.AirFlightManagement)
                .HasForeignKey(e => e.AirFlightManagementsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlight>()
                .HasMany(e => e.AirFlightSeats)
                .WithRequired(e => e.AirFlight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlight>()
                .HasMany(e => e.AirTakeOffStatuses)
                .WithRequired(e => e.AirFlight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlight>()
                .HasMany(e => e.CampaignsCouponAirFlights)
                .WithRequired(e => e.AirFlight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlight>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.AirFlight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlightSaleStatus>()
                .HasMany(e => e.AirFlights)
                .WithRequired(e => e.AirFlightSaleStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlightSeat>()
                .Property(e => e.SeatNum)
                .IsUnicode(false);

            modelBuilder.Entity<AirFlightSeat>()
                .HasMany(e => e.AirBookSeats)
                .WithRequired(e => e.AirFlightSeat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlightSeat>()
                .HasMany(e => e.TicketInvoicingDetails)
                .WithRequired(e => e.AirFlightSeat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirFlightStatus>()
                .HasMany(e => e.AirTakeOffStatuses)
                .WithRequired(e => e.AirFlightStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirMeal>()
                .HasMany(e => e.TicketInvoicingDetails)
                .WithRequired(e => e.AirMeal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirOwn>()
                .HasMany(e => e.AirFlights)
                .WithRequired(e => e.AirOwn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirPort>()
                .Property(e => e.Lata)
                .IsUnicode(false);

            modelBuilder.Entity<AirPort>()
                .HasMany(e => e.AirFlightManagements)
                .WithRequired(e => e.AirPort)
                .HasForeignKey(e => e.DepartureAirportId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirPort>()
                .HasMany(e => e.AirFlightManagements1)
                .WithRequired(e => e.AirPort1)
                .HasForeignKey(e => e.ArrivalAirportId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirType>()
                .HasMany(e => e.AirCabinSeats)
                .WithRequired(e => e.AirType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirType>()
                .HasMany(e => e.AirOwns)
                .WithRequired(e => e.AirType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirType>()
                .HasMany(e => e.SeatGroups)
                .WithRequired(e => e.AirType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campaign>()
                .HasMany(e => e.CampaignsCoupons)
                .WithRequired(e => e.Campaign)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campaign>()
                .HasMany(e => e.CampaignsDiscounts)
                .WithRequired(e => e.Campaign)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignsCoupon>()
                .Property(e => e.DiscountValue)
                .HasPrecision(15, 4);

            modelBuilder.Entity<CampaignsCoupon>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<CampaignsCoupon>()
                .HasMany(e => e.CampaignsCouponAirFlights)
                .WithRequired(e => e.CampaignsCoupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignsCoupon>()
                .HasMany(e => e.CampaignsCouponMembers)
                .WithRequired(e => e.CampaignsCoupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignsCoupon>()
                .HasMany(e => e.CampaignsFlightCouponsUsageHistories)
                .WithRequired(e => e.CampaignsCoupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignsDiscount>()
                .Property(e => e.DiscountValue)
                .HasPrecision(15, 4);

            modelBuilder.Entity<CampaignsDiscount>()
                .Property(e => e.Value)
                .HasPrecision(15, 4);

            modelBuilder.Entity<CampaignsDiscount>()
                .Property(e => e.BundleSKUs)
                .HasPrecision(15, 4);

            modelBuilder.Entity<CampaignsDiscount>()
                .HasMany(e => e.CampaignsDiscountMembers)
                .WithRequired(e => e.CampaignsDiscount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignsDiscount>()
                .HasMany(e => e.CampaignsDiscountTFItems)
                .WithRequired(e => e.CampaignsDiscount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignsDiscount>()
                .HasMany(e => e.CampaignsTFDiscountUsageHistories)
                .WithRequired(e => e.CampaignsDiscount)
                .HasForeignKey(e => e.CampaignsDiscountsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignsDiscountStatusNotification>()
                .HasOptional(e => e.CampaignsDiscountStatusNotifications1)
                .WithRequired(e => e.CampaignsDiscountStatusNotification1);

            modelBuilder.Entity<CompanyDepartment>()
                .HasMany(e => e.CompanyJobs)
                .WithRequired(e => e.CompanyDepartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJob>()
                .HasMany(e => e.CompanyStaffs)
                .WithRequired(e => e.CompanyJob)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyStaffLoginLog>()
                .Property(e => e.IPAddress)
                .IsFixedLength();

            modelBuilder.Entity<CompanyStaff>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<CompanyStaff>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<CompanyStaff>()
                .HasMany(e => e.CompanyStaffLoginLogs)
                .WithRequired(e => e.CompanyStaff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyStaff>()
                .HasMany(e => e.CompanyStaffsChangePasswordLogs)
                .WithRequired(e => e.CompanyStaff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyStaff>()
                .HasMany(e => e.PermissionGroupsAddStaffs)
                .WithRequired(e => e.CompanyStaff)
                .HasForeignKey(e => e.CompanyStaffsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyStaffsChangePasswordLog>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TicketInvoicingDetails)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Luggage>()
                .HasMany(e => e.LuggageOrders)
                .WithRequired(e => e.Luggage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberClass>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.MemberClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberLoginLog>()
                .Property(e => e.IPAddress)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .HasMany(e => e.CampaignsCouponMembers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.CampaignsDiscountMembers)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.MembersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberLoginLogs)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MessageBoxes)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MileageDetails)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.MermberIsd)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.TFOrderlists)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.TFReserves)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.TFWishlists)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MessageBox>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.MessageBox)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MileageDetail>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PermissionGroup>()
                .HasMany(e => e.PermissionGroupsAddStaffs)
                .WithRequired(e => e.PermissionGroup)
                .HasForeignKey(e => e.PermissionGroupsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermissionGroup>()
                .HasMany(e => e.PermissionSettings)
                .WithRequired(e => e.PermissionGroup)
                .HasForeignKey(e => e.PermissionGroupsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermissionPageInfo>()
                .Property(e => e.PageNumber)
                .IsFixedLength();

            modelBuilder.Entity<PermissionPageInfo>()
                .HasMany(e => e.PermissionSettings)
                .WithRequired(e => e.PermissionPageInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SeatArea>()
                .HasMany(e => e.SeatGroups)
                .WithRequired(e => e.SeatArea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TFCategory>()
                .HasMany(e => e.TFItems)
                .WithRequired(e => e.TFCategory)
                .HasForeignKey(e => e.TFCategoriesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TFItem>()
                .HasMany(e => e.CampaignsDiscountTFItems)
                .WithRequired(e => e.TFItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TFItem>()
                .HasMany(e => e.TFOrderlists)
                .WithRequired(e => e.TFItem)
                .HasForeignKey(e => e.TFItemsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TFItem>()
                .HasMany(e => e.TFReservelists)
                .WithRequired(e => e.TFItem)
                .HasForeignKey(e => e.TFItemsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TFItem>()
                .HasMany(e => e.TFWishlists)
                .WithRequired(e => e.TFItem)
                .HasForeignKey(e => e.TFItemsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TFReservelist>()
                .HasMany(e => e.CampaignsTFDiscountUsageHistories)
                .WithRequired(e => e.TFReservelist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TFReserve>()
                .HasMany(e => e.TFReservelists)
                .WithRequired(e => e.TFReserve)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TicketCancelStatus>()
                .HasMany(e => e.TicketCancels)
                .WithRequired(e => e.TicketCancelStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TicketDetail>()
                .HasMany(e => e.TicketInvoicingDetails)
                .WithRequired(e => e.TicketDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TicketInvoicingDetail>()
                .HasMany(e => e.AirBookSeats)
                .WithRequired(e => e.TicketInvoicingDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TicketInvoicingDetail>()
                .HasMany(e => e.LuggageOrders)
                .WithRequired(e => e.TicketInvoicingDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.CampaignsFlightCouponsUsageHistories)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.TicketCancels)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.TicketDetails)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferMethod>()
                .HasMany(e => e.TransferPayments)
                .WithRequired(e => e.TransferMethod)
                .HasForeignKey(e => e.TransferMethodsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferMethod>()
                .HasMany(e => e.TransferRefunds)
                .WithRequired(e => e.TransferMethod)
                .HasForeignKey(e => e.TransferIMethodsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferPayment>()
                .Property(e => e.PaymentAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TransferPayment>()
                .HasMany(e => e.LuggageOrders)
                .WithRequired(e => e.TransferPayment)
                .HasForeignKey(e => e.TransferPaymentsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferPayment>()
                .HasMany(e => e.TFReserves)
                .WithRequired(e => e.TransferPayment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferPayment>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.TransferPayment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferPayment>()
                .HasMany(e => e.TransferRefunds)
                .WithRequired(e => e.TransferPayment)
                .HasForeignKey(e => e.TransferPaymentsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferRefund>()
                .Property(e => e.RefundtAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TransferRefund>()
                .HasMany(e => e.TicketCancels)
                .WithRequired(e => e.TransferRefund)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeofPassenger>()
                .HasMany(e => e.TicketDetails)
                .WithRequired(e => e.TypeofPassenger)
                .WillCascadeOnDelete(false);
        }
    }
}
