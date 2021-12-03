using Core;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz
{
    public interface IMateriaRepositorio: IRepositorio <tbl_Materia>
    {
        void Inicializar();
    }
}
