using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.WebClient.Models;
using Microsoft.AspNetCore.Components;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Shared.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.Toast.Services;

namespace PublicData.WebClient.Components
{
    public class CityComponent : ComponentBase
    {
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] ICountryRepository CountryRepository { get; set; }
        [Inject] IStateRepository StateRepository { get; set; }
        [Inject] ICityRepository CityRepository { get; set; }

        [Parameter] public IList<Country> Countries { get; set; } = new List<Country>();
        [Parameter] public IList<State> States { get; set; } = new List<State>();
        [Parameter] public IList<City> Cities { get; set; } = new List<City>();
        
        public City City = new City();
        public string SaveButton { get; set; }
        public string SelectedCountryId { get; set; }
        public string SelectedStateId { get; set; }

        public string Message = string.Empty;
        public AlertMessageType MessageType = AlertMessageType.Success;
        public int CityId { get; set; }
        
        protected async override Task OnInitializedAsync()
        {
            // Set to true - loading... will start
            CommonService.IsBusy = true;

            // Set AccessToken
            var userState = AuthenticationState.Result;
            CityRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            
            //Cities = await CityRepository.GetListAsync("/api/master/city");
            SaveButton = "Save";

            Countries = await CountryRepository.GetListAsync("/api/master/country");

            CommonService.IsBusy = false;
        }

        public async Task SaveCity()
        {
            if (!string.IsNullOrWhiteSpace(City.Name))
            {

                if (SaveButton == "Save")
                {
                    CityId = await CityRepository.AddAsync(City, "/api/master/city");
                    City.Id = CityId;
                    Cities.Add(City);
                }
                else
                {
                    await CityRepository.UpdateAsync(City, "/api/master/city");
                    Cities.Remove(City);
                    Cities.Add(City);
                }


                City = new City();
                SaveButton = "Save";
                ToastService.ShowSuccess("The city has been created!!!", "Success");
                StateHasChanged();
            }
            else
            {
                ToastService.ShowError("Something went wrong!!!", "Error");
            }
        }

        public void EditCity(int id)
        {
            SaveButton = "Update";
            City = Cities.Where(x => x.Id == id).FirstOrDefault();
            StateHasChanged();
        }

        public async Task DeleteCity(int id)
        {
            var result = await CityRepository.RemoveAsync("/api/master/city/" + id);

            if (result)
            {
                Cities.Remove(Cities.Where(x => x.Id == id).FirstOrDefault());
                StateHasChanged();
            }
        }

        private async Task GetStatesByCountryIdAsync(string countryId)
        {
            States = await StateRepository.GetListAsync("/api/master/state/" + countryId + "/detail");
            StateHasChanged();
        }

        private async Task GetCitiesByStateIdAsync(string stateId)
        {
            Cities = await CityRepository.GetListAsync("/api/master/state/" + stateId + "/detail");
            StateHasChanged();
        }

        public async Task ChangeCountry(string value)
        {
            SelectedCountryId = value;

            if (value == "0")
            {
                Countries.Clear();
            }
            else
            {
                await GetStatesByCountryIdAsync(value);
            }
        }

        public async Task ChangeState(string value)
        {
            SelectedCountryId = value;

            if (value == "0")
            {
                Countries.Clear();
            }
            else
            {
                await GetStatesByCountryIdAsync(value);
            }
        }
    }
}
