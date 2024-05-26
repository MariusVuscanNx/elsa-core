using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elsa.EntityFrameworkCore.Sqlite.Migrations.Labels
{
    /// <inheritdoc />
    public partial class V3_2 : Migration
    {
        private readonly Elsa.EntityFrameworkCore.Common.Contracts.IElsaDbContextSchema _schema;

        /// <inheritdoc />
        public V3_2(Elsa.EntityFrameworkCore.Common.Contracts.IElsaDbContextSchema schema)
        {
            _schema = schema;
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "WorkflowDefinitionLabels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Labels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "WorkflowDefinitionLabel_TenantId",
                table: "WorkflowDefinitionLabels",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "WorkflowDefinitionLabel_TenantId",
                table: "WorkflowDefinitionLabels");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "WorkflowDefinitionLabels");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Labels");
        }
    }
}
