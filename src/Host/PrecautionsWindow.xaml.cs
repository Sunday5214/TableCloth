﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using TableCloth.Models.Catalog;

namespace Host
{
    public partial class PrecautionsWindow : Window
    {
        public PrecautionsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CatalogDocument catalog = Application.Current.GetCatalogDocument();
            IEnumerable<string> targets = Application.Current.GetInstallSites();
            var buffer = new StringBuilder();

            foreach (CatalogInternetService eachItem in catalog.Services.Where(x => targets.Contains(x.Id)))
            {
                buffer.AppendLine($"[{eachItem.DisplayName} 이용 시 주의 사항]");
                buffer.AppendLine(eachItem.CompatibilityNotes);
            }

            CautionTextBody.AppendText(buffer.ToString());
        }

        private void PerformInstallButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
