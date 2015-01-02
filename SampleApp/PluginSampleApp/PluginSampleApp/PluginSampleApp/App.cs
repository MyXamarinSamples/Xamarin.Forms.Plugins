﻿using System.Collections.Generic;
using System.Reflection;
using SVG.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace PluginSampleApp
{
    public class App : Application
    {
        public App()
        {
            var stackLayout = new StackLayout();

            stackLayout.Children.Add(new Label
            {
                Text = "SVGs are AWESOME!!!",
                Font = Font.BoldSystemFontOfSize(20),
                HorizontalOptions = LayoutOptions.Center
            });

            //Get SVGs from http://thenounproject.com/
            var svgPaths = new List<string>
            {
                "PluginSampleApp.Images.tiger.svg",
                "PluginSampleApp.Images.star_depressed.svg",
                "PluginSampleApp.Images.star_off.svg",
                "PluginSampleApp.Images.star_on.svg",
                "PluginSampleApp.Images.pin.svg",
                "PluginSampleApp.Images.hipster.svg",
            };

            foreach (var svgPath in svgPaths)
            {
                var horizontalStackLayout = new StackLayout {Orientation = StackOrientation.Horizontal};

                for (var y = 1; y <= 4; y++)
                {
                    //IMPORTANT Make sure you set both SvgPath and SvgAssembly
                    var svgImage = new SvgImage {SvgPath = svgPath, SvgAssembly = typeof(App).GetTypeInfo().Assembly, HeightRequest = y*30, WidthRequest = y*30};

                    if (svgPath.Contains("hipster"))
                        svgImage.BackgroundColor = Color.White;

                    horizontalStackLayout.Children.Add(svgImage);
                }

                stackLayout.Children.Add(horizontalStackLayout);
            }

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new ScrollView {Content = stackLayout}
            };
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
