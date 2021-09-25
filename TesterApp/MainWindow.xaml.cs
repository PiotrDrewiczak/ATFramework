// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TesterApp
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> fileNamePathsList;
        private readonly string configurationExtension = "xml";
        private readonly string configurationFilter = "XML Files|*.xml";
        private OpenFileDialog openFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.fileNamePathsList = new List<string>();
            this.XmlView.ItemsSource = this.fileNamePathsList;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            this.LoadXmlFiles();
            this.XmlView.Items.Refresh();
        }

        private void LoadXmlFiles()
        {
            this.openFileDialog = new ()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = this.configurationExtension,
                Filter = this.configurationFilter,
            };

            this.openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(this.openFileDialog.FileName))
            {
                this.fileNamePathsList.Add(this.openFileDialog.FileName);
            }
        }
    }
}