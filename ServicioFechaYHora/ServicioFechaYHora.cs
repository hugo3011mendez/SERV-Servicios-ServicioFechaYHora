using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ServicioFechaYHora
{
    public partial class ServicioFechaYHora : ServiceBase
    {
        string nombreConfiguracion = "configServidorFechaYHora.txt"; // Nombre del archivo del que va a leer el puerto
        int puerto = 31416; // Número de puerto por defecto
        int puertoEnArchivo; // Recpgerá el puerto guardado en el archivo de configuración, si lo hay

        bool conexion = true; // Indica si se puede hacer la conexión o no

        public ServicioFechaYHora()
        {
            InitializeComponent();
        }


        // Función para escribir un evento cuando se necesite
        static void escribeEvento(string mensaje)
        {
            string nombre = "ServidorFechaHora";
            string logDestino = "Application";

            if (!EventLog.SourceExists(nombre))
            {
                EventLog.CreateEventSource(nombre, logDestino);
            }
            EventLog.WriteEntry(nombre, mensaje);
        }


        protected override void OnStart(string[] args)
        {
            escribeEvento("El servidor de fecha y hora se ha iniciado con éxito"); // Nada más lanzar el servidor escribimos el evento confirmando que se ha lanzado con éxito


            bool hayPuertoEnFichero = leerPuertoConfig(); // Intentamos leer el puerto guardado en el archivo de configuración

            if (hayPuertoEnFichero) // Si el archivo contiene un puerto, se establece ese como puerto del server
            {
                puerto = puertoEnArchivo;
            }

            IPEndPoint ie = new IPEndPoint(IPAddress.Loopback, puerto); // Establezco un par IP-Puerto para el server
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Establezco el Socket

            // Compruebo si el puerto está ocupado
            try
            {
                s.Bind(ie); // Se enlaza el Socket al IPEndPoint
                // Salta excepción si el puerto está ocupado

                escribeEvento("Servidor de fecha y hora lanzado en el puerto " + ie.Port); // Escribo un evento informando del puerto en el que he lanzado el servidor
            }
            catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
            {
                // Si está ocupado, cambio la propiedad a otro secundario, y el puerto del IPEndPoint lo establezco a esa propiedad
                puerto = 31416;
                ie.Port = puerto;

                try
                {
                    s.Bind(ie);
                    escribeEvento("Servidor de fecha y hora lanzado en el puerto " + ie.Port); // Escribo un evento informando del puerto en el que he lanzado el servidor
                }
                catch (SocketException e1) when (e1.ErrorCode == (int)SocketError.AddressAlreadyInUse)
                {
                    conexion = false; // Pongo la variable que indica si hay conexión a false

                    // Si el secundario también está ocupado, escribo un evento informando de que los dos puertos están ocupados y cierro el sever
                    escribeEvento("Ambos puertos ocupados, no se puede lanzar el servidor de fecha y hora");
                    s.Close();
                    return;
                }
            }

            s.Listen(5); // Se queda esperando una conexión y se establece la cola a 5 clientes máximo en cola

            if (conexion) // Si se puede realizar la conexión, se crea el servidor y éste lanza su hilo
            {
                Server server = new Server(s);
            }
        }


        protected override void OnStop() // Cuando pare el servicio, crearé un evento informando de que se ha parado
        {
            escribeEvento("El servidor de fecha y hora se ha detenido con éxito");
        }



        // Intenta leer el puerto guardado en el archivo de configuración :
        protected bool leerPuertoConfig()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\" + nombreConfiguracion)) // Uso la variable de entorno
                {
                    string linea = sr.ReadLine();
                    if (linea != null && Int32.TryParse(linea, out puertoEnArchivo)) // Compruebo si hay un número de puerto guardado en una línea y devuelvo true si lo hay
                    {
                        return true;
                    }
                }
            }
            catch (IOException e)
            {
                escribeEvento("Error leyendo el archivo de configuración : " + e.Message); // Si ocurre algún error, escribo un evento informando
            }

            return false; // Si ocurre un error, pasará por aquí, por lo que devuelvo false
        }
    }
}
