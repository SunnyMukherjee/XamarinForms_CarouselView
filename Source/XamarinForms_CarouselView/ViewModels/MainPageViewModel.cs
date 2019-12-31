using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using Xamarin.Forms;
using XamarinForms_CarouselView.Models;

namespace XamarinForms_CarouselView.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Members

        private static readonly Lazy<MainPageViewModel> _lazy = new Lazy<MainPageViewModel>(() => { return new MainPageViewModel(); });

        public static MainPageViewModel Instance => _lazy.Value;

        internal int CurrentIndex { get; set; }

        public ObservableCollection<ProductModel> Products { get; set; }

        internal Timer TimerObj { get; set; }

        internal object TimerLock = new object();

        #endregion


        #region Constructors

        public MainPageViewModel()
        {
            Initialize();
        }

        #endregion


        #region Functions

        private void Initialize()
        {
            CurrentIndex = 0;

            Products = new ObservableCollection<ProductModel>()
            {
                new ProductModel("https://images.freeimages.com/images/large-previews/4eb/desserts-1323159.jpg", "Ice Cream"),
                new ProductModel("https://images.freeimages.com/images/large-previews/e08/desserts-1323172.jpg", "Ice Cream Cake"),
                new ProductModel("https://images.freeimages.com/images/large-previews/0a6/butter-biscuits-1329768.jpg", "Butter Biscuits"),
                new ProductModel("https://images.freeimages.com/images/large-previews/611/dessert-1-1322053.jpg", "More Ice Cream"),
                new ProductModel("https://images.freeimages.com/images/large-previews/ba1/crepes-1317880.jpg", "Crepe"),
                new ProductModel("https://images.freeimages.com/images/large-previews/28f/banana-split-close-up-1578551.jpg", "Banana Split"),
                new ProductModel("https://images.freeimages.com/images/large-previews/c38/muffins-1-1317826.jpg", "Chocolate Chip")
            };

            TimerObj = new Timer()
            {
                Interval = 5000,
                AutoReset = true,
                Enabled = true
            };

            TimerObj.Start();

            TimerObj.Elapsed += (sender, e) =>
            {
                lock(TimerLock)
                {
                    if (CurrentIndex < Products.Count - 1)
                    {
                        CurrentIndex++;
                    }
                    else
                    {
                        CurrentIndex = 0;
                    }

                    MessagingCenter.Send<MainPageViewModel>(this, "TimerElapsed");
                }
            };
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
