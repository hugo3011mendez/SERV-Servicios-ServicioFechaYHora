using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ServicioFechaYHora
{
    class Server
    {
        Socket s;
        bool conexion;


        public Server(Socket s)
        {
            this.s = s;
            conexion = true;

            Thread hilo = new Thread(hiloServidor);
            hilo.IsBackground = true;
            hilo.Start();
        }


        private void hiloServidor()
        {
            while (this.conexion)
            {
                // Cliente :
                Socket sClient = s.Accept(); // Aceptamos la conexión del cliente

                // Obtenemos info del cliente :
                IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint; // Casteo a IPEndPoint porque EndPoint es más genérico
                Console.WriteLine("Client connected :\n{0} at port {1}", ieClient.Address, ieClient.Port); // Muestro la IP del cliente y el puerto al que está conectado

                // Conexión :
                // Uso using para no tener que cerrarlos después
                using (NetworkStream ns = new NetworkStream(sClient)) // Se crea un Stream que hará de puente entre el Socket, el StreamReader y el StreamWriter
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    sw.WriteLine("Bienvenido al servidor de hora y fecha! IP : " + ieClient.Address);
                    sw.Flush(); // Fuerzo el envío de los datos sin esperar al cierre de la conexión

                    string msg = ""; // Creo y defino variable para el mensaje que manda el cliente
                    string msgParaElCliente = "";

                    // No pongo un while porque el ejercicio requiere que se cierre la conexión después de mandar un comando al servidor
                    try
                    {
                        msg = sr.ReadLine();
                        switch (msg)
                        {
                            case "HORA":
                                msgParaElCliente = "El cliente con IP " + ieClient.Address + " ha proporcionado la hora : " + DateTime.Now.ToString("HH:mm:ss");
                                break;

                            case "FECHA":
                                msgParaElCliente = "El cliente con IP " + ieClient.Address + " ha proporcionado la fecha : " + DateTime.Now.ToString("dd/MM/yyyy");
                                break;

                            case "TODO":
                                msgParaElCliente = "El cliente con IP " + ieClient.Address + " ha proporcionado la hora : " + DateTime.Now.ToString("HH:mm:ss") + "\nEl cliente con IP " + ieClient.Address + " ha proporcionado la fecha : " + DateTime.Now.ToString("dd/MM/yyyy");
                                break;

                            case "APAGAR":
                                msgParaElCliente = "Cerrando conexión...";
                                conexion = false;
                                break;

                            default:
                                msgParaElCliente = "Comando no válido";
                                break;
                        }

                        sw.WriteLine(msgParaElCliente);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }

                sClient.Close();
            }

            s.Close();
        }
    }
}
