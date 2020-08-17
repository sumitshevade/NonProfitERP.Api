using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PublicData.WebClient.DataModels;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using PublicData.WebClient.Repository;
using System;
using System.Linq;
using PublicData.WebClient.Models;

namespace PublicData.WebClient.Components
{
    public class DetailComponent : ComponentBase
    {
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] IDetailRepository DetailRepository { get; set; }
        [Inject] IHeaderRepository HeaderRepository { get; set; }
        [Parameter] public IList<Header> Headers { get; set; } = new List<Header>();
        [Parameter] public IList<Detail> Details { get; set; } = new List<Detail>();
        [Parameter] public string DetailFormDisplay { get; set; }
        
        public Detail detail = new Detail();
        public string SelectedHeaderId { get; set; }
        public string DetailButton { get; set; }

        public string Message = string.Empty;
        public AlertMessageType MessageType = AlertMessageType.Success;
        
        protected async override Task OnInitializedAsync()
        {
            // Set to true - loading... will start
            CommonService.IsBusy = true;

            // Set AccessToken
            var userState = AuthenticationState.Result;
            HeaderRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            DetailRepository.SetToken(userState.User.FindFirst("AccessToken").Value);
            
            Headers = await GetHeadersAsync();

            SelectedHeaderId = detail.HeaderId.ToString();
            DetailButton = "Save";

            CommonService.IsBusy = false;
        }

        async Task<IList<Header>> GetHeadersAsync()
        {
            return await HeaderRepository.GetListAsync("/api/master/header");
        }

        private async Task GetDetailsByHeaderIdAsync(string headerId)
        {
            Details = await DetailRepository.GetListAsync("/api/master/header/" + headerId + "/detail");
            StateHasChanged();
        }

        public async Task SaveDetail()
        {
            if (!string.IsNullOrWhiteSpace(detail.Value))
            {
                if (DetailButton == "Save")
                {
                    detail.HeaderId = Convert.ToInt32(SelectedHeaderId);
                    await DetailRepository.AddAsync(detail, "/api/master/detail");
                }
                else
                {
                    detail.HeaderId = Convert.ToInt32(SelectedHeaderId);
                    await DetailRepository.UpdateAsync(detail, "/api/master/detail");
                }

                detail.Value = "";
                ChangeHeader(SelectedHeaderId);

                DetailButton = "Save";
                StateHasChanged();
            }
            else
            {
                Message = "Value should not be empty";
                MessageType = Models.AlertMessageType.Error;
            }
        }

        public void EditDetail(int detailId)
        {
            DetailButton = "Update";
            detail = Details.Where(x => x.Id == detailId).FirstOrDefault();
            SelectedHeaderId = detail.HeaderId.ToString();
            StateHasChanged();
        }

        public async Task DeleteDetail(int detailId)
        {
            await DetailRepository.RemoveAsync("/api/master/detail/" + detailId);
            StateHasChanged();
        }

        public async void ChangeHeader(string value)
        {
            SelectedHeaderId = value;

            if (value == "0")
            {
                Details.Clear();
            }
            else
            {
                await GetDetailsByHeaderIdAsync(value);
            }
        }
    }
}
