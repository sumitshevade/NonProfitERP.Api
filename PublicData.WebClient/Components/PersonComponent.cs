using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace PublicData.WebClient.Components
{
    public class PersonComponent : ComponentBase
    {
        [Inject]
        public IPersonService PeopleService { get; set; }

        [Inject]
        public ICommonService CommonService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public bool IsLoading = false;
        [Parameter] public IEnumerable<PersonModel> People { get; set; } = new List<PersonModel>();
        [Parameter] public PersonModel Person { get; set; } = new PersonModel();
        [Parameter] public int PeopleId { get; set; }
        [Parameter] public PersonModel PeopleUpdate { get; set; } = new PersonModel();
        [Parameter] public IEnumerable<Details> PersonTypes { get; set; } = new List<Details>();
        [Parameter] public string ContactFormDisplay { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    ContactFormDisplay = "d-none";
        //    PersonTypes = new List<Details> { new Details { Id = 1, Value = "Wardhak" }, new Details { Id = 2, Value = "Teacher" } };
        //    await Task.Run(Get);
        //}

        //protected override async Task OnParametersSetAsync()
        //{
        //    //await Get(PeopleId);
        //}

        //private async Task Get()
        //{
        //    People = (await PeopleService.Get()).ToList();
        //    IsLoading = true;
        //    StateHasChanged();
        //}

        //protected async Task Get(int id)
        //{
        //    PeopleUpdate = await PeopleService.GetById(id);
        //}

        //public async void Save()
        //{
        //    await PeopleService.Add(Person);
        //    NavigationManager.NavigateTo("/person/create");
        //}

        //public void Edit()
        //{
        //    PeopleService.Update(PeopleUpdate);
        //    NavigationManager.NavigateTo("/person/create");
        //}

        //protected async Task Delete(int id)
        //{
        //    await PeopleService.Delete(id);
        //    await Get();
        //}
    }
}
