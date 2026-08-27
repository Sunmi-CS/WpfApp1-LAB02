using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class ConductoresViewModel : BaseViewModel
    {
        private readonly AppDataService _service;

        private string _nombre = "";
        private string _licencia = "";
        private string _transporte = "";
        private string _mensaje = "";

        public ObservableCollection<Conductor> Conductores => _service.Conductores;

        public string Nombre
        {
            get => _nombre;
            set { _nombre = value; OnPropertyChanged(); }
        }

        public string Licencia
        {
            get => _licencia;
            set { _licencia = value; OnPropertyChanged(); }
        }

        public string Transporte
        {
            get => _transporte;
            set { _transporte = value; OnPropertyChanged(); }
        }

        public string Mensaje
        {
            get => _mensaje;
            set { _mensaje = value; OnPropertyChanged(); }
        }

        public ICommand GuardarConductorCommand { get; }

        public ConductoresViewModel(AppDataService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            GuardarConductorCommand = new RelayCommand(_ => Guardar());
        }

        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                Mensaje = "Ingrese el nombre del conductor.";
                return;
            }

            var c = new Conductor { Nombre = Nombre.Trim(), Licencia = Licencia?.Trim() ?? "", Transporte = Transporte?.Trim() ?? "" };

            _service.AddConductor(c);

            Mensaje = "Conductor registrado.";

            Nombre = "";
            Licencia = "";
            Transporte = "";
        }
    }
}
