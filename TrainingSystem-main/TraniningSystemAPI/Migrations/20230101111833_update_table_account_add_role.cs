using Microsoft.EntityFrameworkCore.Migrations;

namespace TraniningSystemAPI.Migrations
{
    public partial class update_table_account_add_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Department_DepartmentId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_JobPosition_JobPositionId",
                table: "Trainee");

            migrationBuilder.AlterColumn<int>(
                name: "TraineeAge",
                table: "Trainee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobPositionId",
                table: "Trainee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Trainee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Trainee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_AccountId",
                table: "Trainee",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Account_AccountId",
                table: "Trainee",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Department_DepartmentId",
                table: "Trainee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_JobPosition_JobPositionId",
                table: "Trainee",
                column: "JobPositionId",
                principalTable: "JobPosition",
                principalColumn: "JobPositionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Account_AccountId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Department_DepartmentId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_JobPosition_JobPositionId",
                table: "Trainee");

            migrationBuilder.DropIndex(
                name: "IX_Trainee_AccountId",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "TraineeAge",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobPositionId",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Department_DepartmentId",
                table: "Trainee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_JobPosition_JobPositionId",
                table: "Trainee",
                column: "JobPositionId",
                principalTable: "JobPosition",
                principalColumn: "JobPositionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
