using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca
{
    public abstract class MaterialBibliografico
    {
        public int NumeroInventario { get; set; }
        public string Titulo { get; set; }
        public bool Disponible { get; set; }
        public string ClasificacionCDU { get; set; }

        // Método virtual o abstracto para aplicar polimorfismo
        public abstract bool EsPrestableADomicilio();
    }

    public class Libro : MaterialBibliografico
    {
        public string Editorial { get; set; }
        public bool EsEjemplarUnico { get; set; }

        // REDEFINICIÓN (Override): Implementamos el método abstracto aplicando el polimorfismo 
        // y cumpliendo con la regla de negocio: si es el único ejemplar, se bloquea el préstamo a domicilio.
        public override bool EsPrestableADomicilio()
        {
            // Retorna 'false' si es ejemplar único (prioriza consulta en sala), 'true' en caso contrario.
            return !EsEjemplarUnico;
        }
    }
    public class Tesis : MaterialBibliografico
    {
        public string Autor { get; set; }
        public string Carrera { get; set; }

        // REDEFINICIÓN (Override): Aplicando las restricciones estrictas del sistema, 
        // las tesis por norma no pueden salir de la institución bajo ninguna circunstancia.
        public override bool EsPrestableADomicilio()
        {
            // POLIMORFISMO EN ACCIÓN: A diferencia del libro, la tesis siempre retorna 'false' 
            // porque están restringidas exclusivamente a lectura en sala.
            return false;
        }
    }
}
