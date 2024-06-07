using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GS_Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_Inspetor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Rg = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Especializacao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Inspetor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_Veiculo",
                columns: table => new
                {
                    Tie = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TipoMotor = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Sonar = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LinkImagem = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Veiculo", x => x.Tie);
                    table.ForeignKey(
                        name: "FK_GS_Veiculo_GS_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "GS_Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EstadoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_Cidade_GS_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "GS_Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Vistoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    NivelRuido = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Resultado = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Observacoes = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    VeiculoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Vistoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_Vistoria_GS_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "GS_Veiculo",
                        principalColumn: "Tie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Rua = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    CidadeId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_Endereco_GS_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "GS_Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GS_Endereco_GS_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "GS_Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Inspetores_Vistorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InspetorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VistoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_Inspetores_Vistorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_Inspetores_Vistorias_GS_Inspetor_InspetorId",
                        column: x => x.InspetorId,
                        principalTable: "GS_Inspetor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GS_Inspetores_Vistorias_GS_Vistoria_VistoriaId",
                        column: x => x.VistoriaId,
                        principalTable: "GS_Vistoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GS_Cidade_EstadoId",
                table: "GS_Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_Endereco_CidadeId",
                table: "GS_Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_Endereco_EmpresaId",
                table: "GS_Endereco",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_Inspetores_Vistorias_InspetorId",
                table: "GS_Inspetores_Vistorias",
                column: "InspetorId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_Inspetores_Vistorias_VistoriaId",
                table: "GS_Inspetores_Vistorias",
                column: "VistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_Veiculo_EmpresaId",
                table: "GS_Veiculo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_Vistoria_VeiculoId",
                table: "GS_Vistoria",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GS_Endereco");

            migrationBuilder.DropTable(
                name: "GS_Inspetores_Vistorias");

            migrationBuilder.DropTable(
                name: "GS_Cidade");

            migrationBuilder.DropTable(
                name: "GS_Inspetor");

            migrationBuilder.DropTable(
                name: "GS_Vistoria");

            migrationBuilder.DropTable(
                name: "GS_Estado");

            migrationBuilder.DropTable(
                name: "GS_Veiculo");

            migrationBuilder.DropTable(
                name: "GS_Empresa");
        }
    }
}
