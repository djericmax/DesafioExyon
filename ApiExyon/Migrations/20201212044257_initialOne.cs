using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiExyon.Migrations
{
    public partial class initialOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CiaAereas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanhiaAerea = table.Column<string>(maxLength: 50, nullable: false),
                    Aviao = table.Column<string>(nullable: false),
                    QtdeAssentos = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiaAereas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumdoVoo = table.Column<string>(nullable: false),
                    Assento = table.Column<string>(maxLength: 8, nullable: false),
                    DataPartida = table.Column<DateTime>(nullable: false),
                    Horapartida = table.Column<DateTime>(nullable: false),
                    ValorPassagem = table.Column<string>(nullable: false),
                    CiaAereaId = table.Column<int>(nullable: false),
                    PassageiroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voos_CiaAereas_CiaAereaId",
                        column: x => x.CiaAereaId,
                        principalTable: "CiaAereas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voos_Passageiros_PassageiroId",
                        column: x => x.PassageiroId,
                        principalTable: "Passageiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CiaAereas",
                columns: new[] { "Id", "Aviao", "CompanhiaAerea", "QtdeAssentos" },
                values: new object[] { 1, "3", "Gol", "120" });

            migrationBuilder.InsertData(
                table: "CiaAereas",
                columns: new[] { "Id", "Aviao", "CompanhiaAerea", "QtdeAssentos" },
                values: new object[] { 2, "2", "LaTam", "120" });

            migrationBuilder.InsertData(
                table: "CiaAereas",
                columns: new[] { "Id", "Aviao", "CompanhiaAerea", "QtdeAssentos" },
                values: new object[] { 3, "4", "Vasp", "120" });

            migrationBuilder.InsertData(
                table: "CiaAereas",
                columns: new[] { "Id", "Aviao", "CompanhiaAerea", "QtdeAssentos" },
                values: new object[] { 4, "1", "Varig", "120" });

            migrationBuilder.InsertData(
                table: "Passageiros",
                columns: new[] { "Id", "CPF", "Nome", "Sobrenome" },
                values: new object[] { 1, "12345678978", "Roberto Carlos", "de Lima" });

            migrationBuilder.InsertData(
                table: "Passageiros",
                columns: new[] { "Id", "CPF", "Nome", "Sobrenome" },
                values: new object[] { 2, "45454545445", "Dercy", "Gonçalves" });

            migrationBuilder.InsertData(
                table: "Passageiros",
                columns: new[] { "Id", "CPF", "Nome", "Sobrenome" },
                values: new object[] { 3, "14141414141", "Marcos", "Palmeiras" });

            migrationBuilder.InsertData(
                table: "Passageiros",
                columns: new[] { "Id", "CPF", "Nome", "Sobrenome" },
                values: new object[] { 4, "97878979845", "Humberto", "Martins" });

            migrationBuilder.InsertData(
                table: "Passageiros",
                columns: new[] { "Id", "CPF", "Nome", "Sobrenome" },
                values: new object[] { 5, "54343535454", "Khloé", "Kardashian" });

            migrationBuilder.InsertData(
                table: "Voos",
                columns: new[] { "Id", "Assento", "CiaAereaId", "DataPartida", "Horapartida", "NumdoVoo", "PassageiroId", "ValorPassagem" },
                values: new object[] { 5, "C21", "4", new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 12, 13, 55, 0, 0, DateTimeKind.Unspecified), 2, 1, "300.75" });

            migrationBuilder.InsertData(
                table: "Voos",
                columns: new[] { "Id", "Assento", "CiaAereaId", "DataPartida", "Horapartida", "NumdoVoo", "PassageiroId", "ValorPassagem" },
                values: new object[] { 3, "A09", "4", new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 12, 13, 55, 0, 0, DateTimeKind.Unspecified), 2, 2, "480.75" });

            migrationBuilder.InsertData(
                table: "Voos",
                columns: new[] { "Id", "Assento", "CiaAereaId", "DataPartida", "Horapartida", "NumdoVoo", "PassageiroId", "ValorPassagem" },
                values: new object[] { 2, "B14", "2", new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 12, 18, 5, 0, 0, DateTimeKind.Unspecified), 1, 3, "230.25" });

            migrationBuilder.InsertData(
                table: "Voos",
                columns: new[] { "Id", "Assento", "CiaAereaId", "DataPartida", "Horapartida", "NumdoVoo", "PassageiroId", "ValorPassagem" },
                values: new object[] { 4, "A14", "4", new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 12, 13, 55, 0, 0, DateTimeKind.Unspecified), 2, 4, "487.25" });

            migrationBuilder.InsertData(
                table: "Voos",
                columns: new[] { "Id", "Assento", "CiaAereaId", "DataPartida", "Horapartida", "NumdoVoo", "PassageiroId", "ValorPassagem" },
                values: new object[] { 1, "B01", "2", new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 12, 18, 5, 0, 0, DateTimeKind.Unspecified), 1, 5, "325.25" });

            migrationBuilder.CreateIndex(
                name: "IX_Voos_CiaAereaId",
                table: "Voos",
                column: "CiaAereaId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_PassageiroId",
                table: "Voos",
                column: "PassageiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voos");

            migrationBuilder.DropTable(
                name: "CiaAereas");

            migrationBuilder.DropTable(
                name: "Passageiros");
        }
    }
}
