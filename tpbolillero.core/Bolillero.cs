using System.Collections.Generic;
using System;
namespace tpbolillero.core
{
    public class Bolillero : ICloneable
    {
        public List<byte> Adentro { get; set; }
        public List<byte> Afuera { get; set; }
        public IAzar Azar { get; set; }
        public Bolillero() { }
        public Bolillero(byte bolillas) => Crearbolillas(bolillas);
        
        private Bolillero(Bolillero Original)
        {
            Adentro = new List<byte>(Original.Adentro);
            Afuera = new List<byte>(Original.Afuera);

        }
        private void Crearbolillas(byte numero)
        {
            Adentro = new List<byte>();
            Afuera = new List<byte>();
            for (byte bolilla = 0; bolilla < numero; bolilla++)
            {
                Adentro.Add(bolilla);
            }
        }
        public void Reingresar()
        {
            Adentro.AddRange(Afuera);
            Afuera.Clear();
        }
        public byte SacarBolilla()
        {
            byte bolilla = Azar.SacarBolilla(Adentro);
            Adentro.Remove(bolilla);
            Afuera.Add(bolilla);
            return bolilla;
        }
        public bool Jugar(List<byte> jugada) => jugada.TrueForAll(j => j == SacarBolilla());
        public long JugarN(List<byte> bolillas, long cantidad)
        {
            long contador = 0;
            for (int i = 0; i < cantidad; i++)
            {
                Reingresar();

                if (Jugar(bolillas))
                {
                    contador++;
                }
            }
            return contador;
        }


        public object Clone()
        {
            return new Bolillero(this);
        }
    }
}