using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyX.Migrations
{
    /// <inheritdoc />
    public partial class EnergyX_MigrationV3_UpdateTblTurnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gs_el_localizacao_reator",
                columns: table => new
                {
                    loc_reator_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    setor = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    unidade = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gs_el_localizacao_reator", x => x.loc_reator_id);
                });

            migrationBuilder.CreateTable(
                name: "gs_el_tipo_reator",
                columns: table => new
                {
                    tipo_reator_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    descricao_reator = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    capacidade_energia = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    tecnologia = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    fabricante = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gs_el_tipo_reator", x => x.tipo_reator_id);
                });

            migrationBuilder.CreateTable(
                name: "gs_el_turnos",
                columns: table => new
                {
                    turno_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    descricao_turno = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gs_el_turnos", x => x.turno_id);
                });

            migrationBuilder.CreateTable(
                name: "gs_el_reatores",
                columns: table => new
                {
                    reator_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_reator = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    pressao_max = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    temperatura_max = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    radiacao_max = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    tipo_reator_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    loc_reator_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gs_el_reatores", x => x.reator_id);
                    table.ForeignKey(
                        name: "gs_el_localizacao_reator_fk",
                        column: x => x.loc_reator_id,
                        principalTable: "gs_el_localizacao_reator",
                        principalColumn: "loc_reator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "gs_el_tipo_reator_fk",
                        column: x => x.tipo_reator_id,
                        principalTable: "gs_el_tipo_reator",
                        principalColumn: "tipo_reator_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gs_el_operadores",
                columns: table => new
                {
                    operador_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_operador = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    senha_operador = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    cargo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    lor = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    turno_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gs_el_operadores", x => x.operador_id);
                    table.ForeignKey(
                        name: "gs_el_turnos_fk",
                        column: x => x.turno_id,
                        principalTable: "gs_el_turnos",
                        principalColumn: "turno_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gs_el_relatorios_turno",
                columns: table => new
                {
                    relatorio_turno_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_hora_relatorio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    resumo_atividades = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    observacoes = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: true),
                    operador_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    reator_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gs_el_relatorios_turno", x => x.relatorio_turno_id);
                    table.ForeignKey(
                        name: "gs_el_operadores_fk",
                        column: x => x.operador_id,
                        principalTable: "gs_el_operadores",
                        principalColumn: "operador_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "gs_el_reatores_fk",
                        column: x => x.reator_id,
                        principalTable: "gs_el_reatores",
                        principalColumn: "reator_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gs_el_historico_relatorio",
                columns: table => new
                {
                    hist_relatorio_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_hora_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    observacoes = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    relatorio_turno_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gs_el_historico_relatorio", x => x.hist_relatorio_id);
                    table.ForeignKey(
                        name: "gs_el_relatorios_turno_fk",
                        column: x => x.relatorio_turno_id,
                        principalTable: "gs_el_relatorios_turno",
                        principalColumn: "relatorio_turno_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gs_el_historico_relatorio_relatorio_turno_id",
                table: "gs_el_historico_relatorio",
                column: "relatorio_turno_id");

            migrationBuilder.CreateIndex(
                name: "IX_gs_el_operadores_turno_id",
                table: "gs_el_operadores",
                column: "turno_id");

            migrationBuilder.CreateIndex(
                name: "IX_gs_el_reatores_loc_reator_id",
                table: "gs_el_reatores",
                column: "loc_reator_id");

            migrationBuilder.CreateIndex(
                name: "IX_gs_el_reatores_tipo_reator_id",
                table: "gs_el_reatores",
                column: "tipo_reator_id");

            migrationBuilder.CreateIndex(
                name: "IX_gs_el_relatorios_turno_operador_id",
                table: "gs_el_relatorios_turno",
                column: "operador_id");

            migrationBuilder.CreateIndex(
                name: "IX_gs_el_relatorios_turno_reator_id",
                table: "gs_el_relatorios_turno",
                column: "reator_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gs_el_historico_relatorio");

            migrationBuilder.DropTable(
                name: "gs_el_relatorios_turno");

            migrationBuilder.DropTable(
                name: "gs_el_operadores");

            migrationBuilder.DropTable(
                name: "gs_el_reatores");

            migrationBuilder.DropTable(
                name: "gs_el_turnos");

            migrationBuilder.DropTable(
                name: "gs_el_localizacao_reator");

            migrationBuilder.DropTable(
                name: "gs_el_tipo_reator");
        }
    }
}
