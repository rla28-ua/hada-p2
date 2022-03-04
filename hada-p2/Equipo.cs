using HADA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HADA.Jugador;

namespace Hada
{
    class Equipo
    {
        private List<Jugador> jugadores;
        private List<Jugador> amonestaciones;
        private List<Jugador> faltas;
        private List<Jugador> energia;
        public static int minJugadores { get; set; }
        public static int maxNumeroMovimientos { get; set; }
        public int movimientos { get; private set; }
        public string nombreEquipo { get; private set; }

        public Equipo(int nj, string nom)
        {
            jugadores = new List<Jugador>();
            amonestaciones = new List<Jugador>();
            faltas = new List<Jugador>();
            energia = new List<Jugador>();

            for(int i = 0; i < nj; i++)
            {
                jugadores.Add(new Jugador("jugador_" + i, 0, 0, 0, 50));
                jugadores[i].amonestacionesMaximoExcedido += cuandoAmonestacionesMaximoExcedido;
                jugadores[i].faltasMaximoExcedido += cuandoFaltasMaximoExcedido;
                jugadores[i].energiaMinimaExcedida += cuandoEnergiaMinimaExcedida;
            }
        }
        public bool moverJugadores()
        {
            bool mover = false;

            for(int i = 0; i < jugadores.Count(); i++)
            {
                if (jugadores[i].todoOk())
                {
                    mover = true;
                    jugadores[i].mover();
                }
            }
            return mover;
        }
        public void moverJugadoresEnBucle()
        {
            while (moverJugadores())
            {
                moverJugadores();
            }
        }
        public int sumarPuntos()
        {
            int puntosTotal = 0;

            for(int i = 0; i < jugadores.Count(); i++)
            {
                puntosTotal += jugadores[i].puntos;
            }
            return puntosTotal;
        }

        public List<Jugador> getJugadoresExcedenLimiteAmonestaciones()
        {
            return amonestaciones;
        }
        public List<Jugador> getJugadoresExcedenLimiteFaltas()
        {
            return faltas;
        }
        public List<Jugador> getJugadoresExcedenMinimoEnergia()
        {
            return energia;
        }
        public override string ToString()
        {
            string cadena;

            cadena = "[" + nombreEquipo + "] Puntos: " + puntos + "; ";
            cadena += "Expulsados" + getJugadoresExcedenLimiteAmonestaciones().Count() + "; ";
            cadena += "Lesionados: " + getJugadoresExcedenLimiteFaltas().Count() + "; ";
            cadena += "Retirados: " + getJugadoresExcedenMinimoEnergia().Count() + "\n";

            for(int i = 0; i < jugadores.Count(); i++)
            {
                cadena += jugadores[i].ToString() + "\n";
            }

            return cadena;
        }

        private void cuandoAmonestacionesMaximoExcedido(object sender, AmonestacionesMaximoExcedidoArgs evento)
        {
            Jugador jugador = (Jugador)sender;

            if(amonestaciones.Contains(jugador) == false)
            {
                amonestaciones.Add(jugador);
            }
            Console.WriteLine("¡¡Número máximo excedido de amonestaciones. Jugador Expulsado");
            Console.WriteLine("Jugador: " + jugador.nombre);
            Console.WriteLine("Equipo: " + );
            Console.WriteLine("Amonestaciones: " + evento.amonestaciones);
        }

        private void cuandoFaltasMaximoExcedido(object sender, FaltasMaximoExcedidoArgs evento)
        {
            Jugador jugador = (Jugador)(sender);

            if(faltas.Contains(jugador) == false)
            {
                faltas.Add(jugador);
            }
            Console.WriteLine("¡¡Número máximo excedido de faltas recibidas. Jugador lesionado!!");
            Console.WriteLine("Jugador: " + jugador.nombre);
            Console.WriteLine("Equipo: " + nombreEquipo);
            Console.WriteLine("Faltas: " + evento.faltas);
        }
        private void cuandoEnergiaMinimaExcedida(Object sender, EnergiaMinimaExcedidaArgs evento)
        {
            Jugador jugador = (Jugador)(sender);

            if(energia.Contains(jugador) == false)
            {
                energia.Add(jugador);
            }
            Console.WriteLine("¡¡Energía mínima excedida. Jugador retirado!!");
            Console.WriteLine("Jugador: " + jugador.nombre);
            Console.WriteLine("Equipo: " + nombreEquipo);
            Console.WriteLine("Energía: " + evento.energia + " %");
        }
    }
}
