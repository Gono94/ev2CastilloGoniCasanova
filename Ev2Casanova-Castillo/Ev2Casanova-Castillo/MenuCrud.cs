using Ev2Casanova_Castillo.DAL;
using Ev2Casanova_Castillo.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ev2Casanova_Castillo
{
    public class MenuCrud
    {
        public void imprimirMenuCrud()
        {   
            MonstruoDALArchivo monstruoDAL = new MonstruoDALArchivo();
            Console.WriteLine("Bienvenido al Crud de cartas, seleccione una opcion....");
            Console.WriteLine("1.-Añadir Carta");
            Console.WriteLine("2.-Listar Cartas");
            Console.WriteLine("3.-Editar Cartas");
            Console.WriteLine("4.-Eliminar Cartas");
            Console.WriteLine("5.-VOLVER A MENU PRINCIPAL");

            int opcion = Convert.ToInt32(Console.ReadLine());

           if (opcion >= 1 && opcion <= 5)
            {
                switch (opcion)
                {
                    case 1:


                        switchAgregar();
                        Thread.Sleep(1000);// PAUSA


                        Console.WriteLine("Desea seguir agregando Monstruo? - [1] para sí, [2] para no.");
                        int op = Convert.ToInt32(Console.ReadLine());


                        /***
                                                switch (op)
                                                {
                                                    case 1:
                                                        switchAgregar();
                                                        break;
                                                    case 2:
                                                        imprimirMenuCrud();
                                                        break;
                                                    default:
                                                        Console.WriteLine("ERROR, DEBE SELECCIONAR UNA OPCION DE  1 AL 2  ");
                                                        Thread.Sleep(3000);// PAUSA
                                                        Console.Clear();
                                                        imprimirMenuCrud();
                                                        break;
                                                }

                                                */

                        break;

                    case 2:
                        Console.WriteLine("Ahora vamos a mostrar las cartas ");
                        monstruoDAL.listarMonstruos(monstruoDAL.cargarMonstruos());

                        break;

                    case 3:
                        Console.WriteLine("Vamos editar las cartas");
                        monstruoDAL.listarMonstruos(monstruoDAL.cargarMonstruos());
                        Console.WriteLine("Seleccione id de la carta");
                        int id = Convert.ToInt32(Console.ReadLine());
                        monstruoDAL.editarMonstruo(id - 1, monstruoDAL.cargarMonstruos());




                        break;

                    case 4:

                        //Llamo al metodo eliminar pasandole la lista
                        monstruoDAL.eliminarMonstruo(monstruoDAL.cargarMonstruos());
                        break;
                    case 5:
                        Console.Clear();
                        imprimirMenuPrincipal();
                        break;

                    default:
                        // code block
                        break;
                }

            } else
            {

                Console.WriteLine("ERROR, DEBE SELECCIONAR UNA OPCION DE  1 AL 5  ");
                Thread.Sleep(3000);// PAUSA
                Console.Clear();
                imprimirMenuCrud();


            }




        }









        public void imprimirMenuPrincipal()
        {
            Console.WriteLine("Bienvenido a Sumagi");
            Console.WriteLine("1.-Jugar");
            Console.WriteLine("2.-Crud cartas");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion >= 1 && opcion <= 2)
            {
                switch (opcion)
                {
                    case 1:
                        LogicaJuego juego = new LogicaJuego();
                 

                        juego.lanzarCartas();



                        juego.atacar();
                        
                        
                        
                        break;
                    case 2:
                        Console.Clear();
                        MenuCrud menu = new MenuCrud();
                        menu.imprimirMenuCrud();
                        break;

                }
            }
            else
            {
                Console.WriteLine("ERROR, DEBE SELECCIONAR UNA OPCION DE  1 AL 2  ");
                Thread.Sleep(3000);// PAUSA
                Console.Clear();
                imprimirMenuPrincipal();
            }


          
        }

        public void switchAgregar()
        {
            MonstruoDALArchivo monstruoDAL = new MonstruoDALArchivo();

            Console.WriteLine("Vamos a crear una nueva Carta");
            Console.WriteLine("Ingrese nombre Monstruo");
            String nombreMonstruo = Console.ReadLine();
            Console.WriteLine("Ingrese Categoria");
            int idCategoria = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese puntos Vida");
            int puntosVida = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese puntos ataque");
            int puntosAtaque = Convert.ToInt32(Console.ReadLine());
            Monstruo m = new Monstruo()
            {
                NombreMonstruo = nombreMonstruo,
                IdCategoria = idCategoria,
                PuntosVida = puntosVida,
                PuntosAtaque = puntosAtaque
            };

            monstruoDAL.agregarMonstruo(m);


            

        }













    }
}
