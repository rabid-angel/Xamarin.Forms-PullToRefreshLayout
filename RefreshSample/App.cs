﻿/*
 * Copyright (C) 2015 Refractored LLC & James Montemagno: 
 * http://github.com/JamesMontemagno
 * http://twitter.com/JamesMontemagno
 * http://refractored.com
 * 
 * The MIT License (MIT) see GitHub For more information
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Xamarin.Forms;
using RefreshSample.Views;

namespace RefreshSample
{
    public class App : Application
    {
        Page scrollViewPage;
        public App()
        {

            var scrollView = new Button { Text = "ScrollView" };
            var scrollViewXaml = new Button { Text = "ScrollView Xaml" };
            var listView = new Button { Text = "ListView" };
            var stackLayout = new Button { Text = "StackLayout" };
            var grid = new Button { Text = "Grid" };
            var scrollViewIn = new Button { Text = "ScrollView" };
            var listViewIn = new Button { Text = "ListView" };
            var stackLayoutIn = new Button { Text = "StackLayout" };
            var gridIn = new Button { Text = "Grid" };
            var disposeCrash = new Button { Text = "Dispose Crash" };
            var disposeCrash2 = new Button { Text = "Dispose Crash" };


            scrollViewPage = new ScrollViewPage(false);
            Page page;
            // The root page of your application
            MainPage = page = new NavigationPage(new ContentPage
            {
                Title = "Pull to Refresh!",
                Content = new ScrollView
                {
                    Content = new StackLayout
                    {
                        Padding = 25,
                        Children =
                            {
                                new Label
                                {
                                    Text = "Pull to Refresh in:"
                                },
                                scrollView,
                                listView,
                                stackLayout,
                                grid,
                                scrollViewXaml,
                                new Label
                                {
                                    Text = "Inside a layout:"
                                },
                                scrollViewIn,
                                listViewIn,
                                stackLayoutIn,
                                gridIn,
                                new Label
                                {
                                    Text = "Misc"
                                },
                                disposeCrash,
                                disposeCrash2
                            }
                    }
                }
            })
            {
                BackgroundColor = Color.FromHex("3498db"),
                BarTextColor = Color.White
            };

            scrollView.Clicked += async (sender, e) =>
            {
                var page2 = new ScrollViewXamlPage();
                await page.Navigation.PushAsync(scrollViewPage);
                await scrollViewPage.Navigation.PushAsync(page2);
            };
            scrollViewXaml.Clicked += (sender, e) => page.Navigation.PushAsync(new ScrollViewXamlPage());
            scrollViewIn.Clicked += (sender, e) => page.Navigation.PushAsync(new ScrollViewPage(true));
            listView.Clicked += (sender, e) => page.Navigation.PushAsync(new ListViewPage(false));
            listViewIn.Clicked += (sender, e) => page.Navigation.PushAsync(new ListViewPage(true));
            stackLayout.Clicked += (sender, e) => page.Navigation.PushAsync(new StackLayoutPage(false));
            stackLayoutIn.Clicked += (sender, e) => page.Navigation.PushAsync(new StackLayoutPage(true));
            grid.Clicked += (sender, e) => page.Navigation.PushAsync(new GridPage(false));
            gridIn.Clicked += (sender, e) => page.Navigation.PushAsync(new GridPage(true));
            disposeCrash.Clicked += (sender, e) => MainPage = new TabbedPage1();
            disposeCrash2.Clicked += (sender, e) => MainPage = new DisposeCrashPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

