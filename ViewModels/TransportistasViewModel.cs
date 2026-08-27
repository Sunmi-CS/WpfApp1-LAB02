using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class TransportistasViewModel : BaseViewModel
    {
        private readonly AppDataService _service;

        private string _nombre = "";
        private string _ruc = "";
        private string _mensaje = "";

        public ObservableCollection<Transportista> Transportistas => _service.Transportistas;

        public string Nombre { get => _nombre; set { _nombre = value; OnPropertyChanged(); } }
        public string RUC { get => _ruc; set { _ruc = value; OnPropertyChanged(); } }
        public string Mensaje { get => _mensaje; set { _mensaje = value; OnPropertyChanged(); } }

        public ICommand GuardarCommand { get; }

        public TransportistasViewModel(AppDataService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            GuardarCommand = new RelayCommand(_ => Guardar());
        }

        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) { Mensaje = "Ingrese el nombre."; return; }

            var t = new Transportista { Nombre = Nombre.Trim(), RUC = RUC?.Trim() ?? "" };
            _service.AddTransportista(t);
            Mensaje = "Transportista registrado.";
            Nombre = ""; RUC = "";
        }
    }
}
