using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Damco.Domain.Migrations
{
    public partial class first_migration_20_02_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "damco_supplier",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_damco_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "damco_supplier_rate",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rate = table.Column<double>(type: "float", nullable: false),
                    fk_supplier_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_damco_supplier_rate", x => x.id);
                    table.ForeignKey(
                        name: "FK_damco_supplier_rate_damco_supplier_fk_supplier_id",
                        column: x => x.fk_supplier_id,
                        principalTable: "damco_supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_damco_supplier_rate_fk_supplier_id",
                table: "damco_supplier_rate",
                column: "fk_supplier_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "damco_supplier_rate");

            migrationBuilder.DropTable(
                name: "damco_supplier");
        }
    }
}
