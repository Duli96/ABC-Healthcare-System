using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientService.Migrations
{
    /// <inheritdoc />
    public partial class changepProcedureTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Conditions_ConditionId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Patients_PatientId",
                table: "Procedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

            migrationBuilder.RenameTable(
                name: "Procedures",
                newName: "MedicalProcedures");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_PatientId",
                table: "MedicalProcedures",
                newName: "IX_MedicalProcedures_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_ConditionId",
                table: "MedicalProcedures",
                newName: "IX_MedicalProcedures_ConditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalProcedures",
                table: "MedicalProcedures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalProcedures_Conditions_ConditionId",
                table: "MedicalProcedures",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalProcedures_Patients_PatientId",
                table: "MedicalProcedures",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalProcedures_Conditions_ConditionId",
                table: "MedicalProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalProcedures_Patients_PatientId",
                table: "MedicalProcedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalProcedures",
                table: "MedicalProcedures");

            migrationBuilder.RenameTable(
                name: "MedicalProcedures",
                newName: "Procedures");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalProcedures_PatientId",
                table: "Procedures",
                newName: "IX_Procedures_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalProcedures_ConditionId",
                table: "Procedures",
                newName: "IX_Procedures_ConditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Conditions_ConditionId",
                table: "Procedures",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Patients_PatientId",
                table: "Procedures",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
