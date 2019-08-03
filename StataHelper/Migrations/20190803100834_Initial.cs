using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StataHelper.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelCollections",
                columns: table => new
                {
                    LabelCollectionsID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabelName = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelCollections", x => x.LabelCollectionsID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectsID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Project = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectsID);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    LabelsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabelCollectionsID = table.Column<short>(nullable: false),
                    Key = table.Column<byte>(nullable: false),
                    Label = table.Column<string>(maxLength: 15, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.LabelsID);
                    table.ForeignKey(
                        name: "FK_Labels_LabelCollections_LabelCollectionsID",
                        column: x => x.LabelCollectionsID,
                        principalTable: "LabelCollections",
                        principalColumn: "LabelCollectionsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    VariablesID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Variable = table.Column<string>(maxLength: 8, nullable: false),
                    ProjectsID = table.Column<short>(nullable: false),
                    Description = table.Column<string>(maxLength: 20, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.VariablesID);
                    table.ForeignKey(
                        name: "FK_Variables_Projects_ProjectsID",
                        column: x => x.ProjectsID,
                        principalTable: "Projects",
                        principalColumn: "ProjectsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Varlabs",
                columns: table => new
                {
                    VarlabsID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VariablesID = table.Column<short>(nullable: false),
                    LabelsID = table.Column<short>(nullable: false),
                    LabelsID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varlabs", x => x.VarlabsID);
                    table.ForeignKey(
                        name: "FK_Varlabs_Labels_LabelsID1",
                        column: x => x.LabelsID1,
                        principalTable: "Labels",
                        principalColumn: "LabelsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Varlabs_Variables_VariablesID",
                        column: x => x.VariablesID,
                        principalTable: "Variables",
                        principalColumn: "VariablesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)1, "Short name of months of the year", "Short Months" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)2, "Full name of months of the year", "Full Months" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)3, "Short name of days of the week", "Short Weeks" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)4, "Full name of days of the week", "Full Weeks" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)5, "Short gender", "Short Gender" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)6, "Long gender", "Long Gender" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)7, "Short form of yes/no responses", "Short Yes/Nos" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)8, "Long form of yes/no responses", "Long Yes/No's" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)9, "True of false represented as T/F", "Short True/False" });

            migrationBuilder.InsertData(
                table: "LabelCollections",
                columns: new[] { "LabelCollectionsID", "Description", "LabelName" },
                values: new object[] { (short)10, "True of false as is", "True/False" });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 1, (byte)1, "Jan", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 28, (byte)4, "Thur", (short)3 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 29, (byte)5, "Fri", (short)3 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 30, (byte)6, "Sat", (short)3 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 31, (byte)7, "Sun", (short)3 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 33, (byte)1, "Monday", (short)4 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 34, (byte)2, "Tuesday", (short)4 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 35, (byte)3, "Wednesday", (short)4 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 36, (byte)4, "Thursday", (short)4 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 37, (byte)5, "Friday", (short)4 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 38, (byte)6, "Saturday", (short)4 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 39, (byte)7, "Sunday", (short)4 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 40, (byte)0, "F", (short)5 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 41, (byte)1, "M", (short)5 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 42, (byte)0, "Female", (short)6 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 43, (byte)1, "Male", (short)6 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 44, (byte)0, "Y", (short)7 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 45, (byte)1, "N", (short)7 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 46, (byte)0, "Yes", (short)8 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 47, (byte)1, "No", (short)8 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 48, (byte)0, "F", (short)9 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 49, (byte)1, "T", (short)9 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 27, (byte)3, "Wed", (short)3 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 26, (byte)2, "Tue", (short)3 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 25, (byte)1, "Mon", (short)3 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 24, (byte)12, "December", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 2, (byte)2, "Feb", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 3, (byte)3, "Mar", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 4, (byte)4, "Apr", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 5, (byte)5, "May", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 6, (byte)6, "Jun", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 7, (byte)7, "Jul", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 8, (byte)8, "Aug", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 9, (byte)9, "Sep", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 10, (byte)10, "Oct", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 11, (byte)11, "Nov", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 50, (byte)0, "False", (short)10 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 12, (byte)12, "Dec", (short)1 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 14, (byte)2, "February", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 15, (byte)3, "March", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 16, (byte)4, "April", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 17, (byte)5, "May", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 18, (byte)6, "June", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 19, (byte)7, "July", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 20, (byte)8, "August", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 21, (byte)9, "September", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 22, (byte)10, "October", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 23, (byte)11, "November", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 13, (byte)1, "January", (short)2 });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelsID", "Key", "Label", "LabelCollectionsID" },
                values: new object[] { 51, (byte)1, "True", (short)10 });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_LabelCollectionsID",
                table: "Labels",
                column: "LabelCollectionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Variables_ProjectsID",
                table: "Variables",
                column: "ProjectsID");

            migrationBuilder.CreateIndex(
                name: "IX_Varlabs_LabelsID1",
                table: "Varlabs",
                column: "LabelsID1");

            migrationBuilder.CreateIndex(
                name: "IX_Varlabs_VariablesID",
                table: "Varlabs",
                column: "VariablesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Varlabs");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "LabelCollections");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
