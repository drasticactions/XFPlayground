using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFPlayground.Pages;

namespace XFPlayground
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.TitlePage, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.TitlePage:
                        MenuPages.Add(id, new NavigationPage(new TitlePage()));
                        break;
                    case (int)MenuItemType.ImageComponentPage:
                        MenuPages.Add(id, new NavigationPage(new ImageComponentPage()));
                        break;
                    case (int)MenuItemType.ImagePage:
                        MenuPages.Add(id, new NavigationPage(new ImagePage()));
                        break;
                    case (int)MenuItemType.VideoPage:
                        MenuPages.Add(id, new NavigationPage(new VideoPage()));
                        break;
                    case (int)MenuItemType.VideoMosaicPage:
                        MenuPages.Add(id, new NavigationPage(new VideoMosaicPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
