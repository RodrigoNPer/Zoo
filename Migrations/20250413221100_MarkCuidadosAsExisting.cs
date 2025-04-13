using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooAPI.Migrations
{
    /// <inheritdoc />
    public partial class MarkCuidadosAsExisting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Deixe vazio, pois as tabelas já existem no banco de dados
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Deixe vazio, pois não queremos desfazer nada
        }
    }
}