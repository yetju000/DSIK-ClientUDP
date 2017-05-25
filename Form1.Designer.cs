namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.haslo = new System.Windows.Forms.TextBox();
            this.Info = new System.Windows.Forms.TextBox();
            this.zaloguj = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.Zarejestruj = new System.Windows.Forms.Button();
            this.Wyloguj = new System.Windows.Forms.Button();
            this.Pliki = new System.Windows.Forms.TextBox();
            this.sciezka_Wrzuc = new System.Windows.Forms.TextBox();
            this.Plik = new System.Windows.Forms.TextBox();
            this.sciezkaZapis = new System.Windows.Forms.TextBox();
            this.Wrzuc = new System.Windows.Forms.Button();
            this.Sciagnij = new System.Windows.Forms.Button();
            this.nazwaPlikuWrzut = new System.Windows.Forms.TextBox();
            this.odswiez = new System.Windows.Forms.Button();
            this.usun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // haslo
            // 
            this.haslo.AcceptsTab = true;
            this.haslo.Location = new System.Drawing.Point(89, 66);
            this.haslo.Name = "haslo";
            this.haslo.Size = new System.Drawing.Size(100, 20);
            this.haslo.TabIndex = 1;
            this.haslo.Text = "haslo";
            this.haslo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.haslo.TextChanged += new System.EventHandler(this.haslo_TextChanged);
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(36, 162);
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.Size = new System.Drawing.Size(225, 20);
            this.Info.TabIndex = 3;
            this.Info.TextChanged += new System.EventHandler(this.Info_TextChanged);
            // 
            // zaloguj
            // 
            this.zaloguj.Location = new System.Drawing.Point(36, 108);
            this.zaloguj.Name = "zaloguj";
            this.zaloguj.Size = new System.Drawing.Size(100, 35);
            this.zaloguj.TabIndex = 4;
            this.zaloguj.Text = "Zaloguj";
            this.zaloguj.UseVisualStyleBackColor = true;
            this.zaloguj.Click += new System.EventHandler(this.zaloguj_Click);
            // 
            // login
            // 
            this.login.AcceptsTab = true;
            this.login.Location = new System.Drawing.Point(89, 29);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(100, 20);
            this.login.TabIndex = 5;
            this.login.Text = "login";
            this.login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.login.TextChanged += new System.EventHandler(this.login_TextChanged);
            // 
            // Zarejestruj
            // 
            this.Zarejestruj.Location = new System.Drawing.Point(163, 108);
            this.Zarejestruj.Name = "Zarejestruj";
            this.Zarejestruj.Size = new System.Drawing.Size(98, 35);
            this.Zarejestruj.TabIndex = 6;
            this.Zarejestruj.Text = "Zarejestruj";
            this.Zarejestruj.UseVisualStyleBackColor = true;
            this.Zarejestruj.Click += new System.EventHandler(this.Zarejestruj_Click);
            // 
            // Wyloguj
            // 
            this.Wyloguj.Location = new System.Drawing.Point(77, 108);
            this.Wyloguj.Name = "Wyloguj";
            this.Wyloguj.Size = new System.Drawing.Size(127, 35);
            this.Wyloguj.TabIndex = 7;
            this.Wyloguj.Text = "Wyloguj";
            this.Wyloguj.UseVisualStyleBackColor = true;
            this.Wyloguj.Visible = false;
            this.Wyloguj.Click += new System.EventHandler(this.Wyloguj_Click);
            // 
            // Pliki
            // 
            this.Pliki.Location = new System.Drawing.Point(570, 29);
            this.Pliki.Multiline = true;
            this.Pliki.Name = "Pliki";
            this.Pliki.ReadOnly = true;
            this.Pliki.Size = new System.Drawing.Size(255, 438);
            this.Pliki.TabIndex = 8;
            this.Pliki.Visible = false;
            this.Pliki.TextChanged += new System.EventHandler(this.Pliki_TextChanged);
            // 
            // sciezka_Wrzuc
            // 
            this.sciezka_Wrzuc.Location = new System.Drawing.Point(36, 230);
            this.sciezka_Wrzuc.Name = "sciezka_Wrzuc";
            this.sciezka_Wrzuc.Size = new System.Drawing.Size(369, 20);
            this.sciezka_Wrzuc.TabIndex = 9;
            this.sciezka_Wrzuc.Text = "sciezka pliku do wrzucenia na server";
            this.sciezka_Wrzuc.Visible = false;
            // 
            // Plik
            // 
            this.Plik.Location = new System.Drawing.Point(36, 350);
            this.Plik.Name = "Plik";
            this.Plik.Size = new System.Drawing.Size(369, 20);
            this.Plik.TabIndex = 10;
            this.Plik.Text = "Ktory plik";
            this.Plik.Visible = false;
            // 
            // sciezkaZapis
            // 
            this.sciezkaZapis.Location = new System.Drawing.Point(36, 376);
            this.sciezkaZapis.Name = "sciezkaZapis";
            this.sciezkaZapis.Size = new System.Drawing.Size(369, 20);
            this.sciezkaZapis.TabIndex = 11;
            this.sciezkaZapis.Text = "sciezka gdzie zapisac";
            this.sciezkaZapis.Visible = false;
            // 
            // Wrzuc
            // 
            this.Wrzuc.Location = new System.Drawing.Point(135, 256);
            this.Wrzuc.Name = "Wrzuc";
            this.Wrzuc.Size = new System.Drawing.Size(126, 44);
            this.Wrzuc.TabIndex = 12;
            this.Wrzuc.Text = "Wrzuc";
            this.Wrzuc.UseVisualStyleBackColor = true;
            this.Wrzuc.Visible = false;
            this.Wrzuc.Click += new System.EventHandler(this.Wrzuc_Click);
            // 
            // Sciagnij
            // 
            this.Sciagnij.Location = new System.Drawing.Point(135, 402);
            this.Sciagnij.Name = "Sciagnij";
            this.Sciagnij.Size = new System.Drawing.Size(126, 46);
            this.Sciagnij.TabIndex = 13;
            this.Sciagnij.Text = "Sciagnij";
            this.Sciagnij.UseVisualStyleBackColor = true;
            this.Sciagnij.Visible = false;
            this.Sciagnij.Click += new System.EventHandler(this.Sciagnij_Click);
            // 
            // nazwaPlikuWrzut
            // 
            this.nazwaPlikuWrzut.Location = new System.Drawing.Point(36, 204);
            this.nazwaPlikuWrzut.Name = "nazwaPlikuWrzut";
            this.nazwaPlikuWrzut.Size = new System.Drawing.Size(369, 20);
            this.nazwaPlikuWrzut.TabIndex = 14;
            this.nazwaPlikuWrzut.Text = "nazwa pliku wrzucanego/usuwanego z servera";
            this.nazwaPlikuWrzut.Visible = false;
            // 
            // odswiez
            // 
            this.odswiez.Location = new System.Drawing.Point(489, 30);
            this.odswiez.Name = "odswiez";
            this.odswiez.Size = new System.Drawing.Size(75, 56);
            this.odswiez.TabIndex = 15;
            this.odswiez.Text = "odswiez liste plikow";
            this.odswiez.UseVisualStyleBackColor = true;
            this.odswiez.Visible = false;
            this.odswiez.Click += new System.EventHandler(this.odswiez_Click);
            // 
            // usun
            // 
            this.usun.Location = new System.Drawing.Point(330, 152);
            this.usun.Name = "usun";
            this.usun.Size = new System.Drawing.Size(75, 46);
            this.usun.TabIndex = 17;
            this.usun.Text = "usun plik";
            this.usun.UseVisualStyleBackColor = true;
            this.usun.Visible = false;
            this.usun.Click += new System.EventHandler(this.usun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 504);
            this.Controls.Add(this.usun);
            this.Controls.Add(this.odswiez);
            this.Controls.Add(this.nazwaPlikuWrzut);
            this.Controls.Add(this.Sciagnij);
            this.Controls.Add(this.Wrzuc);
            this.Controls.Add(this.sciezkaZapis);
            this.Controls.Add(this.Plik);
            this.Controls.Add(this.sciezka_Wrzuc);
            this.Controls.Add(this.Pliki);
            this.Controls.Add(this.Wyloguj);
            this.Controls.Add(this.Zarejestruj);
            this.Controls.Add(this.login);
            this.Controls.Add(this.zaloguj);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.haslo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox haslo;
        private System.Windows.Forms.TextBox Info;
        private System.Windows.Forms.Button zaloguj;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Button Zarejestruj;
        private System.Windows.Forms.Button Wyloguj;
        private System.Windows.Forms.TextBox Pliki;
        private System.Windows.Forms.TextBox sciezka_Wrzuc;
        private System.Windows.Forms.TextBox Plik;
        private System.Windows.Forms.TextBox sciezkaZapis;
        private System.Windows.Forms.Button Wrzuc;
        private System.Windows.Forms.Button Sciagnij;
        private System.Windows.Forms.TextBox nazwaPlikuWrzut;
        private System.Windows.Forms.Button odswiez;
        private System.Windows.Forms.Button usun;
    }
}

