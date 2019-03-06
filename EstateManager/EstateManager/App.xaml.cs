using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EstateManager.DataAccess;

namespace EstateManager
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await EstateDbContext.Initialize();
            /*
            var p = new Model.Photo()
            {
                Title = "Photo 1",
                Content = "Content 1"
            };
            EstateDbContext.Current.Add(p); //sauvegarde en cache
            EstateDbContext.Current.SaveChanges(); //sauvegarde ds données en cache dans le fichier

            var monBien = EstateDbContext.Current.Estate
                .Where(estate => estate.City == "LYON" && ... || ...)
                .Include(estate => estate.Contracts).ThenInclude(contract => contract.Estate)
                .Include(estate => estate.Photos) //charge les contrats associés au bien / foreign keys SINON propriété est vide ( ou null ?)
                .Include(estate => estate.MainPhotos) //besoin de using Microsoft.EntityFrameworkCore
                .OrderBy(estate => estate.address)
                .Select(estate => estate.Surface) // remplace Select * par Select Surface
                .first(); //requete SQL .ToList()

            */
        }
    }
}
