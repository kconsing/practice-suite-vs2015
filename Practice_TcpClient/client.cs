using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Practice_TcpClient
{
    class client
    {
        private TcpClient client_socket;
        private Int32 port = 22222;
        private StreamReader reader;
        private StreamWriter sender;
        private String target = "10.1.10.130";

        public client(string connect_to, int port)
        {
            this.port = port;
            this.target = connect_to;
        }

        public client(int port)   /* localhost default for testing */
        {
            this.port = port;
            this.target = "10.1.10.130";
        }

        public List<string> Request(String send_MESG)
        {
            List<string> response = new List<string>();
            try
            {
                this.client_socket = new TcpClient(this.target, this.port);

                this.sender = new StreamWriter(this.client_socket.GetStream(), Encoding.ASCII);
                this.sender.WriteLine(send_MESG);
                this.sender.Flush();

                /* RECEIVE RESPONSE */
                response = new List<string>();
                String rcvd_MESG = String.Empty;

                this.reader = new StreamReader(this.client_socket.GetStream(), Encoding.ASCII);

                //rcvd_MESG = reader.ReadToEnd();

                while ((rcvd_MESG = this.reader.ReadLine()) != null)
                {
                    response.Add(rcvd_MESG);
                }
                

                this.reader.Close();
                this.sender.Close();
                this.client_socket.Close();
            }
            catch (ArgumentNullException e)
            {
                response.Add("ERROR: " + e.Message);
                //msg.Show("ArgumentNullException:" + e.Message);
            }
            catch (SocketException e)
            {
                response.Add("ERROR: " + e.Message);
                //msg.Show("SocketException: {0}" + e.Message);
            }
            catch (Exception e)
            {
                response.Add("ERROR: " + e.Message);
            }

            return response;
        }
    }
}
