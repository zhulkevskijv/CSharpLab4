using System;
using Lab03.Views;

namespace Lab03.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.PersonInput:
                    ViewsDictionary.Add(viewType, new PersonInputView());
                    break;
                case ViewType.Result:
                    ViewsDictionary.Add(viewType, new ResultView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
