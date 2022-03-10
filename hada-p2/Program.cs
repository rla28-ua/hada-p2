using HADA;
using System;
using System.Collections.Generic;
using static HADA.Jugador;

namespace Hada
{
    class Program
    {
        public static bool JugadorOk()
        {
            string nombre = "jugador";
            int amonestaciones = 9;
            int faltas = 4;
            int energia = 10;
            int puntos = 15;

            Jugador jugador = new Jugador(nombre, amonestaciones, faltas, energia, puntos);

            nombre = jugador.nombre;
            jugador.incAmonestaciones();
            jugador.incFaltas();
            jugador.incPuntos();
            jugador.decEnergia();
            jugador.mover();

            Console.WriteLine(jugador);

            AmonestacionesMaximoExcedidoArgs amonestacionesMax = new AmonestacionesMaximoExcedidoArgs(amonestaciones);
            amonestaciones = amonestacionesMax.amonestaciones;
            FaltasMaximoExcedidoArgs faltasMax = new FaltasMaximoExcedidoArgs(faltas);
            faltas = faltasMax.faltas;
            EnergiaMinimaExcedidaArgs energiaMin = new EnergiaMinimaExcedidaArgs(energia);
            energia = energiaMin.energia;

            return jugador.todoOk();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Programa principal");

            Jugador.maxAmonestaciones = 6;
            Jugador.maxFaltas = 8;
            Jugador.minEnergia = 1;
            Jugador.rand = new Random();

            if (JugadorOk())
            {
                Equipo equipo1 = new Equipo(12, "EQUIPO_A");
                Console.WriteLine(equipo1);

                if (equipo1.moverJugadores())
                {
                    equipo1.moverJugadoresEnBucle();
                }
            }
        }
    }
}