using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NonProfitERP.Application.Features.People.CreatePerson;
using NonProfitERP.Application.Features.People.GetAllPerson;
using NonProfitERP.Application.Features.People.GetPersonById;
using NonProfitERP.Application.Features.Person.DeletePersonById;
using NonProfitERP.Application.Features.Person.SearchPerson;
using NonProfitERP.Application.Features.Person.UpdatePersonById;
using NonProfitERP.Application.Features.PersonAchievement.CreatePersonAchievement;
using NonProfitERP.Application.Features.PersonAchievement.DeletePersonAchievementByAchievementId;
using NonProfitERP.Application.Features.PersonAchievement.GetPersonAchievementByAchievementId;
using NonProfitERP.Application.Features.PersonAchievement.GetPersonAllAchievements;
using NonProfitERP.Application.Features.PersonAchievement.UpdatePersonAchievementByAchievementId;
using NonProfitERP.Application.Features.PersonAddress.CreatePersonAddress;
using NonProfitERP.Application.Features.PersonAddress.DeletePersonAddressByAddressId;
using NonProfitERP.Application.Features.PersonAddress.GetPersonAddressById;
using NonProfitERP.Application.Features.PersonAddress.GetPersonAllAddresses;
using NonProfitERP.Application.Features.PersonAddress.UpdatePersonAddressByAddressId;
using NonProfitERP.Application.Features.PersonContact.CreatePersonContact;
using NonProfitERP.Application.Features.PersonContact.DeletePersonContactByContactId;
using NonProfitERP.Application.Features.PersonContact.GetPersonAllContacts;
using NonProfitERP.Application.Features.PersonContact.GetPersonContactByContactId;
using NonProfitERP.Application.Features.PersonContact.UpdatePersonContactByContactId;
using NonProfitERP.Application.Features.PersonDisability.CreatePersonDisability;
using NonProfitERP.Application.Features.PersonDisability.DeletePersonDisabilityByDisabilityId;
using NonProfitERP.Application.Features.PersonDisability.GetPersonAllDisabilities;
using NonProfitERP.Application.Features.PersonDisability.GetPersonDisabilityByDisabilityId;
using NonProfitERP.Application.Features.PersonDisability.UpdatePersonDisabilityByDisabilityId;
using NonProfitERP.Application.Features.PersonEducation.CreatePersonEducation;
using NonProfitERP.Application.Features.PersonEducation.DeletePersonEducationByEducationId;
using NonProfitERP.Application.Features.PersonEducation.GetPersonAllEducations;
using NonProfitERP.Application.Features.PersonEducation.GetPersonEducationByEducationId;
using NonProfitERP.Application.Features.PersonEducation.UpdatePersonEducationByEducationId;
using NonProfitERP.Application.Features.PersonFamilyDetail.CreatePersonFamilyDetail;
using NonProfitERP.Application.Features.PersonFamilyDetail.DeletePersonFamilyDetailById;
using NonProfitERP.Application.Features.PersonFamilyDetail.GetPersonAllFamilyDetails;
using NonProfitERP.Application.Features.PersonFamilyDetail.GetPersonFamilyDetailByFamilyId;
using NonProfitERP.Application.Features.PersonFamilyDetail.UpdatePersonFamilyDetailByFamilyId;
using NonProfitERP.Application.Features.PersonHealthDetail.CreatePersonHealthDetail;
using NonProfitERP.Application.Features.PersonHealthDetail.DeletePersonHealthDetailById;
using NonProfitERP.Application.Features.PersonHealthDetail.GetPersonAllHealthDetails;
using NonProfitERP.Application.Features.PersonHealthDetail.GetPersonHealthDetailsByHealthId;
using NonProfitERP.Application.Features.PersonHealthDetail.UpdatePersonHealthDetailByHealthId;
using NonProfitERP.Application.Features.PersonHobbyFavorite.CreatePersonHobbyFavorite;
using NonProfitERP.Application.Features.PersonHobbyFavorite.DeletePersonHobbyFavoriteById;
using NonProfitERP.Application.Features.PersonHobbyFavorite.GetPersonAllHobbyFavorite;
using NonProfitERP.Application.Features.PersonHobbyFavorite.GetPersonHobbyFavoriteByHFId;
using NonProfitERP.Application.Features.PersonHobbyFavorite.UpdatePersonHobbyFavoriteByHFId;
using NonProfitERP.Application.Features.PersonLanguage.CreatePersonLanguage;
using NonProfitERP.Application.Features.PersonLanguage.DeletePersonLanguageById;
using NonProfitERP.Application.Features.PersonLanguage.GetPersonAllLanguages;
using NonProfitERP.Application.Features.PersonLanguage.GetPersonLanguageByLanguageId;
using NonProfitERP.Application.Features.PersonLanguage.UpdatePersonLanguageByLanguageId;
using NonProfitERP.Application.Features.PersonPrivateInformation.CreatePersonPrivateInformation;
using NonProfitERP.Application.Features.PersonPrivateInformation.GetPersonPrivateInformation;
using NonProfitERP.Application.Features.PersonSocialMediaAccount.CreatePersonSocialMediaAccount;
using NonProfitERP.Application.Features.PersonSocialMediaAccount.DeletePersonSocialMediaAccount;
using NonProfitERP.Application.Features.PersonSocialMediaAccount.GetPersonAllSocialMediaAccount;
using NonProfitERP.Application.Features.PersonSocialMediaAccount.GetPersonSocialMediaAccountByAccountId;
using NonProfitERP.Application.Features.PersonSocialMediaAccount.UpdatePersonSocialMediaAccountByAccountId;
using NonProfitERP.Application.Features.PersonWorkExperience.CreatePersonWorkExperience;
using NonProfitERP.Application.Features.PersonWorkExperience.DeletePersonWorkExperience;
using NonProfitERP.Application.Features.PersonWorkExperience.GetPersonAllWorkExperiences;
using NonProfitERP.Application.Features.PersonWorkExperience.GetPersonWorkExperienceByExperienceId;
using NonProfitERP.Application.Features.PersonWorkExperience.UpdatePersonWorkExperienceByExperienceId;

namespace NonProfitERP.Main.Controllers
{
    [Authorize]
    [ApiController]
    public class PersonController : ApiController
    {
        #region --- Person APIs ---
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetAllPersonQuery());
            return new JsonResult(result);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetPersonByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePersonByIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonByIdCommand { Id = id }));
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchPerson(SearchPersonQuery query)
        {
            return new JsonResult(await Mediator.Send(query));
        }

        #endregion

        #region --- Person Address APIs ---

        [HttpGet]
        [Route("{personId}/address")]
        public async Task<IActionResult> GetAddresses(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllAddressesQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/address/{addressId}")]
        public async Task<IActionResult> GetAddressById(int addressId)
        {
            var result = await Mediator.Send(new GetPersonAddressByIdQuery { AddressId = addressId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/address")]
        public async Task<IActionResult> PostAddress(CreatePersonAddressCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/address")]
        public async Task<IActionResult> PutAddress(UpdatePersonAddressByAddressIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/address/{addressId}")]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonAddressByAddressIdCommand { AddressId = addressId }));
        }

        #endregion

        #region --- Person Contact APIs ---

        [HttpGet]
        [Route("{personId}/contact")]
        public async Task<IActionResult> GetContacts(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllContactsQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/contact/{contactId}")]
        public async Task<IActionResult> GetContactById(int contactId)
        {
            var result = await Mediator.Send(new GetPersonContactByContactIdQuery { ContactId = contactId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/contact")]
        public async Task<IActionResult> PostContact(CreatePersonContactCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/contact")]
        public async Task<IActionResult> PutContact(UpdatePersonContactByContactIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/contact/{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonContactByContactIdCommand { ContactId = contactId }));
        }

        #endregion

        #region --- Person Achievements APIs ---

        [HttpGet]
        [Route("{personId}/achievement")]
        public async Task<IActionResult> GetAchievements(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllAchievementsQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/achievement/{achievementId}")]
        public async Task<IActionResult> GetAchievementById(int achievementId)
        {
            var result = await Mediator.Send(new GetPersonAchievementByAchievementIdQuery { AchievementIdId = achievementId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/achievement")]
        public async Task<IActionResult> PostAchievement(CreatePersonAchievementCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/achievement")]
        public async Task<IActionResult> PutAchievement(UpdatePersonAchievementByAchievementIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/achievement/{achievementId}")]
        public async Task<IActionResult> DeleteAchievement(int achievementId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonAchievementByAchievementIdCommand { AchievementId = achievementId }));
        }

        #endregion

        #region --- Person Education APIs ---

        [HttpGet]
        [Route("{personId}/education")]
        public async Task<IActionResult> GetEducations(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllEducationsQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/education/{educationId}")]
        public async Task<IActionResult> GetEducationById(int educationId)
        {
            var result = await Mediator.Send(new GetPersonEducationByEducationIdQuery { EducationId = educationId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/education")]
        public async Task<IActionResult> PostEducation(CreatePersonEducationCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/education")]
        public async Task<IActionResult> PutEducation(UpdatePersonEducationByEducationIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/education/{educationId}")]
        public async Task<IActionResult> DeleteEducation(int educationId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonEducationByEducationIdCommand { EducationId = educationId }));
        }

        #endregion

        #region --- Person Family Details APIs ---

        [HttpGet]
        [Route("{personId}/familydetails")]
        public async Task<IActionResult> GetFamilyDetails(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllFamilyDetailsQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/familydetails/{familyDetailId}")]
        public async Task<IActionResult> GetFamilyDetailById(int familyDetailId)
        {
            var result = await Mediator.Send(new GetPersonFamilyDetailByFamilyIdQuery { FamilyId = familyDetailId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/familydetails")]
        public async Task<IActionResult> PostFamilyDetail(CreatePersonFamilyDetailCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/familydetails")]
        public async Task<IActionResult> PutFamilyDetail(UpdatePersonFamilyDetailByFamilyIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/familydetails/{familyDetailId}")]
        public async Task<IActionResult> DeleteFamilyMember(int familyDetailId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonFamilyDetailByIdCommand { FamilyMemberId = familyDetailId }));
        }

        #endregion

        #region --- Person Disabilities APIs ---

        [HttpGet]
        [Route("{personId}/disabilities")]
        public async Task<IActionResult> GetDisabilities(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllDisabilitiesQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/disabilities/{disabilityId}")]
        public async Task<IActionResult> GetDisabilityById(int disabilityId)
        {
            var result = await Mediator.Send(new GetPersonDisabilityByDisabilityIdQuery { DisabilityId = disabilityId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/disabilities")]
        public async Task<IActionResult> PostDisability(CreatePersonDisabilityCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/disabilities")]
        public async Task<IActionResult> PutDisability(UpdatePersonDisabilityByDisabilityIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/disabilities/{disabilityId}")]
        public async Task<IActionResult> DeleteDisability(int disabilityId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonDisabilityByDisabilityIdCommand { DisabilityId = disabilityId }));
        }

        #endregion

        #region --- Person Health Details APIs ---

        [HttpGet]
        [Route("{personId}/healthdetails")]
        public async Task<IActionResult> GetHealthDetails(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllHealthDetailsQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/healthdetails/{healthdetailId}")]
        public async Task<IActionResult> GetHealthDetailById(int healthdetailId)
        {
            var result = await Mediator.Send(new GetPersonHealthDetailsByHealthIdQuery { HealthId = healthdetailId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/healthdetails")]
        public async Task<IActionResult> PostHealthDetail(CreatePersonHealthDetailCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/healthdetails")]
        public async Task<IActionResult> PutHealthDetail(UpdatePersonHealthDetailByHealthIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/healthdetails/{healthDetailId}")]
        public async Task<IActionResult> DeleteHealthDetail(int healthDetailId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonHealthDetailByIdCommand { HealthDetailId = healthDetailId }));
        }

        #endregion

        #region --- Person Hobby Favorite APIs ---

        [HttpGet]
        [Route("{personId}/hobbyfavorite")]
        public async Task<IActionResult> GetHobbies(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllHobbyFavoriteQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/hobbyfavorite/{hfId}")]
        public async Task<IActionResult> GetHobbyById(int hfId)
        {
            var result = await Mediator.Send(new GetPersonHobbyFavoriteByHFIdQuery { HFId = hfId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/hobbyfavorite")]
        public async Task<IActionResult> PostHobby(CreatePersonHobbyFavoriteCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/hobbyfavorite")]
        public async Task<IActionResult> PutHobby(UpdatePersonHobbyFavoriteByHFIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/hobbyfavorite/{hfId}")]
        public async Task<IActionResult> DeleteHobbyFavorite(int hfId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonHobbyFavoriteByIdCommand { HFId = hfId }));
        }

        #endregion

        #region --- Person Languages APIs ---

        [HttpGet]
        [Route("{personId}/languages")]
        public async Task<IActionResult> GetLanguages(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllLanguagesQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/languages/{languageId}")]
        public async Task<IActionResult> GetLanguageById(int languageId)
        {
            var result = await Mediator.Send(new GetPersonLanguageByLanguageIdQuery { LanguageId = languageId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/languages")]
        public async Task<IActionResult> PostLanguage(CreatePersonLanguageCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/languages")]
        public async Task<IActionResult> PutLanguage(UpdatePersonLanguageByLanguageIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/languages/{languageId}")]
        public async Task<IActionResult> DeleteLanguage(int languageId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonLanguageByIdCommand { PersonLanguageId = languageId }));
        }

        #endregion

        #region --- Person Private Information APIs ---

        [HttpGet]
        [Route("{personId}/private")]
        public async Task<IActionResult> GetPrivateInfo(int personId)
        {
            var result = await Mediator.Send(new GetPersonPrivateInformationQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/private")]
        public async Task<IActionResult> PostPrivate(CreatePersonPrivateInformationCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        #endregion

        #region --- Person Social Media Account APIs ---

        [HttpGet]
        [Route("{personId}/smaccounts")]
        public async Task<IActionResult> GetSMAccounts(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllSocialMediaAccountsQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/smaccounts/{accountId}")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var result = await Mediator.Send(new GetPersonSocialMediaAccountByAccountIdQuery { SocialMediaAccountId = accountId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/smaccounts")]
        public async Task<IActionResult> PostAccount(CreatePersonSocialMediaAccountCommand command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/smaccounts")]
        public async Task<IActionResult> PutAccount(UpdatePersonSocialMediaAccountQuery command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/smaccounts/{accountId}")]
        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonSocialMediaAccountByIdCommand { SocialMediaAccountId = accountId }));
        }

        #endregion

        #region --- Person Work Experience APIs ---

        [HttpGet]
        [Route("{personId}/workexperience")]
        public async Task<IActionResult> GetWorkExps(int personId)
        {
            var result = await Mediator.Send(new GetPersonAllWorkExperiencesQuery { PersonId = personId });
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{personId}/workexperience/{accountId}")]
        public async Task<IActionResult> GetWorkExpById(int accountId)
        {
            var result = await Mediator.Send(new GetPersonWorkExperienceByExperienceIdQuery { WorkExperienceId = accountId });
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{personId}/workexperience")]
        public async Task<IActionResult> PostWorkExp(CreatePersonWorkExperienceQuery command, int personId)
        {
            command.PersonId = personId;
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("{personId}/workexperience")]
        public async Task<IActionResult> PutWorkExp(UpdatePersonWorkExperienceByExperienceIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{personId}/workexperience/{workId}")]
        public async Task<IActionResult> DeleteWorkExp(int workId)
        {
            return new JsonResult(await Mediator.Send(new DeletePersonWorkExperienceByIdCommand { WorkExpId = workId }));
        }

        #endregion
    }
}
