using System;

namespace WpfApp1.Models
{
    public class Carga
    {
        public DateTime FechaHora { get; set; }
        public string Placa { get; set; } = "";
        public string Turno { get; set; } = "";
        public string Conductor { get; set; } = "";
        public string Producto { get; set; } = "";
        public decimal Peso { get; set; }
        public string Transporte { get; set; } = "";
    }
}
