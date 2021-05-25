using Ev2Casanova_Castillo.DAL;
using Ev2Casanova_Castillo.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ev2Casanova_Castillo
{
    public class LogicaJuego
    {
        MonstruoDALArchivo monstruoDAL = new MonstruoDALArchivo();
        CategoriaDALArchivo categoriaDAL = new CategoriaDALArchivo();
        List<Monstruo> listaMazoA = new List<Monstruo>();
        List<Monstruo> listaMazoB = new List<Monstruo>();
        public void lanzarCartas()
        {
            List<Monstruo> listaMazo = new List<Monstruo>();
            listaMazo = monstruoDAL.cargarMonstruos();

            Random rnd = new Random();

            for (int i = 0; i<2; i++)
            {
                int posicionAzar = rnd.Next(0, listaMazo.Count);
                listaMazoA.Add(listaMazo[posicionAzar]);
                listaMazo.RemoveAt(posicionAzar);
            }

            for (int i = 0; i <2; i++)
            {
                int posicionAzar = rnd.Next(0, listaMazo.Count);
                listaMazoB.Add(listaMazo[posicionAzar]);
                listaMazo.RemoveAt(posicionAzar);
            }

        }

        public void matchJuego ()
        {
            Console.WriteLine("!Es hora de de de de deeeel DUELOOO¡");
            
       
        }

        public void atacar()
        {
            //TURNO USUARIO
            do
            {



                //match de categoria 


                Console.WriteLine("Cartas de JUGADOR A...");
                Thread.Sleep(2000);// PAUSA
                monstruoDAL.listarMonstruos(listaMazoA);

                //SE DEBE ELIMINAR (!)
                Console.WriteLine("Cartas de MAQUINA...");
                Thread.Sleep(2000);// PAUSA
                monstruoDAL.listarMonstruos(listaMazoB);

                //eleccion de carta para declarar ataque
                Console.WriteLine($"\nJugador, ingrese el número de carta con que desea declarar ATACANTE (1 al {listaMazoA.Count})");
                int cartaA = Convert.ToInt32(Console.ReadLine());
                int cartaSeleccionadaA = cartaA - 1;

                Thread.Sleep(1000);// PAUSA
                Console.WriteLine("*********************************************************");
                // Mostrar monstruo que ataca
                Console.WriteLine("--------Monstruo de JUGADOR A declarado ATACANTE---------");
                Console.WriteLine($"1.-Nombre: {listaMazoA[cartaSeleccionadaA].NombreMonstruo}\n" +
                                  $"2.-IdCategoria: {listaMazoA[cartaSeleccionadaA].IdCategoria}\n" +
                                  $"3.-Puntos de Vida: {listaMazoA[cartaSeleccionadaA].PuntosVida}\n" +
                                  $"4.-Puntos de Ataque: {listaMazoA[cartaSeleccionadaA].PuntosAtaque}");
                Console.WriteLine("---------------------------------------------------------");

                Console.WriteLine("*********************************************************");

                //eleccion de carta enemiga

                Thread.Sleep(1000);// PAUSA
                Console.WriteLine($"Jugador, ingrese el número de carta ENEMIGA que desea ATACAR  (1 al {listaMazoB.Count})");
                int B = Convert.ToInt32(Console.ReadLine());
                int cartaAtacadaB = B - 1;
                Thread.Sleep(1000);// PAUSA
                                   //Mostrar monstruo enemigo
                Console.WriteLine("*********************************************************");
                Console.WriteLine("-----------MONSTRUO ENEMIGO ATACADO-------------------");
                Console.WriteLine($"Monstruo {listaMazoA[cartaSeleccionadaA].NombreMonstruo} ataca al siguiente monstruo de la MAQUINA: ");
                Console.WriteLine($"1.-Nombre: {listaMazoB[cartaAtacadaB].NombreMonstruo}\n" +
                                  $"2.-IdCategoria: {listaMazoB[cartaAtacadaB].IdCategoria}\n" +
                                  $"3.-Puntos de Vida: {listaMazoB[cartaAtacadaB].PuntosVida}\n" +
                                  $"4.-Puntos de Ataque: {listaMazoB[cartaAtacadaB].PuntosAtaque}");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("*********************************************************");
                Categoria categoriaB = new Categoria();
                Categoria categoriaA = new Categoria();
                ///// Pausa para depurar
                Thread.Sleep(5000);// PAUSA
                categoriaA = categoriaDAL.obtenerCategorias(listaMazoA[cartaSeleccionadaA].IdCategoria);

                categoriaB = categoriaDAL.obtenerCategorias(listaMazoB[cartaAtacadaB].IdCategoria);



                //Ahora se ejecuta la logica 
                //Logica para el jugador A          
                //para el jugador A
                if (listaMazoA[cartaSeleccionadaA].IdCategoria == categoriaB.Debilidad) // tiene debilidad
                {
                    Console.WriteLine($"El {listaMazoB[cartaAtacadaB].NombreMonstruo} su categoria es {categoriaB.CategoriaMostruo} tiene debilidad a {categoriaA.CategoriaMostruo}");
                    int vida = (listaMazoB[cartaAtacadaB].PuntosVida - listaMazoA[cartaSeleccionadaA].PuntosAtaque * 2); //duplica ataque
                    if (vida <= 0) // comprueba si queda vivo 
                    {
                        Console.WriteLine($"El {listaMazoB[cartaAtacadaB].NombreMonstruo} ha fallecido"); //declara que fallecio y remueve de la lista
                        listaMazoB.RemoveAt(cartaAtacadaB);
                    }
                    else //setea la nueva vida de la carta
                    {
                        Console.WriteLine($"El {listaMazoB[cartaAtacadaB].NombreMonstruo} ha reducido su vida a {vida}");
                        listaMazoB[cartaAtacadaB].PuntosVida = vida;
                    }
                }
                else if (listaMazoA[cartaSeleccionadaA].IdCategoria == categoriaB.Resistencia) // tiene resistencia
                {
                    Console.WriteLine($"{listaMazoB[cartaAtacadaB].NombreMonstruo} su categoria es {categoriaB.CategoriaMostruo} tiene Resistencia a {categoriaA.CategoriaMostruo}");
                    int vida = (listaMazoB[cartaAtacadaB].PuntosVida - listaMazoA[cartaSeleccionadaA].PuntosAtaque / 2); //divide ataque
                    if (vida <= 0) // comprueba si queda vivo 
                    {
                        Console.WriteLine($"El {listaMazoB[cartaAtacadaB].NombreMonstruo} ha fallecido"); //declara que fallecio y remueve de la lista
                        listaMazoB.RemoveAt(cartaAtacadaB);
                    }
                    else //setea la nueva vida de la carta
                    {
                        Console.WriteLine($"El {listaMazoB[cartaAtacadaB].NombreMonstruo} ha reducido su vida a {vida}");
                        listaMazoB[cartaAtacadaB].PuntosVida = vida;
                    }

                }
                else // no cambia nada 
                {
                    Console.WriteLine("No tiene debilidad ni resistencia, se produce el ataque normal");
                    int vida = (listaMazoB[cartaAtacadaB].PuntosVida - listaMazoA[cartaSeleccionadaA].PuntosAtaque); //divide ataque
                    if (vida <= 0) // comprueba si queda vivo 
                    {
                        Console.WriteLine($"El {listaMazoB[cartaAtacadaB].NombreMonstruo} ha fallecido"); //declara que fallecio y remueve de la lista
                        listaMazoB.RemoveAt(cartaAtacadaB);
                    }
                    else //setea la nueva vida de la carta
                    {
                        Console.WriteLine($"El {listaMazoB[cartaAtacadaB].NombreMonstruo} ha reducido su vida a {vida}");
                        listaMazoB[cartaAtacadaB].PuntosVida = vida;
                    }
                }



                //------------------------------------------------------Aqui modificar esta logica-------------------------------------//
                //TURNO DE LA MAQUINA

                Random rnd = new Random();
                Thread.Sleep(3000);// PAUSA
                Console.WriteLine("\n///////////////////ES EL TURNO DE LA MAQUINA//////////////////////////\n");

                Console.WriteLine("LA MÁQUINA ESTA ESCOGIENDO SU CARTA DE ATAQUE....\n");
                //eleccion de carta enemiga
                Thread.Sleep(3000); // PAUSA
                int cartaB = rnd.Next(0, listaMazoB.Count);
                int cartaSeleccionadaB = cartaB;
                categoriaB = categoriaDAL.obtenerCategorias(listaMazoB[cartaAtacadaB].IdCategoria);
                // Mostrar monstruo que ataca
                Console.WriteLine("*********************************************************");
                Console.WriteLine("--Monstruo de la MAQUINA declarado atacante--");
                Console.WriteLine($"1.-Nombre: {listaMazoB[cartaSeleccionadaB].NombreMonstruo}\n" +
                                  $"2.-IdCategoria: {listaMazoB[cartaSeleccionadaB].IdCategoria}\n" +
                                  $"3.-Puntos de Vida: {listaMazoB[cartaSeleccionadaB].PuntosVida}\n" +
                                  $"4.-Puntos de Ataque: {listaMazoB[cartaSeleccionadaB].PuntosAtaque}");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("*********************************************************");
                //eleccion de carta enemiga
                int cartaAtacadaA = rnd.Next(0, listaMazoA.Count);

                Thread.Sleep(3000);// PAUSA
                Console.WriteLine("LA MÁQUINA HA ESCOGIDO ATACAR A LA SIGUIENTE CARTA: \n");
                Thread.Sleep(3000);// PAUSA

                //Mostrar monstruo atacado
                Console.WriteLine("*********************************************************");
                Console.WriteLine("--------Monstruo Atacado del JUGADOR---------");
                Console.WriteLine($"Monstruo {listaMazoB[cartaSeleccionadaB].NombreMonstruo} ataca al siguiente monstruo de JUGADOR A: ");
                Console.WriteLine($"1.-Nombre: {listaMazoA[cartaAtacadaA].NombreMonstruo}\n" +
                                  $"2.-IdCategoria: {listaMazoA[cartaAtacadaA].IdCategoria}\n" +
                                  $"3.-Puntos de Vida: {listaMazoA[cartaAtacadaA].PuntosVida}\n" +
                                  $"4.-Puntos de Ataque: {listaMazoA[cartaAtacadaA].PuntosAtaque}");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("*********************************************************");
                //aqui comienza el match segun categorias// // esto debio haber sido un metodo//
                //Logica para la MAQUINA
                //para la maquina
                if (listaMazoB[cartaSeleccionadaB].IdCategoria == categoriaA.Debilidad) // tiene debilidad
                {
                    Console.WriteLine($"El {listaMazoA[cartaAtacadaA].NombreMonstruo} su categoria es {categoriaA.CategoriaMostruo} tiene debilidad a {categoriaB.CategoriaMostruo}");
                    int vida = (listaMazoA[cartaAtacadaA].PuntosVida - listaMazoB[cartaSeleccionadaB].PuntosAtaque * 2); //duplica ataque
                    if (vida <= 0) // comprueba si queda vivo 
                    {
                        Console.WriteLine($"El {listaMazoA[cartaAtacadaA].NombreMonstruo} ha fallecido"); //declara que fallecio y remueve de la lista
                        listaMazoB.RemoveAt(cartaAtacadaA);
                    }
                    else //setea la nueva vida de la carta
                    {
                        Console.WriteLine($"El {listaMazoA[cartaAtacadaA].NombreMonstruo} ha reducido su vida a {vida}");
                        listaMazoA[cartaAtacadaA].PuntosVida = vida;
                    }
                }
                else if (listaMazoB[cartaSeleccionadaB].IdCategoria == categoriaA.Resistencia) // tiene resistencia
                {
                    Console.WriteLine($"{listaMazoA[cartaAtacadaA].NombreMonstruo} su categoria es {categoriaA.CategoriaMostruo} tiene Resistencia a {categoriaB.CategoriaMostruo}");
                    int vida = (listaMazoA[cartaAtacadaA].PuntosVida - listaMazoB[cartaSeleccionadaB].PuntosAtaque / 2); //divide ataque
                    if (vida <= 0) // comprueba si queda vivo 
                    {
                        Console.WriteLine($"El {listaMazoA[cartaAtacadaA].NombreMonstruo} ha fallecido"); //declara que fallecio y remueve de la lista
                        listaMazoB.RemoveAt(cartaAtacadaA);
                    }
                    else //setea la nueva vida de la carta
                    {
                        Console.WriteLine($"El {listaMazoA[cartaAtacadaA].NombreMonstruo} ha reducido su vida a {vida}");
                        listaMazoB[cartaAtacadaA].PuntosVida = vida;
                    }

                }
                else // no cambia nada 
                {
                    Console.WriteLine("No tiene debilidad ni resistencia, se produce el ataque normal");
                    int vida = (listaMazoA[cartaAtacadaA].PuntosVida - listaMazoB[cartaSeleccionadaB].PuntosAtaque); //divide ataque
                    if (vida <= 0) // comprueba si queda vivo 
                    {
                        Console.WriteLine($"El {listaMazoA[cartaAtacadaA].NombreMonstruo} ha fallecido"); //declara que fallecio y remueve de la lista
                        listaMazoA.RemoveAt(cartaAtacadaA);
                    }
                    else //setea la nueva vida de la carta
                    {
                        Console.WriteLine($"El {listaMazoA[cartaAtacadaA].NombreMonstruo} ha reducido su vida a {vida}");
                        listaMazoA[cartaAtacadaA].PuntosVida = vida;
                    }
                }




                //aqui termina el match segun categorias// // esto debio haber sido un metodo//




                Thread.Sleep(4000);// PAUSA
                Console.WriteLine("*********************** FIN DEL MATCH ***********************");
                Thread.Sleep(4000);// PAUSA

            } while (listaMazoA != null || listaMazoB != null);


                }

        

        }





    }

