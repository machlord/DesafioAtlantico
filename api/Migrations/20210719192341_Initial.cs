using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    valor = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CaixasNotas",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CaixaId = table.Column<int>(type: "INTEGER", nullable: false),
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaixasNotas", x => new { x.CaixaId, x.NotaId });
                    table.ForeignKey(
                        name: "FK_CaixasNotas_Caixas_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaixasNotas_Notas_NotaId",
                        column: x => x.NotaId,
                        principalTable: "Notas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "id", "descricao", "valor" },
                values: new object[] { 1, "R$ 50", 50f });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "id", "descricao", "valor" },
                values: new object[] { 2, "R$ 20", 20f });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "id", "descricao", "valor" },
                values: new object[] { 3, "R$ 10", 10f });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "id", "descricao", "valor" },
                values: new object[] { 4, "R$ 5", 5f });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "id", "descricao", "valor" },
                values: new object[] { 5, "R$ 2", 2f });

            migrationBuilder.CreateIndex(
                name: "IX_CaixasNotas_NotaId",
                table: "CaixasNotas",
                column: "NotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaixasNotas");

            migrationBuilder.DropTable(
                name: "Caixas");

            migrationBuilder.DropTable(
                name: "Notas");
        }
    }
}
