using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanYourDegree_WS02.Migrations
{
    public partial class Initial : Migration
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
                name: "Degree",
                columns: table => new
                {
                    DegreeId = table.Column<int>(nullable: false),
                    DegreeAbrrev = table.Column<string>(maxLength: 6, nullable: false),
                    DegreeName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.DegreeId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    First = table.Column<string>(maxLength: 40, nullable: false),
                    Last = table.Column<string>(maxLength: 40, nullable: false),
                    Snumber = table.Column<string>(nullable: true),
                    catpawsnum = table.Column<int>(nullable: false),
                    Done = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
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
                name: "DegreePlan",
                columns: table => new
                {
                    DegreePlanId = table.Column<int>(nullable: false),
                    DegreeID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    DegreePlanAbbrev = table.Column<string>(maxLength: 20, nullable: false),
                    DegreePlanName = table.Column<string>(maxLength: 30, nullable: false),
                    Done = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreePlan", x => x.DegreePlanId);
                    table.ForeignKey(
                        name: "FK_DegreePlan_Degree_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "Degree",
                        principalColumn: "DegreeId");
                    table.ForeignKey(
                        name: "FK_DegreePlan_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentTerm",
                columns: table => new
                {
                    StudentTermId = table.Column<int>(nullable: false),
                    Term = table.Column<int>(nullable: false),
                    TermLabel = table.Column<string>(maxLength: 20, nullable: false),
                    DegreePlanId = table.Column<int>(nullable: false),
                    Done = table.Column<bool>(nullable: false),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTerm", x => x.StudentTermId);
                    table.ForeignKey(
                        name: "FK_StudentTerm_DegreePlan_DegreePlanId",
                        column: x => x.DegreePlanId,
                        principalTable: "DegreePlan",
                        principalColumn: "DegreePlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTerm_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    RequirementID = table.Column<int>(nullable: false),
                    RequirementAbbrev = table.Column<string>(maxLength: 30, nullable: false),
                    CourseName = table.Column<string>(maxLength: 50, nullable: false),
                    DegreeId = table.Column<int>(nullable: false),
                    StudentTermId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.RequirementID);
                    table.ForeignKey(
                        name: "FK_Requirement_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirement_StudentTerm_StudentTermId",
                        column: x => x.StudentTermId,
                        principalTable: "StudentTerm",
                        principalColumn: "StudentTermId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DegreeplanTermRequirement",
                columns: table => new
                {
                    DegreePlanTermRequirementId = table.Column<int>(nullable: false),
                    DegreePlanID = table.Column<int>(nullable: false),
                    TermID = table.Column<int>(nullable: false),
                    RequirementID = table.Column<int>(nullable: false),
                    StudentTermId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeplanTermRequirement", x => x.DegreePlanTermRequirementId);
                    table.ForeignKey(
                        name: "FK_DegreeplanTermRequirement_DegreePlan_DegreePlanID",
                        column: x => x.DegreePlanID,
                        principalTable: "DegreePlan",
                        principalColumn: "DegreePlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeplanTermRequirement_Requirement_RequirementID",
                        column: x => x.RequirementID,
                        principalTable: "Requirement",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeplanTermRequirement_StudentTerm_StudentTermId",
                        column: x => x.StudentTermId,
                        principalTable: "StudentTerm",
                        principalColumn: "StudentTermId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DegreeRequirement",
                columns: table => new
                {
                    DegreeRequirementId = table.Column<int>(nullable: false),
                    DegreeId = table.Column<int>(nullable: false),
                    RequirementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeRequirement", x => x.DegreeRequirementId);
                    table.ForeignKey(
                        name: "FK_DegreeRequirement_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "DegreeId");
                    table.ForeignKey(
                        name: "FK_DegreeRequirement_Requirement_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirement",
                        principalColumn: "RequirementID");
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
                name: "IX_DegreePlan_DegreeID",
                table: "DegreePlan",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_DegreePlan_StudentID",
                table: "DegreePlan",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeplanTermRequirement_DegreePlanID",
                table: "DegreeplanTermRequirement",
                column: "DegreePlanID");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeplanTermRequirement_RequirementID",
                table: "DegreeplanTermRequirement",
                column: "RequirementID");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeplanTermRequirement_StudentTermId",
                table: "DegreeplanTermRequirement",
                column: "StudentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeRequirement_DegreeId",
                table: "DegreeRequirement",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeRequirement_RequirementId",
                table: "DegreeRequirement",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_DegreeId",
                table: "Requirement",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_StudentTermId",
                table: "Requirement",
                column: "StudentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTerm_DegreePlanId",
                table: "StudentTerm",
                column: "DegreePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTerm_StudentId",
                table: "StudentTerm",
                column: "StudentId");
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
                name: "DegreeplanTermRequirement");

            migrationBuilder.DropTable(
                name: "DegreeRequirement");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "StudentTerm");

            migrationBuilder.DropTable(
                name: "DegreePlan");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
