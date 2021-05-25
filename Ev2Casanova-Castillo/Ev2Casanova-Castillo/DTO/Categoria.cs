using System;
using System.Collections.Generic;
using System.Text;

namespace Ev2Casanova_Castillo
{
    public class Categoria
    {
        private int idCategoria;
        private String categoriaMostruo;
        private int debilidad;
        private int resistencia;

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string CategoriaMostruo { get => categoriaMostruo; set => categoriaMostruo = value; }
        public int Debilidad { get => debilidad; set => debilidad = value; }
        public int Resistencia { get => resistencia; set => resistencia = value; }
    }
}
