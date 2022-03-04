using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Equipo
    {
        private List<Jugador> jugadores;
        private List<Jugador> amonestacionesExc;
        private List<Jugador> faltasExc;
        private List<Jugador> puntosExc;
        private List<Jugador> energiaExc;
        public static int minJugadores { get; set; }
        public static int maxNumeroMovimientos { get; set; }
        public static int movimientos { get; private set; }
        public static string nombreEquipo { get; private set; }

        public Equipo(int nj, string nom)
        {
            jugadores = new List<Jugador>();
            amonestacionesExc = new List<Jugador>();
            faltasExc = new List<Jugador>();
            puntosExc = new List<Jugador>();
            energiaExc = new List<Jugador>();

            for(int i = 0; i < nj; i++)
            {
                jugadores.Add(new Jugador("jugador_" + i, 0, 0, 0, 50));
                jugadores[i].
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
        }

        public List<Jugador> getJugadoresExcedenLimiteAmonestaciones()
        {
            return amonestacionesExc;
        }
        public List<Jugador> getJugadoresExcedenLimiteFaltas()
        {
            return faltasExc;
        }
        public List<Jugador> getJugadoresExcedenMinimoEnergia()
        {
            return energiaExc;
        }
        public override string ToString()
        {
            string cadena;

            cadena = 

            return cadena;
        }

        private cuandoAmonestacionesMaximoExcedido(object sender, AmonestacionesMaximoExcedidoArgs evento)
        {
            jugadores jugador = (jugador)sender;


        }
    }
}
