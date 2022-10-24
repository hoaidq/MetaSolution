using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaSolution.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Code = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsShowOnHome = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 19, 8, 25, 7, 474, DateTimeKind.Utc).AddTicks(6957)),
                    UserCreated = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TitleSite = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MetaAlias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CatalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogLanguages_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogLanguages_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionInModules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionInModules", x => new { x.ModuleId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_ActionInModules_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionInModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LanguageCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleLanguages_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleLanguages_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInCatalogs",
                columns: table => new
                {
                    CatalogId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCatalogs", x => new { x.CatalogId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInCatalogs_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInCatalogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<string>(type: "ntext", nullable: true),
                    TitleSite = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLanguages_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLanguages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 19, 8, 25, 7, 475, DateTimeKind.Utc).AddTicks(7173)),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMedias_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => new { x.RoleId, x.ModuleId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_Permissions_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 19, 8, 25, 7, 475, DateTimeKind.Utc).AddTicks(9425)),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShipAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShipEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ShipPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValueInProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AttributeValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueInProducts", x => new { x.ProductId, x.AttributeValueId });
                    table.ForeignKey(
                        name: "FK_AttributeValueInProducts_AttributeValues_AttributeValueId",
                        column: x => x.AttributeValueId,
                        principalTable: "AttributeValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValueInProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValueLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeValueId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValueLanguages_AttributeValues_AttributeValueId",
                        column: x => x.AttributeValueId,
                        principalTable: "AttributeValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValueLanguages_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Configs",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "HomeTitle", "This is homepage of Meta Solution" },
                    { 2, "HomeKeyword", "This is keyword of Meta Solution" },
                    { 3, "HomeDescription", "This is description of Meta Solution" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "Description", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "en-US", null, false, "English" },
                    { "vi-VN", null, false, "Tiếng Việt" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "Level", "Order", "ParentId" },
                values: new object[,]
                {
                    { 1, "groups", 1, 1, null },
                    { 2, "users", 1, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "DateModified", "Price", "PromotionPrice", "UserCreated", "UserModified", "ViewCount", "Warranty" },
                values: new object[] { 1, new DateTime(2022, 10, 19, 8, 25, 7, 485, DateTimeKind.Utc).AddTicks(7434), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12000000m, 10500000m, "admin (hoaidq@gmail.com)", null, 0, 12 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("75f218bb-7f54-4276-83d2-61a97077f66b"), "d2ddc838-5b23-4e37-801b-9ffe8bd8647f", "Administrator Role", "Administrator", "admin" });

            migrationBuilder.InsertData(
                table: "UserInRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("75f218bb-7f54-4276-83d2-61a97077f66b"), new Guid("6ebfc0b1-b951-4a1d-8b76-8acbe45ecd0e") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6ebfc0b1-b951-4a1d-8b76-8acbe45ecd0e"), 0, "88dbbcce-bab7-45ad-b018-5ed9ec7cd5a0", new DateTime(1981, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoaidq@gmail.com", true, "Hoai", "Dương", false, null, "hoaidq@gmail.com", "admin", "AQAAAAEAACcQAAAAEDKfIvg6XyFmGIC1/IXQl48d9OKYbd1KQopp0CYUojv4XIHEmjGxGf3cF8GG5eoSiA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "CatalogLanguages",
                columns: new[] { "Id", "CatalogId", "LanguageCode", "MetaAlias", "MetaDescription", "MetaKeywords", "Title", "TitleSite" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "dien-thoai", "Điện thoại di động", "điện thoại, điện thoại di động", "Điện thoại", "Điện thoại di động" },
                    { 2, 1, "en-US", "mobile-phone", "mobile phone", "mobile phone", "Phone", "Mobile phone" },
                    { 3, 2, "vi-VN", "phu-kien", "phụ kiện di động", "phụ kiện, phụ kiện di động", "Phụ kiện", "Phụ kiện di động" },
                    { 4, 2, "en-US", "mobile-accessory", "mobile accessory", "mobile accessory", "Accessory", "Mobile accessory" }
                });

            migrationBuilder.InsertData(
                table: "ModuleLanguages",
                columns: new[] { "Id", "Description", "LanguageCode", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 1, "", "vi-VN", 1, "Quản lý nhóm" },
                    { 2, "", "en-US", 1, "Group manager" },
                    { 3, "", "vi-VN", 2, "Quản lý thành viên" },
                    { 4, "", "en-US", 2, "Member manager" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCatalogs",
                columns: new[] { "CatalogId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductLanguages",
                columns: new[] { "Id", "Content", "Description", "LanguageCode", "MetaDescription", "MetaKeywords", "ProductId", "Title", "TitleSite" },
                values: new object[,]
                {
                    { 1, "", "", "vi-VN", "", "Điện thoại iPhone XS Max 64GB", 1, "Điện thoại iPhone XS Max 64GB", "Điện thoại iPhone XS Max 64GB" },
                    { 2, "", "", "en-US", "", "iPhone XS Max 64GB", 1, "iPhone XS Max 64GB", "iPhone XS Max 64GB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionInModules_ActionId",
                table: "ActionInModules",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueInProducts_AttributeValueId",
                table: "AttributeValueInProducts",
                column: "AttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueLanguages_AttributeValueId",
                table: "AttributeValueLanguages",
                column: "AttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueLanguages_LanguageCode",
                table: "AttributeValueLanguages",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogLanguages_CatalogId",
                table: "CatalogLanguages",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogLanguages_LanguageCode",
                table: "CatalogLanguages",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleLanguages_LanguageCode",
                table: "ModuleLanguages",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleLanguages_ModuleId",
                table: "ModuleLanguages",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ActionId",
                table: "Permissions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ModuleId",
                table: "Permissions",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCatalogs_ProductId",
                table: "ProductInCatalogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLanguages_LanguageCode",
                table: "ProductLanguages",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLanguages_ProductId",
                table: "ProductLanguages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedias_ProductId",
                table: "ProductMedias",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionInModules");

            migrationBuilder.DropTable(
                name: "AttributeValueInProducts");

            migrationBuilder.DropTable(
                name: "AttributeValueLanguages");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "CatalogLanguages");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "ModuleLanguages");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ProductInCatalogs");

            migrationBuilder.DropTable(
                name: "ProductLanguages");

            migrationBuilder.DropTable(
                name: "ProductMedias");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserInRoles");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
