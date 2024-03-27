using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementApp.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBasicMoneyManagementTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    UpdaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyAccounts_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyAccounts_users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyAccounts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MoneyMovementReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    UpdaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyMovementReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyMovementReasons_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyMovementReasons_users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoneyBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    UpdaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyBanks_MoneyAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "MoneyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyBanks_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyBanks_users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoneyBorrowed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    OriginBankId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    UpdaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyBorrowed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyBorrowed_MoneyAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "MoneyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyBorrowed_MoneyBanks_OriginBankId",
                        column: x => x.OriginBankId,
                        principalTable: "MoneyBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyBorrowed_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyBorrowed_users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoneyMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    OriginBankId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    UpdaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyMovements_MoneyAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "MoneyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyMovements_MoneyBanks_OriginBankId",
                        column: x => x.OriginBankId,
                        principalTable: "MoneyBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyMovements_MoneyMovementReasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "MoneyMovementReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyMovements_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyMovements_users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyAccounts_CreatorId",
                table: "MoneyAccounts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyAccounts_UpdaterId",
                table: "MoneyAccounts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyAccounts_UserId",
                table: "MoneyAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyBanks_AccountId",
                table: "MoneyBanks",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyBanks_CreatorId",
                table: "MoneyBanks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyBanks_UpdaterId",
                table: "MoneyBanks",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyBorrowed_AccountId",
                table: "MoneyBorrowed",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyBorrowed_CreatorId",
                table: "MoneyBorrowed",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyBorrowed_OriginBankId",
                table: "MoneyBorrowed",
                column: "OriginBankId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyBorrowed_UpdaterId",
                table: "MoneyBorrowed",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMovementReasons_CreatorId",
                table: "MoneyMovementReasons",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMovementReasons_UpdaterId",
                table: "MoneyMovementReasons",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMovements_AccountId",
                table: "MoneyMovements",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMovements_CreatorId",
                table: "MoneyMovements",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMovements_OriginBankId",
                table: "MoneyMovements",
                column: "OriginBankId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMovements_ReasonId",
                table: "MoneyMovements",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMovements_UpdaterId",
                table: "MoneyMovements",
                column: "UpdaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyBorrowed");

            migrationBuilder.DropTable(
                name: "MoneyMovements");

            migrationBuilder.DropTable(
                name: "MoneyBanks");

            migrationBuilder.DropTable(
                name: "MoneyMovementReasons");

            migrationBuilder.DropTable(
                name: "MoneyAccounts");
        }
    }
}
