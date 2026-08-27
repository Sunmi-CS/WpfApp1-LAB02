using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class ProductosViewModel : BaseViewModel
    {
        private readonly AppDataService _service;

        private string _nombre = "";
        private string _codigo = "";
        private string _mensaje = "";

        public ObservableCollection<Producto> Productos => _service.Productos;

        public string Nombre { get => _nombre; set { _nombre = value; OnPropertyChanged(); } }
        public string Codigo { get => _codigo; set { _codigo = value; OnPropertyChanged(); } }
        public string Mensaje { get => _mensaje; set { _mensaje = value; OnPropertyChanged(); } }

        public ICommand GuardarCommand { get; }

        public ProductosViewModel(AppDataService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            GuardarCommand = new RelayCommand(_ => Guardar());
        }

        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) { Mensaje = "Ingrese el nombre del producto."; return; }

            var p = new Producto { Nombre = Nombre.Trim(), Codigo = Codigo?.Trim() ?? "" };
            _service.AddProducto(p);
            Mensaje = "Producto registrado.";
            Nombre = ""; Codigo = "";
        }
    }
}
