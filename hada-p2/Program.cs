using HADA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HADA.Jugador;

namespace Hada
{
    class Program
    {
        public static int GenerarPartida(Equipo equipoA, Equipo equipoB)
        {
            bool estadoA, estadoB;
            int estado = -1;

            do
            {
                estadoA = equipoA.moverJugadores();
                estadoB = equipoB.moverJugadores();

                Console.WriteLine("Movimiento " + equipoA.movimientos);

                Console.WriteLine(equipoA.ToString());
                Console.WriteLine();
                Console.WriteLine(equipoB.ToString());

                if (!estadoA)
                {
                    if (!estadoB)
                    {
                        estado = 4;
                    }
                    else
                    {
                        estado = 2;
                    }
                    break;
                }
                else
                {
                    if (!estadoB)
                    {
                        estado = 1;
                        break;
                    }
                }
                if(equipoA.movimientos > Equipo.maxNumeroMovimientos)
                {
                    estado = 3;
                    break;
                }
            } while (estadoA && estadoB);

            return estado;
        }
        public static void MostrarResultado(Equipo equipoA, Equipo equipoB, int estado)
        {
            switch (estado)
            {
                case 1:
                    Console.WriteLine("Gana el [" + equipoA.nombreEquipo + "] utilizando " + equipoA.movimientos + " movimientos.");
                    break;
                case 2:
                    Console.WriteLine("Gana el [" + equipoB.nombreEquipo + "] utilizando " + equipoB.movimientos + " movimientos.");
                    break;
                case 3:
                    int puntosA = equipoA.sumarPuntos();
                    int puntosB = equipoB.sumarPuntos();

                    if(puntosA == puntosB)
                    {
                        Console.WriteLine("El [" + equipoA.nombreEquipo + "] y el [" + equipoB.nombreEquipo + "] han empatado utilizando " + equipoA.movimientos + " movimientos.");
                    }
                    else
                    {
                        if(puntosA > puntosB)
                        {
                            Console.WriteLine("Gana el equipo [" + equipoA.nombreEquipo + "] utilizando " + equipoA.movimientos + " movimientos.");
                            Console.WriteLine(equipoA.ToString());
                            Console.WriteLine();
                            Console.WriteLine(equipoB.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Gana el equipo [" + equipoB.nombreEquipo + "] utilizando " + equipoB.movimientos + " movimientos.");
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("El [" + equipoA.nombreEquipo + "] y el [" + equipoB.nombreEquipo + "] han empatado utilizando " + equipoA.movimientos + " movimientos (descalificados).");
                    break;
            }
            Console.WriteLine(equipoA);
            Console.WriteLine();
            Console.WriteLine(equipoB);
        }
        public static void ProbarMoverJugador()
        {
            string nombre = "Cristiano Ronaldo";
            int amonestaciones = 0;
            int faltas = 0;
            int energia = 50;
            int puntos = 0;

            Jugador jugador = new Jugador(nombre, amonestaciones, faltas, energia, puntos);

            Console.WriteLine("Estado inicial del jugador");
            Console.WriteLine(jugador);
            Console.WriteLine();

            Console.WriteLine("Estado después de mover manualmente");
            jugador.incAmonestaciones();
            jugador.incFaltas();
            jugador.incPuntos();
            jugador.decEnergia();

            Console.WriteLine(jugador);
            Console.WriteLine();

            Console.WriteLine("Estado después de mover automáticamente (función mover())");
            jugador.mover();
            Console.WriteLine(jugador);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Programa principal");

            Jugador.maxAmonestaciones = 6;
            Jugador.maxFaltas = 8;
            Jugador.minEnergia = 1;
            Jugador.rand = new Random();

            Equipo.maxNumeroMovimientos = 8;
            Equipo.minJugadores = 2;

            ProbarMoverJugador();

            Equipo equipoA = new Equipo(6, "equipo_A");
            Equipo equipoB = new Equipo(6, "equipo_B");

            int estado = GenerarPartida(equipoA, equipoB);

            Console.WriteLine("-------------------------------");
            MostrarResultado(equipoA, equipoB, estado);

            Console.WriteLine("Pulse una tecla para finalizar");
            Console.WriteLine();


        }
    }
}