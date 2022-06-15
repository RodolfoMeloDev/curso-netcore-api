using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations
{
    public partial class Uf_Municipio_Cep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0efb9fe7-562b-49b6-bf64-783b02583449"));

            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Sigla = table.Column<string>(maxLength: 2, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    CodIBGE = table.Column<int>(nullable: false),
                    UfId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cep",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 60, nullable: false),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    MunicipioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cep_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "CreateAt", "Nome", "Sigla", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("3288e581-e757-4eb8-9733-cbb70d55a0eb"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4167), "Acre", "AC", null },
                    { new Guid("c9a717c5-5867-4214-b805-c6602dac8015"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4246), "Sergipe", "SE", null },
                    { new Guid("716321b8-2d7e-4a74-ab1f-b2d677ac4e45"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4244), "São Paulo", "SP", null },
                    { new Guid("32951f32-4525-4792-a56e-8c33c58d3c29"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4243), "Santa Catarina", "SC", null },
                    { new Guid("62c6a60b-dad1-4ba3-8c77-58f123d11698"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4240), "Roraima", "RR", null },
                    { new Guid("43206e20-fb64-4d67-96ae-df791565c62b"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4239), "Rondônia", "RO", null },
                    { new Guid("e2f51d32-b690-4605-a3c8-933eac54a0c6"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4237), "Rio Grande do Sul", "RS", null },
                    { new Guid("1baf28b2-1226-4667-ac65-285a0eec7700"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4236), "Rio Grande do Norte", "RN", null },
                    { new Guid("3dccb54e-3849-4031-a263-651bc735af99"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4235), "Rio de Janeiro", "RJ", null },
                    { new Guid("40cf97e6-9b8e-463e-9f3f-c71fca2268dd"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4234), "Piauí", "PI", null },
                    { new Guid("c67a06cb-3a94-4269-a27f-94d60b02a696"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4232), "Pernambuco", "PE", null },
                    { new Guid("e2bfd56b-239e-41b3-bc12-4267971b28de"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4231), "Paraná", "PR", null },
                    { new Guid("c6219f8b-eaf2-4deb-817d-1006dc327657"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4227), "Paraíba", "PB", null },
                    { new Guid("d927e748-2adb-40ca-84f6-fc71ce2b13e9"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4226), "Pará", "PA", null },
                    { new Guid("2e7ccd9c-3d30-4f38-a60b-372ccfce48a5"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4225), "Minas Gerais", "MG", null },
                    { new Guid("a14c6830-c68b-41da-a9a2-2ccd353f2b92"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4223), "Mato Grosso do Sul", "MS", null },
                    { new Guid("957b661e-ebfa-4abb-8797-40be5b071bae"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4222), "Mato Grosso", "MT", null },
                    { new Guid("00a4a51c-f313-46f1-9259-9dd13e5fc75f"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4221), "Maranhão", "MA", null },
                    { new Guid("7dd11d6b-c8d0-476c-b1ad-748dadf96a30"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4219), "Goiás", "GO", null },
                    { new Guid("19547a13-0d11-4228-91be-eacd3d9db48e"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4218), "Espírito Santo", "ES", null },
                    { new Guid("246b07ac-f2de-442f-833d-b3846df15762"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4212), "Distrito Federal", "DF", null },
                    { new Guid("bb0f8cb5-4c7f-4fc7-9a6f-0065f00f4301"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4211), "Ceara", "CE", null },
                    { new Guid("a3bb6218-35fb-488d-a424-799a474d6eee"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4209), "Bahia", "BA", null },
                    { new Guid("0de15f83-0e35-4d21-9bae-d4ca40fa4c95"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4208), "Amazonas", "AM", null },
                    { new Guid("331dfce2-9ebb-4e0f-996f-c57c02ad166f"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4206), "Amapá", "AP", null },
                    { new Guid("ea42922a-b199-4f55-849f-1c0de46be666"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4204), "Alagoas", "AL", null },
                    { new Guid("29596d6d-df1a-45cb-824b-2472bffbebc7"), new DateTime(2022, 6, 15, 22, 0, 6, 271, DateTimeKind.Utc).AddTicks(4247), "STocantins", "TO", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("4fab99be-2508-4f67-b2e6-3f8bc891da71"), new DateTime(2022, 6, 15, 22, 0, 6, 269, DateTimeKind.Utc).AddTicks(5421), "admin@mail.com", "Administrador", null });

            migrationBuilder.CreateIndex(
                name: "IX_Cep_Cep",
                table: "Cep",
                column: "Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Cep_MunicipioId",
                table: "Cep",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_CodIBGE",
                table: "Municipio",
                column: "CodIBGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_UfId",
                table: "Municipio",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Uf_Sigla",
                table: "Uf",
                column: "Sigla",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cep");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Uf");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4fab99be-2508-4f67-b2e6-3f8bc891da71"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("0efb9fe7-562b-49b6-bf64-783b02583449"), new DateTime(2022, 5, 25, 0, 15, 2, 599, DateTimeKind.Utc).AddTicks(1861), "admin@mail.com", "Administrador", null });
        }
    }
}
