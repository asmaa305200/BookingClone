using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAttractionImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttractionImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ImageUrlPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionImages", x => new { x.ID, x.ImageUrlPath });
                    table.ForeignKey(
                        name: "FK_AttractionImages_Attractions_ID",
                        column: x => x.ID,
                        principalTable: "Attractions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionImages");
        }
    }
}
