using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class ReporteSalidasViewModel : BaseViewModel
    {
        private readonly AppDataService _service;

        private DateTime? _fechaInicio;
        private DateTime? _fechaFin;
        private string _placa = "";
        private string _conductor = "";
        private string _producto = "";

        public ObservableCollection<Salida> Resultados { get; } = new ObservableCollection<Salida>();

        public DateTime? FechaInicio { get => _fechaInicio; set { _fechaInicio = value; OnPropertyChanged(); } }
        public DateTime? FechaFin { get => _fechaFin; set { _fechaFin = value; OnPropertyChanged(); } }
        public string Placa { get => _placa; set { _placa = value; OnPropertyChanged(); } }
        public string Conductor { get => _conductor; set { _conductor = value; OnPropertyChanged(); } }
        public string Producto { get => _producto; set { _producto = value; OnPropertyChanged(); } }

        public ICommand BuscarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public ReporteSalidasViewModel(AppDataService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            BuscarCommand = new RelayCommand(_ => Buscar());
            LimpiarCommand = new RelayCommand(_ => Limpiar());
            Refrescar(_service.Salidas);
        }

        private void Refrescar(System.Collections.Generic.IEnumerable<Salida> items)
        {
            Resultados.Clear();
            foreach (var i in items.OrderByDescending(x => x.FechaHora)) Resultados.Add(i);
        }

        private void Buscar()
        {
            var q = _service.FilterSalidas(FechaInicio, FechaFin, Placa, Conductor, Producto);
            Refrescar(q);
        }

        private void Limpiar()
        {
            FechaInicio = null; FechaFin = null; Placa = ""; Conductor = ""; Producto = "";
            Refrescar(_service.Salidas);
        }
    }
}
