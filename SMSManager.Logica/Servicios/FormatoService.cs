using SMSManager.Datos.Repositorios;
using SMSManager.Objetos.Modelos;

namespace SMSManager.Logica.Servicios
{
    public class FormatoService
    {
        private readonly FormatoRepository repo = new FormatoRepository();

        public void GuardarFormato(Formato formato)
        {
            if (repo.ExisteNombre(formato.Nombre))
                throw new System.Exception("Ya existe un formato con ese nombre.");

            repo.Insertar(formato);
        }
        public List<Formato> ObtenerTodos() => repo.ObtenerTodos();

        public void EliminarFormato(int id) => repo.Eliminar(id);
        public void ActualizarFormato(Formato formato)
        {
            repo.Actualizar(formato);
        }

    }
}
