using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca
{
    // ==========================================
    // 5. CLASE DE OPERACIÓN: Prestamo
    // ==========================================
    // Explicación: Gestiona la relación de asociación entre una persona, un material, 
    // el bibliotecario responsable y el turno en el que se ejecuta.
    public class Prestamo
    {
        public Persona Solicitante { get; set; } // Puede ser Socio o LectorSalaNoSocio
        public MaterialBibliografico Material { get; set; }
        public PersonalBiblioteca BibliotecarioResponsable { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; } // Plazo de 24 horas
        public string Turno { get; set; }
        public string Destino { get; set; } // "Domicilio" o "Sala"
        public bool Renovado { get; set; }

        public Prestamo(Persona solicitante, MaterialBibliografico material, PersonalBiblioteca bibliotecario, string turno, string destino)
        {
            Solicitante = solicitante;
            Material = material;
            BibliotecarioResponsable = bibliotecario;
            FechaPrestamo = DateTime.Now;
            FechaDevolucion = FechaPrestamo.AddHours(24); // Regla de 24 horas
            Turno = turno;
            Destino = destino;
            Renovado = false;
        }
    }
}
