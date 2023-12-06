using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTfull.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressPermanentRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressTemporaryRegistration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Educations_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeignPassports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignPassports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ForeignPassports_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Infos_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternationalPassports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentIssuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDateOfIssue = table.Column<DateTime>(type: "Date", nullable: false),
                    DocumentExpirationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalPassports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InternationalPassports_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jobs_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RussianPassports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentIssuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentIssuerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RussianPassports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RussianPassports_Individuals_IndividualID",
                        column: x => x.IndividualID,
                        principalTable: "Individuals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IndividualID",
                table: "Addresses",
                column: "IndividualID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IndividualID",
                table: "Documents",
                column: "IndividualID");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_IndividualID",
                table: "Educations",
                column: "IndividualID");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignPassports_IndividualID",
                table: "ForeignPassports",
                column: "IndividualID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infos_IndividualID",
                table: "Infos",
                column: "IndividualID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternationalPassports_IndividualID",
                table: "InternationalPassports",
                column: "IndividualID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IndividualID",
                table: "Jobs",
                column: "IndividualID");

            migrationBuilder.CreateIndex(
                name: "IX_RussianPassports_IndividualID",
                table: "RussianPassports",
                column: "IndividualID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "ForeignPassports");

            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "InternationalPassports");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "RussianPassports");

            migrationBuilder.DropTable(
                name: "Individuals");
        }
    }
}
