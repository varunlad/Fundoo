using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class LabelFundoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelsTable",
                columns: table => new
                {
                    LableId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lable = table.Column<string>(nullable: true),
                    NoteID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    RegistrationModelUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelsTable", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_LabelsTable_Notes_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Notes",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabelsTable_UsersTable_RegistrationModelUserId",
                        column: x => x.RegistrationModelUserId,
                        principalTable: "UsersTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelsTable_NoteID",
                table: "LabelsTable",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_LabelsTable_RegistrationModelUserId",
                table: "LabelsTable",
                column: "RegistrationModelUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelsTable");
        }
    }
}
