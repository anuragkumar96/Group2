using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanYourDegree.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DegreeReq",
                columns: table => new
                {
                    DegreeReqId = table.Column<int>(nullable: false),
                    DegreeId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeReq", x => x.DegreeReqId);
                });

            migrationBuilder.CreateTable(
                name: "DegreeTermReq",
                columns: table => new
                {
                    DegreeTermReqId = table.Column<int>(nullable: false),
                    DegreePlanId = table.Column<int>(nullable: false),
                    StudentTermId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeTermReq", x => x.DegreeTermReqId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    CourseAbbrev = table.Column<string>(maxLength: 10, nullable: false),
                    CourseName = table.Column<string>(nullable: false),
                    DegreeReqId = table.Column<int>(nullable: true),
                    DegreeTermReqId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_DegreeReq_DegreeReqId",
                        column: x => x.DegreeReqId,
                        principalTable: "DegreeReq",
                        principalColumn: "DegreeReqId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_DegreeTermReq_DegreeTermReqId",
                        column: x => x.DegreeTermReqId,
                        principalTable: "DegreeTermReq",
                        principalColumn: "DegreeTermReqId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DegreePlan",
                columns: table => new
                {
                    DegreePlanId = table.Column<int>(nullable: false),
                    DegreeId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    DegreePlanAbbreve = table.Column<string>(maxLength: 20, nullable: false),
                    DegreePlanName = table.Column<string>(maxLength: 50, nullable: true),
                    DegreeTermReqId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreePlan", x => x.DegreePlanId);
                    table.ForeignKey(
                        name: "FK_DegreePlan_DegreeTermReq_DegreeTermReqId",
                        column: x => x.DegreeTermReqId,
                        principalTable: "DegreeTermReq",
                        principalColumn: "DegreeTermReqId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTerm",
                columns: table => new
                {
                    StudentTermId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Term = table.Column<int>(nullable: false),
                    TermName = table.Column<string>(maxLength: 20, nullable: false),
                    TermAbbrev = table.Column<string>(maxLength: 10, nullable: false),
                    DegreeTermReqId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTerm", x => x.StudentTermId);
                    table.ForeignKey(
                        name: "FK_StudentTerm_DegreeTermReq_DegreeTermReqId",
                        column: x => x.DegreeTermReqId,
                        principalTable: "DegreeTermReq",
                        principalColumn: "DegreeTermReqId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    DegreeId = table.Column<int>(nullable: false),
                    DegreeAbbrive = table.Column<string>(maxLength: 20, nullable: false),
                    DegreeName = table.Column<string>(maxLength: 40, nullable: false),
                    DegreePlanId = table.Column<int>(nullable: true),
                    DegreeReqId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.DegreeId);
                    table.ForeignKey(
                        name: "FK_Degree_DegreePlan_DegreePlanId",
                        column: x => x.DegreePlanId,
                        principalTable: "DegreePlan",
                        principalColumn: "DegreePlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Degree_DegreeReq_DegreeReqId",
                        column: x => x.DegreeReqId,
                        principalTable: "DegreeReq",
                        principalColumn: "DegreeReqId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    NineOneNine = table.Column<int>(maxLength: 9, nullable: false),
                    DegreePlanId = table.Column<int>(nullable: true),
                    StudentTermId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_DegreePlan_DegreePlanId",
                        column: x => x.DegreePlanId,
                        principalTable: "DegreePlan",
                        principalColumn: "DegreePlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_StudentTerm_StudentTermId",
                        column: x => x.StudentTermId,
                        principalTable: "StudentTerm",
                        principalColumn: "StudentTermId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DegreeReqId",
                table: "Course",
                column: "DegreeReqId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DegreeTermReqId",
                table: "Course",
                column: "DegreeTermReqId");

            migrationBuilder.CreateIndex(
                name: "IX_Degree_DegreePlanId",
                table: "Degree",
                column: "DegreePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Degree_DegreeReqId",
                table: "Degree",
                column: "DegreeReqId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreePlan_DegreeTermReqId",
                table: "DegreePlan",
                column: "DegreeTermReqId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DegreePlanId",
                table: "Student",
                column: "DegreePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentTermId",
                table: "Student",
                column: "StudentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTerm_DegreeTermReqId",
                table: "StudentTerm",
                column: "DegreeTermReqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DegreeReq");

            migrationBuilder.DropTable(
                name: "DegreePlan");

            migrationBuilder.DropTable(
                name: "StudentTerm");

            migrationBuilder.DropTable(
                name: "DegreeTermReq");
        }
    }
}
