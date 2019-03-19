namespace Lab4.Tools.Navigation
{
    internal enum ViewType
    {
        PersonInput,
        Result,
        PersonsList
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
