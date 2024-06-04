using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stamp.Site.Migrations
{
    /// <inheritdoc />
    public partial class cv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StampMakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transferee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmationReceipt = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StampMakers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StampMakers");
        }
    }
}
