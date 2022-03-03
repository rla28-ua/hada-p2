﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HADA
{
    internal class Jugador
    {
        public static int maxAmonestaciones { get; set; }
        public static int maxFaltas { get; set; }
        public static int minEnergia { get; set; }
        public static Random rand { private get; set; }
        public string nombre { get; private set; }
        public int puntos { get; set; }
        private int amonestaciones
        {
            get { return amonestaciones; }
            set
            {
                if (value < maxAmonestaciones)
                {
                    amonestaciones = 0;
                }
                else
                {
                    amonestaciones = value;

                    if (value > maxAmonestaciones && amonestacionesMaximoExcedido != null)
                    {
                        amonestacionesMaximoExcedido(this, new amonestacionesMaximoExcedidoArgs(amonestaciones));
                    }
                }
            }
        }
        private int faltas
        {
            get { return faltas; }
            set
            {
                faltas = value;

                if(value > maxFaltas && faltasMaximoExcedido != null)
                {
                    faltasMaximoExcedido(this, new faltasMaximoExcedido(faltas));
                }
            }
        }
        private int energia
        {
            get { return energia; }
            set
            {
                if(value < 0)
                {
                    energia = 0;
                }
                else
                {
                    if(value > 100)
                    {
                        value = 100;
                    }
                    else
                    {
                        energia = value;

                        if(value < minEnergia && energiaMinimaExcedida != null)
                        {
                            energiaMinimaExcedida(this, new energiaMinimaExcedida(energia));
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
            amonestaciones += rand.Next(0, 2);
        }
        public void incFaltas()
        {
            faltas += rand.Next(0, 3);
        }
        public void decEnergia()
        {
            energia -= rand.Next(1, 7);
        }
        public void incPuntos()
        {
            puntos += rand.Next(0, 3);
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
            cadena += "Amonestaciones: " + amonestaciones + "; ";
            cadena += "Faltas: " + faltas + "; ";
            cadena += "Energia: " + energia + " %; ";
            cadena += "Ok: " + todoOk();
        }
    }
}
