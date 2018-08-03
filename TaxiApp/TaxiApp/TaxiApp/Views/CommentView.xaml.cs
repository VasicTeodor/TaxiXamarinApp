using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentView : ContentPage
	{
        object _parameter;
        CommentViewModel _commentViewModel;
        public CommentView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            _commentViewModel = new CommentViewModel(AppBootstrapper.NavigationService, AppBootstrapper.DriveServices);
            BindingContext = _commentViewModel;
		}

        public CommentView(object parameter) : this()
        {
            _parameter = parameter;

            if (_parameter != null)
            {
                _commentViewModel.Initialize(_parameter);
            }
        }
    }
}