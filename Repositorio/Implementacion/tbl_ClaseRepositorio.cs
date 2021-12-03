using Contexto;
using Entidades;
using Repositorio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion
{
    public class tbl_ClaseRepositorio: Repositorio <tbl_Clase>, IClaseRepositorio
    {
        public tbl_ClaseRepositorio(ContextoUniversidad contexto)
            : base(contexto)
        {
        }

        public void Inicializar()
        {
            this.Context = new ContextoUniversidad();
        }
    }
}
