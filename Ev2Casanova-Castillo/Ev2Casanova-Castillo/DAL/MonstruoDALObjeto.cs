using Ev2Casanova_Castillo.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ev2Casanova_Castillo.DAL
{
    public class MonstruoDALObjeto
    {
        private static List<Monstruo> arrMonstruos = new List<Monstruo>();

        public void agregarMonstruo(Monstruo m)
        {
            arrMonstruos.Add(m);
        }

        public List<Monstruo> listarMonstruos()
        {
            return arrMonstruos;
        }

        public List<Monstruo> editarMonstruo(String nombreMonstruo)
        {
            return arrMonstruos.FindAll(m => m.NombreMonstruo.Equals(nombreMonstruo));
        }

        public List<Monstruo> listarMonstruos(List<Monstruo> listaDeMonstruo)
        {
            throw new NotImplementedException();
        }

        //EliminarMonstruo

        //ResumenBatalla

    }
}
