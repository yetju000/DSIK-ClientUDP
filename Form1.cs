using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        String adres_IP = "192.168.43.91";
        byte[] ServerLoginByte = new byte[20];
        byte[] ServerHasloByte = new byte[20];
        UdpClient client;   
        string path;
        IPEndPoint ep;
        public Form1()
        {
            client = new UdpClient();
            ep = new IPEndPoint(IPAddress.Parse(adres_IP), 4444); // inicjujemy klienta
            client.Connect(ep);
            InitializeComponent();
            client.Send(new byte[] { 15 }, 1);
        }
        private void zaloguj_Click(object sender, EventArgs e)
        {
            path = "/home/adrian/Pulpit/Katalog/" + login.Text;
            string wiad;
            byte[] LoginByte = new byte[login.Text.Length];
            byte[] HasloByte = new byte[haslo.Text.Length];
            LoginByte = System.Text.Encoding.UTF8.GetBytes(login.Text);
            HasloByte = System.Text.Encoding.UTF8.GetBytes(haslo.Text);

            client.Send(new byte[] { 48 }, 1);  //wysylamy ze niezalogowany
            client.Send(new byte[] { 49 }, 1);   //chcemy sie logowac
            client.Send(LoginByte, LoginByte.Length); //dane logowania
            client.Send(HasloByte, HasloByte.Length);  //dane logowania

            byte[] wiadomosc = new byte[30];
            wiadomosc = client.Receive(ref ep);
            wiad = System.Text.Encoding.UTF8.GetString(wiadomosc, 0, wiadomosc.Length);

            if (wiad.Contains("zalogowano pomyslnie")) {
                ServerLoginByte = LoginByte;
                ServerHasloByte = HasloByte;
                
                znikaj();
                Pliki.Text = "";
                while(true)
                {
                    wiadomosc = client.Receive(ref ep);
                    wiad = System.Text.Encoding.UTF8.GetString(wiadomosc, 0, wiadomosc.Length);
                    if (wiad.Contains("q")) break;
                    Pliki.Text = Pliki.Text + wiad;
                    Pliki.AppendText(Environment.NewLine);
                }
                Info.Text = "zalogowano pomyslnie";
            }
            else
            {
                path = "";
                Info.Text = wiad;
            }
            wiad = null;
            LoginByte = null;
            HasloByte = null;
            wiadomosc = null;

        }
       

        private void login_TextChanged(object sender, EventArgs e)
        {

        }

        private void Zarejestruj_Click(object sender, EventArgs e)
        {
            byte[] LoginByte = new byte[login.Text.Length];
            byte[] HasloByte = new byte[haslo.Text.Length];
            LoginByte = System.Text.Encoding.UTF8.GetBytes(login.Text);
            HasloByte = System.Text.Encoding.UTF8.GetBytes(haslo.Text);

            client.Send(new byte[] { 48 }, 1); //wysylamy ze nie zalogowany
            client.Send(new byte[] { 50 }, 1);  //wysylamy ze rejestracja
            client.Send(LoginByte, LoginByte.Length);
            client.Send(HasloByte, HasloByte.Length);

            byte[] wiadomosc = new byte[30];
            wiadomosc = client.Receive(ref ep);
            
            Info.Text = System.Text.Encoding.UTF8.GetString(wiadomosc, 0, wiadomosc.Length);

            LoginByte = null;
            HasloByte = null;
            wiadomosc = null;
        }

        private void Wyloguj_Click(object sender, EventArgs e)
        {
            
            client.Send(new byte[] { 57}, 1);
            client.Send(ServerLoginByte, ServerLoginByte.Length);
            client.Send(ServerHasloByte, ServerHasloByte.Length);
            client.Send(new byte[] { 49 }, 1);
          
            pojaw();
            Info.Text = "Wylogowano";
        }



        private void Wrzuc_Click(object sender, EventArgs e)
        {
         

            client.Send(new byte[] { 57 }, 1); //wysylamy ze zalogowany
            client.Send(ServerLoginByte, ServerLoginByte.Length);
            client.Send(ServerHasloByte, ServerHasloByte.Length);
            client.Send(new byte[] { 51 }, 1); //wysylamy ze chcemy wrzucic
            client.Send(System.Text.Encoding.UTF8.GetBytes(path), path.Length); //wysylamy gdzie

            byte[] nazwaByte = new byte[nazwaPlikuWrzut.Text.Length];
            nazwaByte = System.Text.Encoding.UTF8.GetBytes(nazwaPlikuWrzut.Text);
            client.Send(nazwaByte, nazwaByte.Length);  //wysylamy nazwe do utworzenia
            


            Pliki.Text = "";
            byte[] wiadomosc2 = new byte[100];
            wiadomosc2 = client.Receive(ref ep);
            string wiad = System.Text.Encoding.UTF8.GetString(wiadomosc2);
            if (wiad.Contains("."))
            {
                Info.Text = "brak wolnych portow";
                Info.Refresh();
            }
            else {
                UdpClient client2;   //57 logged , 48 not logged

                IPEndPoint ep2;
                client2 = new UdpClient();
                ep2 = new IPEndPoint(IPAddress.Parse(adres_IP), Convert.ToInt32(wiad)); // endpoint where server is listening
                client2.Connect(ep2);

                int gg = 0;
                int ilepakietow = 0;
                string wyslij = "";
                using (var reader = File.OpenText(@sciezka_Wrzuc.Text))
                {
                    string pomoc;
                    while ((pomoc = reader.ReadLine()) != null)
                    {

                        ilepakietow++;
                    }
                }
                StreamReader sr = new StreamReader(sciezka_Wrzuc.Text);
                wyslij = "";
                while (sr.Peek() >= 0)
                {
                    string zmienna = sr.ReadLine();
                    
                   
                    //C:\Users\Adrian\Desktop\plik.txt
                    gg++;
                    Info.Text = "wyslanych pakietow : " + Convert.ToString(gg) + "/" + Convert.ToString(ilepakietow);
                    Info.Refresh();
                    
                    
                        string dlugosc = Convert.ToString(zmienna.Length);
                        client2.Send(System.Text.Encoding.UTF8.GetBytes(dlugosc), dlugosc.Length);

                        client2.Send(System.Text.Encoding.UTF8.GetBytes(zmienna), zmienna.Length); //wysylamy pakiety
                        wyslij = "";
                   

                }

                if (wyslij.Length != 0)
                {
                    string dlugosc = Convert.ToString(wyslij.Length);
                    client2.Send(System.Text.Encoding.UTF8.GetBytes(dlugosc), dlugosc.Length);

                    client2.Send(System.Text.Encoding.UTF8.GetBytes(wyslij), wyslij.Length); //wysylamy pakiety

                }

                client2.Send(new byte[] { 49 }, 1); //wysylamy ze koniec odbioru
                client2.Send(new byte[] { 113 }, 1); //wysylamy ze koniec odbioru

                sr.Close();
                

                //  string wiad;
                    client.Send(new byte[] { 50 }, 1);
                while (true)
                {
                    byte[] wiadomosc = new byte[100];
                    wiadomosc = client2.Receive(ref ep);
                    wiad = System.Text.Encoding.UTF8.GetString(wiadomosc, 0, wiadomosc.Length);
                    if (wiad.Contains("q")) break;
                    Pliki.Text = Pliki.Text + wiad;
                    Pliki.AppendText(Environment.NewLine);
                }
                Info.Text = "plik zostal umieszczony na serverze";
                Info.Refresh();
                client2.Close();
            }
        }

        private void Sciagnij_Click(object sender, EventArgs e)
        {
            
                string wiad;
            byte[] wiadomosc = new byte[512];
            byte[] plik = new byte[path.Length+Plik.Text.Length+1];
            plik = System.Text.Encoding.UTF8.GetBytes(path+'/'+Plik.Text);
            
            client.Send(new byte[] { 57 }, 1); //wysylamy ze zalogowany
            client.Send(ServerLoginByte, ServerLoginByte.Length);
            client.Send(ServerHasloByte, ServerHasloByte.Length);
            client.Send(new byte[] { 52 }, 1); //wysylamy ze chcemy sciagnac
            client.Send(plik, plik.Length);

            byte[] wiadomosc2 = new byte[100];
            wiadomosc2 = client.Receive(ref ep);
            string wiad2 = System.Text.Encoding.UTF8.GetString(wiadomosc2);
            
            if (wiad2.Contains("."))
            {
                Info.Text = "brak wolnych portow";
                Info.Refresh();
            }
            else {
                UdpClient client2;   //57 logged , 48 not logged

                IPEndPoint ep2;
                client2 = new UdpClient();
                
                ep2 = new IPEndPoint(IPAddress.Parse(adres_IP), Convert.ToInt32(wiad2)); // endpoint where server is listening

                client2.Connect(ep2);
               
                client2.Send(new byte[] { 1 }, 1);
                wiadomosc = client2.Receive(ref ep2);
                
                wiad = System.Text.Encoding.UTF8.GetString(wiadomosc, 0, wiadomosc.Length);



                if (wiad[0] == '.')
                {
                    Info.Text = "";
                    Info.Text = "nie ma takiego pliku";
                    Info.Refresh();


                }
                else
                {
                    FileStream fs = File.Create(sciezkaZapis.Text);
                    
                    while (true)
                    {

                        fs.Write(wiadomosc, 0, wiadomosc.Length);
                        fs.Write(System.Text.Encoding.UTF8.GetBytes(System.Environment.NewLine), 0, Environment.NewLine.Length);
                        wiadomosc = client2.Receive(ref ep2);

                        if (wiadomosc[0] == '.') break;
                    }
                    fs.Close();
                }
                Info.Text = "sciaganie zakonczone pomyslnie";
                Info.Refresh();

            }
        }

        private void odswiez_Click(object sender, EventArgs e)
        {
            string wiad;
            byte[] wiadomosc = new byte[512];
            byte[] sciezka = new byte[path.Length];
            sciezka = System.Text.Encoding.UTF8.GetBytes(path);
            
            client.Send(new byte[] { 57 }, 1); //wysylamy ze zalogowany
            client.Send(ServerLoginByte, ServerLoginByte.Length);
            client.Send(ServerHasloByte, ServerHasloByte.Length);
            client.Send(new byte[] { 50 }, 1); //wysylamy ze chcemy wrzucic
            client.Send(sciezka, sciezka.Length); //path
            Pliki.Text = "";
            
            while (true)
            {
                wiadomosc = client.Receive(ref ep);
                wiad = System.Text.Encoding.UTF8.GetString(wiadomosc, 0, wiadomosc.Length);
                if (wiad.Contains("q")) break;
                Pliki.Text = Pliki.Text + wiad;
                Pliki.AppendText(Environment.NewLine);
             
            }
            
        }

        private void usun_Click(object sender, EventArgs e)
        {
            bool a = true;
            string pomoc = nazwaPlikuWrzut.Text;
            for (int i=0; i<pomoc.Length; i++)
            {
                if (pomoc[i] == ' ')
                {
                    a = false;
                    break;
                }
            }
            if (a == true)
            {
                string wiad = path + "/" + pomoc;

                byte[] wiadomosc = new byte[512];
                byte[] sciezka = new byte[wiad.Length];
                sciezka = System.Text.Encoding.UTF8.GetBytes(wiad);
                
                client.Send(new byte[] { 57 }, 1); //wysylamy ze zalogowany
                client.Send(ServerLoginByte, ServerLoginByte.Length);
                client.Send(ServerHasloByte, ServerHasloByte.Length);
                client.Send(new byte[] { 53 }, 1); //wysylamy ze chcemy usunac

                client.Send(sciezka, sciezka.Length); //path 
                wiadomosc = client.Receive(ref ep);
                wiad = System.Text.Encoding.UTF8.GetString(wiadomosc, 0, wiadomosc.Length);
                Info.Text = wiad;
                Info.Refresh();
            
            }
            else
            {
                Info.Text = "";
                Info.Text = "nazwa nie moze miec spacji";
                Info.Refresh();
            }
        }

        public void znikaj()
        {
            haslo.Visible = false;
            login.Visible = false;
            zaloguj.Visible = false;
            Zarejestruj.Visible = false;
            Wyloguj.Visible = true;
            sciezka_Wrzuc.Visible = true;
            sciezkaZapis.Visible = true;
            Plik.Visible = true;
            Sciagnij.Visible = true;
            Wrzuc.Visible = true;
            nazwaPlikuWrzut.Visible = true;
            odswiez.Visible = true;
            Pliki.Visible = true;
            usun.Visible = true;
        }
                                            //pojaw() i znikaj() do obslugi interfaceu
        public void pojaw()
        {
            haslo.Visible = true;
            login.Visible = true;
            zaloguj.Visible = true;
            Zarejestruj.Visible = true;
            Wyloguj.Visible = false;
            Pliki.Visible = false;
            sciezka_Wrzuc.Visible = false;
            sciezkaZapis.Visible = false;
            Plik.Visible = false;
            Sciagnij.Visible = false;
            Wrzuc.Visible = false;
            nazwaPlikuWrzut.Visible = false;
            odswiez.Visible = false;
            usun.Visible = false;
            Pliki.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Info_TextChanged(object sender, EventArgs e)
        {

        }
        private void haslo_TextChanged(object sender, EventArgs e)
        {

        }
        private void Pliki_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
