using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSManager.UI
{
    /// <summary>
    /// Clase base para todos los formularios principales del sistema.
    /// Define un punto de extensión común para recargar contenido dinámico.
    /// </summary>
    public class FormPrincipal : BaseForm
    {
        /// <summary>
        /// Método virtual que puede ser sobrescrito por formularios principales
        /// para recargar o preparar su contenido.
        /// </summary>
        public virtual void CargarContenido() { }
    }
}
