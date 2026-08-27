using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class AppDataService
    {
        public ObservableCollection<Conductor> Conductores { get; } = new ObservableCollection<Conductor>();

        public ObservableCollection<Ingreso> Ingresos { get; } = new ObservableCollection<Ingreso>();
        public ObservableCollection<Transportista> Transportistas { get; } = new ObservableCollection<Transportista>();
        public ObservableCollection<Camion> Camiones { get; } = new ObservableCollection<Camion>();
        public ObservableCollection<Producto> Productos { get; } = new ObservableCollection<Producto>();
        public ObservableCollection<Carga> Cargas { get; } = new ObservableCollection<Carga>();
        public ObservableCollection<Salida> Salidas { get; } = new ObservableCollection<Salida>();

        public AppDataService()
        {
            // Datos de ejemplo para desarrollo
            Conductores.Add(new Conductor { Nombre = "Juan Perez", Licencia = "A12345", Transporte = "Transporte 1" });
            Conductores.Add(new Conductor { Nombre = "María Gómez", Licencia = "B67890", Transporte = "Transporte 2" });

            // Ejemplos básicos
            Transportistas.Add(new Transportista { Nombre = "Transporte 1", RUC = "201000111" });
            Transportistas.Add(new Transportista { Nombre = "Transporte 2", RUC = "201000222" });

            Camiones.Add(new Camion { Placa = "ABC-123", Modelo = "Volvo F12", Transportista = "Transporte 1" });
            Camiones.Add(new Camion { Placa = "DEF-456", Modelo = "Scania R", Transportista = "Transporte 2" });

            Productos.Add(new Producto { Nombre = "Maíz", Codigo = "P-001" });
            Productos.Add(new Producto { Nombre = "Trigo", Codigo = "P-002" });
        }

        public void AddConductor(Conductor c)
        {
            if (c == null) return;
            Conductores.Add(c);
        }

        public void AddIngreso(Ingreso i)
        {
            if (i == null) return;
            Ingresos.Add(i);
        }

        public void AddTransportista(Transportista t)
        {
            if (t == null) return;
            Transportistas.Add(t);
        }

        public void AddCamion(Camion c)
        {
            if (c == null) return;
            Camiones.Add(c);
        }

        public void AddProducto(Producto p)
        {
            if (p == null) return;
            Productos.Add(p);
        }

        public void AddCarga(Carga c)
        {
            if (c == null) return;
            Cargas.Add(c);
        }

        public void AddSalida(Salida s)
        {
            if (s == null) return;
            Salidas.Add(s);
        }

        public IEnumerable<Ingreso> FilterIngresos(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string placa,
            string conductor,
            string producto)
        {
            IEnumerable<Ingreso> query = Ingresos;

            if (fechaInicio.HasValue)
                query = query.Where(x => x.FechaHora.Date >= fechaInicio.Value.Date);

            if (fechaFin.HasValue)
                query = query.Where(x => x.FechaHora.Date <= fechaFin.Value.Date);

            if (!string.IsNullOrWhiteSpace(placa))
                query = query.Where(x => x.Placa?.IndexOf(placa, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(conductor))
                query = query.Where(x => x.Conductor?.IndexOf(conductor, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(producto))
                query = query.Where(x => x.Producto?.IndexOf(producto, StringComparison.OrdinalIgnoreCase) >= 0);

            return query;
        }

        public IEnumerable<Carga> FilterCargas(DateTime? fechaInicio, DateTime? fechaFin, string placa, string conductor, string producto)
        {
            IEnumerable<Carga> query = Cargas;

            if (fechaInicio.HasValue)
                query = query.Where(x => x.FechaHora.Date >= fechaInicio.Value.Date);

            if (fechaFin.HasValue)
                query = query.Where(x => x.FechaHora.Date <= fechaFin.Value.Date);

            if (!string.IsNullOrWhiteSpace(placa))
                query = query.Where(x => x.Placa?.IndexOf(placa, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(conductor))
                query = query.Where(x => x.Conductor?.IndexOf(conductor, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(producto))
                query = query.Where(x => x.Producto?.IndexOf(producto, StringComparison.OrdinalIgnoreCase) >= 0);

            return query;
        }

        public IEnumerable<Salida> FilterSalidas(DateTime? fechaInicio, DateTime? fechaFin, string placa, string conductor, string producto)
        {
            IEnumerable<Salida> query = Salidas;

            if (fechaInicio.HasValue)
                query = query.Where(x => x.FechaHora.Date >= fechaInicio.Value.Date);

            if (fechaFin.HasValue)
                query = query.Where(x => x.FechaHora.Date <= fechaFin.Value.Date);

            if (!string.IsNullOrWhiteSpace(placa))
                query = query.Where(x => x.Placa?.IndexOf(placa, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(conductor))
                query = query.Where(x => x.Conductor?.IndexOf(conductor, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(producto))
                query = query.Where(x => x.Producto?.IndexOf(producto, StringComparison.OrdinalIgnoreCase) >= 0);

            return query;
        }
    }
}
