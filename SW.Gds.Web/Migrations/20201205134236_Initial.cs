using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SW.Gds.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "gds");

            migrationBuilder.CreateTable(
                name: "country",
                schema: "gds",
                columns: table => new
                {
                    id = table.Column<string>(type: "character(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    iso_code3 = table.Column<string>(type: "character(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    iso_number = table.Column<short>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    capital = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    tld = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    phone = table.Column<int>(type: "integer", nullable: false),
                    post_code_format = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    post_code_regex = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    languages = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    currency_code = table.Column<string>(type: "character(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    currency_name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phone_numbering_plan",
                schema: "gds",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country = table.Column<string>(type: "character(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    type = table.Column<byte>(type: "smallint", nullable: false),
                    area_code_length = table.Column<byte>(type: "smallint", nullable: false),
                    min_length = table.Column<byte>(type: "smallint", nullable: false),
                    max_length = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_phone_numbering_plan", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_country_currency_code",
                schema: "gds",
                table: "country",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_country_iso_code3",
                schema: "gds",
                table: "country",
                column: "iso_code3");

            migrationBuilder.CreateIndex(
                name: "ix_country_iso_number",
                schema: "gds",
                table: "country",
                column: "iso_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "country",
                schema: "gds");

            migrationBuilder.DropTable(
                name: "phone_numbering_plan",
                schema: "gds");
        }
    }
}
