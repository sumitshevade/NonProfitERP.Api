using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicData.WebClient.Components
{
    public class PeopleComponent : ComponentBase
    {
        [Inject]
        public IPeopleService PeopleService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public bool IsLoading = false;
        [Parameter] public IEnumerable<People> People { get; set; } = new List<People>();
        [Parameter] public People Person { get; set; } = new People();
        [Parameter] public int PeopleId { get; set; }
        [Parameter] public People PeopleUpdate { get; set; } = new People();
        [Parameter] public IEnumerable<Details> PersonTypes { get; set; } = new List<Details>();

        protected override async Task OnInitializedAsync()
        {
            PersonTypes = new List<Details> { new Details { Id = 1, Value = "Wardhak" }, new Details { Id = 2, Value = "Teacher" } };
            await Task.Run(Get);
        }

        //protected override async Task OnParametersSetAsync()
        //{
        //    //await Get(PeopleId);
        //}

        private async Task Get()
        {
            People = (await PeopleService.Get()).ToList();
            IsLoading = true;
            StateHasChanged();
        }

        protected async Task Get(int id)
        {
            PeopleUpdate = await PeopleService.GetById(id);
        }

        public async void Save()
        {
            await PeopleService.Add(Person);
            NavigationManager.NavigateTo("/people");
        }

        public void Edit()
        {
            PeopleService.Update(PeopleUpdate);
            NavigationManager.NavigateTo("/people");
        }

        protected async Task Delete(int id)
        {
            await PeopleService.Delete(id);
            await Get();
        }
    }
}
