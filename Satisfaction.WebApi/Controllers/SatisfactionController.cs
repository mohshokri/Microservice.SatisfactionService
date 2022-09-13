using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Satisfaction.Application.Commands.Acts;
using Satisfaction.Application.Commands.SurveyAssignments;
using Satisfaction.Application.Commands.Surveys;
using Satisfaction.Application.DTOs;
using Satisfaction.Application.Queries.AssignedChassis;
using Satisfaction.Application.Queries.CallHistory;
using Satisfaction.Application.Queries.ChassisIncluded;
using Satisfaction.Application.Queries.Configurations;
using Satisfaction.Application.Queries.ContactTypes;
using Satisfaction.Application.Queries.CustomerStates;
using Satisfaction.Application.Queries.Franchises;
using Satisfaction.Application.Queries.Parties;
using Satisfaction.Application.Queries.SurveyQuestions;
using Satisfaction.Application.Queries.Surveys;
using Satisfaction.Application.Queries.SurveyTitles;
using Satisfaction.Application.Services;
using Satisfaction.Domain.AggregatesModel.ActAggregate;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;
using SurveyConfiguration = Satisfaction.Application.Queries.Configurations.SurveyConfiguration;
using SurveyQuestion = Satisfaction.Application.Commands.Surveys.SurveyQuestion;
using SurveyQuestionItem = Satisfaction.Application.Commands.Surveys.SurveyQuestionItem;

namespace Satisfaction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisfactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISurveyQueryService _surveyQueryService;
        private readonly ISurveyConfigurationRepository _surveyConfigurationRepository;
        private readonly ISurveyTitleQueryService _surveyTitleQueryService;
        private readonly IAssignedChassisQueryService _assignedChassisQueryService;
        public SatisfactionController(IMediator mediator, ISurveyQueryService surveyQueryService, ISurveyConfigurationRepository surveyCfgRepository, ISurveyTitleQueryService surveyTitleQueryService, IAssignedChassisQueryService assignedChassisQueryService)
        {
            //if (mediator == null)
            //    throw new ArgumentNullException(nameof(mediator));
            //_mediator = mediator;

            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _surveyQueryService = surveyQueryService;
            _surveyConfigurationRepository = surveyCfgRepository;
            _surveyTitleQueryService = surveyTitleQueryService;
            _assignedChassisQueryService = assignedChassisQueryService;
        }

        [HttpGet("GetSurveyList")]
        public async Task<List<SurveyListViewModel>> GetSurveyList()
        {
            return await _surveyQueryService.GetSurveyListQuery();
        }


        [HttpGet("GetSelectedSurvey")]
        public async Task<SurveyViewModel> GetSelectedSurvey(int surveyId)
        {
            return await _surveyQueryService.GetSelectedSurvey(surveyId);
        }


        [HttpPost("CreateSurvey")]
        public async Task CreateSurvey([FromBody] CreateSurveyRequest createSurveyRequest)
        {
            var command = MapRequestToCommand(createSurveyRequest);
            await _mediator.Send(command);
        }

        private CreateSurveyCommand MapRequestToCommand(CreateSurveyRequest createSurveyRequest)
        {
            var questionList = createSurveyRequest.Questions.Select(q =>
            {
                var questionItems = q.QuestionItems.Select(s => { return new SurveyQuestionItem(s.QuestionItemTitle); }).ToList();
                return new SurveyQuestion(q.QuestionTitle, q.QuestionOrder, q.Required,/* q.Creator,*/ questionItems);
            }).ToList();

            var surveyType = SurveyType.FromValue(createSurveyRequest.SurveyType);
            return new CreateSurveyCommand(createSurveyRequest.SurveyCode, surveyType, createSurveyRequest.SurveyTitle
                , createSurveyRequest.LogoAttachmentContent, createSurveyRequest.LogoFileExtention,
                createSurveyRequest.IsActive, createSurveyRequest.StartDate,
                createSurveyRequest.EndDate, questionList, createSurveyRequest.Creator);
        }

        [HttpPost("EditSurvey")]
        public async Task EditSurvey(EditSurveyRequest editSurveyRequest)
        {
            var command = MapRequestToCommand(editSurveyRequest);
            await _mediator.Send(command);
        }
        private EditSurveyCommand MapRequestToCommand(EditSurveyRequest editSurveyRequest)
        {
            var questionList = editSurveyRequest.Questions.Select(q =>
            {
                var questionItems = q.QuestionItems.Select(s => { return new SurveyQuestionItem(s.QuestionItemTitle); }).ToList();
                return new SurveyQuestion(q.QuestionTitle, q.QuestionOrder, q.Required/*, q.Creator*/, questionItems);
            }).ToList();

            return new EditSurveyCommand(editSurveyRequest.SurveyCode, editSurveyRequest.SurveyType, editSurveyRequest.SurveyTitle
                , editSurveyRequest.LogoAttachmentContent, editSurveyRequest.LogoFileExtention,
                editSurveyRequest.IsActive, editSurveyRequest.StartDate,
                editSurveyRequest.EndDate, questionList, editSurveyRequest.Creator);
        }

        [HttpGet("GetSurveyConfigurationList")]
        public async Task<IEnumerable<SurveyConfiguration>> GetSurveyConfigurationList([FromQuery] GetSurveyConfigurationQuery query)
        {
            var configurationList = await _mediator.Send(query);
            return configurationList.SurveyConfigurations;
        }

        [HttpGet("GetChassisIncludedCount")]
        public async Task<int> GetChassisIncludedCount([FromQuery] GetChassisIncludedQuery query)
        {
            return await _mediator.Send(query);
        }
        //[HttpGet("GetChassisIncludedCount")]
        //public async Task<int> GetChassisIncludedCount([FromQuery] GetChassisIncludedQuery query)
        //{
        //    return await _mediator.Send(query);
        //}

        //[HttpGet("/included/{qid}/count")]
        //public async Task<int> GetChassisIncludedCount(int qid)
        //{
        //    return await _mediator.Send(qid);
        //}
        [HttpPost("ExpertSubmit")]
        public async Task ExpertSubmitAct([FromBody] ExpertSubmitActRequest expertSubmitActRequest)
        {
            var command = MapRequestToCommand(expertSubmitActRequest);
            await _mediator.Send(command);
        }

        private ExpertSubmitActCommand MapRequestToCommand(ExpertSubmitActRequest expertSubmitActRequest)
        {
            var customerStateId = CustomerState.FromValue(expertSubmitActRequest.CustomerStateId);
            var contactTypeId = ContactType.FromValue(expertSubmitActRequest.ContactTypeId);
            var answerItems = expertSubmitActRequest.AnswerItems.Select(s => new AnswerItem(s.SurveyQuestionItemId, s.Description)).ToList();
            return new ExpertSubmitActCommand(expertSubmitActRequest.AssignedChassisId, expertSubmitActRequest.IsSuccessCall, customerStateId, expertSubmitActRequest.ActDate, expertSubmitActRequest.AlarmDate, expertSubmitActRequest.AlarmTime,
                expertSubmitActRequest.AlarmDescription, contactTypeId, answerItems, expertSubmitActRequest.Creator);
        }

        [HttpPost("SupervisorSubmit")]
        public async Task SupervisorSubmitAct([FromBody] SupervisorSubmitActRequest supervisorSubmitActRequest)
        {
            var command = MapRequestToCommand(supervisorSubmitActRequest);
            await _mediator.Send(command);
        }

        private SupervisorSubmitActCommand MapRequestToCommand(SupervisorSubmitActRequest supervisorSubmitActRequest)
        {
            return new SupervisorSubmitActCommand(supervisorSubmitActRequest.AssignedChassisId,supervisorSubmitActRequest.IsSuccessCall,supervisorSubmitActRequest.ActDate
            ,supervisorSubmitActRequest.AlarmDate,supervisorSubmitActRequest.AlarmTime,supervisorSubmitActRequest.AlarmDescription,supervisorSubmitActRequest.CrmSupervisorDescription
            ,supervisorSubmitActRequest.ContactTypeId,supervisorSubmitActRequest.Creator);
        }

        [HttpPost("AssignChassis")]
        public async Task ExpertSubmitAct([FromBody] AssignChassisRequest assignChassisRequest)
        {
            var command = MapRequestToCommand(assignChassisRequest);
            await _mediator.Send(command);
        }

        private AssignChassisCommand MapRequestToCommand(AssignChassisRequest assignChassisRequest)
        {
            var productTypeId = ProductType.FromValue(assignChassisRequest.ProductType);

            return new AssignChassisCommand(assignChassisRequest.FranchiseId,
                assignChassisRequest.PartyId, assignChassisRequest.AssignedChassisCount,
                productTypeId, assignChassisRequest.EndDate, assignChassisRequest.SurveyConfigurationId);
        }

        [HttpPost("GetExpertList")]
        public async Task<IEnumerable<PartyInfo>> GetExpertList([FromBody] GetPartyQuery query)
        {
            var ret = await _mediator.Send(query);
            return ret.PartyInfos;
        }

        [HttpPost("GetFranchiseList")]
        public async Task<IEnumerable<FranchiseInfo>> GetFranchiseList([FromBody] GetFranchiseQuery query)
        {
            var x = await _mediator.Send(query);
            return x.FranchiseInfos;
        }

        [HttpGet("ContactType")]
        public async Task<IEnumerable<ContactTypeInfo>> GetContactType()
        {
            var contactTypeInfos=await _mediator.Send(new ContactTypeQuery());
            return contactTypeInfos;
        }

        [HttpGet("CustomerState")]
        public async Task<IEnumerable<CustomerStateInfo>> GetCustomerState()
        {
            var customerStateInfos = await _mediator.Send(new CustomerStateQuery());
            return customerStateInfos;
        }
        [HttpGet("GetSurveyTitle")]
        public async Task<IEnumerable<SurveyTitleInfo>> GetSurveyTitle([FromQuery] SurveyTitleQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("GetQuestionList")]
        public async Task<IEnumerable<QuestionInfo>> GetQuestionList([FromQuery] QuestionQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("CallHistory")]
        public async Task<IEnumerable<ContactInfo>> GetContactInfo([FromQuery] ContactQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("AssignedChassisInfo")]
        public async Task<IEnumerable<AssignedChassisInfo>> GetAssignedChassisInfo([FromQuery] AssignedChassisQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
