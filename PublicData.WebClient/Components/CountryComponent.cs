using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.WebClient.Models;
using Microsoft.AspNetCore.Components;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Shared.Entities;
using Microsoft.AspNetCore.Components.Authorization;

namespace PublicData.WebClient.Components
{
    public class CountryComponent : ComponentBase
    {
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] ICountryRepository CountryRepository { get; set; }
        [Parameter] public IList<Country> Countries { get; set; } = new List<Country>();
        
        public Country Country = new Country();
        public string SaveButton { get; set; }

        public string Message = string.Empty;
        public AlertMessageType MessageType = AlertMessageType.Success;
        
        protected async override Task OnInitializedAsync()
        {
            // Set to true - loading... will start
            CommonService.IsBusy = true;

            // Set AccessToken
            var userState = AuthenticationState.Result;
            CountryRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            
            Countries = await CountryRepository.GetListAsync("/api/master/country");
            SaveButton = "Save";

            CommonService.IsBusy = false;
        }

        public async Task SaveCountry()
        {
            if (!string.IsNullOrWhiteSpace(Country.Name))
            {
                if (SaveButton == "Save")
                {
                    await CountryRepository.AddAsync(Country, "/api/master/country");
                }
                else
                {
                    await CountryRepository.UpdateAsync(Country, "/api/master/country");
                }

                Countries.Add(Country);

                SaveButton = "Save";
                StateHasChanged();
            }
            else
            {
                Message = "Name should not be empty";
                MessageType = Models.AlertMessageType.Error;
            }
        }

        public void EditCountry(int id)
        {
            SaveButton = "Update";
            Country = Countries.Where(x => x.Id == id).FirstOrDefault();
            StateHasChanged();
        }

        public async Task DeleteCountry(int id)
        {
            await CountryRepository.RemoveAsync("/api/master/country/" + id);
            StateHasChanged();
        }
    }
}
