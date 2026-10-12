using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca
{
    public class AsistenciaSala
    {
        public Persona Asistente { get; set; }
        public DateTime FechaHora { get; set; }
        public string Turno { get; set; }

        public AsistenciaSala(Persona asistente, string turno)
        {
            Asistente = asistente;
            FechaHora = DateTime.Now;
            Turno = turno;
        }
    }
}
