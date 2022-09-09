using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;

namespace RISTORANTE
{
    public partial class Form1 : Form
    {
        const string fileNameP = @"./loginProprietario.txt";
        const string filePiatti = @"./piatti.txt";
        int window = 0;
        bool proprietario = true;
        float totale = 0;

        string nomeProprietario = "Mario";
        string passwordProprietario = "Mario2005";
        string emailProprietario = "botezmariocosmin@gmail.com";
        bool showPassP = false;

        bool Ant1 = false;
        bool Ant2 = false;
        bool Ant3 = false;
        bool Prim1 = false;
        bool Prim2 = false;
        bool Prim3 = false;
        bool Prim4 = false;
        bool Sec1 = false;
        bool Sec2 = false;
        bool Sec3 = false;
        bool Sec4 = false;
        bool Des1 = false;
        bool Des2 = false;
        bool Des3 = false;

        public struct piatto
        {
            public string nome;
            public float prezzo;
            public string portata;
            public string ingrediente1;
            public string ingrediente2;
            public string ingrediente3;
            public string ingrediente4;
        }


        public Form1()
        {
            InitializeComponent();
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnShowPass.BackgroundImageLayout = ImageLayout.Stretch;
            pnlPrincipale.Location = new Point(0,0);

            //proprietario
            pnlAccesso.Hide();            
            pnlForgotPassword.Hide();
            pnlEmailInviata.Hide();
            pnlPin.Hide();
            lblNuovaPass.Hide();
            textBoxNuovaPass.Hide();
            btnOK3.Hide();
            pnlPrincipale.Hide();
            pnlCliente.Hide();

            passwordProprietario = leggiPasswordP(fileNameP);
            scrivi(nomeProprietario, passwordProprietario, fileNameP);

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPINCheck.Hide();
            pnlAccesso.Location = new Point(271, 146);
            pnlForgotPassword.Location = new Point(295, 132);
            pnlEmailInviata.Location = new Point(295, 132);
            pnlPin.Location = new Point(295, 132);
            pnlCliente.Location = new Point(295, 132);
            this.pnlAggiungi.Location = new Point(200,0);
            this.pnlGestisciMenu.Location = new Point(200, 0);

            pictureBoxMenu.Hide();
            pnlAggiungi.Hide();

            //scritta trasparente sopra il libro
            lblNomeRistoranteProp.Location = pictureBoxMenu.PointToClient(lblNomeRistoranteProp.Parent.PointToScreen(lblNomeRistoranteProp.Location));
            lblNomeRistoranteProp.Parent = pictureBoxMenu;
            lblNomeRistoranteProp.BackColor = Color.Transparent;
            lblAntipasti.Location = pictureBoxMenu.PointToClient(lblAntipasti.Parent.PointToScreen(lblAntipasti.Location));
            lblAntipasti.Parent = pictureBoxMenu;
            lblAntipasti.BackColor = Color.Transparent;
            lblAntipasto1.Location = pictureBoxMenu.PointToClient(lblAntipasto1.Parent.PointToScreen(lblAntipasto1.Location));
            lblAntipasto1.Parent = pictureBoxMenu;
            lblAntipasto1.BackColor = Color.Transparent;
            lblAntipasto2.Location = pictureBoxMenu.PointToClient(lblAntipasto2.Parent.PointToScreen(lblAntipasto2.Location));
            lblAntipasto2.Parent = pictureBoxMenu;
            lblAntipasto2.BackColor = Color.Transparent;
            lblAntipasto3.Location = pictureBoxMenu.PointToClient(lblAntipasto3.Parent.PointToScreen(lblAntipasto3.Location));
            lblAntipasto3.Parent = pictureBoxMenu;
            lblAntipasto3.BackColor = Color.Transparent;
            lblAntipasto1Ingr.Location = pictureBoxMenu.PointToClient(lblAntipasto1Ingr.Parent.PointToScreen(lblAntipasto1Ingr.Location));
            lblAntipasto1Ingr.Parent = pictureBoxMenu;
            lblAntipasto1Ingr.BackColor = Color.Transparent;
            lblAntipasto2Ingr.Location = pictureBoxMenu.PointToClient(lblAntipasto2Ingr.Parent.PointToScreen(lblAntipasto2Ingr.Location));
            lblAntipasto2Ingr.Parent = pictureBoxMenu;
            lblAntipasto2Ingr.BackColor = Color.Transparent;
            lblAntipasto3Ingr.Location = pictureBoxMenu.PointToClient(lblAntipasto3Ingr.Parent.PointToScreen(lblAntipasto3Ingr.Location));
            lblAntipasto3Ingr.Parent = pictureBoxMenu;
            lblAntipasto3Ingr.BackColor = Color.Transparent;
            lblAntipasto1Prezzo.Location = pictureBoxMenu.PointToClient(lblAntipasto1Prezzo.Parent.PointToScreen(lblAntipasto1Prezzo.Location));
            lblAntipasto1Prezzo.Parent = pictureBoxMenu;
            lblAntipasto1Prezzo.BackColor = Color.Transparent;
            lblAntipasto2Prezzo.Location = pictureBoxMenu.PointToClient(lblAntipasto2Prezzo.Parent.PointToScreen(lblAntipasto2Prezzo.Location));
            lblAntipasto2Prezzo.Parent = pictureBoxMenu;
            lblAntipasto2Prezzo.BackColor = Color.Transparent;
            lblAntipasto3Prezzo.Location = pictureBoxMenu.PointToClient(lblAntipasto3Prezzo.Parent.PointToScreen(lblAntipasto3Prezzo.Location));
            lblAntipasto3Prezzo.Parent = pictureBoxMenu;
            lblAntipasto3Prezzo.BackColor = Color.Transparent;
            lblPrimi.Location = pictureBoxMenu.PointToClient(lblPrimi.Parent.PointToScreen(lblPrimi.Location));
            lblPrimi.Parent = pictureBoxMenu;
            lblPrimi.BackColor = Color.Transparent;
            lblSecondi.Location = pictureBoxMenu.PointToClient(lblSecondi.Parent.PointToScreen(lblSecondi.Location));
            lblSecondi.Parent = pictureBoxMenu;
            lblSecondi.BackColor = Color.Transparent;
            lblDessert.Location = pictureBoxMenu.PointToClient(lblDessert.Parent.PointToScreen(lblDessert.Location));
            lblDessert.Parent = pictureBoxMenu;
            lblDessert.BackColor = Color.Transparent;
            lblPrimo1.Location = pictureBoxMenu.PointToClient(lblPrimo1.Parent.PointToScreen(lblPrimo1.Location));
            lblPrimo1.Parent = pictureBoxMenu;
            lblPrimo1.BackColor = Color.Transparent;
            lblPrimo2.Location = pictureBoxMenu.PointToClient(lblPrimo2.Parent.PointToScreen(lblPrimo2.Location));
            lblPrimo2.Parent = pictureBoxMenu;
            lblPrimo2.BackColor = Color.Transparent;
            lblPrimo3.Location = pictureBoxMenu.PointToClient(lblPrimo3.Parent.PointToScreen(lblPrimo3.Location));
            lblPrimo3.Parent = pictureBoxMenu;
            lblPrimo3.BackColor = Color.Transparent;
            lblPrimo4.Location = pictureBoxMenu.PointToClient(lblPrimo4.Parent.PointToScreen(lblPrimo4.Location));
            lblPrimo4.Parent = pictureBoxMenu;
            lblPrimo4.BackColor = Color.Transparent;
            lblPrimo1Ingr.Location = pictureBoxMenu.PointToClient(lblPrimo1Ingr.Parent.PointToScreen(lblPrimo1Ingr.Location));
            lblPrimo1Ingr.Parent = pictureBoxMenu;
            lblPrimo1Ingr.BackColor = Color.Transparent;
            lblPrimo2Ingr.Location = pictureBoxMenu.PointToClient(lblPrimo2Ingr.Parent.PointToScreen(lblPrimo2Ingr.Location));
            lblPrimo2Ingr.Parent = pictureBoxMenu;
            lblPrimo2Ingr.BackColor = Color.Transparent;
            lblPrimo3Ingr.Location = pictureBoxMenu.PointToClient(lblPrimo3Ingr.Parent.PointToScreen(lblPrimo3Ingr.Location));
            lblPrimo3Ingr.Parent = pictureBoxMenu;
            lblPrimo3Ingr.BackColor = Color.Transparent;
            lblPrimo4Ingr.Location = pictureBoxMenu.PointToClient(lblPrimo4Ingr.Parent.PointToScreen(lblPrimo4Ingr.Location));
            lblPrimo4Ingr.Parent = pictureBoxMenu;
            lblPrimo4Ingr.BackColor = Color.Transparent;
            lblPrimo1Prezzo.Location = pictureBoxMenu.PointToClient(lblPrimo1Prezzo.Parent.PointToScreen(lblPrimo1Prezzo.Location));
            lblPrimo1Prezzo.Parent = pictureBoxMenu;
            lblPrimo1Prezzo.BackColor = Color.Transparent;
            lblPrimo2Prezzo.Location = pictureBoxMenu.PointToClient(lblPrimo2Prezzo.Parent.PointToScreen(lblPrimo2Prezzo.Location));
            lblPrimo2Prezzo.Parent = pictureBoxMenu;
            lblPrimo2Prezzo.BackColor = Color.Transparent;
            lblPrimo3Prezzo.Location = pictureBoxMenu.PointToClient(lblPrimo3Prezzo.Parent.PointToScreen(lblPrimo3Prezzo.Location));
            lblPrimo3Prezzo.Parent = pictureBoxMenu;
            lblPrimo3Prezzo.BackColor = Color.Transparent;
            lblPrimo4Prezzo.Location = pictureBoxMenu.PointToClient(lblPrimo4Prezzo.Parent.PointToScreen(lblPrimo4Prezzo.Location));
            lblPrimo4Prezzo.Parent = pictureBoxMenu;
            lblPrimo4Prezzo.BackColor = Color.Transparent;
            lblSecondo1.Location = pictureBoxMenu.PointToClient(lblSecondo1.Parent.PointToScreen(lblSecondo1.Location));
            lblSecondo1.Parent = pictureBoxMenu;
            lblSecondo1.BackColor = Color.Transparent;
            lblSecondo2.Location = pictureBoxMenu.PointToClient(lblSecondo2.Parent.PointToScreen(lblSecondo2.Location));
            lblSecondo2.Parent = pictureBoxMenu;
            lblSecondo2.BackColor = Color.Transparent;
            lblSecondo3.Location = pictureBoxMenu.PointToClient(lblSecondo3.Parent.PointToScreen(lblSecondo3.Location));
            lblSecondo3.Parent = pictureBoxMenu; 
            lblSecondo3.BackColor = Color.Transparent;
            lblSecondo4.Location = pictureBoxMenu.PointToClient(lblSecondo4.Parent.PointToScreen(lblSecondo4.Location));
            lblSecondo4.Parent = pictureBoxMenu;
            lblSecondo4.BackColor = Color.Transparent;
            lblSecondo1Ingr.Location = pictureBoxMenu.PointToClient(lblSecondo1Ingr.Parent.PointToScreen(lblSecondo1Ingr.Location));
            lblSecondo1Ingr.Parent = pictureBoxMenu;
            lblSecondo1Ingr.BackColor = Color.Transparent;
            lblSecondo2Ingr.Location = pictureBoxMenu.PointToClient(lblSecondo2Ingr.Parent.PointToScreen(lblSecondo2Ingr.Location));
            lblSecondo2Ingr.Parent = pictureBoxMenu;
            lblSecondo2Ingr.BackColor = Color.Transparent;
            lblSecondo3Ingr.Location = pictureBoxMenu.PointToClient(lblSecondo3Ingr.Parent.PointToScreen(lblSecondo3Ingr.Location));
            lblSecondo3Ingr.Parent = pictureBoxMenu;
            lblSecondo3Ingr.BackColor = Color.Transparent;
            lblSecondo4Ingr.Location = pictureBoxMenu.PointToClient(lblSecondo4Ingr.Parent.PointToScreen(lblSecondo4Ingr.Location));
            lblSecondo4Ingr.Parent = pictureBoxMenu;
            lblSecondo4Ingr.BackColor = Color.Transparent;
            lblSecondo1Prezzo.Location = pictureBoxMenu.PointToClient(lblSecondo1Prezzo.Parent.PointToScreen(lblSecondo1Prezzo.Location));
            lblSecondo1Prezzo.Parent = pictureBoxMenu;
            lblSecondo1Prezzo.BackColor = Color.Transparent;
            lblSecondo2Prezzo.Location = pictureBoxMenu.PointToClient(lblSecondo2Prezzo.Parent.PointToScreen(lblSecondo2Prezzo.Location));
            lblSecondo2Prezzo.Parent = pictureBoxMenu;
            lblSecondo2Prezzo.BackColor = Color.Transparent;
            lblSecondo3Prezzo.Location = pictureBoxMenu.PointToClient(lblSecondo3Prezzo.Parent.PointToScreen(lblSecondo3Prezzo.Location));
            lblSecondo3Prezzo.Parent = pictureBoxMenu;
            lblSecondo3Prezzo.BackColor = Color.Transparent;
            lblSecondo4Prezzo.Location = pictureBoxMenu.PointToClient(lblSecondo4Prezzo.Parent.PointToScreen(lblSecondo4Prezzo.Location));
            lblSecondo4Prezzo.Parent = pictureBoxMenu;
            lblSecondo4Prezzo.BackColor = Color.Transparent;
            lblDessert1.Location = pictureBoxMenu.PointToClient(lblDessert1.Parent.PointToScreen(lblDessert1.Location));
            lblDessert1.Parent = pictureBoxMenu;
            lblDessert1.BackColor = Color.Transparent;
            lblDessert2.Location = pictureBoxMenu.PointToClient(lblDessert2.Parent.PointToScreen(lblDessert2.Location));
            lblDessert2.Parent = pictureBoxMenu;
            lblDessert2.BackColor = Color.Transparent;
            lblDessert3.Location = pictureBoxMenu.PointToClient(lblDessert3.Parent.PointToScreen(lblDessert3.Location));
            lblDessert3.Parent = pictureBoxMenu;
            lblDessert3.BackColor = Color.Transparent;
            lblDessert1Ingr.Location = pictureBoxMenu.PointToClient(lblDessert1Ingr.Parent.PointToScreen(lblDessert1Ingr.Location));
            lblDessert1Ingr.Parent = pictureBoxMenu;
            lblDessert1Ingr.BackColor = Color.Transparent;
            lblDessert2Ingr.Location = pictureBoxMenu.PointToClient(lblDessert2Ingr.Parent.PointToScreen(lblDessert2Ingr.Location));
            lblDessert2Ingr.Parent = pictureBoxMenu;
            lblDessert2Ingr.BackColor = Color.Transparent;
            lblDessert3Ingr.Location = pictureBoxMenu.PointToClient(lblDessert3Ingr.Parent.PointToScreen(lblDessert3Ingr.Location));
            lblDessert3Ingr.Parent = pictureBoxMenu;
            lblDessert3Ingr.BackColor = Color.Transparent;
            lblDessert1Prezzo.Location = pictureBoxMenu.PointToClient(lblDessert1Prezzo.Parent.PointToScreen(lblDessert1Prezzo.Location));
            lblDessert1Prezzo.Parent = pictureBoxMenu;
            lblDessert1Prezzo.BackColor = Color.Transparent;
            lblDessert2Prezzo.Location = pictureBoxMenu.PointToClient(lblDessert2Prezzo.Parent.PointToScreen(lblDessert2Prezzo.Location));
            lblDessert2Prezzo.Parent = pictureBoxMenu;
            lblDessert2Prezzo.BackColor = Color.Transparent;
            lblDessert3Prezzo.Location = pictureBoxMenu.PointToClient(lblDessert3Prezzo.Parent.PointToScreen(lblDessert3Prezzo.Location));
            lblDessert3Prezzo.Parent = pictureBoxMenu;
            lblDessert3Prezzo.BackColor = Color.Transparent;
            lblPriceA.Location = pictureBoxMenu.PointToClient(lblPriceA.Parent.PointToScreen(lblPriceA.Location));
            lblPriceA.Parent = pictureBoxMenu;
            lblPriceA.BackColor = Color.Transparent;
            lblPriceB.Location = pictureBoxMenu.PointToClient(lblPriceB.Parent.PointToScreen(lblPriceB.Location));
            lblPriceB.Parent = pictureBoxMenu;
            lblPriceB.BackColor = Color.Transparent;
        }

        private void btnProprietario_Click(object sender, EventArgs e)
        {
            pnlAccesso.Show();
            pnlForgotPassword.Hide();
            pnlEmailInviata.Hide();
            pnlPin.Hide();
            window = 1;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            window = 10;
            pnlCliente.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            textBoxNome.Text = "";
            textBoxPassword.Text = "";
            textBoxPinC.Text = "";
            textBoxNuovaPass.Text = "";
            textBoxEmail.Text = "";

            if (window == 1)
            {
                pnlAccesso.Hide();
                pnlForgotPassword.Hide();
                pnlEmailInviata.Hide();
                pnlPin.Hide();
                window = 0;
            }
            else if (window == 2)
            {
                pnlAccesso.Show();
                pnlForgotPassword.Hide();
                pnlEmailInviata.Hide();
                pnlPin.Hide();
                window = 1;
            }
            else if (window == 3)
            {
                pnlEmailInviata.Show();
                pnlAccesso.Hide();
                pnlForgotPassword.Hide();
                pnlPin.Hide();
                window = 4;
            }
            else if (window == 4)
            {
                pnlEmailInviata.Hide();
                pnlAccesso.Hide();
                pnlForgotPassword.Hide();
                pnlPin.Show();
                window = 0;
            }
            else if (window == 10)
            {
                pnlCliente.Hide();
                window = 0;
            }
            
        }

        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlForgotPassword.Show();
            pnlAccesso.Hide();
            pnlEmailInviata.Hide();
            pnlPin.Hide();
            window = 2;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string userEmail = textBoxEmail.Text;
            if (userEmail != emailProprietario)
            {
                MessageBox.Show("L'email non corrisponde a quella con cui si è registrati.");
                textBoxEmail.Text = "";
                return;
            }
            int pin = sendEmail(userEmail);
            textBoxPINCheck.Text = Convert.ToString(pin);
            textBoxEmail.Text = "";
            pnlEmailInviata.Show();
            pnlAccesso.Hide();
            pnlForgotPassword.Hide();
            pnlPin.Hide();
            window = 3; 
        }

        public static int sendEmail(string userEmail)
        {
            string fromMail = "boteznoreply@gmail.com";
            string fromPassword = "yuwllbjajuurqzcv";
            int pin = pinGenerate();

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Reimposta password";
            message.To.Add(new MailAddress(userEmail));
            message.Body = "<html><body> Per reimpostare la password dell'account di BOTEZ'S RESTAURANT inserire il seguente codice: " + pin + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
            return pin;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pnlPin.Show();
            pnlAccesso.Hide();
            pnlForgotPassword.Hide();
            pnlEmailInviata.Hide();
            window = 4;
        }

        public static int pinGenerate()
        {
            Random rnd = new Random();
            int x = rnd.Next(10000, 100000);
            return x;
        }

        private void lblOK2_Click(object sender, EventArgs e)
        {
            try
            {
                int pincheck = Convert.ToInt32(textBoxPinC.Text);
                int pinCorrect = Convert.ToInt32(textBoxPINCheck.Text);

                if (pincheck == pinCorrect)
                {
                    lblInserisciPin.Hide();
                    textBoxPinC.Hide();
                    lblOK2.Hide();
                    lblNuovaPass.Show();
                    textBoxNuovaPass.Show();
                    btnOK3.Show();
                }
                else
                {
                    textBoxPinC.Text = "";
                    MessageBox.Show("Pin errato!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Pin errato! Il pin contiene 6 cifre.");
            }


        }

        private void btnAccedi_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            btnOrdinaAntipasto1.Hide();
            btnOrdinaAntipasto2.Hide();
            btnOrdinaAntipasto3.Hide();
            btnOrdinaPrimo1.Hide();
            btnOrdinaPrimo2.Hide();
            btnOrdinaPrimo3.Hide();
            btnOrdinaPrimo4.Hide();
            btnOrdinaSecondo1.Hide();
            btnOrdinaSecondo2.Hide();
            btnOrdinaSecondo3.Hide();
            btnOrdinaSecondo4.Hide();
            btnOrdinaDessert1.Hide();
            btnOrdinaDessert2.Hide();
            btnOrdinaDessert3.Hide();

            string checkName = textBoxNome.Text;
            string checkPassword = textBoxPassword.Text;

            if (leggiNomeP(fileNameP) == checkName)
            {
                if (leggiPasswordP(fileNameP) == checkPassword)
                {
                    pnlAccesso.Hide();
                    pnlGestisciMenu.Hide();
                    pnlPrincipale.Show();
                    lblNomeProprietario.Text = nomeProprietario;
                    proprietario = true;
                }
                else
                {
                    MessageBox.Show("Credenziali errate.");
                }
            }
            else
                MessageBox.Show("Credenziali errate.");

            textBoxNome.Text = "";
            textBoxPassword.Text = "";
        }

        public static void scrivi(string content, string content2, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(content);
            sw.WriteLine(content2);
            sw.Close();
        }

        public static string leggiNomeP(string filename)
        {
            StreamReader sr = new StreamReader(fileNameP);
            string nome = sr.ReadLine();
            sr.Close();
            return nome;
        }

        public static string leggiPasswordP(string filename)
        {
            StreamReader sr = new StreamReader(fileNameP);
            string nome = sr.ReadLine();
            string password = sr.ReadLine();
            sr.Close();
            return password;
        }

        private void btnOK3_Click(object sender, EventArgs e) //pulsante cambia password proprietario
        {
            string nuovaPassP = textBoxNuovaPass.Text;
            scrivi(nomeProprietario, nuovaPassP, fileNameP);
            textBoxNuovaPass.Text = "";
            MessageBox.Show("Nuova password impostata");
            pnlPin.Hide();
            window = 0;
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (showPassP == false)
            {
                textBoxPassword.UseSystemPasswordChar = false;
                btnShowPass.BackgroundImage = Properties.Resources.HidePass;
                showPassP = true;
                return;
            }
            else if (showPassP == true)
            {
                textBoxPassword.UseSystemPasswordChar = true;
                btnShowPass.BackgroundImage = Properties.Resources.ShowPass;
                showPassP = false;
            }

        }

        private void btnEsci_Click(object sender, EventArgs e)
        {
            window = 0;
            pnlPrincipale.Hide();
            rimuoviOrdine();
        }

        void rimuoviOrdine()//rimuove valori ordine in caso di logout
        {
            btnOrdinaAntipasto1.Text = "";
            btnOrdinaAntipasto2.Text = "";
            btnOrdinaAntipasto3.Text = "";
            btnOrdinaPrimo1.Text = "";
            btnOrdinaPrimo2.Text = "";
            btnOrdinaPrimo3.Text = "";
            btnOrdinaPrimo4.Text = "";
            btnOrdinaSecondo1.Text = "";
            btnOrdinaSecondo2.Text = "";
            btnOrdinaSecondo3.Text = "";
            btnOrdinaSecondo4.Text = "";
            btnOrdinaDessert1.Text = "";
            btnOrdinaDessert2.Text = "";
            btnOrdinaDessert3.Text = "";
            Prim1 = false;
            Prim2 = false;
            Prim3 = false;
            Prim4 = false;
            Ant1 = false;
            Ant2 = false;
            Ant3 = false;
            Sec1 = false;
            Sec2 = false;
            Sec3 = false;
            Sec4 = false;
            Des1 = false;
            Des2 = false;
            Des3 = false;
            textBoxTotale.Text = "0,00€";
            totale = 0;
        }

        private void btnVisualizzaMenu_Click(object sender, EventArgs e)
        {
            pnlAggiungi.Hide();
            pictureBoxMenu.Show();

            if (proprietario == true)
            {
                nascondiPulsantiOrdine();
            }
            else if (proprietario == false)
            {
                mostraPulsantiOrdine();
            }

            int ant = 0, prim = 0, seco = 0, des = 0;
            int esist = provaEsistenzaStringa();

            for (int j = 0; j < esist; j++)
            {
                string stringaPiatto = leggiPiatto(filePiatti, j);
                string[] piattoDiviso = stringaPiatto.Split(new char[] { ';' });

                string[] array = new string[20];
                int i = 0;

                foreach (var sub in piattoDiviso)
                {
                    array[i] = ($"{sub}");
                    i++;
                }

                if (array[2] == "antipasto" && ant < 3)
                {
                    if (ant == 0)
                    {
                        lblAntipasto1.Text = array[0];
                        lblAntipasto1Prezzo.Text = array[1];
                        lblAntipasto1Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        ant = 1;
                    }
                    else if (ant == 1)
                    {
                        lblAntipasto2.Text = array[0];
                        lblAntipasto2Prezzo.Text = array[1];
                        lblAntipasto2Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        ant = 2;
                    }
                    else if (ant == 2)
                    {
                        lblAntipasto3.Text = array[0];
                        lblAntipasto3Prezzo.Text = array[1];
                        lblAntipasto3Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        ant = 3;
                    }
                }
                else if (array[2] == "primo" && prim < 4)
                {
                    if (prim == 0)
                    {
                        lblPrimo1.Text = array[0];
                        lblPrimo1Prezzo.Text = array[1];
                        lblPrimo1Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        prim = 1;
                    }
                    else if (prim == 1)
                    {
                        lblPrimo2.Text = array[0];
                        lblPrimo2Prezzo.Text = array[1];
                        lblPrimo2Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        prim = 2;
                    }
                    else if (prim == 2)
                    {
                        lblPrimo3.Text = array[0];
                        lblPrimo3Prezzo.Text = array[1];
                        lblPrimo3Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        prim = 3;
                    }
                    else if (prim == 3)
                    {
                        lblPrimo4.Text = array[0];
                        lblPrimo4Prezzo.Text = array[1];
                        lblPrimo4Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        prim = 4;
                    }
                }
                else if (array[2] == "secondo" && seco < 4)
                {
                    if (seco == 0)
                    {
                        lblSecondo1.Text = array[0];
                        lblSecondo1Prezzo.Text = array[1];
                        lblSecondo1Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        seco = 1;
                    }
                    else if (seco == 1)
                    {
                        lblSecondo2.Text = array[0];
                        lblSecondo2Prezzo.Text = array[1];
                        lblSecondo2Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        seco = 2;
                    }
                    else if (seco == 2)
                    {
                        lblSecondo3.Text = array[0];
                        lblSecondo3Prezzo.Text = array[1];
                        lblSecondo3Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        seco = 3;
                    }
                    else if (seco == 3)
                    {
                        lblSecondo4.Text = array[0];
                        lblSecondo4Prezzo.Text = array[1];
                        lblSecondo4Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        seco = 4;
                    }
                }
                else if (array[2] == "dessert" && des < 3)
                {
                    if (des == 0)
                    {
                        lblDessert1.Text = array[0];
                        lblDessert1Prezzo.Text = array[1];
                        lblDessert1Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        des = 1;
                    }
                    else if (des == 1)
                    {
                        lblDessert2.Text = array[0];
                        lblDessert2Prezzo.Text = array[1];
                        lblDessert2Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        des = 2;
                    }
                    else if (des == 2)
                    {
                        lblDessert3.Text = array[0];
                        lblDessert3Prezzo.Text = array[1];
                        lblDessert3Ingr.Text = array[3] + ", " + array[4] + ", " + array[5] + ", " + array[6];
                        des = 3;
                    }
                }
                else
                {
                    j = 14;
                }

            }

            if (lblAntipasto1.Text == "Antipasto1")
            {
                lblAntipasto1.Hide();
                lblAntipasto1Ingr.Hide();
                lblAntipasto1Prezzo.Hide();
                btnOrdinaAntipasto1.Hide();
            }
            else
            {
                lblAntipasto1.Show();
                lblAntipasto1Ingr.Show();
                lblAntipasto1Prezzo.Show();
                btnOrdinaAntipasto1.Show();
            }

            if (lblAntipasto2.Text != "Antipasto2")
            {
                lblAntipasto2.Show();
                lblAntipasto2Ingr.Show();
                lblAntipasto2Prezzo.Show();
                btnOrdinaAntipasto2.Show();
            }
            else
            {
                lblAntipasto2.Hide();
                lblAntipasto2Ingr.Hide();
                lblAntipasto2Prezzo.Hide();
                btnOrdinaAntipasto2.Hide();
            }

            if (lblAntipasto3.Text != "Antipasto3")
            {
                lblAntipasto3.Show();
                lblAntipasto3Ingr.Show();
                lblAntipasto3Prezzo.Show();
                btnOrdinaAntipasto3.Show();
            }
            else
            {
                lblAntipasto3.Hide();
                lblAntipasto3Ingr.Hide();
                lblAntipasto3Prezzo.Hide();
                btnOrdinaAntipasto3.Hide();
            }


            if (lblPrimo1.Text != "Primo1")
            {
                lblPrimo1.Show();
                lblPrimo1Ingr.Show();
                lblPrimo1Prezzo.Show();
                btnOrdinaPrimo1.Show();
            }
            else
            {
                lblPrimo1.Hide();
                lblPrimo1Ingr.Hide();
                lblPrimo1Prezzo.Hide();
                btnOrdinaPrimo1.Hide();
            }

            if (lblPrimo2.Text != "Primo2")
            {
                lblPrimo2.Show();
                lblPrimo2Ingr.Show();
                lblPrimo2Prezzo.Show();
                btnOrdinaPrimo2.Show();
            }
            else
            {
                lblPrimo2.Hide();
                lblPrimo2Ingr.Hide();
                lblPrimo2Prezzo.Hide();
                btnOrdinaPrimo2.Hide();
            }

            if (lblPrimo3.Text != "Primo3")
            {
                lblPrimo3.Show();
                lblPrimo3Ingr.Show();
                lblPrimo3Prezzo.Show();
                btnOrdinaPrimo3.Show();
            }
            else
            {
                lblPrimo3.Hide();
                lblPrimo3Ingr.Hide();
                lblPrimo3Prezzo.Hide();
                btnOrdinaPrimo3.Hide();
            }

            if (lblPrimo4.Text != "Primo4")
            {
                lblPrimo4.Show();
                lblPrimo4Ingr.Show();
                lblPrimo4Prezzo.Show();
                btnOrdinaPrimo4.Show();
            }
            else
            {
                lblPrimo4.Hide();
                lblPrimo4Ingr.Hide();
                lblPrimo4Prezzo.Hide();
                btnOrdinaPrimo4.Hide();
            }
        }

        private void btnAggiungiPiatto_Click(object sender, EventArgs e)
        {
            pictureBoxMenu.Hide();
            pnlAggiungi.Show();
        }

        public static string leggiPiatto(string filename, int j)
        {
            StreamReader sr = new StreamReader(filePiatti);
            for (int i = 0; i <= j; i++)
            {
                string piatto = sr.ReadLine();
                if (j == i)
                {
                    sr.Close();
                    return piatto;
                }
            }
            return "////";

        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e) //preme accedi quando si clicca enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAccedi_Click(this, new EventArgs());
            }
        }

        public static int provaEsistenzaStringa()
        {
            string[] array = new string[14];
            for (int i = 0; i < 14; i++)
            {
                array[i] = leggiPiatto(filePiatti, i);
                if (array[i] == null)
                {
                    return i;
                }
            }
            return 0;
        }

        private void btnAggiungiPiattoInvia_Click(object sender, EventArgs e)
        {

            try
            {
                piatto p;
                p.nome = textBoxAggiungiNome.Text;
                p.prezzo = float.Parse(textBoxAggiungiPrezzo.Text);

                p.portata = comboBoxPortata.Text;
                p.ingrediente1 = textBoxAggiungiIng1.Text;
                p.ingrediente2 = textBoxAggiungiIng2.Text;
                p.ingrediente3 = textBoxAggiungiIng3.Text;
                p.ingrediente4 = textBoxAggiungiIng4.Text;

                scriviPiatto(p, filePiatti);
            }
            catch
            {
                MessageBox.Show("prezzo non valido.");
            }
            textBoxAggiungiNome.Text = "";
            textBoxAggiungiPrezzo.Text = "";
            comboBoxPortata.Text = "";
            textBoxAggiungiIng1.Text = "";
            textBoxAggiungiIng2.Text = "";
            textBoxAggiungiIng3.Text = "";
            textBoxAggiungiIng4.Text = "";
        }

        public static void scriviPiatto(piatto p, string filename)
        {
            string s = ";";
            StreamWriter sw = new StreamWriter(filename, append: true);
            sw.WriteLine(p.nome + s + p.prezzo + s + p.portata + s + p.ingrediente1 + s + p.ingrediente2 + s + p.ingrediente3 + s + p.ingrediente4 + s );
            sw.Close();
        }

        private void btnCercaPiatto_Click(object sender, EventArgs e)
        {
            pictureBoxMenu.Hide();
            pnlAggiungi.Hide();
        }

        private void btnOrdinaAntipasto1_Click(object sender, EventArgs e)
        {
            if (lblAntipasto1.Text != "Antipasto1")
            {
                if (Ant1 == false)
                {
                    btnOrdinaAntipasto1.Text = "X";
                    totale = totale + float.Parse(lblAntipasto1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Ant1 = true;
                }
                else if (Ant1 == true)
                {
                    btnOrdinaAntipasto1.Text = null;
                    totale = totale - float.Parse(lblAntipasto1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €"; ;
                    Ant1 = false;
                }
            }    
        }

        private void btnOrdinaAntipasto2_Click(object sender, EventArgs e)
        {
            if (lblAntipasto2.Text != "Antipasto2")
            {
                if (Ant2 == false)
                {
                    btnOrdinaAntipasto2.Text = "X";
                    totale = totale + float.Parse(lblAntipasto2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Ant2 = true;
                }
                else if (Ant2 == true)
                {
                    btnOrdinaAntipasto2.Text = null;
                    totale = totale - float.Parse(lblAntipasto2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Ant2 = false;
                }
            }
        }

        private void btnOrdinaAntipasto3_Click(object sender, EventArgs e)
        {
            if (lblAntipasto3.Text != "Antipasto3")
            {
                if (Ant3 == false)
                {
                    btnOrdinaAntipasto3.Text = "X";
                    totale = totale + float.Parse(lblAntipasto3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Ant3 = true;
                }
                else if (Ant3 == true)
                {
                    btnOrdinaAntipasto3.Text = null;
                    totale = totale - float.Parse(lblAntipasto3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Ant3 = false;
                }
            }
        }

        private void btnEliminaPiatto_Click(object sender, EventArgs e)
        {
            pnlAggiungi.Hide();
            pictureBoxMenu.Show();
        }

        private void btnbtnGestisciMenu_Click(object sender, EventArgs e)
        {
            pictureBoxMenu.Hide();
            pnlAggiungi.Hide();
            pnlGestisciMenu.Show();
        }

        private void btnClienteOspite_Click(object sender, EventArgs e)
        {
            proprietario = false;
            pnlCliente.Hide();
            pnlGestisciMenu.Hide();
            btnAggiungiPiatto.Hide();
            btnGestisciMenu.Hide();
            pictureBoxMenu.Hide();
            lblNomeProprietario.Text = "Ospite";
            nascondiPulsantiOrdine();
            panel3.Show();
            pnlPrincipale.Show();
        }

        public void nascondiPulsantiOrdine()
        {
            btnOrdinaAntipasto1.Hide();
            btnOrdinaAntipasto2.Hide();
            btnOrdinaAntipasto3.Hide();
            btnOrdinaPrimo1.Hide();
            btnOrdinaPrimo2.Hide();
            btnOrdinaPrimo3.Hide();
            btnOrdinaPrimo4.Hide();
            btnOrdinaSecondo1.Hide();
            btnOrdinaSecondo2.Hide();
            btnOrdinaSecondo3.Hide();
            btnOrdinaSecondo4.Hide();
            btnOrdinaDessert1.Hide();
            btnOrdinaDessert2.Hide();
            btnOrdinaDessert3.Hide();
        }

        public void mostraPulsantiOrdine()
        {
            btnOrdinaAntipasto1.Show();
            btnOrdinaAntipasto2.Show();
            btnOrdinaAntipasto3.Show();
            btnOrdinaPrimo1.Show();
            btnOrdinaPrimo2.Show();
            btnOrdinaPrimo3.Show();
            btnOrdinaPrimo4.Show();
            btnOrdinaSecondo1.Show();
            btnOrdinaSecondo2.Show();
            btnOrdinaSecondo3.Show();
            btnOrdinaSecondo4.Show();
            btnOrdinaDessert1.Show();
            btnOrdinaDessert2.Show();
            btnOrdinaDessert3.Show();
        }

        private void btnOrdinaPrimo1_Click(object sender, EventArgs e)
        {
            if (lblPrimo1.Text != "Primo1")
            {
                if (Prim1 == false)
                {
                    btnOrdinaPrimo1.Text = "X";
                    totale = totale + float.Parse(lblPrimo1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim1 = true;
                }
                else if (Prim1 == true)
                {
                    btnOrdinaPrimo1.Text = null;
                    totale = totale - float.Parse(lblPrimo1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim1 = false;
                }
            }
        }

        private void btnOrdinaPrimo2_Click(object sender, EventArgs e)
        {
            if (lblPrimo2.Text != "Primo2")
            {
                if (Prim2 == false)
                {
                    btnOrdinaPrimo2.Text = "X";
                    totale = totale + float.Parse(lblPrimo2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim2 = true;
                }
                else if (Prim2 == true)
                {
                    btnOrdinaPrimo2.Text = null;
                    totale = totale - float.Parse(lblPrimo2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim2 = false;
                }
            }
        }

        private void btnOrdinaPrimo3_Click(object sender, EventArgs e)
        {
            if (lblPrimo3.Text != "Primo3")
            {
                if (Prim3 == false)
                {
                    btnOrdinaPrimo3.Text = "X";
                    totale = totale + float.Parse(lblPrimo3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim3 = true;
                }
                else if (Prim3 == true)
                {
                    btnOrdinaPrimo3.Text = null;
                    totale = totale - float.Parse(lblPrimo3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim3 = false;
                }
            }
        }

        private void btnOrdinaPrimo4_Click(object sender, EventArgs e)
        {
            if (lblPrimo4.Text != "Primo4")
            {
                if (Prim4 == false)
                {
                    btnOrdinaPrimo4.Text = "X";
                    totale = totale + float.Parse(lblPrimo4Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim4 = true;
                }
                else if (Prim4 == true)
                {
                    btnOrdinaPrimo4.Text = null;
                    totale = totale - float.Parse(lblPrimo4Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Prim4 = false;
                }
            }
        }

        private void btnOrdinaSecondo1_Click(object sender, EventArgs e)
        {
            if (lblSecondo1.Text != "Secondo1")
            {
                if (Sec1 == false)
                {
                    btnOrdinaSecondo1.Text = "X";
                    totale = totale + float.Parse(lblSecondo1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec1 = true;
                }
                else if (Sec1 == true)
                {
                    btnOrdinaSecondo1.Text = null;
                    totale = totale - float.Parse(lblSecondo1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec1 = false;
                }
            }
        }

        private void btnOrdinaSecondo2_Click(object sender, EventArgs e)
        {
            if (lblSecondo2.Text != "Secondo2")
            {
                if (Sec2== false)
                {
                    btnOrdinaSecondo2.Text = "X";
                    totale = totale + float.Parse(lblSecondo2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec2 = true;
                }
                else if (Sec2 == true)
                {
                    btnOrdinaSecondo2.Text = null;
                    totale = totale - float.Parse(lblSecondo2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec2 = false;
                }
            }
        }

        private void btnOrdinaSecondo3_Click(object sender, EventArgs e)
        {
            if (lblSecondo3.Text != "Secondo3")
            {
                if (Sec3 == false)
                {
                    btnOrdinaSecondo3.Text = "X";
                    totale = totale + float.Parse(lblSecondo3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec3 = true;
                }
                else if (Sec3 == true)
                {
                    btnOrdinaSecondo3.Text = null;
                    totale = totale - float.Parse(lblSecondo3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec3 = false;
                }
            }
        }

        private void btnOrdinaSecondo4_Click(object sender, EventArgs e)
        {
            if (lblSecondo4.Text != "Secondo4")
            {
                if (Sec4 == false)
                {
                    btnOrdinaSecondo4.Text = "X";
                    totale = totale + float.Parse(lblSecondo4Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec4 = true;
                }
                else if (Sec4 == true)
                {
                    btnOrdinaSecondo4.Text = null;
                    totale = totale - float.Parse(lblSecondo4Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Sec4 = false;
                }
            }
        }

        private void btnOrdinaDessert1_Click(object sender, EventArgs e)
        {
            if (lblDessert1.Text != "Dessert1")
            {
                if (Des1 == false)
                {
                    btnOrdinaDessert1.Text = "X";
                    totale = totale + float.Parse(lblDessert1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Des1 = true;
                }
                else if (Des1 == true)
                {
                    btnOrdinaDessert1.Text = null;
                    totale = totale - float.Parse(lblDessert1Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Des1 = false;
                }
            }
        }

        private void btnOrdinaDessert2_Click(object sender, EventArgs e)
        {
            if (lblDessert2.Text != "Dessert2")
            {
                if (Des2 == false)
                {
                    btnOrdinaDessert2.Text = "X";
                    totale = totale + float.Parse(lblDessert2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Des2 = true;
                }
                else if (Des2 == true)
                {
                    btnOrdinaDessert2.Text = null;
                    totale = totale - float.Parse(lblDessert2Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Des2 = false;
                }
            }
        }

        private void btnOrdinaDessert3_Click(object sender, EventArgs e)
        {
            if (lblDessert3.Text != "Dessert3")
            {
                if (Des3 == false)
                {
                    btnOrdinaDessert3.Text = "X";
                    totale = totale + float.Parse(lblDessert3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Des3 = true;
                }
                else if (Des3 == true)
                {
                    btnOrdinaDessert3.Text = null;
                    totale = totale - float.Parse(lblDessert3Prezzo.Text);
                    textBoxTotale.Text = Convert.ToString(totale) + " €";
                    Des3 = false;
                }
            }
        }
    }
}
