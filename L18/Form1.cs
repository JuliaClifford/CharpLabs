﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L18
{
    public partial class Form1 : Form
    {
        private const string FolderName = "Folder_";
        
        private const string TestDirectoryName = "Your 100 Folders here!";
        
        private const int NumberSubFolders = 100;
        
        private int _subFoldersCount;
        
        private readonly DirectoryInfo _dirInfo;

        public Form1()
        {
            InitializeComponent();
            _dirInfo = new DirectoryInfo(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + TestDirectoryName);
        }

        private void DeleteFolders()
        {
            foreach (var folder in _dirInfo.GetDirectories())
                folder.Delete(true);
        }
        private void ShowMaxNumberSubFolder()
        {
            var path = "D:";
            var count = 0;

            try
            {
                while (true)
                {
                    path += @"\" + 'a';
                    count++;
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Максимальное количество папок " + count);
            }

            Directory.Delete(@"D:\a",true);
        }
        
        private void CreateSubFolders(DirectoryInfo dir)
        {
            try
            {
                if (_subFoldersCount == NumberSubFolders)
                    return;

                dir.CreateSubdirectory(FolderName + _subFoldersCount++);
                CreateSubFolders(dir.GetDirectories()[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Максимальное количество папок " + _subFoldersCount);
            }
        }

        private void CreateFolder_Click(object sender, EventArgs e)
        {
            if (!_dirInfo.Exists)
            {
                _dirInfo.Create();
            }

            for (int i = 0; i < 100; i++)
            {
                _dirInfo.CreateSubdirectory(FolderName + i);
            }

            MessageBox.Show("Проверьте рабочий стол! (После нажатия ОК проверять будет нечего)");

            if (_dirInfo.Exists)
            {
                DeleteFolders();
            }

            _dirInfo.Delete(true);
        }
        private void CreateSubFolder_Click(object sender, EventArgs e)
        {
            if (!_dirInfo.Exists)
                _dirInfo.Create();
            else
                DeleteFolders();

            CreateSubFolders(_dirInfo);
        }
        private void CheckMaxSubFolders_Click(object sender, EventArgs e)
        {
            ShowMaxNumberSubFolder();
        }
        

        private void TextBoxFindPlace_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.OK)
                TextBoxFindPlace.Text = browserDialog.SelectedPath;
        }

        private static IEnumerable<string> EnumerateAllFiles(string path, string pattern)
        { 
            IEnumerable<string> files = null;
            try
            {
                files = Directory.EnumerateFiles(path, pattern);
            }
            catch
            {
                // ignored
            }

            if (files != null)
            {
                foreach (var file in files) yield return file;
            }

            IEnumerable<string> directories = null;
            try
            {
                directories = Directory.EnumerateDirectories(path);
            }
            catch
            {
                // ignored
            }

            if (directories == null) yield break;
            {
                foreach (var file in directories.SelectMany(d => EnumerateAllFiles(d, pattern)))
                {
                    yield return file;
                }
            }
        }
        
        private int TryCreateFolder()
        {
            var tempName = "a";
            
            try
            {
                while (true)
                {
                    if (!_dirInfo.Exists)
                    {
                        _dirInfo.Create();
                    }
                    _dirInfo.CreateSubdirectory(tempName);
                    tempName += "a";
                    _dirInfo.Delete(true);
                }
            }
            catch
            {
                return tempName.Length - 1;
            }
            
        }

        private void CheckFolderNameLengthButton_Click(object sender, EventArgs e) => MessageBox.Show(TryCreateFolder().ToString());
        
    }
}