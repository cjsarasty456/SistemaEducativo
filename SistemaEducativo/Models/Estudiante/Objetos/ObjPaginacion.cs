using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEducativo.Models.Estudiante.Objetos
{
    public class ObjPaginacion
    {
        public int PaginaActual { get; set; }
        public int TotalRegistros { get; set; }
        public int RegistrosPagina { get; set; }

        public ObjPaginacion()
        {
            RegistrosPagina = 10;
        }
    }
}