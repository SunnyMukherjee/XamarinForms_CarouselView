using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinForms_CarouselView.Models
{
    public class ProductModel
    {
        public Image ImageObj { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }

        public ProductModel(string imageUrl, string title)
        {
            ImageObj = new Image()
            {
                Source = ImageSource.FromUri(new Uri(imageUrl))
            };

            ImageUrl = imageUrl;
            Title = title;
        }
    }
}
