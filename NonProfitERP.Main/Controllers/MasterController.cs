using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NonProfitERP.Application.Features.Master.Batch.CreateBatch;
using NonProfitERP.Application.Features.Master.Batch.DeleteBatch;
using NonProfitERP.Application.Features.Master.Batch.GetBatchById;
using NonProfitERP.Application.Features.Master.Batch.GetBatchesByCourseId;
using NonProfitERP.Application.Features.Master.Batch.UpdateBatchById;
using NonProfitERP.Application.Features.Master.City.CreateCity;
using NonProfitERP.Application.Features.Master.City.DeleteCity;
using NonProfitERP.Application.Features.Master.City.GetCitiesByStateId;
using NonProfitERP.Application.Features.Master.City.GetCityById;
using NonProfitERP.Application.Features.Master.City.UpdateCityById;
using NonProfitERP.Application.Features.Master.Country.CreateCountry;
using NonProfitERP.Application.Features.Master.Country.DeleteCountry;
using NonProfitERP.Application.Features.Master.Country.GetAllCountries;
using NonProfitERP.Application.Features.Master.Country.GetCountryById;
using NonProfitERP.Application.Features.Master.Country.UpdateCountryById;
using NonProfitERP.Application.Features.Master.Department.CreateDepartment;
using NonProfitERP.Application.Features.Master.Department.DeleteDepartment;
using NonProfitERP.Application.Features.Master.Department.GetAllDepartments;
using NonProfitERP.Application.Features.Master.Department.GetDepartmentById;
using NonProfitERP.Application.Features.Master.Department.UpdateDepartment;
using NonProfitERP.Application.Features.Master.Detail.CreateDetail;
using NonProfitERP.Application.Features.Master.Detail.DeleteDetail;
using NonProfitERP.Application.Features.Master.Detail.GetDetailByHeaderId;
using NonProfitERP.Application.Features.Master.Detail.GetDetailById;
using NonProfitERP.Application.Features.Master.Detail.GetDetails;
using NonProfitERP.Application.Features.Master.Detail.UpdateDetail;
using NonProfitERP.Application.Features.Master.District.CreateDistrict;
using NonProfitERP.Application.Features.Master.District.DeleteDistrict;
using NonProfitERP.Application.Features.Master.District.GetAllDistrictByStateId;
using NonProfitERP.Application.Features.Master.District.GetDistrictById;
using NonProfitERP.Application.Features.Master.District.UpdateDistrict;
using NonProfitERP.Application.Features.Master.Header.CreateHeader;
using NonProfitERP.Application.Features.Master.Header.DeleteHeader;
using NonProfitERP.Application.Features.Master.Header.GetAllHeaders;
using NonProfitERP.Application.Features.Master.Header.GetHeaderById;
using NonProfitERP.Application.Features.Master.Header.UpdateHeader;
using NonProfitERP.Application.Features.Master.Program.CreateProgram;
using NonProfitERP.Application.Features.Master.Program.DeleteProgram;
using NonProfitERP.Application.Features.Master.Program.GetAllPrograms;
using NonProfitERP.Application.Features.Master.Program.GetProgramById;
using NonProfitERP.Application.Features.Master.Program.UpdateProgram;
using NonProfitERP.Application.Features.Master.School.CreateSchool;
using NonProfitERP.Application.Features.Master.School.DeleteSchool;
using NonProfitERP.Application.Features.Master.School.GetAllSchools;
using NonProfitERP.Application.Features.Master.School.GetSchoolById;
using NonProfitERP.Application.Features.Master.School.UpdateSchool;
using NonProfitERP.Application.Features.Master.State.CreateState;
using NonProfitERP.Application.Features.Master.State.DeleteState;
using NonProfitERP.Application.Features.Master.State.GetStateById;
using NonProfitERP.Application.Features.Master.State.GetStatesByCountryId;
using NonProfitERP.Application.Features.Master.State.UpdateStateById;
using NonProfitERP.Application.Features.Master.Taluka.CreateTaluka;
using NonProfitERP.Application.Features.Master.Taluka.DeleteTaluka;
using NonProfitERP.Application.Features.Master.Taluka.GetAllTalukasByDistrictId;
using NonProfitERP.Application.Features.Master.Taluka.GetTalukaById;
using NonProfitERP.Application.Features.Master.Taluka.UpdateTaluka;
using NonProfitERP.Application.Features.Master.University.CreateUniversity;
using NonProfitERP.Application.Features.Master.University.DeleteUniversity;
using NonProfitERP.Application.Features.Master.University.GetAllUniversities;
using NonProfitERP.Application.Features.Master.University.GetUniversityById;
using NonProfitERP.Application.Features.Master.University.UpdateUniversity;
using System.Threading.Tasks;

namespace NonProfitERP.Main.Controllers
{
    [ApiController]
    [Authorize]
    public class MasterController : ApiController
    {
        #region --- Batch APIs ---

        [HttpGet, Route("courses/{courseId}/batches")]
        public async Task<IActionResult> GetBatchesByCourseId(int courseId)
        {
            var result = await Mediator.Send(new GetBatchesByCourseId { CourseId = courseId });
            return new JsonResult(result);
        }

        [HttpGet("batches/{id}")]
        public async Task<IActionResult> GetBatchById(int id)
        {
            var result = await Mediator.Send(new GetBatchByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("batches")]
        public async Task<IActionResult> PostBatch(CreateBatchCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("batches")]
        public async Task<IActionResult> PutBatch(UpdateBatchByIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("batches/{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteBatchCommand { Id = id }));
        }

        // TODO: Maybe in future we will require delete multiple by passing ids
        #endregion

        #region --- City APIs ---

        [HttpGet, Route("state/{stateId}/city")]
        public async Task<IActionResult> GetCitiesByStateId(int stateId)
        {
            var result = await Mediator.Send(new GetCitiesByStateId { StateId = stateId });
            return new JsonResult(result);
        }

        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var result = await Mediator.Send(new GetCityByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpGet("city/search/{strName}")]
        public async Task<IActionResult> GetCityByName(string strName)
        {
            var result = await Mediator.Send(new SearchCityByNameQuery { Name = strName });
            return new JsonResult(result);
        }

        [HttpPost("city")]
        public async Task<IActionResult> PostCity(CreateCityCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("city")]
        public async Task<IActionResult> PutCity(UpdateCityByIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("city/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteCityCommand { Id = id }));
        }

        #endregion

        #region --- Country APIs ---

        [HttpGet("country")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await Mediator.Send(new GetCountriesQuery());
            return new JsonResult(result);
        }

        [HttpGet("country/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var result = await Mediator.Send(new GetCountryByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("country")]
        public async Task<IActionResult> PostCountry(CreateCountryCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("country")]
        public async Task<IActionResult> PutCountry(UpdateCountryByIdCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("country/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteCountryCommand { Id = id }));
        }

        #endregion

        #region --- State APIs ---

        [HttpGet("country/{countryId}/state")]
        public async Task<IActionResult> GetStatesByCountryId(int countryId)
        {
            var result = await Mediator.Send(new GetStatesByCountryIdQuery { CountryId = countryId });
            return new JsonResult(result);
        }

        [HttpGet("state/{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            var result = await Mediator.Send(new GetStateByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("state")]
        public async Task<IActionResult> PostState(CreateStateCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("state")]
        public async Task<IActionResult> PutState(UpdateStateCommnd command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("state/{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteStateCommand { Id = id }));
        }

        #endregion

        #region --- Department APIs ---

        [HttpGet("department")]
        public async Task<IActionResult> GetDepartments()
        {
            var result = await Mediator.Send(new GetAllDepartmentsQuery());
            return new JsonResult(result);
        }

        [HttpGet("department/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await Mediator.Send(new GetDepartmentByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("department")]
        public async Task<IActionResult> PostDepartment(CreateDepartmentCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("department")]
        public async Task<IActionResult> PutDepartment(UpdateDepartmentCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("department/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteDepartmentCommand { Id = id }));
        }

        #endregion

        #region --- Program APIs ---

        /// <summary>
        /// Get the list of all progams
        /// </summary>
        [HttpGet("program")]
        public async Task<IActionResult> GetPrograms()
        {
            var result = await Mediator.Send(new GetAllProgramsQuery());
            return new JsonResult(result);
        }

        [HttpGet("program/{id}")]
        public async Task<IActionResult> GetProgramById(int id)
        {
            var result = await Mediator.Send(new GetProgramByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("program")]
        public async Task<IActionResult> PostProgram(CreateProgramCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("program")]
        public async Task<IActionResult> PutProgram(UpdateProgramCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("program/{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteProgramCommand { Id = id }));
        }

        #endregion

        #region --- University APIs ---

        [HttpGet("university")]
        public async Task<IActionResult> GetUniversities()
        {
            var result = await Mediator.Send(new GetAllUniversitiesQuery());
            return new JsonResult(result);
        }

        [HttpGet("university/{id}")]
        public async Task<IActionResult> GetUniversityById(int id)
        {
            var result = await Mediator.Send(new GetUniversityByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("university")]
        public async Task<IActionResult> PostUniversity(CreateUniversityCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("university")]
        public async Task<IActionResult> PutUniversity(UpdateUniversityCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("university/{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteUniversityCommand { Id = id }));
        }

        #endregion

        #region --- Header APIs

        [HttpGet("header")]
        public async Task<IActionResult> GetHeaders()
        {
            var result = await Mediator.Send(new GetHeadersQuery());
            return new JsonResult(result);
        }

        [HttpGet("header/{id}")]
        public async Task<IActionResult> GetHeaderById(int id)
        {
            var result = await Mediator.Send(new GetHeaderByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("header")]
        public async Task<IActionResult> PostHeader(CreateHeaderCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("header")]
        public async Task<IActionResult> PutHeader(UpdateHeaderCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("header/{id}")]
        public async Task<IActionResult> DeleteHeader(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteHeaderCommand { Id = id }));
        }

        #endregion

        #region --- Detail APIs ---

        /// <summary>
        /// Single endpoint to return all details
        /// </summary>
        [HttpGet("header/details")]
        public async Task<IActionResult> GetDetails()
        {
            var result = await Mediator.Send(new GetDetailsQuery { });
            return new JsonResult(result);
        }

        [HttpGet("header/{headerId}/detail")]
        public async Task<IActionResult> GetDetailsByHeaderId(int headerId)
        {
            var result = await Mediator.Send(new GetDetailsByHeaderIdQuery { HeaderId = headerId });
            return new JsonResult(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetailById(int id)
        {
            var result = await Mediator.Send(new GetDetailByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("detail")]
        public async Task<IActionResult> PostDetail(CreateDetailCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("detail")]
        public async Task<IActionResult> PutDetail(UpdateDetailCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("detail/{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteDetailCommand { Id = id }));
        }

        #endregion

        #region --- District APIs ---

        [HttpGet("state/{stateId}/district")]
        public async Task<IActionResult> GetDistrictsByStateId(int stateId)
        {
            var result = await Mediator.Send(new GetAllDistrictByStateIdQuery { StateId = stateId });
            return new JsonResult(result);
        }

        [HttpGet("district/{id}")]
        public async Task<IActionResult> GetDistrictById(int id)
        {
            var result = await Mediator.Send(new GetDistrictByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("district")]
        public async Task<IActionResult> PostDistrict(CreateDistrictCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("district")]
        public async Task<IActionResult> PutDistrict(UpdateDistrictCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("district/{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteDistrictCommand { Id = id }));
        }

        #endregion

        #region --- Taluka APIs ---

        [HttpGet("district/{districtId}/taluka")]
        public async Task<IActionResult> GetTalukasByDistrictId(int districtId)
        {
            var result = await Mediator.Send(new GetAllTalukasByDistrictIdQuery { DistrictId = districtId });
            return new JsonResult(result);
        }

        [HttpGet("taluka/{id}")]
        public async Task<IActionResult> GetTalukaById(int id)
        {
            var result = await Mediator.Send(new GetTalukaByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("taluka")]
        public async Task<IActionResult> PostTaluka(CreateTalukaCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("taluka")]
        public async Task<IActionResult> PutTaluka(UpdateTalukaCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("taluka/{id}")]
        public async Task<IActionResult> DeleteTaluka(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteTalukaCommand { Id = id }));
        }

        #endregion

        #region --- School APIs ---

        [HttpGet("school")]
        public async Task<IActionResult> GetSchools()
        {
            var result = await Mediator.Send(new GetAllSchoolsQuery());
            return new JsonResult(result);
        }

        [HttpGet("school/{id}")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            var result = await Mediator.Send(new GetSchoolByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost("school")]
        public async Task<IActionResult> PostSchool(CreateSchoolCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpPut("school")]
        public async Task<IActionResult> PutSchool(UpdateSchoolCommand command)
        {
            return new JsonResult(await Mediator.Send(command));
        }

        [HttpDelete("school/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            return new JsonResult(await Mediator.Send(new DeleteSchoolCommand { Id = id }));
        }

        #endregion

        #region --- Organization APIs ---

        // APIs

        #endregion

        #region --- Program APIs ---

        // APIs

        #endregion
    }
}