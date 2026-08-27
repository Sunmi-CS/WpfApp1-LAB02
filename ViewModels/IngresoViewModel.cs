using System;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class IngresoViewModel : BaseViewModel
    {
        private readonly AppDataService _service;

        private string _tipoDocumento = "";
        private string _numeroDocumento = "";
        private string _placa = "";
        private string _turno = "";
        private string _conductor = "";
        private string _cliente = "";
        private string _pesoText = "";
        private string _mensaje = "";

        public string TipoDocumento
        {
            get => _tipoDocumento;
            set { _tipoDocumento = value; OnPropertyChanged(); }
        }

        public string NumeroDocumento
        {
            get => _numeroDocumento;
            set { _numeroDocumento = value; OnPropertyChanged(); }
        }

        public string Placa
        {
            get => _placa;
            set { _placa = value; OnPropertyChanged(); }
        }

        public string Turno
        {
            get => _turno;
            set { _turno = value; OnPropertyChanged(); }
        }

        public string Conductor
        {
            get => _conductor;
            set { _conductor = value; OnPropertyChanged(); }
        }

        public string Cliente
        {
            get => _cliente;
            set { _cliente = value; OnPropertyChanged(); }
        }

        public string PesoText
        {
            get => _pesoText;
            set { _pesoText = value; OnPropertyChanged(); }
        }

        public DateTime FechaHora { get; set; } = DateTime.Now;

        public string Mensaje
        {
            get => _mensaje;
            set { _mensaje = value; OnPropertyChanged(); }
        }

        public ICommand GuardarCommand { get; }

        public IngresoViewModel(AppDataService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            GuardarCommand = new RelayCommand(_ => Guardar());
        }

        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(NumeroDocumento) ||
                string.IsNullOrWhiteSpace(Placa) ||
                string.IsNullOrWhiteSpace(Conductor))
            {
                Mensaje = "Complete los campos obligatorios.";
                return;
            }

            if (!decimal.TryParse(PesoText, out decimal peso) || peso <= 0)
            {
                Mensaje = "Ingrese un peso válido mayor que 0.";
                return;
            }

            var ingreso = new Ingreso
            {
                TipoDocumento = TipoDocumento,
                NumeroDocumento = NumeroDocumento,
                Placa = Placa,
                Turno = Turno,
                Conductor = Conductor,
                Cliente = Cliente,
                FechaHora = FechaHora,
                Peso = peso
            };

            _service.AddIngreso(ingreso);

            Mensaje = "Ingreso registrado correctamente.";

            NumeroDocumento = "";
            Placa = "";
            Conductor = "";
            Cliente = "";
            PesoText = "";
            FechaHora = DateTime.Now;
        }
    }
}
