﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBase.Util
{
    class FileSearcher
    {
#nullable enable
        public string? SearchText { get; set; }
        public bool NestSearch { get; set; } = false;

        public FileSearcher(string searchText) { SearchText = searchText; }
        public FileSearcher() { }

        public List<string>? Search()
        {
            if (SearchText == null || SearchText == string.Empty)
                return null;
            var currentPath = AppContext.BaseDirectory;
            // files为绝对路径
            var allFiles = new List<string>();
            var files = new List<string>();
            if (NestSearch)
            {
                GetFilesInDirectory(currentPath, allFiles);
            }
            else
            {
                allFiles = Directory.GetFiles(currentPath).ToList();
            }
            foreach ( var file in allFiles)
            {
                if (file.Contains(SearchText))
                {
                    files.Add(file);
                }
            }
            Debug.WriteLine($"搜索关键字:{SearchText}");
            return files;
        }

        public List<string>? Search(string path)
        {
            if (SearchText == null || SearchText == string.Empty)
                return null;
            var currentPath = path;
            // files为绝对路径
            var files = new List<string>();
            GetFilesInDirectory(currentPath, files);
            Console.WriteLine($"搜索关键字:{SearchText}");
            foreach (var file in files)
            {
                var filename = Path.GetFileName(file);
                if (filename.Contains(SearchText))
                    Console.WriteLine($"file:{Path.GetFileName(file)}");
            }
            return files;
        }

        public void ProcessDirectory(string targetDirectory, int level)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);

            // 输出当前文件夹的名字和层次
            Console.WriteLine($"{new string(' ', level * 4)}{Path.GetFileName(targetDirectory)}");

            // 输出当前文件夹下的文件
            foreach (string fileName in fileEntries)
            {
                Console.WriteLine($"{new string(' ', (level + 1) * 4)}{Path.GetFileName(fileName)}");
            }

            // 递归处理当前文件夹下的子文件夹
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory, level + 1);
            }
        }

        public void GetFilesInDirectory(string targetDirectory, List<string> fileList)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);

            foreach (string fileName in fileEntries)
            {
                fileList.Add(fileName);
            }

            foreach (string subdirectory in subdirectoryEntries)
            {
                GetFilesInDirectory(subdirectory, fileList);
            }
        }

        public static IEnumerable<string> ReadFrom(string file)
        {
            string? line;
            using var reader = System.IO.File.OpenText(file);
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
