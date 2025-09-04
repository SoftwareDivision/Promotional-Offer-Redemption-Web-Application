using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campaignproducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsPerUnit = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaignproducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BusinessAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BusinessLicense = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GSTNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PANNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StoreType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BusinessHours = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NotificationSettingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecuritySettingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferenceSettingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedManufacturerId = table.Column<int>(type: "int", nullable: true),
                    AssignedResellerId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_AssignedManufacturerId",
                        column: x => x.AssignedManufacturerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_AssignedResellerId",
                        column: x => x.AssignedResellerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    RewardType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VoucherGenerationThreshold = table.Column<int>(type: "int", nullable: true),
                    VoucherValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VoucherValidityDays = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResellerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsPerUnit = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    RedeemedPoints = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPoints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    ResellerId = table.Column<int>(type: "int", nullable: false),
                    TotalPointsEarned = table.Column<int>(type: "int", nullable: false),
                    PointsUsedForVouchers = table.Column<int>(type: "int", nullable: false),
                    AvailablePoints = table.Column<int>(type: "int", nullable: false),
                    TotalOrderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalOrders = table.Column<int>(type: "int", nullable: false),
                    TotalVouchersGenerated = table.Column<int>(type: "int", nullable: false),
                    TotalVoucherValueGenerated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastVoucherGeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignPoints_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignPoints_Users_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CampaignResellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    ResellerId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    TotalPointsEarned = table.Column<int>(type: "int", nullable: false),
                    TotalOrderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsUsedForVouchers = table.Column<int>(type: "int", nullable: false),
                    TotalVouchersGenerated = table.Column<int>(type: "int", nullable: false),
                    TotalVoucherValueGenerated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastVoucherGeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignResellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignResellers_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignResellers_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignResellers_Users_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreeProductVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResellerId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    FreeProductId = table.Column<int>(type: "int", nullable: false),
                    EligibleProductId = table.Column<int>(type: "int", nullable: true),
                    FreeProductQty = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeProductVouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeProductVouchers_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreeProductVouchers_Users_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardTiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    Threshold = table.Column<int>(type: "int", nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardTiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardTiers_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempOrderPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResellerId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPointsEarned = table.Column<int>(type: "int", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempOrderPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempOrderPoints_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempOrderPoints_Users_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResellerId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsRequired = table.Column<int>(type: "int", nullable: false),
                    EligibleProducts = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsRedeemed = table.Column<bool>(type: "bit", nullable: false),
                    RedeemedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RedeemedByShopkeeperId = table.Column<int>(type: "int", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QrCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vouchers_Users_RedeemedByShopkeeperId",
                        column: x => x.RedeemedByShopkeeperId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vouchers_Users_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CampaignEligibleProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    CampaignProductId = table.Column<int>(type: "int", nullable: false),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    RedemptionLimit = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MinPurchaseQuantity = table.Column<int>(type: "int", nullable: true),
                    FreeProductId = table.Column<int>(type: "int", nullable: true),
                    FreeProductQty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignEligibleProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignEligibleProducts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignEligibleProducts_Products_FreeProductId",
                        column: x => x.FreeProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignEligibleProducts_campaignproducts_CampaignProductId",
                        column: x => x.CampaignProductId,
                        principalTable: "campaignproducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignFreeProductRewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignFreeProductRewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignFreeProductRewards_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignFreeProductRewards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignVoucherProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VoucherValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignVoucherProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignVoucherProducts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignVoucherProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempOrderPointsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempOrderPointsId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EligibleProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TempOrderPointsId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempOrderPointsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempOrderPointsItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempOrderPointsItems_TempOrderPoints_TempOrderPointsId",
                        column: x => x.TempOrderPointsId,
                        principalTable: "TempOrderPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempOrderPointsItems_TempOrderPoints_TempOrderPointsId1",
                        column: x => x.TempOrderPointsId1,
                        principalTable: "TempOrderPoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RedemptionHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    RedeemedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ResellerId = table.Column<int>(type: "int", nullable: true),
                    ShopkeeperId = table.Column<int>(type: "int", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    RedeemedProducts = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RedemptionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RedemptionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedemptionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedemptionHistories_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RedemptionHistories_Users_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RedemptionHistories_Users_ShopkeeperId",
                        column: x => x.ShopkeeperId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RedemptionHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RedemptionHistories_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEligibleProducts_CampaignId",
                table: "CampaignEligibleProducts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEligibleProducts_CampaignProductId",
                table: "CampaignEligibleProducts",
                column: "CampaignProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEligibleProducts_FreeProductId",
                table: "CampaignEligibleProducts",
                column: "FreeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignFreeProductRewards_CampaignId",
                table: "CampaignFreeProductRewards",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignFreeProductRewards_ProductId",
                table: "CampaignFreeProductRewards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignPoints_CampaignId_ResellerId",
                table: "CampaignPoints",
                columns: new[] { "CampaignId", "ResellerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignPoints_ResellerId",
                table: "CampaignPoints",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignResellers_ApprovedByUserId",
                table: "CampaignResellers",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignResellers_CampaignId_ResellerId",
                table: "CampaignResellers",
                columns: new[] { "CampaignId", "ResellerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignResellers_ResellerId",
                table: "CampaignResellers",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_DateRange",
                table: "Campaigns",
                columns: new[] { "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_IsActive",
                table: "Campaigns",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ManufacturerId",
                table: "Campaigns",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ProductType",
                table: "Campaigns",
                column: "ProductType");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignVoucherProducts_CampaignId",
                table: "CampaignVoucherProducts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignVoucherProducts_ProductId",
                table: "CampaignVoucherProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeProductVouchers_CampaignId",
                table: "FreeProductVouchers",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeProductVouchers_ResellerId",
                table: "FreeProductVouchers",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category",
                table: "Products",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_RedemptionHistories_CampaignId",
                table: "RedemptionHistories",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_RedemptionHistories_ResellerId",
                table: "RedemptionHistories",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_RedemptionHistories_ShopkeeperId",
                table: "RedemptionHistories",
                column: "ShopkeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_RedemptionHistories_UserId",
                table: "RedemptionHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RedemptionHistories_VoucherId",
                table: "RedemptionHistories",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardTiers_CampaignId",
                table: "RewardTiers",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_TempOrderPoints_CampaignId",
                table: "TempOrderPoints",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_TempOrderPoints_ResellerId",
                table: "TempOrderPoints",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_TempOrderPointsItems_ProductId",
                table: "TempOrderPointsItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TempOrderPointsItems_TempOrderPointsId",
                table: "TempOrderPointsItems",
                column: "TempOrderPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_TempOrderPointsItems_TempOrderPointsId1",
                table: "TempOrderPointsItems",
                column: "TempOrderPointsId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserPoints_UserId",
                table: "UserPoints",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AssignedManufacturerId",
                table: "Users",
                column: "AssignedManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AssignedResellerId",
                table: "Users",
                column: "AssignedResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_CampaignId",
                table: "Vouchers",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_RedeemedByShopkeeperId",
                table: "Vouchers",
                column: "RedeemedByShopkeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_ResellerId",
                table: "Vouchers",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_VoucherCode",
                table: "Vouchers",
                column: "VoucherCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignEligibleProducts");

            migrationBuilder.DropTable(
                name: "CampaignFreeProductRewards");

            migrationBuilder.DropTable(
                name: "CampaignPoints");

            migrationBuilder.DropTable(
                name: "CampaignResellers");

            migrationBuilder.DropTable(
                name: "CampaignVoucherProducts");

            migrationBuilder.DropTable(
                name: "FreeProductVouchers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RedemptionHistories");

            migrationBuilder.DropTable(
                name: "RewardTiers");

            migrationBuilder.DropTable(
                name: "TempOrderPointsItems");

            migrationBuilder.DropTable(
                name: "UserPoints");

            migrationBuilder.DropTable(
                name: "campaignproducts");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TempOrderPoints");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
