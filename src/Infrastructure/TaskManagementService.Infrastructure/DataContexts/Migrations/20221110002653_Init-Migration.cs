using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementService.Infrastructure.DataContexts.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentTaskId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EffortEstimation = table.Column<int>(type: "int", nullable: false),
                    AggregatedEfforEstimation = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.CheckConstraint("CK__Tasks__Id", "Id > 0 and Id < 100000");
                    table.CheckConstraint("CK__Tasks__ParentTaskId", "ParentTaskId > 0 and ParentTaskId < 100000");
                    table.CheckConstraint("CK__Tasks__EffortEstimation", "EffortEstimation >= 0 and EffortEstimation < 1000");
                    table.CheckConstraint("CK__Tasks__AggregatedEfforEstimation", "AggregatedEfforEstimation >= 0 and AggregatedEfforEstimation < 1000");

                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ParentTaskId",
                table: "Tasks",
                column: "ParentTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
