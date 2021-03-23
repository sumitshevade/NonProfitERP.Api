using System;
using System.Linq;
using Blazored.LocalStorage;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Blazored.Toast.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Shared.Models;
using PublicData.WebClient.Shared.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using PublicData.WebClient.Models;
using Microsoft.JSInterop;

namespace PublicData.WebClient.Components
{
    public class PersonComponent : ComponentBase
    {
        #region -- Injected repositories / dependencies
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IPersonRepository PersonRepository { get; set; }
        [Inject] IDetailRepository DetailRepository { get; set; }
        [Inject] IProgramRepository ProgramRepository { get; set; }
        [Inject] ICountryRepository CountryRepository  { get; set; }
        [Inject] IStateRepository StateRepository  { get; set; }
        [Inject] ICityRepository CityRepository  { get; set; }
        [Inject] IDistrictRepository DistrictRepository  { get; set; }
        [Inject] ITalukaRepository TalukaRepository  { get; set; }
        [Inject] IPersonContactRepository PersonContactRepository { get; set; }
        [Inject] IPersonAddressRepository PersonAddressRepository { get; set; }
        [Inject] IPersonPrivateInfoRepository PersonPrivateInfoRepository { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] ILocalStorageService LocalStorageService { get; set; }
        [Inject] ISessionStorageService SessionStorageService { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }
        #endregion

        #region -- Parameters / Model instances
        [Parameter] public Person Person { get; set; } = new Person();
        [Parameter] public PersonContact PersonContact { get; set; } = new PersonContact();
        [Parameter] public PersonAddress PersonAddress { get; set; } = new PersonAddress();
        [Parameter] public PersonPrivateInformation PersonPrivateInformation { get; set; } = new PersonPrivateInformation();
        [Parameter] public string FormDisplay { get; set; } // helps to hide show form
        [Parameter] public IList<PersonContact> PersonContacts { get; set; } = new List<PersonContact>();
        [Parameter] public IList<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();
        [Parameter] public IList<Detail> ContactTypes { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> Details { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> HomeStatus { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> LocalityClass { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> ResidentialAreas { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> ResidentialStatus { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> JoinedAs { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> PersonTypes { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> WorkFrequencies { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> ParentalStatus { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> Religions { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> Castes { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> Categories { get; set; } = new List<Detail>();

        [Parameter] public IList<Country> Countries { get; set; } = new List<Country>();
        [Parameter] public IList<State> States { get; set; } = new List<State>();
        [Parameter] public IList<City> Cities { get; set; } = new List<City>();
        [Parameter] public IList<District> Districts { get; set; } = new List<District>();
        [Parameter] public IList<Taluka> Talukas { get; set; } = new List<Taluka>();
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }

        #endregion

        #region -- Public properties / Selected properties
        public string SelectedShakhaId { get; set; } = "0";
        public string SelectedPersonTypeId { get; set; } = "0";
        public string SelectedJoinedAsId { get; set; } = "0";
        public string SelectedNationalityId { get; set; } = "0";
        public string SelectedCountryId { get; set; } = "0";
        public string SelectedStateId { get; set; } = "0";
        public string SelectedCityId { get; set; } = "0";
        public string SelectedTalukaId { get; set; } = "0";
        public string SelectedDistrictId { get; set; } = "0";
        public string SelectedWorkFrequencyId { get; set; } = "0";
        public string SelectedIsWorker { get; set; } = "0";
        public string SelectedContactTypeId { get; set; } = "0";
        public string SelectedIsDefaultContact { get; set; } = "0";
        public string SelectedIsPermanentAddress { get; set; } = "0";
        public string SelectedIsGovtBuiltUp { get; set; } = "0";
        public string SelectedHomeStatusId { get; set; } = "0";
        public string SelectedLocalityClassId { get; set; } = "0";
        public string SelectedResidentialStatusId { get; set; } = "0";
        public string SelectedResidentialAreaId { get; set; } = "0";
        public string SelectedMaritalStatus { get; set; } = "0";
        public string SelectedParentalStatusId { get; set; } = "0";
        public string SelectedReligionId { get; set; } = "0";
        public string SelectedCasteId { get; set; } = "0";
        public string SelectedCategoryId { get; set; } = "0";
        public string SelectedGenderId { get; set; }

        public string ContactDisabled { get; set; }

        public string Message = string.Empty;
        public string ContactSaveButton = string.Empty;
        public string AddressSaveButton = string.Empty;
        public string PrivateSaveButton = string.Empty;

        public AlertMessageType MessageType = AlertMessageType.Success;

        #endregion

        private int _editContactId = 0;
        private int _editAddressId = 0;

        // TODO: if only one state - on load, load cities and districts

        protected async override Task OnInitializedAsync()
        {
            CommonService.IsBusy = true;

            // Set AccessToken
            var userState = AuthenticationState.Result;
            PersonRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            PersonContactRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            PersonAddressRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            PersonPrivateInfoRepository.SetToken(userState.User.FindFirst("AccessToken").Value);

            DetailRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            ProgramRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            CountryRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            StateRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            CityRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            DistrictRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            TalukaRepository.SetToken(userState.User.FindFirst("AccessToken").Value);

            var personId = await SessionStorageService.GetItemAsync<int>("personId");
            if (personId == 0)
            {
                ContactDisabled = "disabled";
            }
            else
            {
                ContactDisabled = "";
                Person = await PersonRepository.GetByIdAsync("/api/person/" + personId);
                PersonContacts = await PersonContactRepository.GetListAsync("/api/person/" + personId + "/contact");
                PersonAddresses = await PersonAddressRepository.GetListAsync("/api/person/" + personId + "/address");
                var ppi = await PersonPrivateInfoRepository.GetByIdAsync("/api/person/" + personId + "/private");
                PersonPrivateInformation = ppi ?? new PersonPrivateInformation();

                Countries = await CountryRepository.GetListAsync("/api/master/country");

                Details = await DetailRepository.GetListAsync("/api/master/header/details");

                if (Details != null)
                {
                    Castes = Details.Where(w => w.HeaderId == 2).ToList();
                    Categories = Details.Where(w => w.HeaderId == 3).ToList();
                    HomeStatus = Details.Where(h => h.HeaderId == 8).ToList();
                    JoinedAs = Details.Where(j => j.HeaderId == 10).ToList();
                    LocalityClass = Details.Where(h => h.HeaderId == 12).ToList();
                    ParentalStatus = Details.Where(c => c.HeaderId == 14).ToList();
                    ContactTypes = Details.Where(c => c.HeaderId == 15).ToList();
                    PersonTypes = Details.Where(p => p.HeaderId == 16).ToList();
                    Religions = Details.Where(w => w.HeaderId == 18).ToList();
                    ResidentialAreas = Details.Where(h => h.HeaderId == 19).ToList();
                    ResidentialStatus = Details.Where(h => h.HeaderId == 20).ToList();
                    WorkFrequencies = Details.Where(w => w.HeaderId == 26).ToList();
                }

                SelectedNationalityId = Person.CountryId.ToString();
                SelectedPersonTypeId = Person.PersonTypeId.ToString();
                SelectedJoinedAsId = Person.JoinedAsId.ToString();
                SelectedWorkFrequencyId = Person.WorkFrequencyId.ToString();
                SelectedIsWorker = Person.IsWorker == false ? "false" : "true";

                SelectedContactTypeId = PersonContact.ContactTypeId.ToString();
                SelectedIsDefaultContact = PersonContact.IsDefault == false ? "false" : "true";

                SelectedMaritalStatus = PersonPrivateInformation.MaritalStatus.ToString();
                SelectedParentalStatusId = PersonPrivateInformation.ParentalStatusId.ToString();
                SelectedReligionId = PersonPrivateInformation.ReligionId.ToString();
                SelectedCasteId = PersonPrivateInformation.CasteId.ToString();
                SelectedCategoryId = PersonPrivateInformation.CategoryId.ToString();

                ContactSaveButton = "Save";
                AddressSaveButton = "Save";
            }

            CommonService.IsBusy = false;
        }

        #region -- Person
        public async Task CreatePerson()
        {
            CommonService.IsBusy = true;

            Person.PersonTypeId = Convert.ToInt32(SelectedPersonTypeId);
            Person.WorkFrequencyId = Convert.ToInt32(SelectedWorkFrequencyId);
            Person.CountryId = Convert.ToInt32(SelectedCountryId);
            Person.JoinedAsId = Convert.ToInt32(SelectedJoinedAsId);
            Person.IsWorker = Convert.ToBoolean(SelectedIsWorker);
            Person.Gender = Convert.ToChar(SelectedGenderId);

            var result = 0;

            var savedPersonId = await SessionStorageService.GetItemAsync<int>("personId");
            if (savedPersonId == 0)
            {
                result = await PersonRepository.AddAsync(Person, "/api/person");        // create new
            }
            else
            {
                Person.Id = Convert.ToInt32(savedPersonId);
                var boolResult = await PersonRepository.UpdateAsync(Person, "/api/person");        // update
                if (boolResult == true)
                    result = 1;
            }

            if (result > 0)
            {
                ContactDisabled = "";
                await SessionStorageService.SetItemAsync("personId", result);
                ToastService.ShowSuccess("The person has been created!!!", "Success");
            }
            else
            {
                ToastService.ShowError("Something went wrong!!!", "Error");
            }

            CommonService.IsBusy = false;
        }

        public async Task RemovePersonId()
        {
            CommonService.IsBusy = true;

            await SessionStorageService.RemoveItemAsync("personId");

            Person = new Person();
            PersonContact = new PersonContact();
            PersonAddress = new PersonAddress();

            ContactDisabled = "disabled";
            StateHasChanged();
            ToastService.ShowSuccess("Ready to add new Person!!!", "Success");

            CommonService.IsBusy = false;
        }

        #endregion

        #region -- Person Contact

        public async Task CreatePersonContact()
        {
            CommonService.IsBusy = true;

            PersonContact.ContactTypeId = Convert.ToInt32(SelectedContactTypeId);
            PersonContact.IsDefault = Convert.ToBoolean(SelectedIsDefaultContact);

            var result = 0;

            var savedPersonId = await SessionStorageService.GetItemAsync<int>("personId");

            if (_editContactId == 0)
            {
                result = await PersonContactRepository.AddAsync(PersonContact, "/api/person/" + savedPersonId + "/contact");        // create new
            }
            else
            {
                PersonContact.Id = _editContactId;
                PersonContact.PersonId = savedPersonId;
                var boolResult = await PersonContactRepository.UpdateAsync(PersonContact, "/api/person/" + savedPersonId + "/contact");        // update
                result = boolResult ? 1 : 0;
            }

            if (result > 0)
            {
                ContactSaveButton = "Save";
                _editContactId = 0;
                PersonContact.Id = result;
                PersonContact.ContactTypeDetail = await DetailRepository.GetByIdAsync("/api/master/detail/" + SelectedContactTypeId);
                PersonContacts.Remove(PersonContact);
                PersonContacts.Add(PersonContact);
                PersonContact = new PersonContact();
                ToastService.ShowSuccess("The contact has been created!!!", "Success");
                StateHasChanged();
            }
            else
            {
                ToastService.ShowError("Something went wrong!!!", "Error");
            }

            CommonService.IsBusy = false;
        }

        public void EditContact(int contactId)
        {
            ContactSaveButton = "Update";
            _editContactId = contactId;
            PersonContact = PersonContacts.Where(x => x.Id == contactId).FirstOrDefault();
            SelectedContactTypeId = PersonContact.ContactTypeId.ToString();
            SelectedIsDefaultContact = PersonContact.IsDefault == false ? "false" : "true";
            StateHasChanged();
        }

        public async Task DeleteContact(int contactId)
        {
            var personId = await SessionStorageService.GetItemAsync<int>("personId");
            if (personId == 0)
                ToastService.ShowError("Something went wrong!!!", "Error");
            else
            {
                if (await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure?"))
                {
                    CommonService.IsBusy = true;

                    if (await PersonContactRepository.RemoveAsync("/api/person/" + personId + "/contact/" + contactId))
                    {
                        var pC = PersonContacts.Where(pc => pc.Id == contactId).SingleOrDefault();
                        PersonContacts.Remove(pC);

                        ToastService.ShowSuccess("Contact has been deleted!!!", "Success");
                        StateHasChanged();
                    }

                    CommonService.IsBusy = false;
                }
                else
                {
                    ToastService.ShowInfo("Your record is safe!!!", "Error");
                }
            }
        }

        public void CancelContact()
        {
            ContactSaveButton = "Save";
            StateHasChanged();
        }

        #endregion

        #region -- Person Address

        public async Task CreateAddress()
        {
            CommonService.IsBusy = true;

            PersonAddress.CountryId = Convert.ToInt32(SelectedCountryId);
            PersonAddress.StateId = Convert.ToInt32(SelectedStateId);
            PersonAddress.CityId = Convert.ToInt32(SelectedCityId);
            PersonAddress.DistrictId = Convert.ToInt32(SelectedDistrictId);
            PersonAddress.TalukaId = Convert.ToInt32(SelectedTalukaId);
            PersonAddress.IsGovtBuildUp = Convert.ToBoolean(SelectedIsGovtBuiltUp);
            PersonAddress.IsPermanent = Convert.ToBoolean(SelectedIsPermanentAddress);
            PersonAddress.HomeStatusId = Convert.ToInt32(SelectedHomeStatusId);
            PersonAddress.LocalityClassId = Convert.ToInt32(SelectedLocalityClassId);
            PersonAddress.ResidentialStatusId = Convert.ToInt32(SelectedResidentialStatusId);
            PersonAddress.ResidentialAreaId = Convert.ToInt32(SelectedResidentialAreaId);

            var result = 0;

            var savedPersonId = await SessionStorageService.GetItemAsync<int>("personId");

            if (_editAddressId == 0)
            {
                result = await PersonAddressRepository.AddAsync(PersonAddress, "/api/person/" + savedPersonId + "/address");
            }
            else
            {
                PersonAddress.Id = _editAddressId;
                PersonAddress.PersonId = savedPersonId;
                var boolResult = await PersonAddressRepository.UpdateAsync(PersonAddress, "/api/person/" + savedPersonId + "/address");        // update
                result = boolResult ? 1 : 0;
            }

            if (result > 0)
            {
                AddressSaveButton = "Save";
                _editAddressId = 0;
                PersonAddress.Id = result;

                PersonAddresses.Remove(PersonAddress);
                PersonAddresses.Add(PersonAddress);
                PersonAddress = new PersonAddress();
                ToastService.ShowSuccess("Record has been created!!!", "Success");
                StateHasChanged();
            }
            else
            {
                ToastService.ShowError("Something went wrong!!!", "Error");
            }

            CommonService.IsBusy = false;
        }

        public async Task EditAddress(int addressId)
        {
            AddressSaveButton = "Update";
            _editAddressId = addressId;
            PersonAddress = PersonAddresses.Where(x => x.Id == addressId).FirstOrDefault();

            // TODO: We need to add show address as well
            // that time just resolve the address and show instead dropdowns (country, state, city)

            SelectedCountryId = PersonAddress.CountryId.ToString();
            await GetStatesByCountry();

            SelectedStateId = PersonAddress.StateId.ToString();
            await GetCitiesByState();
            await GetDistrictsByState();

            SelectedCityId = PersonAddress.CityId.ToString();
            SelectedDistrictId = PersonAddress.DistrictId.ToString();
            await GetTalukasByDistrict();

            SelectedTalukaId = PersonAddress.TalukaId.ToString();
            SelectedIsGovtBuiltUp = PersonAddress.IsGovtBuildUp == false ? "false" : "true";
            SelectedIsPermanentAddress = PersonAddress.IsPermanent == false ? "false" : "true";
            SelectedHomeStatusId = PersonAddress.HomeStatusId.ToString();
            SelectedLocalityClassId = PersonAddress.LocalityClassId.ToString();
            SelectedResidentialStatusId = PersonAddress.ResidentialStatusId.ToString();
            SelectedResidentialAreaId = PersonAddress.ResidentialAreaId.ToString();

            StateHasChanged();
        }

        public async Task DeleteAddress(int addressId)
        {
            var personId = await SessionStorageService.GetItemAsync<int>("personId");
            if (personId == 0)
                ToastService.ShowError("Something went wrong!!!", "Error");
            else
            {
                if (await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure?"))
                {
                    CommonService.IsBusy = true;

                    if (await PersonAddressRepository.RemoveAsync("/api/person/" + personId + "/address/" + addressId))
                    {
                        var pC = PersonAddresses.Where(pc => pc.Id == addressId).SingleOrDefault();
                        PersonAddresses.Remove(pC);

                        ToastService.ShowSuccess("Record has been deleted!!!", "Success");
                        StateHasChanged();
                    }

                    CommonService.IsBusy = false;
                }
                else
                {
                    ToastService.ShowInfo("Your record is safe!!!", "Error");
                }
            }
        }

        public void CancelAddress()
        {
            AddressSaveButton = "Save";
            StateHasChanged();
        }

        #endregion

        #region -- Person Private Info

        public async Task SavePrivateInfo()
        {
            CommonService.IsBusy = true;

            PersonPrivateInformation.ReligionId = Convert.ToInt32(SelectedReligionId);
            PersonPrivateInformation.CasteId = Convert.ToInt32(SelectedCasteId);
            PersonPrivateInformation.CategoryId = Convert.ToInt32(SelectedCategoryId);
            PersonPrivateInformation.MaritalStatus = Convert.ToInt32(SelectedMaritalStatus);
            PersonPrivateInformation.ParentalStatusId = Convert.ToInt32(SelectedParentalStatusId);

            var savedPersonId = await SessionStorageService.GetItemAsync<int>("personId");

            PersonPrivateInformation.PersonId = savedPersonId;
            var result = await PersonPrivateInfoRepository.AddAsync(PersonPrivateInformation, "/api/person/" + savedPersonId + "/private");        // update or add

            if (result > 0)
            {
                PersonPrivateInformation.Id = result;
                ToastService.ShowSuccess("The record has been saved!!!", "Success");
                StateHasChanged();
            }
            else
            {
                ToastService.ShowError("Something went wrong!!!", "Error");
            }

            CommonService.IsBusy = false;
        }

        #endregion


        #region -- Change value methods

        public void ChangeNationality(string value)
            => SelectedCountryId = value;

        public void ChangeState(string value)
            => SelectedStateId = value;

        public void ChangeCity(string value)
            => SelectedCityId = value;

        public void ChangeTaluka(string value)
            => SelectedTalukaId = value;

        public void ChangeDistrict(string value)
            => SelectedDistrictId = value;

        public void ChangePersonType(string value)
            => SelectedPersonTypeId = value;

        public void ChangeWorkFrequency(string value)
            => SelectedWorkFrequencyId = value;

        public void ChangeJoinedAs(string value)
            => SelectedJoinedAsId = value;

        public void ChangeIsWorker(string value)
            => SelectedIsWorker = value;

        public void ChangeContactType(string value)
            => SelectedContactTypeId = value;

        public void ChangeIsDefaultContact(string value)
            => SelectedIsDefaultContact = value;

        public async Task CancelPerson()
        {
            ToastService.ShowError("This record is already saved...!!! You have to delete explicitly.", "Error");
            await RemovePersonId();
        }

        public async Task ChangeCountryForStates(string value)
        {
            SelectedCountryId = value;

            if (value == "0")
            {
                States.Clear();
                Cities.Clear();
            }
            else
            {
                await GetStatesByCountry();
            }
        }

        public async Task GetStatesByCountry()
        {
            States = await StateRepository.GetListAsync("/api/master/country/" + SelectedCountryId + "/state");
            Cities.Clear();
            StateHasChanged();
        }

        public async Task ChangeStateForCitiesDistricts(string value)
        {
            SelectedStateId = value;

            if (value == "0")
            {
                Cities.Clear();
            }
            else
            {
                await GetCitiesByState();
                await GetDistrictsByState();
            }
        }

        public async Task GetCitiesByState()
        {
            Cities = await CityRepository.GetListAsync("/api/master/state/" + SelectedStateId + "/city");
            StateHasChanged();
        }

        public async Task GetDistrictsByState()
        {
            Districts = await DistrictRepository.GetListAsync("/api/master/state/" + SelectedStateId + "/district");
            StateHasChanged();
        }

        public async Task GetTalukasByDistrict()
        {
            Talukas = await TalukaRepository.GetListAsync("/api/master/district/" + SelectedDistrictId + "/taluka");
            StateHasChanged();
        }

        public async Task ChangeDistrictForTaluka(string value)
        {
            SelectedDistrictId = value;

            if (value == "0")
            {
                Talukas.Clear();
            }
            else
            {
                await GetTalukasByDistrict();
            }
        }

        public void ChangeIsGovtBuiltUp(string value)
            => SelectedIsGovtBuiltUp = value;

        public void ChangeIsPermanentAddress(string value)
            => SelectedIsPermanentAddress = value;

        public void ChangeHomeStatus(string value)
            => SelectedHomeStatusId = value;
        
        public void ChangeResidentialStatus(string value)
            => SelectedResidentialStatusId = value;

        public void ChangeResidentialArea(string value)
            => SelectedResidentialAreaId = value;

        public void ChangeLocalityStatus(string value)
            => SelectedLocalityClassId = value;

        public void ChangeMaritalStatus(string value)
            => SelectedMaritalStatus = value;

        public void ChangeParentalStatus(string value)
            => SelectedParentalStatusId = value;

        public void ChangeReligion(string value)
            => SelectedReligionId = value;

        public void ChangeCaste(string value)
            => SelectedCasteId = value;

        public void ChangeCategory(string value)
            => SelectedCategoryId = value;

        public void ChangeGender(string value)
            => SelectedGenderId = value;

        #endregion
    }
}
