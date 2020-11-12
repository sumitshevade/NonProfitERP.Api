namespace PublicData.WebClient.Interfaces
{
    public interface ICommonService
    {
        #region Properties

        bool IsBusy { get; set; }
        bool ShowErrors { get; set; }
        string Error { get; set; }

        #endregion

        #region Methods

        string ToggleClass(string variableName, string property);
        
        #endregion
    }
}
