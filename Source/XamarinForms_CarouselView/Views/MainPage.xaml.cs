using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms_CarouselView.ViewModels;

namespace XamarinForms_CarouselView.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = MainPageViewModel.Instance;

            MessagingCenter.Subscribe<MainPageViewModel>
                (
                   this,
                   "TimerElapsed",
                   (arg) =>
                   {
                       MainPageViewModel mainPageViewModel = arg as MainPageViewModel;

                       Device.BeginInvokeOnMainThread
                       (
                           () =>
                           {
                               this.ProductCarousel.ScrollTo(mainPageViewModel.CurrentIndex, position: ScrollToPosition.MakeVisible, animate: true);
                           }
                        );                       
                   }
                );
        }
    }
}
