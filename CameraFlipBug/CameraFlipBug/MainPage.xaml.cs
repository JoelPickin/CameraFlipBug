using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace CameraFlipBug
{
    public partial class MainPage : ContentPage
    {
        private PortraitContentView _portrait;
        private LandscapeContentView _landscape;

        public MainPage()
        {
            InitializeComponent();

		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                Content = GetLandscapeView();
            }
            else
            {
                Content = GetPortraitView();
            }
        }

        private View GetPortraitView()
        {
            if (_portrait == null)
            {
                _portrait = new PortraitContentView();
            }

            return _portrait;
        }

        private View GetLandscapeView()
        {
            if (_landscape == null)
            {
                _landscape = new LandscapeContentView();
            }

            return _landscape;
        }
    }
}
