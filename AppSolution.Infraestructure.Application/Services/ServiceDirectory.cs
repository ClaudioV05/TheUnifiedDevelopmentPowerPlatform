﻿using AppSolution.Infraestructure.Application.Interfaces;
using System.Reflection;

namespace AppSolution.Infraestructure.Application.Services
{
    public class ServiceDirectory : IServiceDirectory
    {
        private const string NAME_DIRECTORY_CONFIG = "\\config";
        private const string NAME_DIRECTORY_APP = "\\app";
        private const string NAME_DIRECTORY_BIN = "bin";
        private const string NAME_DIRECTORY_DEBUG = "debug";

        public ServiceDirectory()
        {

        }

        public void CreateDefaultDirectory()
        {
            try
            {
                int posRootDirectory = 0;
                string? rootDirectory = GetRootPath();

                if (!string.IsNullOrEmpty(rootDirectory) && rootDirectory.Contains(NAME_DIRECTORY_DEBUG))
                {
                    posRootDirectory = rootDirectory.IndexOf(NAME_DIRECTORY_DEBUG);
                }
                else if (!string.IsNullOrEmpty(rootDirectory) && rootDirectory.Contains(NAME_DIRECTORY_BIN))
                {
                    posRootDirectory = rootDirectory.IndexOf(NAME_DIRECTORY_BIN);
                }

                string? path = rootDirectory.Substring(0, posRootDirectory - 1).ToLowerInvariant();

                if (!string.IsNullOrEmpty(path))
                {
                    CreateAppDirectory(path);
                }
            }
            catch (Exception)
            {

            }
        }

        public void CreateAppDirectory(string? path)
        {
            if (Directory.Exists($"{path}{NAME_DIRECTORY_APP}"))
            {
                Directory.Delete($"{path}{NAME_DIRECTORY_APP}", true);
            }

            Directory.CreateDirectory($"{path}{NAME_DIRECTORY_APP}");
        }

        private string GetRootPath()
        {
            string? rootPath = string.IsNullOrEmpty(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) ? string.Empty : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return rootPath.ToLowerInvariant();
        }

        public void CreateConfigDirectory(string? path)
        {
            throw new NotImplementedException();
        }
    }
}