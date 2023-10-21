﻿namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServiceDirectory
    {
        void CreateDefaultDirectory();
        void CreateAppDirectory(string? path);
        void CreateConfigDirectory(string? path);
    }
}