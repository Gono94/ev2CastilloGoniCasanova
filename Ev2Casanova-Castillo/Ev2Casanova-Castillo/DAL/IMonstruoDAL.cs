using Ev2Casanova_Castillo.DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace Ev2Casanova_Castillo.DAL
{
    public interface IMonstruoDAL
    {
        void agregarMonstruo(Monstruo m);
       
        List<Monstruo> editarMonstruo(int id);
        List<Monstruo> listarMonstruos(List<Monstruo> listaDeMonstruo);
    }
}
