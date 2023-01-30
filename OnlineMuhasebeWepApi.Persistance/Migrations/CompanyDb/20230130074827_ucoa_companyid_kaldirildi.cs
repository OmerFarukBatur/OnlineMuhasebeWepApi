using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebeWepApi.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class ucoacompanyidkaldirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "UCOA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "UCOA",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
