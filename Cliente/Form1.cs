using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    public partial class Form1 : Form
    {
        String ip = "127.0.0.1";
        int puerto = 31416;
        IPEndPoint ie;
        Socket server;

        // Función donde el cliente se conecta al servidor indicado
        public bool conectarServer()
        {
            // Formateo el texto escrito en los textboxes para la conexión al servidor :
            ie = new IPEndPoint(IPAddress.Parse(ip.Trim()), puerto);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Y creo el socket del servidor

            try
            {
                // El cliente inicia la conexión haciendo petición con Connect
                server.Connect(ie);
            }
            catch (SocketException e)
            {
                lblError.Text = "Error connection: " + e.Message + "\nError code: " + (SocketError)e.ErrorCode + "(" + e.ErrorCode + ")";
                return false; // Si da error en la conexión, devuelve false
            }

            return true;
        }


        public Form1()
        {
            InitializeComponent();

            lblComando.Text = "";
            lblError.Text = "";
        }


        public void pulsarBotonComando(object sender, EventArgs e)
        {
            string comando = null;

            if (!conectarServer())
            {
                lblError.Text = "ERROR : No se ha podido conectar al servidor con la IP y el puerto especificados";
            }
            else
            {
                lblError.Text = "";

                // Le doy valor a la variable comando con la propiedad Tag del botón pulsado, así me ahorro código
                Button pulsado = (Button)sender;
                comando = pulsado.Tag.ToString();
                
                using (NetworkStream ns = new NetworkStream(server)) // Se crea un Stream que hará de puente entre el Socket, el StreamReader y el StreamWriter
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    sw.WriteLine(comando);
                    sw.Flush();

                    sr.ReadLine();
                    try
                    {
                        string respuestaServer = sr.ReadToEnd();
                        lblComando.Text = respuestaServer;
                    }
                    catch (IOException e1)
                    {
                        lblError.Text = e1.Message;
                    }
                }

            }
            server.Close();
        }

        private void MenuItemParametros_Click(object sender, EventArgs e)
        {
            // Creo una variable booleana y un bucle para validar la IP y el puerto escritos en el formulario
            bool repetir = true;
            while (repetir)
            {
                Form2 f = new Form2();
                DialogResult res;
                res = f.ShowDialog(); // Aquí se para la ejecución del programa

                switch (res)
                {
                    case DialogResult.OK:

                        // Defino un contador de los puntos que contiene la IP escrita
                        int contadorPuntos = 0;
                        for (int i = 0; i < f.txtIP.Text.Trim().Length; i++)
                        {
                            if (f.txtIP.Text.Trim()[i] == '.')
                            {
                                contadorPuntos ++;
                            }
                        }

                        // Si hay 3 puntos en la IP y ésta tiene un máximo de 3 números por clase
                        if (contadorPuntos == 3 && f.txtIP.Text.Trim().Length <= 15)
                        {
                            ip = f.txtIP.Text.Trim();
                            repetir = false;
                        }

                        try
                        {
                            puerto = Convert.ToInt32(f.txtPuerto.Text.Trim());

                            if (puerto >= 0 && puerto <= 65535)
                            {
                                puerto = Convert.ToInt32(f.txtPuerto.Text.Trim());
                                repetir = false;
                            }
                        }
                        catch (Exception e2) when (e2 is FormatException || e2 is OverflowException)
                        {
                            repetir = true;
                        }


                    break;
                }
            }
        }
    }

}
