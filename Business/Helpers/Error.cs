using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class Error
    {
        /// <summary>
        /// Método para retornar objetos de error
        /// </summary>
        /// <param name="title">Nombre del servicio o titulo del objeto</param>
        /// <returns>Retorna objeto General con estructura de error 505</returns>
        public static General ResponseCatchError(string title)
        {
            return new General
            {
                title = title,
                idError = -999,
                error = true,
                message = "Internal Error Server"
            };
        }
    }
}
