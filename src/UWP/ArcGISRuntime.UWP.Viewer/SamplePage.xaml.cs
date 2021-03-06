﻿// Copyright 2018 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific
// language governing permissions and limitations under the License.

using ArcGISRuntime.Samples.Managers;
using System;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace ArcGISRuntime.UWP.Viewer
{
    public sealed partial class SamplePage
    {
        public SamplePage()
        {
            InitializeComponent();

            HideStatusBar();

            // Get selected sample and set that as the DataContext.
            DataContext = SampleManager.Current.SelectedSample;

            // Load and show the sample.
            SampleContainer.Content = SampleManager.Current.SampleToControl(SampleManager.Current.SelectedSample);

            // Default to the live sample view.
            LiveSample.IsChecked = true;

            SourceCodeContainer.LoadSourceCode();
        }
       
        private static async void HideStatusBar()
        {
            // Check if the phone contract is available (mobile) and hide status bar if it is there.
            if (!ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0)) return;
            await StatusBar.GetForCurrentView().HideAsync();
        }

        private void LiveSample_Checked(object sender, RoutedEventArgs e)
        {
            // Make sure that only one is selected.
            Description.IsChecked = false;
            SourceButton.IsChecked = false;
            DescriptionContainer.Visibility = Visibility.Collapsed;
            SampleContainer.Visibility = Visibility.Visible;
            SourceCodeContainer.Visibility = Visibility.Collapsed;
        }

        private void Description_Checked(object sender, RoutedEventArgs e)
        {
            // Make sure that only one is selected.
            LiveSample.IsChecked = false;
            SourceButton.IsChecked = false;
            DescriptionContainer.Visibility = Visibility.Visible;
            SampleContainer.Visibility = Visibility.Collapsed;
            SourceCodeContainer.Visibility = Visibility.Collapsed;
        }
        private void SourceCode_Checked(object sender, RoutedEventArgs e)
        {
            // Make sure that only one is selected.
            Description.IsChecked = false;
            LiveSample.IsChecked = false;
            DescriptionContainer.Visibility = Visibility.Collapsed;
            SampleContainer.Visibility = Visibility.Collapsed;
            SourceCodeContainer.Visibility = Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Prevent user from going back
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }


    }
}