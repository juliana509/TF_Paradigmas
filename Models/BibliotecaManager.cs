namespace SistemaBiblioteca.Models
{
    // ==========================================
    // 7. CLASE CONTROLADORA: BibliotecaManager (Patrón Singleton)
    // ==========================================
    // Explicación: Garantiza una única instancia centralizada en la memoria RAM del servidor,
    // actuando como gestor central de listas (sin base de datos relacional).
    public sealed class BibliotecaManager
    {
        private static BibliotecaManager _instancia = null;
        private static readonly object _lock = new object();

        // Listas centralizadas en memoria
        public List<MaterialBibliografico> Inventario { get; set; }
        public List<Persona> Personas { get; set; }
        public List<Prestamo> PrestamosActivos { get; set; }
        public List<AsistenciaSala> Asistencias { get; set; }

        // CAMBIO CLAVE: El constructor pasa a ser público (o se maneja de forma segura) 
        // para que el contenedor de ASP.NET Core pueda instanciarlo la primera vez, 
        // manteniendo la filosofía del Singleton mediante el método de acceso único.
        public BibliotecaManager()
        {
            Inventario = new List<MaterialBibliografico>();
            Personas = new List<Persona>();
            PrestamosActivos = new List<Prestamo>();
            Asistencias = new List<AsistenciaSala>();
        }

        // Método estático para asegurar la instancia única si se llama de forma manual
        public static BibliotecaManager ObtenerInstancia()
        {
            lock (_lock)
            {
                if (_instancia == null)
                {
                    _instancia = new BibliotecaManager();
                }
            }
            return _instancia;
        }

        // ... (tus métodos de negocio como RegistrarPrestamo continúan aquí abajo)
    }
}
