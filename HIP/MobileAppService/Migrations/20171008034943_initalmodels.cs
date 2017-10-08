using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HIP.MobileAppService.Migrations
{
    public partial class initalmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventOccurrence",
                columns: table => new
                {
                    BlackoutTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EventModelId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOccurrence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventOccurrence_Events_EventModelId1",
                        column: x => x.EventModelId1,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventOccurrence_Events_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecurringEventOccurrence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EventModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecurrenceEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecurrenceStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecurringDay = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringEventOccurrence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringEventOccurrence_Events_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventOccurrence_EventModelId1",
                table: "EventOccurrence",
                column: "EventModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_EventOccurrence_EventModelId",
                table: "EventOccurrence",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypeId",
                table: "Events",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringEventOccurrence_EventModelId",
                table: "RecurringEventOccurrence",
                column: "EventModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventOccurrence");

            migrationBuilder.DropTable(
                name: "RecurringEventOccurrence");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventType");
        }
    }
}
