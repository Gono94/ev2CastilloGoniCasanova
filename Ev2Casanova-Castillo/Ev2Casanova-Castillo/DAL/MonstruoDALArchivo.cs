using Ev2Casanova_Castillo.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ev2Casanova_Castillo.DAL
{
    public class MonstruoDALArchivo
    {
        private static String archivo = "Monstruo.txt";
        private static String ruta = Directory.GetCurrentDirectory()+"/"+archivo;
        public void agregarMonstruo(Monstruo m)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    String texto = m.NombreMonstruo + "," +
                                   m.IdCategoria + "," +
                                   m.PuntosVida + "," +
                                   m.PuntosAtaque+",";

                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error al escribir el archivo " + e.Message);
            }
        }

        public List<Monstruo> editarMonstruo(int id, List<Monstruo> listaDeMonstruo)
        {

            Console.WriteLine("-----------------");
            Console.WriteLine($"1.-Nombre: {listaDeMonstruo[id].NombreMonstruo}\n" +
                              $"2.-IdCategoria: {listaDeMonstruo[id].IdCategoria}\n" +
                              $"3.-Puntos de vida: {listaDeMonstruo[id].PuntosVida}\n" +
                              $"4.-Puntos de Ataque: {listaDeMonstruo[id].PuntosAtaque}\n");
            Console.WriteLine("-----------------");
            Console.WriteLine("Ingrese que desea modificar");
            int modificar = Convert.ToInt32(Console.ReadLine());

            switch (modificar)
            {
                case 1:
                    Console.WriteLine($"Nombre Actual :{listaDeMonstruo[id].NombreMonstruo}");
                    Console.WriteLine("Ingrese nuevo nombre.....");
                    String nuevoNombre = Console.ReadLine();
                    listaDeMonstruo[id].NombreMonstruo = nuevoNombre;

                    break;

                case 2:
                    Console.WriteLine($"IdCategoria Actual :{listaDeMonstruo[id].IdCategoria}");
                    Console.WriteLine("Ingrese nueva categoria....");
                    int nuevaCategoria = Convert.ToInt32(Console.ReadLine());
                    listaDeMonstruo[id].IdCategoria = nuevaCategoria;

                    break;
                case 3:
                    Console.WriteLine($"Puntos de vida actual:{listaDeMonstruo[id].PuntosVida}");
                    Console.WriteLine("Ingrese nuevos puntos de vida...");
                    int nuevaVida = Convert.ToInt32(Console.ReadLine());
                    listaDeMonstruo[id].PuntosVida = nuevaVida;

                    break;
                case 4:
                    Console.WriteLine($"Puntos de Ataque actual:{listaDeMonstruo[id].PuntosAtaque}");
                    Console.WriteLine("Ingrese nuevos puntos de ataque...");
                    int nuevoAtaque = Convert.ToInt32(Console.ReadLine());
                    listaDeMonstruo[id].PuntosAtaque = nuevoAtaque;
                    break;

            };

            Console.WriteLine("--------Carta Editada---------");
            Console.WriteLine($"1.-Nombre: {listaDeMonstruo[id].NombreMonstruo}\n" +
                              $"2.-IdCategoria: {listaDeMonstruo[id].IdCategoria}\n" +
                              $"3.-Puntos de vida: {listaDeMonstruo[id].PuntosVida}\n" +
                              $"4.-Puntos de Ataque: {listaDeMonstruo[id].PuntosAtaque}\n");
            Console.WriteLine("------------------------------");


            Boolean iteracion = false;
            for (int i = 0; i < listaDeMonstruo.Count; i++)
            {

                try
                {
                    using (StreamWriter writer = new StreamWriter(ruta, iteracion))
                    {
                        String texto = listaDeMonstruo[i].NombreMonstruo + "," +
                                       listaDeMonstruo[i].IdCategoria + "," +
                                       listaDeMonstruo[i].PuntosVida + "," +
                                       listaDeMonstruo[i].PuntosAtaque + ",";

                        writer.WriteLine(texto);
                        writer.Flush();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al escribir el archivo " + e.Message);
                }

                iteracion = true;

            }

            Console.WriteLine("Se guardo el archivo de texto nuevo");


            return listaDeMonstruo;
        }

        public List<Monstruo> cargarMonstruos()
        {
            List<Monstruo> listaDeMonstruos = new List<Monstruo>();
            try
            {
                using (StreamReader reader = new StreamReader(ruta))
                {
                    String filas="";

                    do
                    {
                        filas = reader.ReadLine();
                        if(filas != null)
                        {
                            String[] textArr = filas.Split(",");
                            string nombreMonstruo = textArr[0];
                            int idCategoria = Convert.ToInt32(textArr[1]);
                            int puntosVida = Convert.ToInt32(textArr[2]);
                            int puntosAtaque = Convert.ToInt32(textArr[3]);

                            Monstruo m = new Monstruo()
                            {
                                NombreMonstruo = nombreMonstruo,
                                IdCategoria = idCategoria,
                                PuntosVida = puntosVida,
                                PuntosAtaque = puntosAtaque
                            };
                            listaDeMonstruos.Add(m);
                            
                        };

                        


                    } while (filas != null);
                }



            }
            catch(Exception e)
            {
                Console.WriteLine("Error al leer el archivo " + e.Message);
            }



            return listaDeMonstruos;
        }

        public  List<Monstruo> eliminarMonstruo(List<Monstruo> listaDeMonstruo)
        {


            listarMonstruos(cargarMonstruos());

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Que Monstruo desea eliminar? Ingrese ID:....");
            int id = Convert.ToInt32(Console.ReadLine());
            listaDeMonstruo.RemoveAt(id-1);
            Console.WriteLine("La Carta se elimino correctamente");
            //esto esta por ahora.....
            Boolean iteracion = false;
            for (int i=0; i< listaDeMonstruo.Count; i++)
            {

                try
                {
                    using (StreamWriter writer = new StreamWriter(ruta, iteracion))
                    {
                        String texto = listaDeMonstruo[i].NombreMonstruo + "," +
                                       listaDeMonstruo[i].IdCategoria + "," +
                                       listaDeMonstruo[i].PuntosVida + "," +
                                       listaDeMonstruo[i].PuntosAtaque + ",";

                        writer.WriteLine(texto);
                        writer.Flush();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al escribir el archivo " + e.Message);
                }

                iteracion = true;

            }
            



            






            return listaDeMonstruo;

        }

        public List<Monstruo> listarMonstruos(List<Monstruo> listaDeMonstruo)
        {
            for (int i = 0; i < listaDeMonstruo.Count; i++)
            {

                Console.WriteLine($"" +
                        $"------------------\n" +
                        $"ID: {i + 1}\n" +
                        $"Nombre: {listaDeMonstruo[i].NombreMonstruo}\n" +
                        $"Categoria:{listaDeMonstruo[i].IdCategoria}\n" +
                        $"PuntosVida:{listaDeMonstruo[i].PuntosVida}\n" +
                        $"PuntosAtaque:{listaDeMonstruo[i].PuntosAtaque}");
                Console.WriteLine("------------------");

            }

            return listaDeMonstruo;

            
        }

       
    }
}
