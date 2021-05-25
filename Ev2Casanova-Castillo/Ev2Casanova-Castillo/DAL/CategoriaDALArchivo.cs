using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ev2Casanova_Castillo.DAL
{
    public class CategoriaDALArchivo
    {
        private static String archivo = "Categorias.txt";
        private static String ruta = Directory.GetCurrentDirectory() + "/" + archivo;
        public List<Categoria> cargarCategorias()
        {
            
        List<Categoria> listaDeCategorias = new List<Categoria>();
            try
            {
                using (StreamReader reader = new StreamReader(ruta))
                {
                    String filas = "";

                    do
                    {
                        filas = reader.ReadLine();
                        if (filas != null)
                        {
                            String[] textArr = filas.Split(",");
                            int idCategoria  = Convert.ToInt32(textArr[0]);
                            String categoria = textArr[1];
                            int debilidad = Convert.ToInt32(textArr[2]);
                            int resitencia = Convert.ToInt32(textArr[3]);

                            Categoria c = new Categoria()
                            {
                                CategoriaMostruo = categoria,
                                IdCategoria = idCategoria,
                                Debilidad = debilidad,
                                Resistencia = resitencia
                            };
                            listaDeCategorias.Add(c);

                        };




                    } while (filas != null);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer el archivo " + e.Message);
            }



            return listaDeCategorias;
        }

        public Categoria obtenerCategorias(int idCategoria)
        {
            List<Categoria> listaDeCategorias = new List<Categoria>();
            listaDeCategorias = cargarCategorias();
            Categoria c = new Categoria();

            for (int i = 0; i < listaDeCategorias.Count; i++)
            {
                if (listaDeCategorias[i].IdCategoria == idCategoria)
                {
                    c = listaDeCategorias[i];
                    break;
                } 
                
            }
            return c;  
        }
    }
}
