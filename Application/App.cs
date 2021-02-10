using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Models;
 
namespace Application
{
    public class App
    {
        public static Juego Juego { get; set; }
        private static Random _random;

        public App()
        {
            _random = new Random();
        }

        public AhorcadoResponse NewGame(string palabra = null)
        {
            Juego = new Juego(palabra ?? GetPalabraRandom());

            return new AhorcadoResponse
            {
                Palabra = Juego.Palabra,
                Modelo = Juego.Modelo,
                Intentos = Juego.Intentos,
                GameOver = Juego.IsGameOver(),
                Win = Juego.Win
            };
        }

        public AhorcadoResponse ArriesgarLetra(AhorcadoRequest rq)
        {
            var ar = new AhorcadoResponse();

            if (!Juego.KeepPlaying())
            {
                ar.Error = true;
                ar.ErrorMessage = "Fin de Juego.";
            }
            else
            {
                if (!ValidarLetra(rq.Letra))
                {
                    ar.Error = true;
                    ar.ErrorMessage = "Letra Inválida";
                }
                else
                {
                    Juego.CheckLetra(rq.Letra);
                    ar.Error = false;
                }
            }

            ar.Acierto = Juego.Acierto;
            ar.Modelo = Juego.KeepPlaying() ? Juego.Modelo : Juego.Palabra.ToUpper();
            ar.Intentos = Juego.Intentos;
            ar.GameOver = Juego.IsGameOver();
            ar.Win = Juego.Win;
            ar.LetrasIngresadas = Juego.LetrasIngresadas;

            return ar;
        }

        public AhorcadoResponse ArriesgarPalabra(AhorcadoRequest rq)
        {
            var ar = new AhorcadoResponse();

            if (!Juego.KeepPlaying())
            {
                ar.Error = true;
                ar.ErrorMessage = "Fin de Juego.";
            }
            else
            {
                if (!ValidarPalabra(rq.Palabra))
                {
                    ar.Error = true;
                    ar.ErrorMessage = "Palabra Inválida";
                }
                else
                {
                    Juego.CheckPalabra(rq.Palabra);
                    ar.Error = false;
                }
            }

            ar.Acierto = Juego.Acierto;
            ar.Modelo = Juego.KeepPlaying() ? Juego.Modelo : Juego.Palabra.ToUpper();
            ar.Intentos = Juego.Intentos;
            ar.GameOver = Juego.IsGameOver();
            ar.Win = Juego.Win;
            ar.LetrasIngresadas = Juego.LetrasIngresadas;

            return ar;
        }

        private bool ValidarLetra(string letra)
        {
            if (!letra.All(char.IsLetter))
                return false;

            if (letra.Length != 1)
                return false;

            return true;
        }

        private bool ValidarPalabra(string palabra)
        {
            if (!palabra.All(char.IsLetter))
                return false;

            if (palabra.Length <= 1)
                return false;

            return true;
        }

        private string GetPalabraRandom()
        {
            List<string> palabras = new List<string>
            {
                "biblioteca",
                "cientifico",
                "adaptacion",
                "contractura",
                "evaluacion",
                "diagnostico",
                "higiene",
                "procedimiento",
                "ligamento",
                "ocupacion"
            };

            return palabras[_random.Next(palabras.Count)];
        }
    }
}
