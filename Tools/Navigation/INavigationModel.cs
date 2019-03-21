namespace Lab4.Tools.Navigation
{
    internal enum ViewType
    {
        PersonInput,
        PersonsList
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
