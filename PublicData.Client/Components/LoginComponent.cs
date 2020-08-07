using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicData.WebClient.Components
{
    public class LoginComponent : ComponentBase
    {
        public bool IsLoading = false;

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            StateHasChanged();
        }
    }
}
