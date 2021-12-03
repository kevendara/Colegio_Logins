using Contexto;
using Entidades;
using Repositorio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion
{
    public class vta_ClaseRepositorio: Repositorio <vta_Clase>, IVistaClaseRepositorio
    {
        public vta_ClaseRepositorio(Vistas contexto)
            : base(contexto)
        {
        }

        public void Inicializar()
        {
            this.Context = new Vistas();
        }
    }
}
