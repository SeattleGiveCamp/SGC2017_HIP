using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HIP.MobileAppService.Migrations
{
    public partial class changetoprogram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCheckIns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourCount = table.Column<double>(type: "float", nullable: false),
                    ParentUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCheckIns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "EventBlackouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlackoutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBlackouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventOccurences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOccurences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramTypes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTypes", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_ProgramTypes_Name",
                        column: x => x.Name,
                        principalTable: "ProgramTypes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecurringEventOccurrences",
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
                    table.PrimaryKey("PK_RecurringEventOccurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringEventOccurrences_Events_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventBlackouts_EventModelId",
                table: "EventBlackouts",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOccurences_EventModelId",
                table: "EventOccurences",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Name",
                table: "Events",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTypes_EventModelId",
                table: "ProgramTypes",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringEventOccurrences_EventModelId",
                table: "RecurringEventOccurrences",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlackouts_Events_EventModelId",
                table: "EventBlackouts",
                column: "EventModelId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventOccurences_Events_EventModelId",
                table: "EventOccurences",
                column: "EventModelId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramTypes_Events_EventModelId",
                table: "ProgramTypes",
                column: "EventModelId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramTypes_Events_EventModelId",
                table: "ProgramTypes");

            migrationBuilder.DropTable(
                name: "EventBlackouts");

            migrationBuilder.DropTable(
                name: "EventCheckIns");

            migrationBuilder.DropTable(
                name: "EventOccurences");

            migrationBuilder.DropTable(
                name: "RecurringEventOccurrences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ProgramTypes");
        }
    }
}
