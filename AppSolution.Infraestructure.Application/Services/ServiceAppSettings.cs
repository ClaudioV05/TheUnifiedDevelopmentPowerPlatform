﻿using AppSolution.Application.Interfaces;

namespace AppSolution.Application.Services
{
    public class ServiceAppSettings : IServiceAppSettings
    {
        public void AddAppSettings(string key, string value)
        {
            try
            {
               
            }
            catch (Exception)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}