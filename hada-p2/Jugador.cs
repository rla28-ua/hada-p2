using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HADA
{
    class Jugador
    {
        public static int maxAmonestaciones { get; set; }
        public static int maxFaltas { get; set; }
        public static int minEnergia { get; set; }
        public static Random rand { private get; set; }
        public string nombre { get; private set; }
        public int puntos { get; set; }

        private int amonestacion;
        private int faltes;
        private int porcentaje;

        private int amonestaciones
        {
            get { return amonestacion; }
            set 
            {
                if (value < 0)
                {
                    amonestacion = 0;
                }
                else
                {
                    amonestacion = value;

                    if (value > maxAmonestaciones && amonestacionesMaximoExcedido != null)
                    {
                        amonestacionesMaximoExcedido(this, new AmonestacionesMaximoExcedidoArgs(amonestacion));
                    }
                }
            }
        }
        private int faltas
        {
            get { return faltes; }
            set
            {
                faltes = value;

                if(value > maxFaltas && faltasMaximoExcedido != null)
                {
                    faltasMaximoExcedido(this, new FaltasMaximoExcedidoArgs(faltes));
                }
            }
        }
        private int energia
        {
            get { return porcentaje; }
            set
            {
                if(value < 0)
                {
                    porcentaje = 0;
                }
                else
                {
                    if(value > 100)
                    {
                        value = 100;
                    }
                    else
                    {
                        porcentaje = value;

                        if(value < minEnergia && energiaMinimaExcedida != null)
                        {
                            energiaMinimaExcedida(this, new EnergiaMinimaExcedidaArgs(porcentaje));
                        }
                    }
                }
            }
        }
        public Jugador(string nombre, int amonestaciones, int faltas, int energia, int puntos)
        {
            this.nombre = nombre;
            this.amonestaciones = amonestaciones;
            this.faltas = faltas;
            this.energia = energia;
            this.puntos = puntos;
        }
        public void incAmonestaciones()
        {
            amonestaciones += rand.Next(0, 3);
        }
        public void incFaltas()
        {
            faltas += rand.Next(0, 4);
        }
        public void decEnergia()
        {
            energia -= rand.Next(1, 8);
        }
        public void incPuntos()
        {
            puntos += rand.Next(0, 4);
        }
        public bool todoOk()
        {
            if(amonestaciones <= maxAmonestaciones && energia >= minEnergia && faltas <= maxFaltas)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void mover()
        {
            if(todoOk() == true)
            {
                incAmonestaciones();
                incFaltas();
                incPuntos();
                decEnergia();
            }
        }
        public override string ToString()
        {
            string cadena;
            
            cadena = "[" + nombre + "] " + "Puntos: " + puntos + "; ";
            cadena += "Amonestaciones: " + amonestacion + "; ";
            cadena += "Faltas: " + faltes + "; ";
            cadena += "Energia: " + porcentaje + " %; ";
            cadena += "Ok: " + todoOk();

            return cadena;
        }
        public event EventHandler<AmonestacionesMaximoExcedidoArgs> amonestacionesMaximoExcedido;
        public event EventHandler<FaltasMaximoExcedidoArgs> faltasMaximoExcedido;
        public event EventHandler<EnergiaMinimaExcedidaArgs> energiaMinimaExcedida;

        public class AmonestacionesMaximoExcedidoArgs : EventArgs
        {
            public int amonestaciones { get; set; }
            public AmonestacionesMaximoExcedidoArgs(int amonestacion)
            {
                amonestaciones = amonestacion;
            }
        }
        public class FaltasMaximoExcedidoArgs : EventArgs
        {
            public int faltas { get; set; }
            public FaltasMaximoExcedidoArgs(int faltes)
            {
                faltas = faltes;
            }
        }
        public class EnergiaMinimaExcedidaArgs : EventArgs
        {
            public int energia { get; set; }
            public EnergiaMinimaExcedidaArgs(int porcentaje)
            {
                energia = porcentaje;
            }
        }
    }
}
