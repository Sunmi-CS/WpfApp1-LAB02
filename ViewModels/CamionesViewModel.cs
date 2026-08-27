using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class CamionesViewModel : BaseViewModel
    {
        private readonly AppDataService _service;

        private string _placa = "";
        private string _modelo = "";
        private string _transportista = "";
        private string _mensaje = "";

        public ObservableCollection<Camion> Camiones => _service.Camiones;

        public string Placa { get => _placa; set { _placa = value; OnPropertyChanged(); } }
        public string Modelo { get => _modelo; set { _modelo = value; OnPropertyChanged(); } }
        public string Transportista { get => _transportista; set { _transportista = value; OnPropertyChanged(); } }
        public string Mensaje { get => _mensaje; set { _mensaje = value; OnPropertyChanged(); } }

        public ICommand GuardarCommand { get; }

        public CamionesViewModel(AppDataService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            GuardarCommand = new RelayCommand(_ => Guardar());
        }

        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(Placa)) { Mensaje = "Ingrese la placa."; return; }

            var c = new Camion { Placa = Placa.Trim(), Modelo = Modelo?.Trim() ?? "", Transportista = Transportista?.Trim() ?? "" };
            _service.AddCamion(c);
            Mensaje = "Camión registrado.";
            Placa = ""; Modelo = ""; Transportista = "";
        }
    }
}
