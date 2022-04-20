using System;
using Xunit;
using tpbolillero.core;
using System.Collections.Generic;
using System.Linq;


namespace tpbolillero.test
{ 
    public class BolilleroTest
    {
        public Bolillero bolillero {get; set;}
        public BolilleroTest()
        {
            bolillero = new Bolillero(10);
            bolillero.Azar = new Primera();
        }
        [Fact]
        public void SacarBolilla()
        {
            Assert.Equal(0, bolillero.SacarBolilla());
            Assert.Equal(9,bolillero.Adentro.Count);
            Assert.Equal(1,bolillero.Afuera.Count);
        }

        [Fact]
        public void ReIngresar()
        {
            bolillero.SacarBolilla();
            bolillero.Reingresar();
            Assert.Equal(10,bolillero.Adentro.Count);
            Assert.Equal(0,bolillero.Afuera.Count);
        }

        [Fact]
        public void JugarGana()
        {
            List<byte> j1= new List<byte>{0,1,2,3};
            Assert.True(bolillero.Jugar(j1));
        }
        [Fact]
        public void JugarPierde()
        {
            List<byte> j1= new List<byte>{4,2,1};
            Assert.False(bolillero.Jugar(j1));
        }
        [Fact]
        public void GanarNVeces()
        {
            List<byte> j1= new List<byte>{0,1};
            Assert.Equal(1,bolillero.JugarN(j1,1));
        }
    }
}