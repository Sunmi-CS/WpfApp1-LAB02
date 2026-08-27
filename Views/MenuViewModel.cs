using System;
using System.Windows.Input;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private object? _vistaActual;
        private readonly AppDataService _service;
        private int _conductoresCount;
        private int _ingresosCount;
        private int _camionesCount;

        public object? VistaActual
        {
            get => _vistaActual;
            set { _vistaActual = value; OnPropertyChanged(); }
        }

        public ICommand MostrarInicioCommand { get; }
        public ICommand MostrarIngresosCommand { get; }
        public ICommand MostrarSalidaOperacionCommand { get; }
        public ICommand MostrarConductoresCommand { get; }
        public ICommand MostrarTransportistasCommand { get; }
        public ICommand MostrarCamionesCommand { get; }
        public ICommand MostrarProductosCommand { get; }
        public ICommand MostrarReporteIngresosCommand { get; }
        public ICommand MostrarReporteCargasCommand { get; }
        public ICommand MostrarReporteSalidasCommand { get; }

        public MenuViewModel(AppDataService? service)
        {
            _service = service ?? new AppDataService();

            // inicializar contadores
            _conductoresCount = _service.Conductores.Count;
            _ingresosCount = _service.Ingresos.Count;
            _camionesCount = _service.Camiones.Count;

            // suscribirse a cambios para actualizar contadores en tiempo real
            _service.Conductores.CollectionChanged += (s, e) => UpdateCounts();
            _service.Ingresos.CollectionChanged += (s, e) => UpdateCounts();
            _service.Camiones.CollectionChanged += (s, e) => UpdateCounts();

            MostrarInicioCommand = new RelayCommand(_ => VistaActual = null);

            MostrarIngresosCommand = new RelayCommand(_ => VistaActual = new IngresoViewModel(_service));

            MostrarSalidaOperacionCommand = new RelayCommand(_ =>
                VistaActual = new WpfApp1.Views.SalidaView { DataContext = new SalidaViewModel(_service) });

            MostrarConductoresCommand = new RelayCommand(_ => VistaActual = new ConductoresViewModel(_service));

            MostrarTransportistasCommand = new RelayCommand(_ =>
                VistaActual = new WpfApp1.Views.TransportistasView { DataContext = new TransportistasViewModel(_service) });

            MostrarCamionesCommand = new RelayCommand(_ =>
                VistaActual = new WpfApp1.Views.CamionesView { DataContext = new CamionesViewModel(_service) });

            MostrarProductosCommand = new RelayCommand(_ =>
                VistaActual = new WpfApp1.Views.ProductosView { DataContext = new ProductosViewModel(_service) });

            MostrarReporteIngresosCommand = new RelayCommand(_ => VistaActual = new ReporteIngresosViewModel(_service));

            MostrarReporteCargasCommand = new RelayCommand(_ =>
                VistaActual = new WpfApp1.Views.ReporteCargasView { DataContext = new ReporteCargasViewModel(_service) });

            MostrarReporteSalidasCommand = new RelayCommand(_ =>
                VistaActual = new WpfApp1.Views.ReporteSalidasView { DataContext = new ReporteSalidasViewModel(_service) });
        }

        public int ConductoresCount
        {
            get => _conductoresCount;
            private set { _conductoresCount = value; OnPropertyChanged(); }
        }

        public int IngresosCount
        {
            get => _ingresosCount;
            private set { _ingresosCount = value; OnPropertyChanged(); }
        }

        public int CamionesCount
        {
            get => _camionesCount;
            private set { _camionesCount = value; OnPropertyChanged(); }
        }

        private void UpdateCounts()
        {
            ConductoresCount = _service.Conductores.Count;
            IngresosCount = _service.Ingresos.Count;
            CamionesCount = _service.Camiones.Count;
        }
    }
}
