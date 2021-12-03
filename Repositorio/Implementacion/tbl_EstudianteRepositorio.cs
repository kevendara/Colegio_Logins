using Contexto;
using Entidades;
using Repositorio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion
{
    public class tbl_EstudianteRepositorio:Repositorio<tbl_Estudiante>, IEstudianteRepositorio
    {

        public tbl_EstudianteRepositorio(ContextoUniversidad contexto)
            : base(contexto)
        {
        }

        public void Inicializar()
        {
            this.Context = new ContextoUniversidad();
        }
    }
}
