using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevLife.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkillModificator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modificator = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkillModificator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modificator = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTutorialFinished = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTemplate_ContractType_ContractTypesId",
                        column: x => x.ContractTypesId,
                        principalTable: "ContractType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CFrontEnd = table.Column<int>(type: "int", nullable: false),
                    CBackEnd = table.Column<int>(type: "int", nullable: false),
                    CDevops = table.Column<int>(type: "int", nullable: false),
                    CDatabase = table.Column<int>(type: "int", nullable: false),
                    IsAvalaible = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeName_EmployeeNameId",
                        column: x => x.EmployeeNameId,
                        principalTable: "EmployeeName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkillEmployeeSkillModificator",
                columns: table => new
                {
                    EmployeeSkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillModificatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkillEmployeeSkillModificator", x => new { x.EmployeeSkillsId, x.SkillModificatorsId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkillEmployeeSkillModificator_EmployeeSkillModificator_SkillModificatorsId",
                        column: x => x.SkillModificatorsId,
                        principalTable: "EmployeeSkillModificator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkillEmployeeSkillModificator_EmployeeSkill_EmployeeSkillsId",
                        column: x => x.EmployeeSkillsId,
                        principalTable: "EmployeeSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMaterialSkill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialTemplate_MaterialSkill_MaterialSkillId",
                        column: x => x.MaterialSkillId,
                        principalTable: "MaterialSkill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompany = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdContractTemplate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: true),
                    Reward = table.Column<int>(type: "int", nullable: false),
                    ContractTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_ContractTemplate_ContractTemplateId",
                        column: x => x.ContractTemplateId,
                        principalTable: "ContractTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => new { x.EmployeeId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmployeeSkill",
                columns: table => new
                {
                    EmployeeSkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmployeeSkill", x => new { x.EmployeeSkillsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_EmployeeEmployeeSkill_EmployeeSkill_EmployeeSkillsId",
                        column: x => x.EmployeeSkillsId,
                        principalTable: "EmployeeSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployeeSkill_Employee_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmployee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompany = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMaterialTemplate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_MaterialTemplate_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyContractEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContractEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContractEmployee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContractEmployee_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContractEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMaterialEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMaterialEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyMaterialEmployee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMaterialEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMaterialEmployee_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContractEmployee_CompanyId_EmployeeId",
                table: "CompanyContractEmployee",
                columns: new[] { "CompanyId", "EmployeeId" },
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContractEmployee_ContractId_EmployeeId",
                table: "CompanyContractEmployee",
                columns: new[] { "ContractId", "EmployeeId" },
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContractEmployee_EmployeeId",
                table: "CompanyContractEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_CompanyId",
                table: "CompanyEmployee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeeId",
                table: "CompanyEmployee",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaterialEmployee_CompanyId",
                table: "CompanyMaterialEmployee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaterialEmployee_EmployeeId",
                table: "CompanyMaterialEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaterialEmployee_MaterialId_CompanyId",
                table: "CompanyMaterialEmployee",
                columns: new[] { "MaterialId", "CompanyId" },
                unique: true,
                filter: "[MaterialId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaterialEmployee_MaterialId_EmployeeId",
                table: "CompanyMaterialEmployee",
                columns: new[] { "MaterialId", "EmployeeId" },
                unique: true,
                filter: "[MaterialId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractTemplateId",
                table: "Contract",
                column: "ContractTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTemplate_ContractTypesId",
                table: "ContractTemplate",
                column: "ContractTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeNameId",
                table: "Employee",
                column: "EmployeeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployeeSkill_EmployeesId",
                table: "EmployeeEmployeeSkill",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkillEmployeeSkillModificator_SkillModificatorsId",
                table: "EmployeeSkillEmployeeSkillModificator",
                column: "SkillModificatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialTypeId",
                table: "Material",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTemplate_MaterialSkillId",
                table: "MaterialTemplate",
                column: "MaterialSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CompanyId",
                table: "Player",
                column: "CompanyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyContractEmployee");

            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropTable(
                name: "CompanyMaterialEmployee");

            migrationBuilder.DropTable(
                name: "EmployeeEmployeeSkill");

            migrationBuilder.DropTable(
                name: "EmployeeSkillEmployeeSkillModificator");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeSkillModificator");

            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ContractTemplate");

            migrationBuilder.DropTable(
                name: "MaterialTemplate");

            migrationBuilder.DropTable(
                name: "EmployeeName");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropTable(
                name: "MaterialSkill");
        }
    }
}
