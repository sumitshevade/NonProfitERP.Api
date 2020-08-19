using System;
using System.Linq;
using Blazored.LocalStorage;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Blazored.SessionStorage;
using System.Collections.Generic;
using PublicData.WebClient.Models;
using Microsoft.AspNetCore.Components;
using PublicData.WebClient.DataModels;
using PublicData.WebClient.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace PublicData.WebClient.Components
{
    public class SearchPersonComponent : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILocalStorageService LocalStorageService { get; set; }
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] IPersonRepository PersonRepository { get; set; }
        [Inject] IDetailRepository DetailRepository { get; set; }
        [Inject] IDivisionRepository DivisionRepository { get; set; }
        [Inject] ICountryRepository CountryRepository  { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] ISessionStorageService SessionStorageService { get; set; }

        [Parameter] public Person Person { get; set; } = new Person();
        [Parameter] public IList<Person> People { get; set; } = new List<Person>();
        [Parameter] public IList<Detail> JoinedAs { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> PersonTypes { get; set; } = new List<Detail>();
        [Parameter] public IList<Detail> WorkFrequencies { get; set; } = new List<Detail>();
        [Parameter] public IList<Country> Countries { get; set; } = new List<Country>();
        [Parameter] public IList<Detail> ContactTypes { get; set; } = new List<Detail>();
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }

        public string SelectedPersonTypeId { get; set; }
        public string SelectedJoinedAsId { get; set; }
        public string SelectedCountryId { get; set; }
        public string SelectedWorkFrequencyId { get; set; }
        public string SelectedIsWorker { get; set; }
        public string ContactDisabled { get; set; }
        public string SelectedIsAlive { get; set; }

        public string Message = string.Empty;
        public string ContactSaveButton = string.Empty;
        public AlertMessageType MessageType = AlertMessageType.Success;

        protected async override Task OnInitializedAsync()
        {
            CommonService.IsBusy = true;

            // Set AccessToken
            var userState = AuthenticationState.Result;
            PersonRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            DetailRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            DivisionRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            CountryRepository.SetToken(userState.User.FindFirst("AccessToken").Value);

            await SessionStorageService.RemoveItemAsync("personId");
            
            Countries = await CountryRepository.GetListAsync("/api/master/country");
            PersonTypes = await DetailRepository.GetListAsync("/api/master/header/16/detail");
            JoinedAs = await DetailRepository.GetListAsync("/api/master/header/10/detail");
            WorkFrequencies = await DetailRepository.GetListAsync("/api/master/header/26/detail");

            SelectedCountryId = Person.CountryId?.ToString();
            SelectedJoinedAsId = Person.JoinedAsId?.ToString();
            SelectedPersonTypeId = Person.PersonTypeId.ToString();
            SelectedWorkFrequencyId = Person.WorkFrequencyId.ToString();
            SelectedIsWorker = Person.IsWorker == false ? "false" : "true";
            SelectedIsAlive = Person.IsAlive == false ? "false" : "true";

            CommonService.IsBusy = false;
        }

        public async Task SearchPerson()
        {
            CommonService.IsBusy = true;

            Person.PersonTypeId = Convert.ToInt32(SelectedPersonTypeId ?? "0");
            Person.WorkFrequencyId = Convert.ToInt32(SelectedWorkFrequencyId ?? "0");
            Person.JoinedAsId = Convert.ToInt32(SelectedJoinedAsId ?? "0");
            Person.IsWorker = Convert.ToBoolean(SelectedIsWorker ?? "false");
            Person.CountryId = Convert.ToInt32(SelectedCountryId ?? "0");

            var result = await PersonRepository.SearchAsync(Person, "/api/person/search");        // create new

            if (result != null && result.Count != 0)
            {
                People = result;
                StateHasChanged();
                ToastService.ShowSuccess("Person search completed!!!", "Success");
            }
            else
            {
                ToastService.ShowError("Something went wrong!!!", "Error");
            }

            CommonService.IsBusy = false;
        }

        public async Task EditPerson(int value)
        {
            await SessionStorageService.SetItemAsync("personId", value);
            NavigationManager.NavigateTo("/person/create");
        }

        public async Task DeletePerson(int value)
        {
        }

        public async Task CancelPerson()
        {
            Person = new Person();
            ToastService.ShowSuccess("Ready to search!!!", "Success");
        }

        public async Task ChangeCountry(string value)
        {
            SelectedCountryId = value;
        }

        public async Task ChangePersonType(string value)
        {
            SelectedPersonTypeId = value;
        }

        public async Task ChangeWorkFrequency(string value)
        {
            SelectedWorkFrequencyId = value;
        }

        public async Task ChangeJoinedAs(string value)
        {
            SelectedJoinedAsId = value;
        }

        public async Task ChangeIsWorker(string value)
        {
            SelectedIsWorker = value;
        }

        public async Task ChangeIsAlive(string value)
        {
            SelectedIsAlive = value;
        }
    }
}
