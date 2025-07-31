using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamProject.Migrations
{
    /// <inheritdoc />
    public partial class AddAvailabilityToSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionMode",
                columns: table => new
                {
                    QuestionModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionMode = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    GivenPoint = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionMode", x => x.QuestionModeId);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Class_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    TeacherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    TeacherPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teacher_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    StudentRoll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Class",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    AvailableTime = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Class",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "TeachertQA",
                columns: table => new
                {
                    TeacherQuestionAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    QuestionModeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachertQA", x => x.TeacherQuestionAnswerId);
                    table.ForeignKey(
                        name: "FK_TeachertQA_QuestionMode",
                        column: x => x.QuestionModeId,
                        principalTable: "QuestionMode",
                        principalColumn: "QuestionModeId");
                    table.ForeignKey(
                        name: "FK_TeachertQA_Subject",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswer",
                columns: table => new
                {
                    StudentAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TeacherQuestionAnswerId = table.Column<int>(type: "int", nullable: true),
                    QuestionModeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswer", x => x.StudentAnswerId);
                    table.ForeignKey(
                        name: "FK_StudentAnswer_QuestionMode",
                        column: x => x.QuestionModeId,
                        principalTable: "QuestionMode",
                        principalColumn: "QuestionModeId");
                    table.ForeignKey(
                        name: "FK_StudentAnswer_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                    table.ForeignKey(
                        name: "FK_StudentAnswer_TeachertQA",
                        column: x => x.TeacherQuestionAnswerId,
                        principalTable: "TeachertQA",
                        principalColumn: "TeacherQuestionAnswerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_DepartmentId",
                table: "Class",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_QuestionModeId",
                table: "StudentAnswer",
                column: "QuestionModeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_StudentId",
                table: "StudentAnswer",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_TeacherQuestionAnswerId",
                table: "StudentAnswer",
                column: "TeacherQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ClassId",
                table: "Subject",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DepartmentId",
                table: "Teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachertQA_QuestionModeId",
                table: "TeachertQA",
                column: "QuestionModeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachertQA_SubjectId",
                table: "TeachertQA",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAnswer");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TeachertQA");

            migrationBuilder.DropTable(
                name: "QuestionMode");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
