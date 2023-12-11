﻿using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceFile : IServiceFile
    {
        public void UDPLinesGenerate(IEnumerable<string> informations, string rootDirectory)
        {
            File.WriteAllLines(rootDirectory, informations);
        }

        public IEnumerable<string>? UDPLinesRead(string rootDirectory)
        {
            IEnumerable<string>? returnList = null;

            if (File.Exists(rootDirectory)) 
            { 
                returnList = File.ReadAllLines(rootDirectory);
            }

            return returnList;
        }
    }
}