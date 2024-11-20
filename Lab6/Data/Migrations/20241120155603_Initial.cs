using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorInitials = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorLastName = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorDateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    AuthorGenderMFU = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorContactDetails = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorOtherDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookCategoryCode = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookCategoryDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.BookCategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerCode = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerPhone = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RefContactTypes",
                columns: table => new
                {
                    ContactTypeCode = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContactTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefContactTypes", x => x.ContactTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookCategoryCode = table.Column<Guid>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfPublication = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateAcquired = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    BookTitle = table.Column<string>(type: "TEXT", nullable: false),
                    BookRecommendedPrice = table.Column<double>(type: "REAL", nullable: false),
                    BookComments = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorId1 = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookCategoryCode1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BookCategoryCode",
                        column: x => x.BookCategoryCode,
                        principalTable: "BookCategories",
                        principalColumn: "BookCategoryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BookCategoryCode1",
                        column: x => x.BookCategoryCode1,
                        principalTable: "BookCategories",
                        principalColumn: "BookCategoryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    OrderValue = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContactTypeCode = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContactFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    ContactLastName = table.Column<string>(type: "TEXT", nullable: false),
                    ContactWorkPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ContactCellPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ContactOtherDetails = table.Column<string>(type: "TEXT", nullable: false),
                    ContactTypeCode1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_RefContactTypes_ContactTypeCode",
                        column: x => x.ContactTypeCode,
                        principalTable: "RefContactTypes",
                        principalColumn: "ContactTypeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_RefContactTypes_ContactTypeCode1",
                        column: x => x.ContactTypeCode1,
                        principalTable: "RefContactTypes",
                        principalColumn: "ContactTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ItemNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemAgreedPrice = table.Column<double>(type: "REAL", nullable: false),
                    ItemComment = table.Column<string>(type: "TEXT", nullable: false),
                    OrderId1 = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookId1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ItemNumber);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId1",
                        column: x => x.BookId1,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId1",
                table: "Books",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryCode",
                table: "Books",
                column: "BookCategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryCode1",
                table: "Books",
                column: "BookCategoryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactTypeCode",
                table: "Contacts",
                column: "ContactTypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactTypeCode1",
                table: "Contacts",
                column: "ContactTypeCode1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId1",
                table: "OrderItems",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId1",
                table: "Orders",
                column: "CustomerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "RefContactTypes");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
