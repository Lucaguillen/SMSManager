using SMSManager.Datos.Repositorios;
using SMSManager.Objetos.Modelos;

namespace SMSManager.Logica.Servicios
{
    /// <summary>
    /// Servicio encargado de gestionar los formatos de mensaje (plantillas).
    /// Permite agregar, actualizar, eliminar y obtener formatos desde la base de datos.
    /// </summary>
    public class FormatoService
    {
        /// <summary>
        /// Repositorio utilizado para acceder y manipular datos de formatos en la base de datos.
        /// </summary>
        private readonly FormatoRepository repo = new FormatoRepository();

        /// <summary>
        /// Guarda un nuevo formato en la base de datos o lo actualiza si ya existe.
        /// </summary>
        public void GuardarFormato(Formato formato)
        {
            if (repo.ExisteNombre(formato.Nombre))
                throw new System.Exception("Ya existe un formato con ese nombre.");

            repo.Insertar(formato);
        }

        /// <summary>
        /// Obtiene todos los formatos de mensaje disponibles desde la base de datos.
        /// </summary>
        public List<Formato> ObtenerTodos() => repo.ObtenerTodos();

        /// <summary>
        /// Elimina un formato de mensaje por su identificador.
        /// </summary>
        public void EliminarFormato(int id) => repo.Eliminar(id);

        /// <summary>
        /// Actualiza un formato existente en la base de datos.
        /// </summary>
        public void ActualizarFormato(Formato formato)
        {
            repo.Actualizar(formato);
        }

    }
}
