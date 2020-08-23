using Microsoft.EntityFrameworkCore.Migrations;

namespace lcaworld.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCompartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    CompartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCompartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCompartments_Compartments_CompartmentId",
                        column: x => x.CompartmentId,
                        principalTable: "Compartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementaryFlows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    CompartmentId = table.Column<int>(nullable: false),
                    SubCompartmentId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementaryFlows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementaryFlows_Compartments_CompartmentId",
                        column: x => x.CompartmentId,
                        principalTable: "Compartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementaryFlows_SubCompartments_SubCompartmentId",
                        column: x => x.SubCompartmentId,
                        principalTable: "SubCompartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementaryFlows_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterisationFactors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MethodId = table.Column<int>(nullable: false),
                    ElementaryFlowId = table.Column<int>(nullable: false),
                    Factor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterisationFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterisationFactors_ElementaryFlows_ElementaryFlowId",
                        column: x => x.ElementaryFlowId,
                        principalTable: "ElementaryFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterisationFactors_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessExchanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessId = table.Column<int>(nullable: false),
                    ElementaryFlowId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessExchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessExchanges_ElementaryFlows_ElementaryFlowId",
                        column: x => x.ElementaryFlowId,
                        principalTable: "ElementaryFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessExchanges_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterisationFactors_ElementaryFlowId",
                table: "CharacterisationFactors",
                column: "ElementaryFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterisationFactors_MethodId",
                table: "CharacterisationFactors",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementaryFlows_CompartmentId",
                table: "ElementaryFlows",
                column: "CompartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementaryFlows_SubCompartmentId",
                table: "ElementaryFlows",
                column: "SubCompartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementaryFlows_UnitId",
                table: "ElementaryFlows",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessExchanges_ElementaryFlowId",
                table: "ProcessExchanges",
                column: "ElementaryFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessExchanges_ProcessId",
                table: "ProcessExchanges",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCompartments_CompartmentId",
                table: "SubCompartments",
                column: "CompartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterisationFactors");

            migrationBuilder.DropTable(
                name: "ProcessExchanges");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "ElementaryFlows");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "SubCompartments");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Compartments");
        }
    }
}
