using Microsoft.AspNetCore.Components;
using PublicData.WebClient.Interfaces;

namespace PublicData.WebClient.Services
{
    public class CommonService : ICommonService
    {
        public bool IsBusy { get; set; } = false;
        public bool ShowErrors { get; set; }
        public string Error { get; set; }

        public string ToggleClass(string variableName, string property)
        {
            if (string.IsNullOrWhiteSpace(variableName))
                return property;
            else
                return "";
        }
    }
}
