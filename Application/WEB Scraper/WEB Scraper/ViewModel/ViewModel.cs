﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WEB_Scraper
{
    public class ViewModel : ViewModelBase
    {
        private string _url;
        private string _command;
        private string _pathToFile;
        private ICommand _startScrape;
        private string _extension;
        int fileCount;
        private List<Task> _tasks = new List<Task>();

        public int Depth { get; set; }
        public string Extеnsion
        {
            get { return _extension; }
            set
            {
                //if (value == "pdf")
                //{
                //    MessageBox.Show("Comming soon...", "", MessageBoxButton.OK, MessageBoxImage.Information);
                //    return;
                //}

                _extension = value;
            }
        }
        public string URL
        {
            get { return _url; }
            set
            {
                if (!value.Contains("https://") && !value.Contains("http://"))
                {
                    _url = null;
                    MessageBox.Show("Enter valid url.", "INCORRECT URL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                _url = value;
            }
        }
        public string Command
        {
            get { return _command; }
            set { _command = value; }
        }
        public string PathToFile
        {
            get { return _pathToFile; }
            set
            {
                if (value == null) return;
                _pathToFile = @"" + value;
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(_pathToFile);
                    if (!dirInfo.Exists)
                        dirInfo.Create();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Path contains invalid characters such as \", <, >, or |.\n",
                        "INVALID PATH", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    _pathToFile = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    _pathToFile = null;
                }
            }
        }

        public ICommand StartScarpe
        {
            get
            {
                return _startScrape ?? (_startScrape = new RelayCommand(() =>
                {
                    if (URL == null || Command == null || PathToFile == null)
                    {
                        MessageBox.Show("Fill in the fields correctly", "UNFILLED", MessageBoxButton.OK,
                            MessageBoxImage.Exclamation);
                        return;
                    }

                    fileCount++;
                    _tasks.Add(Task.Factory.StartNew(() =>
                    {
                        HtmlLoader htmlLoader = new HtmlLoader();
                        WebParser<string> webParser = new WebParser<string>();
                        Data<string> data = new Data<string>();
                        int fileID = fileCount;

                        foreach (var document in htmlLoader.HtmlLoad(URL, Depth))
                        {
                            if (Extеnsion == "pdf")
                            {
                                data.StorageData($"{PathToFile}/file_({fileID}).doc",
                                webParser.Parse(document, Command));

                                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                                var wordDoc = application.Documents.Open($"{PathToFile}/file_({fileID}).doc");
                                wordDoc.ExportAsFixedFormat($"{PathToFile}/file_({fileID}).pdf", Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                                wordDoc.Close();
                            }
                            else
                            {
                                data.StorageData($"{PathToFile}/file_({fileID}).{Extеnsion}",
                                    webParser.Parse(document, Command));
                            }
                        }

                        MessageBox.Show("I did all the work for you.XD", "DONE", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                    }));
                }));
            }
        }
    }
}
