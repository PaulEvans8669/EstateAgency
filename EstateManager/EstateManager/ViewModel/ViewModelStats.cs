using EstateManager.DataAccess;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using EstateManager.Tools;
using EstateManager.Model;

namespace EstateManager.ViewModel
{
    class ViewModelStats : BaseNotifyPropertyChanged
    {

        private SeriesCollection series;

        public SeriesCollection Series
        {
            get { return GetProperty<SeriesCollection>(); }
            set { SetProperty(value); }
        }

        private double _value;

        public double Value
        {
            get { return GetProperty<double>(); }
            set { SetProperty(value); }
        }

        public ViewModelStats()
        {

            Value = nbPublishedContracts();

            Series = new SeriesCollection {

                new PieSeries
                {
                    Title = Model.Enums.EstateType.House.ToString(),
                    DataLabels = true,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(nbHouse()) }
                }
                ,

                new PieSeries
                {
                    Title = Model.Enums.EstateType.CommercialLocal.ToString(),
                    DataLabels = true,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(nbCommercialLocal()) }
                }
                ,

                new PieSeries
                {
                    Title = Model.Enums.EstateType.Field.ToString(),
                    DataLabels = true,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(nbField()) }
                }
                ,

                new PieSeries
                {
                    Title = Model.Enums.EstateType.Flat.ToString(),
                    DataLabels = true,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(nbFlat()) }
                }
                ,

                new PieSeries
                {
                    Title = Model.Enums.EstateType.Garage.ToString(),
                    DataLabels = true,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(nbGarage()) }
                }
                ,

                new PieSeries
                {
                    Title = Model.Enums.EstateType.Other.ToString(),
                    DataLabels = true,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(nbOther()) }
                }

            };

        }

        public int nbHouse()
        {
            int nbHouse;

            nbHouse = EstateDbContext.Current.Estate.Where(estate => estate.Type == Model.Enums.EstateType.House).Count();

            return nbHouse;
        }

        public int nbFlat()
        {
            int nbFlat;

            nbFlat = EstateDbContext.Current.Estate.Where(estate => estate.Type == Model.Enums.EstateType.Flat).Count();

            return nbFlat;
        }

        public int nbGarage()
        {
            int nbGarage;

            nbGarage = EstateDbContext.Current.Estate.Where(estate => estate.Type == Model.Enums.EstateType.Garage).Count();

            return nbGarage;
        }

        public int nbField()
        {
            int nbField;

            nbField = EstateDbContext.Current.Estate.Where(estate => estate.Type == Model.Enums.EstateType.Field).Count();

            return nbField;
        }

        public int nbCommercialLocal()
        {
            int nbCommercialLocal;

            nbCommercialLocal = EstateDbContext.Current.Estate.Where(estate => estate.Type == Model.Enums.EstateType.CommercialLocal).Count();

            return nbCommercialLocal;
        }

        public int nbOther()
        {
            int nbOther;

            nbOther = EstateDbContext.Current.Estate.Where(estate => estate.Type == Model.Enums.EstateType.Other).Count();

            return nbOther;
        }

        public int nbPublishedContracts()
        {

            int nbPublishedContracts;

            nbPublishedContracts = EstateDbContext.Current.Estate
                .Include(estate => estate.Contracts).ThenInclude(contract => contract.PubDate)
                .Include(estate => estate.Contracts).ThenInclude(contract => contract.SignDate)
                .Include(estate => estate.Contracts).ThenInclude(contract => contract.CloseDate)
                .Where(estate => estate.Contracts.Where(c => c.SignDate == null && c.CloseDate == null && c.PubDate != null).Count() > 0)
                .Count();

            return nbPublishedContracts;
        }

    }
}
