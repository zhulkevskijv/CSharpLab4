namespace Lab03.Tools.Navigation
{
    internal enum ViewType
    {
        PersonInput,
        Result
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
