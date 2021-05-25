using System;
using System.Collections.Generic;
using System.Text;

namespace Ev2Casanova_Castillo.DTO
{
    public class Monstruo : Categoria
    {
        private String nombreMostruo;
        private int puntosVida;
        private int puntosAtaque;

        public string NombreMonstruo { get => nombreMostruo; set => nombreMostruo = value; }
        public int PuntosVida { get => puntosVida; set => puntosVida = value; }
        public int PuntosAtaque { get => puntosAtaque; set => puntosAtaque = value; }
    }
}
