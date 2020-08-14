using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using PublicData.WebClient.DataModels;
using Microsoft.AspNetCore.Components.Authorization;

namespace PublicData.WebClient.Components
{
    public class PersonComponent : ComponentBase
    {
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IPersonRepository PersonRepository { get; set; }
        [Inject] IDetailRepository DetailRepository { get; set; }
        [Inject] IDivisionRepository DivisionRepository { get; set; }

        [Parameter] public Person Person { get; set; } = new Person();
        [Parameter] public Person PeopleUpdate { get; set; } = new Person();
        [Parameter] public string ContactFormDisplay { get; set; }
        [Parameter] public IEnumerable<Detail> JoinedAs { get; set; } = new List<Detail>();
        [Parameter] public IEnumerable<Detail> Shakhas { get; set; } = new List<Detail>();
        [Parameter] public IEnumerable<Detail> PersonTypes { get; set; } = new List<Detail>();
        [Parameter] public IEnumerable<Detail> WorkFrequencies { get; set; } = new List<Detail>();
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }

        public string Message = string.Empty;
        public AlertMessageType MessageType = AlertMessageType.Success;

        protected async override Task OnInitializedAsync()
        {
            CommonService.IsBusy = true;

            // Set AccessToken
            var userState = AuthenticationState.Result;
            PersonRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            DetailRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            DivisionRepository.SetToken(userState.User.FindFirst("AccessToken").Value);

            await GetAsync();
            Shakhas = await DetailRepository.GetListAsync("/api/master/division");
            PersonTypes = await DetailRepository.GetListAsync("/api/master/header/16/detail");
            JoinedAs = await DetailRepository.GetListAsync("/api/master/header/10/detail");
            WorkFrequencies = await DetailRepository.GetListAsync("/api/master/header/26/detail");

            CommonService.IsBusy = false;
        }

        async Task GetAsync()
        {
            CommonService.IsBusy = true;

            CommonService.IsBusy = false;
        }

        async Task PostAsync()
        {
            CommonService.IsBusy = true;

            var result = await PersonRepository.AddAsync(Person, "/api/person");

            if (result > 0)
                NavigationManager.NavigateTo("/person");
            else
            {
                Message = "Something went wrong";
                MessageType = AlertMessageType.Error;
            }

            CommonService.IsBusy = false;
        }
    }
}
