using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application;
using Domain;
using Models;

namespace Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Ingresar_Palabra_Vacia()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = "" };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void Ingresar_Espacio_En_Blanco_En_Lugar_De_Una_Palabra()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = " " };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void Ingresar_Palabra_Con_Caracteres_Que_No_Son_Letras()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = "automov*l" };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void Ingresar_Palabra_Con_Espacio_En_Blanco()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = "auto movil" };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void Ingresar_Palabra_De_Una_Letra()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = "a" };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void Ingresar_Palabra_Valida()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = "automovil" };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsFalse(response.Error);
        }

        [TestMethod]
        public void Arriesgar_Palabra_Sale_Mal()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = "motocicleta" };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsTrue(response.GameOver);
        }

        [TestMethod]
        public void Arriesgar_Palabra_Sale_Bien()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Palabra = "automovil" };

            // Act
            var response = app.ArriesgarPalabra(request);

            // Assert
            Assert.IsTrue(response.Win);
        }

        [TestMethod]
        public void Modelo_Coincide_Con_La_Palabra()
        {
            // Arrange
            Juego juego = new Juego("modelo");

            // Act
            var modelo = juego.Modelo;

            // Assert
            Assert.AreEqual("_ _ _ _ _ _", modelo);
        }

        [TestMethod]
        public void Ingresar_Una_Sola_Letra()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Letra = "aa" };

            // Act
            var response = app.ArriesgarLetra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void No_Ingresar_Espacios_En_Blanco()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Letra = " " };

            // Act
            var response = app.ArriesgarLetra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void Ingresar_Solo_Letras()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Letra = "*" };

            // Act
            var response = app.ArriesgarLetra(request);

            // Assert
            Assert.IsTrue(response.Error);
        }

        [TestMethod]
        public void Ingresar_Letra_Valida()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Letra = "a" };

            // Act
            var response = app.ArriesgarLetra(request);

            // Assert
            Assert.IsFalse(response.Error);
        }

        [TestMethod]
        public void Arriesgar_Letra_Sale_Mal()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Letra = "z" };

            // Act
            var response = app.ArriesgarLetra(request);

            // Assert
            Assert.IsFalse(response.Acierto);
        }

        [TestMethod]
        public void Arriesgar_Letra_Sale_Bien()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Letra = "a" };

            // Act
            var response = app.ArriesgarLetra(request);

            // Assert
            Assert.IsTrue(response.Acierto);
        }

        [TestMethod]
        public void Modelo_Cuando_Se_Arriesga_Una_Primer_Letra_Y_Esta_Bien()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");
            AhorcadoRequest request = new AhorcadoRequest { Letra = "o" };

            // Act
            var response = app.ArriesgarLetra(request);

            // Assert
            Assert.AreEqual("_ _ _ O _ O _ _ _", response.Modelo);
        }

        [TestMethod]
        public void Modelo_Cuando_Se_Arriesga_Una_Segunda_Letra_Y_Esta_Mal()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "o" });
            var response = app.ArriesgarLetra(new AhorcadoRequest { Letra = "z" });

            // Assert
            Assert.AreEqual("_ _ _ O _ O _ _ _", response.Modelo);
        }

        [TestMethod]
        public void Modelo_Cuando_Se_Arriesga_Una_Segunda_Letra_Y_Esta_Bien()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "t" });
            var response = app.ArriesgarLetra(new AhorcadoRequest { Letra = "o" });

            // Assert
            Assert.AreEqual("_ _ T O _ O _ _ _", response.Modelo);
        }

        [TestMethod]
        public void Letras_Ingresadas_Se_Guardan_Correctamente()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "a" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "A" });
            var response = app.ArriesgarLetra(new AhorcadoRequest { Letra = "z" });

            // Assert
            Assert.IsTrue(response.LetrasIngresadas.Contains("a"));
            Assert.IsFalse(response.LetrasIngresadas.Contains("A"));
            Assert.IsTrue(response.LetrasIngresadas.Contains("z"));
        }

        [TestMethod]
        public void Juego_Ganado_Ingresando_Palabra_Correcta()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            var response = app.ArriesgarPalabra(new AhorcadoRequest { Palabra = "automovil" });

            // Assert
            Assert.IsTrue(response.Win);
        }

        [TestMethod]
        public void Juego_Ganado_Ingresando_Letras_Correctas()
        {
            // Arrange
            App app = new App();
            app.NewGame("automoviles");

            // Act
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "a" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "u" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "t" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "o" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "m" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "v" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "i" });
            var response = app.ArriesgarLetra(new AhorcadoRequest { Letra = "l" });

            // Assert
            Assert.IsTrue(response.Win);
        }

        [TestMethod]
        public void Fin_De_Juego_Por_No_Tener_Mas_Intentos_Solo_Con_Letras()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "z" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "x" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "c" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "b" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "n" });
            var response = app.ArriesgarLetra(new AhorcadoRequest { Letra = "s" });

            // Assert
            Assert.IsTrue(response.GameOver);
        }

        [TestMethod]
        public void Fin_De_Juego_Por_No_Tener_Mas_Intentos_Solo_Con_Palabra()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            var response = app.ArriesgarPalabra(new AhorcadoRequest { Palabra = "motocicleta" });

            // Assert
            Assert.IsTrue(response.GameOver);
        }

        [TestMethod]
        public void Comenzar_Un_Nuevo_Juego_Con_Una_Nueva_Palabra()
        {
            // Arrange
            App app = new App();

            // Act
            var response1 = app.NewGame();
            var response2 = app.NewGame();

            // Assert
            Assert.AreNotEqual(response1, response2);
        }

        [TestMethod]
        public void No_Poder_Arriesgar_Mas_Letras_Si_Se_Perdio_El_Juego()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "z" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "x" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "c" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "b" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "n" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "s" });
            var response = app.ArriesgarLetra(new AhorcadoRequest { Letra = "r" });

            // Assert
            Assert.IsTrue(response.GameOver);
            Assert.AreEqual(0, response.Intentos);
        }

        [TestMethod]
        public void No_Poder_Arriesgar_Mas_Letras_Si_Se_Gano_El_Juego()
        {
            // Arrange
            App app = new App();
            app.NewGame("automovil");

            // Act
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "a" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "u" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "t" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "o" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "m" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "v" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "i" });
            app.ArriesgarLetra(new AhorcadoRequest { Letra = "l" });
            var response = app.ArriesgarLetra(new AhorcadoRequest { Letra = "x" });

            // Assert
            Assert.IsTrue(response.Win);
            Assert.AreEqual(6, response.Intentos);
        }
    }
}