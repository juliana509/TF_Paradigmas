using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca
{
    // ==========================================
    // 1. SUPERCLASE ABSTRACTA: Persona
    // ==========================================
    // Explicación: Define los atributos y comportamientos comunes para cualquier individuo
    // que interactúe con el sistema (Socios, Lectores No Socios y Personal de la Biblioteca).
    public abstract class Persona
    {
        public string Dni { get; set; }
        public string NombreApellido { get; set; }
        public string Telefono { get; set; }
        public string DomicilioLocal { get; set; }

        // Método virtual para aplicar polimorfismo en la visualización de datos de cualquier persona.
        public abstract void MostrarDatos();
    }
    // ==========================================
    // 2. SUBCLASE: Socio (Hereda de Persona)
    // ==========================================
    // Explicación: Representa a los socios registrados (alumnos, profesores, externos) 
    // que cumplen con los requisitos de inscripción y pueden retirar materiales.
    public class Socio : Persona
    {
        public bool Activo { get; set; } // Validado para desactivación masiva a fines de febrero
        public string TipoSocio { get; set; } // "Alumno", "Profesor", "Externo"
        public string DatosGarante { get; set; }
        public string RedesSociales { get; set; }

        // Control de elementos en préstamo simultáneo (máximo 3 por regla general)
        public List<MaterialBibliografico> ElementosPrestados { get; set; } = new List<MaterialBibliografico>();

        public override void MostrarDatos()
        {
            Console.WriteLine($"[Socio - {TipoSocio}] DNI: {Dni}, Nombre: {NombreApellido}, Activo: {Activo}");
        }
    }


    // ==========================================
    // 3. SUBCLASE: LectorSalaNoSocio (Hereda de Persona)
    // ==========================================
    // Explicación: Representa a los lectores ocasionales que no son socios. 
    // Pueden pedir elementos, pero estrictamente para uso interno en la sala de estudio.
    public class LectorSalaNoSocio : Persona
    {
        public DateTime FechaRegistroSala { get; set; }

        public LectorSalaNoSocio(string dni, string nombre, string telefono, string domicilio)
        {
            Dni = dni;
            NombreApellido = nombre;
            Telefono = telefono;
            DomicilioLocal = domicilio;
            FechaRegistroSala = DateTime.Now;
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"[Lector en Sala (No Socio)] DNI: {Dni}, Nombre: {NombreApellido}");
        }
    }


    // ==========================================
    // 4. SUBCLASE: PersonalBiblioteca (Hereda de Persona)
    // ==========================================
    // Explicación: Representa al Director y los 8 bibliotecarios autorizados 
    // para operar el sistema en sus turnos rotativos.
    public class PersonalBiblioteca : Persona
    {
        public string Cargo { get; set; } // "Director" o "Bibliotecario"
        public string Turno { get; set; } // "Mañana", "Tarde", "Noche"

        public override void MostrarDatos()
        {
            Console.WriteLine($"[Personal] {Cargo} ({Turno}) - Nombre: {NombreApellido}");
        }
    }
}
