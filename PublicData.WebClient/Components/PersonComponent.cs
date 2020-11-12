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

namespace PublicData.WebClient.Components
{
    public class PersonComponent : ComponentBase
    {
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IPersonRepository PersonRepository { get; set; }
        [Inject] IDetailRepository DetailRepository { get; set; }
        [Inject] IProgramRepository ProgramRepository { get; set; }
        [Inject] ICountryRepository CountryRepository  { get; set; }
        [Inject] IPersonContactRepository PersonContactRepository { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] ILocalStorageService LocalStorageService { get; set; }
        [Inject] ISessionStorageService SessionStorageService { get; set; }

        [Parameter] public Person Person { get; set; } = new Person();
        [Parameter] public PersonContact PersonContact { get; set; } = new PersonContact();
        [Parameter] public IList<PersonContact> PersonContacts { get; set; } = new List<PersonContact>();
        [Parameter] public string ContactFormDisplay { get; set; }
        [Parameter] public IList<Detail> JoinedAs { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> PersonTypes { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> WorkFrequencies { get; set; } = new List<Detail>();
        [Parameter] public IList<Country> Countries { get; set; } = new List<Country>();
        [Parameter] public IList<Detail> ContactTypes { get; set; } = new List<Detail>();
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }

        public string SelectedShakhaId { get; set; }
        public string SelectedPersonTypeId { get; set; }
        public string SelectedJoinedAsId { get; set; }
        public string SelectedCoutryId { get; set; }
        public string SelectedWorkFrequencyId { get; set; }
        public string SelectedIsWorker { get; set; }
        public string ContactDisabled { get; set; }
        public string SelectedContactTypeId { get; set; }
        public string SelectedIsDefaultContact { get; set; }

        public string Message = string.Empty;
        public string ContactSaveButton = string.Empty;
        public AlertMessageType MessageType = AlertMessageType.Success;

        private int _editContactId = 0;

        protected async override Task OnInitializedAsync()
        {
            CommonService.IsBusy = true;

            // Set AccessToken
            var userState = AuthenticationState.Result;
            PersonRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            DetailRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            ProgramRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            CountryRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            PersonContactRepository.SetToken(userState.User.FindFirst("AccessToken").Value);

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
            }

            Countries = await CountryRepository.GetListAsync("/api/master/country");
            PersonTypes = await DetailRepository.GetListAsync("/api/master/header/16/detail");
            JoinedAs = await DetailRepository.GetListAsync("/api/master/header/10/detail");
            WorkFrequencies = await DetailRepository.GetListAsync("/api/master/header/26/detail");

            ContactTypes = await DetailRepository.GetListAsync("/api/master/header/15/detail");

            SelectedCoutryId = Person.CountryId.ToString();
            SelectedPersonTypeId = Person.PersonTypeId.ToString();
            SelectedJoinedAsId = Person.JoinedAsId.ToString();
            SelectedWorkFrequencyId = Person.WorkFrequencyId.ToString();
            SelectedIsWorker = Person.IsWorker == false ? "false" : "true";

            SelectedContactTypeId = PersonContact.ContactTypeId.ToString();
            SelectedIsDefaultContact = PersonContact.IsDefault == false ? "false" : "true";

            ContactSaveButton = "Save";

            CommonService.IsBusy = false;
        }

        public async Task CreatePerson()
        {
            CommonService.IsBusy = true;

            Person.PersonTypeId = Convert.ToInt32(SelectedPersonTypeId);
            Person.WorkFrequencyId = Convert.ToInt32(SelectedWorkFrequencyId);
            Person.CountryId = Convert.ToInt32(SelectedCoutryId);
            Person.JoinedAsId = Convert.ToInt32(SelectedJoinedAsId);
            Person.IsWorker = Convert.ToBoolean(SelectedIsWorker);
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
                var boolResult = await PersonContactRepository.UpdateAsync(PersonContact, "/api/person/" + savedPersonId + "/contact");        // update
                _editContactId = 0;
                if (boolResult == true)
                    result = 1;
            }

            if (result > 0)
            {
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
                await PersonContactRepository.RemoveAsync("/api/person/" + personId + "/contact/" + contactId);
                StateHasChanged();
            }
        }

        public async Task RemovePersonId()
        {
            await SessionStorageService.RemoveItemAsync("personId");
            //await SessionStorageService.RemoveItemAsync("personContactId");
            Person = new Person();
            PersonContact = new PersonContact();
            ContactDisabled = "disabled";
            StateHasChanged();
            ToastService.ShowSuccess("Ready to add new Person!!!", "Success");
        }

        public async Task ChangeCountry(string value)
        {
            CommonService.IsBusy = true;

            SelectedCoutryId = value;

            CommonService.IsBusy = false;
        }

        public async Task ChangePersonType(string value)
        {
            CommonService.IsBusy = true;

            SelectedPersonTypeId = value;

            CommonService.IsBusy = false;
        }

        public async Task ChangeWorkFrequency(string value)
        {
            CommonService.IsBusy = true;

            SelectedWorkFrequencyId = value;

            CommonService.IsBusy = false;
        }

        public async Task ChangeJoinedAs(string value)
        {
            CommonService.IsBusy = true;

            SelectedJoinedAsId = value;

            CommonService.IsBusy = false;
        }

        public async Task ChangeIsWorker(string value)
        {
            CommonService.IsBusy = true;

            SelectedIsWorker = value;

            CommonService.IsBusy = false;
        }

        public async Task ChangeContactType(string value)
        {
            CommonService.IsBusy = true;

            SelectedContactTypeId = value;

            CommonService.IsBusy = false;
        }

        public async Task ChangeIsDefaultContact(string value)
        {
            SelectedIsDefaultContact = value;
        }

        public async Task CancelPerson()
        {
            ToastService.ShowError("This person will be saved...!!! You have to delete explicitly.", "Error");
            await RemovePersonId();
        }
    }
}
