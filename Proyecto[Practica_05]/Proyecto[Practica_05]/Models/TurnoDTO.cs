using Proyecto_Practica_05_.Interfaces;
using System.Text.Json.Serialization;

namespace Proyecto_Practica_05_.Models
{
    public class TurnoDTO : IDataTransferObject
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Cliente { get; set; }
        public TurnoDTO()
        {
            Fecha = DateTime.Now.AddDays(1);
        }

        public bool Validate()
        {
            if (DateTime.Now > Fecha || Fecha > DateTime.Now.AddDays(45) 
                || Cliente == string.Empty) { return false; }
            return true;
        }
        public override string ToString()
        {
            return $"Turno [{Id}]: Fecha: {Fecha.Day}/{Fecha.Month}, Hora: {Fecha.Hour} - Para: {Cliente}";
        }
    }
}
