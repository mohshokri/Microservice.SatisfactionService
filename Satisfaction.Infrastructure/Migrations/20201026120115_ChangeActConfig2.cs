using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Satisfaction.Infrastructure.Migrations
{
    public partial class ChangeActConfig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SurveyAssignmentSequenceId",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SurveyConfigurationSequenceId",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SurveySequenceId",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedChassisId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "CochranFormula",
                columns: table => new
                {
                    CochranFormulaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<int>(nullable: false),
                    Max = table.Column<int>(nullable: false),
                    Trimester = table.Column<int>(nullable: false),
                    OneMonth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CochranFormula", x => x.CochranFormulaId);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    FranchiseId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    BranchCode = table.Column<string>(nullable: false),
                    BranchTitle = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.FranchiseId);
                });

            migrationBuilder.CreateTable(
                name: "OutBoxes",
                columns: table => new
                {
                    OutboxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActId = table.Column<int>(nullable: false),
                    SendType = table.Column<int>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsSent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutBoxes", x => x.OutboxId);
                });

            migrationBuilder.CreateTable(
                name: "SendMessages",
                columns: table => new
                {
                    SendMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageTemplateId = table.Column<int>(nullable: false),
                    ActId = table.Column<int>(nullable: false),
                    CustomizedTextMessage = table.Column<string>(maxLength: 500, nullable: true),
                    SendType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendMessages", x => x.SendMessageId);
                });

            migrationBuilder.CreateTable(
                name: "SurveyConfigurations",
                columns: table => new
                {
                    SurveyConfigurationId = table.Column<int>(nullable: false),
                    SurveyType = table.Column<int>(nullable: false),
                    ImpactRate = table.Column<int>(nullable: false),
                    SamplingMethod = table.Column<int>(nullable: false),
                    Creator = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyConfigurations", x => x.SurveyConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyId = table.Column<int>(nullable: false),
                    PartyId = table.Column<int>(nullable: false),
                    SurveyCode = table.Column<string>(maxLength: 50, nullable: false),
                    SurveyType = table.Column<int>(nullable: false),
                    SurveyTitle = table.Column<string>(maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SurveyImage_LogoAttachmentContent = table.Column<byte[]>(nullable: true),
                    SurveyImage_LogoFileExtention = table.Column<string>(nullable: true),
                    ActivationRange_StartDate = table.Column<DateTime>(nullable: true),
                    ActivationRange_EndDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<int>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyId);
                });

            migrationBuilder.CreateTable(
                name: "TimeSettings",
                columns: table => new
                {
                    TimeSettingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSettings", x => x.TimeSettingId);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<int>(nullable: false),
                    PartyCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Family = table.Column<string>(nullable: false),
                    FranchiseId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    Creator = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<int>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Roles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Parties_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "FranchiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageTemplates",
                columns: table => new
                {
                    MessageTemplateId = table.Column<int>(nullable: false),
                    TemplateTitle = table.Column<string>(nullable: false),
                    TemplateText = table.Column<string>(nullable: false),
                    IsFix = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplates", x => x.MessageTemplateId);
                    table.ForeignKey(
                        name: "FK_MessageTemplates_SendMessages_MessageTemplateId",
                        column: x => x.MessageTemplateId,
                        principalTable: "SendMessages",
                        principalColumn: "SendMessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(nullable: false),
                    QuestionTitle = table.Column<string>(maxLength: 500, nullable: false),
                    QuestionOrder = table.Column<int>(nullable: false),
                    Required = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyScores",
                columns: table => new
                {
                    SurveyScoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(nullable: false),
                    MinScore = table.Column<int>(nullable: false),
                    MaxScore = table.Column<int>(nullable: false),
                    SatisfactionRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyScores", x => x.SurveyScoreId);
                    table.ForeignKey(
                        name: "FK_SurveyScores_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAssignments",
                columns: table => new
                {
                    SurveyAssignmentId = table.Column<int>(nullable: false),
                    SurveyConfigurationId = table.Column<int>(nullable: false),
                    PartyId = table.Column<int>(nullable: false),
                    FranchiseId = table.Column<int>(nullable: false),
                    ProductType = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAssignments", x => x.SurveyAssignmentId);
                    table.ForeignKey(
                        name: "FK_SurveyAssignments_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionItems",
                columns: table => new
                {
                    QuestionItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionItemTitle = table.Column<string>(maxLength: 40, nullable: false),
                    QuestionItemValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionItems", x => x.QuestionItemId);
                    table.ForeignKey(
                        name: "FK_QuestionItems_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedChassis",
                columns: table => new
                {
                    AssignedChassisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyAssignmentId = table.Column<int>(nullable: false),
                    ChassisNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedChassis", x => x.AssignedChassisId);
                    table.ForeignKey(
                        name: "FK_AssignedChassis_SurveyAssignments_SurveyAssignmentId",
                        column: x => x.SurveyAssignmentId,
                        principalTable: "SurveyAssignments",
                        principalColumn: "SurveyAssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestionItems",
                columns: table => new
                {
                    AnswerQuestionItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(nullable: false),
                    QuestionItemId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestionItems", x => x.AnswerQuestionItemId);
                    table.ForeignKey(
                        name: "FK_AnswerQuestionItems_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerQuestionItems_QuestionItems_QuestionItemId",
                        column: x => x.QuestionItemId,
                        principalTable: "QuestionItems",
                        principalColumn: "QuestionItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acts",
                columns: table => new
                {
                    ActId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedChassisId = table.Column<int>(nullable: false),
                    IsSuccessCall = table.Column<bool>(nullable: false),
                    IsSurvey = table.Column<bool>(nullable: false),
                    AnswerId = table.Column<int>(nullable: true),
                    CustomerState = table.Column<int>(nullable: false),
                    ActDate = table.Column<DateTime>(nullable: false),
                    AlarmDate = table.Column<DateTime>(nullable: false),
                    AlarmTime = table.Column<DateTime>(nullable: false),
                    AlarmDescription = table.Column<string>(maxLength: 500, nullable: true),
                    ContactType = table.Column<int>(nullable: false),
                    CrmSupervisorDescription = table.Column<string>(maxLength: 500, nullable: true),
                    Creator = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.ActId);
                    table.ForeignKey(
                        name: "FK_Acts_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acts_AssignedChassis_AssignedChassisId",
                        column: x => x.AssignedChassisId,
                        principalTable: "AssignedChassis",
                        principalColumn: "AssignedChassisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acts_AnswerId",
                table: "Acts",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Acts_AssignedChassisId",
                table: "Acts",
                column: "AssignedChassisId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestionItems_AnswerId",
                table: "AnswerQuestionItems",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestionItems_QuestionItemId",
                table: "AnswerQuestionItems",
                column: "QuestionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedChassis_SurveyAssignmentId",
                table: "AssignedChassis",
                column: "SurveyAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_FranchiseId",
                table: "Parties",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionItems_QuestionId",
                table: "QuestionItems",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAssignments_PartyId",
                table: "SurveyAssignments",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyScores_SurveyId",
                table: "SurveyScores",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acts");

            migrationBuilder.DropTable(
                name: "AnswerQuestionItems");

            migrationBuilder.DropTable(
                name: "CochranFormula");

            migrationBuilder.DropTable(
                name: "MessageTemplates");

            migrationBuilder.DropTable(
                name: "OutBoxes");

            migrationBuilder.DropTable(
                name: "SurveyConfigurations");

            migrationBuilder.DropTable(
                name: "SurveyScores");

            migrationBuilder.DropTable(
                name: "TimeSettings");

            migrationBuilder.DropTable(
                name: "AssignedChassis");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionItems");

            migrationBuilder.DropTable(
                name: "SendMessages");

            migrationBuilder.DropTable(
                name: "SurveyAssignments");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Franchises");

            migrationBuilder.DropSequence(
                name: "SurveyAssignmentSequenceId");

            migrationBuilder.DropSequence(
                name: "SurveyConfigurationSequenceId");

            migrationBuilder.DropSequence(
                name: "SurveySequenceId");
        }
    }
}
