using Microsoft.AspNetCore.Components;

namespace PublicData.WebClient.Components
{
    public abstract class CommonComponent : ComponentBase
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }

        public string ToggleClass(string variableName, string property)
        {
            if (string.IsNullOrWhiteSpace(variableName))
                return property;
            else
                return "";
        }

        public void NavigateToRoute(string routeName)
        {
            NavigationManager.NavigateTo(routeName, false);
        }
    }
}
