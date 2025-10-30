using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintingJob.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SLA_MailBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobStatusHistories_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Carrier", "ClientName", "CreatedAt", "CurrentStatus", "JobName", "Quantity", "SLA_MailBy" },
                values: new object[,]
                {
                    { 1, "USPS", "ACME Corp", new DateTime(2025, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Received", "Brochure Q1", 500, new DateTime(2025, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "UPS", "Beta LLC", new DateTime(2025, 9, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), "Printing", "Sticker Run", 2000, new DateTime(2025, 9, 10, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "FedEx", "Gamma Inc", new DateTime(2025, 9, 3, 8, 15, 0, 0, DateTimeKind.Unspecified), "Inserting", "Catalog 2025", 1200, new DateTime(2025, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "USPS", "Delta Co", new DateTime(2025, 9, 4, 11, 45, 0, 0, DateTimeKind.Unspecified), "Mailed", "Postcards", 10000, new DateTime(2025, 9, 18, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "UPS", "Epsilon", new DateTime(2025, 9, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", "Manuals", 300, new DateTime(2025, 9, 25, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "FedEx", "Zeta Solutions", new DateTime(2025, 9, 6, 9, 30, 0, 0, DateTimeKind.Unspecified), "Received", "Promo Cards", 2500, new DateTime(2025, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "USPS", "Eta Partners", new DateTime(2025, 9, 7, 8, 45, 0, 0, DateTimeKind.Unspecified), "Printing", "Labels", 8000, new DateTime(2025, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "UPS", "Theta Ltd", new DateTime(2025, 9, 8, 13, 20, 0, 0, DateTimeKind.Unspecified), "Exception", "Stickers Large", 1500, new DateTime(2025, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "FedEx", "Iota Group", new DateTime(2025, 9, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), "Inserting", "Invitation Set", 600, new DateTime(2025, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "USPS", "Kappa Works", new DateTime(2025, 9, 10, 15, 10, 0, 0, DateTimeKind.Unspecified), "Mailed", "Catalog Reprint", 400, new DateTime(2025, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobStatusHistories",
                columns: new[] { "Id", "ChangedAt", "JobId", "Note", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Initial received", "Received" },
                    { 2, new DateTime(2025, 9, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, "Initial received", "Received" },
                    { 3, new DateTime(2025, 9, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, "Started print run", "Printing" },
                    { 4, new DateTime(2025, 9, 3, 8, 15, 0, 0, DateTimeKind.Unspecified), 3, "Initial received", "Received" },
                    { 5, new DateTime(2025, 9, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, "Printed pages", "Printing" },
                    { 6, new DateTime(2025, 9, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, "Inserted into envelopes", "Inserting" },
                    { 7, new DateTime(2025, 9, 4, 11, 45, 0, 0, DateTimeKind.Unspecified), 4, "Initial received", "Received" },
                    { 8, new DateTime(2025, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, "Printed", "Printing" },
                    { 9, new DateTime(2025, 9, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, "Inserted", "Inserting" },
                    { 10, new DateTime(2025, 9, 7, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, "Shipped via USPS", "Mailed" },
                    { 11, new DateTime(2025, 9, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, "Initial received", "Received" },
                    { 12, new DateTime(2025, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), 5, "Printed", "Printing" },
                    { 13, new DateTime(2025, 9, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, "Delivered", "Mailed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobStatusHistories_JobId",
                table: "JobStatusHistories",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobStatusHistories");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
