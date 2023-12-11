using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShopApi.DataAccessLayer.Migrations
{
    public partial class add_mig_sub_rev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscribeStatus",
                table: "Subscribes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SubscribeStatus",
                table: "Subscribes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
