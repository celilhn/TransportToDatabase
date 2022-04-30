using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "varchar(1000)", nullable: true),
                    CreditId = table.Column<string>(type: "varchar(100)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    EpisodeCount = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "varchar(300)", nullable: true),
                    Job = table.Column<string>(type: "varchar(200)", nullable: true),
                    EpisodeCount = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    AspectRatio = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Iso6391 = table.Column<string>(type: "varchar(180)", nullable: true),
                    FilePath = table.Column<string>(type: "varchar(180)", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: false),
                    VoteCount = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KnownFors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    MediaType = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownFors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    PersonOldID = table.Column<int>(type: "int", nullable: false),
                    Adult = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    KnownForDepartment = table.Column<string>(type: "varchar(200)", nullable: true),
                    Name = table.Column<string>(type: "varchar(180)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    ProfilePath = table.Column<string>(type: "varchar(200)", nullable: true),
                    Biography = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deathday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Homepage = table.Column<string>(type: "varchar(300)", nullable: true),
                    ImdbId = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaIDs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    FreebaseMid = table.Column<string>(type: "varchar(100)", nullable: true),
                    FreebaseId = table.Column<string>(type: "varchar(100)", nullable: true),
                    ImdbId = table.Column<string>(type: "varchar(100)", nullable: true),
                    TvrageId = table.Column<int>(type: "int", nullable: false),
                    FacebookId = table.Column<string>(type: "varchar(100)", nullable: true),
                    InstagramId = table.Column<string>(type: "varchar(100)", nullable: true),
                    TwitterId = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaIDs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casts");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "KnownFors");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "SocialMediaIDs");
        }
    }
}
