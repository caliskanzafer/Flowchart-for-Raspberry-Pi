using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dinamikPictureBox
{
    public partial class Form1 : Form
    {
        XmlTextWriter yazi = new XmlTextWriter("kodlar.xml", System.Text.UTF8Encoding.UTF8);
        public Form1()
        {
            InitializeComponent();
        }
        //Fonksiyonlar fonk = new Fonksiyonlar();
        ResimNesnesi olustur = new ResimNesnesi();
        List<int> degiskenler = new List<int>();
        List<int> degiskenIslem = new List<int>();
        public static int degiskenIslemSayisi = 0;
        public static int degiskenSayisi = 0;
        ArrayList dizi = new ArrayList();
        ArrayList dizi2 = new ArrayList();
        String algoritmaAdi;

        private void Form1_Load(object sender, EventArgs e)
        {
            yazi.Formatting = Formatting.Indented;
            yazi.WriteStartDocument();

        }
        //              PictureBox Clickler
        private void basla_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls.Add(olustur.basla_Olustur());
                ResimNesnesi.secenek = 0;

            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();
            }
        }
        private void islem_Click(object sender, EventArgs e)
        {
            try
            {

                this.Controls.Add(olustur.islem_Olustur());
                ResimNesnesi.secenek = 1;
                dizi.Add(olustur.getIsim());
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();
            }
        }
        private void dongu_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls.Add(olustur.dongu_Olustur());
                ResimNesnesi.secenek = 2;
                dizi.Add(olustur.getIsim());
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();
            }
        }
        private void karar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls.Add(olustur.karar_Olustur());
                ResimNesnesi.secenek = 3;
                dizi.Add(olustur.getIsim());
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();
            }
        }
        private void veriGirisi_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls.Add(olustur.veriGirisi_Olustur());
                ResimNesnesi.secenek = 4;
                dizi.Add(olustur.getIsim());
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();
            }
        }
        private void veriYazma_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls.Add(olustur.veriYazma_Olustur());
                ResimNesnesi.secenek = 5;
                dizi.Add(olustur.getIsim());
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();
            }
        }
        private void bitir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls.Add(olustur.bitir_Olustur());
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();
            }
        }

        //              Visible İşlemleri
        public void basla_Guncel()
        {
            this.kaydet.Visible = true;
            basla_GroupBox.Visible = true;
            basla_GroupBox.Text = olustur.getIsim();
        }
        public void islem_Guncel()
        {
            islem_GroupBox.Visible = true;
            islem_GroupBox.Text = olustur.getIsim();
            this.kaydet.Visible = true;

            basla_GroupBox.Visible = false;
            dongu_GroupBox.Visible = false;
            karar_GroupBox.Visible = false;
            veriGirisi_GroupBox.Visible = false;
            veriYazma_GroupBox.Visible = false;


        }
        public void dongu_Guncel()
        {
            dongu_cb1.Items.Clear();
            foreach (string a in dizi)
            {
                dongu_cb1.Items.Add(a);
            }

            this.kaydet.Visible = true;

            basla_GroupBox.Visible = false;
            dongu_GroupBox.Visible = true;
            islem_GroupBox.Visible = false;
            karar_GroupBox.Visible = false;
            veriGirisi_GroupBox.Visible = false;
            veriYazma_GroupBox.Visible = false;

            dongu_GroupBox.Text = olustur.getIsim();

        }
        public void karar_Guncel()
        {
            karar_cb5.Items.Clear();
            karar_cb4.Items.Clear();
            karar_cb1.Items.Clear();
            karar_cb2.Items.Clear();
            foreach (string a in dizi)
            {
                karar_cb5.Items.Add(a);
                karar_cb4.Items.Add(a);
            }
            if (degiskenSayisi != 0)
            {
                for (int i = 0; i < degiskenSayisi; i++)
                {
                    karar_cb1.Items.Add(islem_cb2.Items[i].ToString());
                    karar_cb2.Items.Add(islem_cb2.Items[i].ToString());
                }
            }
            this.kaydet.Visible = true;
            basla_GroupBox.Visible = false;
            karar_GroupBox.Visible = true;
            islem_GroupBox.Visible = false;
            dongu_GroupBox.Visible = false;
            veriGirisi_GroupBox.Visible = false;
            veriYazma_GroupBox.Visible = false;

            karar_GroupBox.Text = olustur.getIsim();
        }
        public void veriGirisi_Guncel()
        {
            veriGirisi_cb1.Items.Clear();
            for (int i = 0; i < degiskenSayisi; i++)
            {
                veriGirisi_cb1.Items.Add(olustur.degiskenIsimDondur(i));
            }
            this.kaydet.Visible = true;

            basla_GroupBox.Visible = false;
            veriGirisi_GroupBox.Visible = true;
            islem_GroupBox.Visible = false;
            dongu_GroupBox.Visible = false;
            karar_GroupBox.Visible = false;
            veriYazma_GroupBox.Visible = false;

            veriGirisi_GroupBox.Text = olustur.getIsim();
        }
        public void veriYazma_Guncel()
        {
            this.kaydet.Visible = false;
            basla_GroupBox.Visible = false;
            veriYazma_GroupBox.Visible = true;
            islem_GroupBox.Visible = false;
            dongu_GroupBox.Visible = false;
            karar_GroupBox.Visible = false;
            veriGirisi_GroupBox.Visible = false;

            veriYazma_GroupBox.Text = olustur.getIsim();
        }
        //              Veri Girişi İşlemleri
        private void secenekSifir()
        {
            algoritmaAdi = basla_tx1.Text;
            if (algoritmaAdi != "")
            {
                basla_lb2.Text = "Algoritmanızın ismi: " + algoritmaAdi;
                basla_lb2.ForeColor = Color.Green;
            }
        }
        private void secenekBir()
        {
            String test = olustur.isim;

            if (islem_cb3.SelectedIndex != -1 && islem_cb2.SelectedIndex != -1 && islem_cb4.SelectedIndex != -1)
            {
                string kelime = islem_cb2.SelectedItem.ToString();
                char[] ayir = kelime.ToCharArray();
                foreach (char harf in kelime)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        ayir[i] = harf;
                    }
                }
                string kelime2 = islem_cb4.SelectedItem.ToString();
                char[] ayir2 = kelime2.ToCharArray();
                foreach (char harf in kelime2)
                {
                    for (int k = 0; k < 1; k++)
                    {
                        ayir2[k] = harf;
                    }

                }
                int a = degiskenler[ayir[3] - 48];
                int b = degiskenler[ayir2[3] - 48];
                switch (islem_cb3.SelectedIndex)
                {//+ - * /
                    case 0:
                        {
                            islem_cb1.Items.Add("b" + degiskenIslemSayisi.ToString());
                            degiskenIslemSayisi++;
                            degiskenIslem.Add(a + b);
                            String c = ("b" + degiskenIslemSayisi.ToString());
                            olustur.getText(a + b, c);
                            break;
                        }
                    case 1:
                        {
                            islem_cb1.Items.Add("b" + degiskenIslemSayisi.ToString());
                            degiskenIslemSayisi++;
                            degiskenIslem.Add(a - b);
                            String c = "b" + degiskenIslemSayisi.ToString();
                            olustur.getText(a - b, c);
                            break;
                        }
                    case 2:
                        {
                            islem_cb1.Items.Add("b" + degiskenIslemSayisi.ToString());
                            degiskenIslemSayisi++;
                            degiskenIslem.Add(a * b);
                            String c = "b" + degiskenIslemSayisi.ToString();
                            olustur.getText(a * b, c);
                            break;
                        }
                    case 3:
                        {
                            islem_cb1.Items.Add("b" + degiskenIslemSayisi.ToString());
                            degiskenIslemSayisi++;
                            degiskenIslem.Add(a / b);
                            String c = "b" + degiskenIslemSayisi.ToString();
                            olustur.getText(a / b, c);
                            break;
                        }
                }
            }
            else
                MessageBox.Show("Eksik Değer Girdiniz");
            degiskenYazdir();
            islem_lb1.Text = "İşlem Oluşturuldu";
            islem_lb1.ForeColor = Color.Green;

        }
        private void secenekIki()
        {
            if (dongu_tx1.Text != "" && dongu_cb1.SelectedIndex != -1)
            {
                string isim = olustur.isim;
                int tekrar = Convert.ToInt32(dongu_tx1.Text);
                if (dongu_tx1.Text != "" && dongu_cb1.SelectedIndex != -1)
                {
                    string kelime = dongu_cb1.SelectedItem.ToString();
                    char[] ayir = kelime.ToCharArray();
                    foreach (char harf in kelime)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            ayir[i] = harf;
                        }
                    }
                    string kelime2 = isim;
                    char[] ayir2 = kelime2.ToCharArray();
                    foreach (char harf in kelime2)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            ayir2[i] = harf;
                        }
                    }
                    for (int k = 0; k < tekrar; k++)
                    {
                        for (int i = ayir[2] - 48; i < ayir2[2] - 48; i++)
                        {
                            //Kodlar Yazılıcak
                        }
                    }
                }
            }
            else
                MessageBox.Show("Eksik Değer Girdiniz");
            dongu_lb3.Text = "Döngü Oluşturuldu";
            dongu_lb3.ForeColor = Color.Green;

        }
        private void secenekUc()
        {
            if (karar_cb1.SelectedIndex != -1 && karar_cb2.SelectedIndex != -1 && karar_cb4.SelectedIndex != -1 && karar_cb5.SelectedIndex != -1 && karar_cb3.SelectedIndex != -1)
            {
                switch (karar_cb3.SelectedIndex)
                {
                    case 0:
                        {
                            string kelime = karar_cb1.SelectedItem.ToString();
                            char[] ayir = kelime.ToCharArray();
                            foreach (char harf in kelime)
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    ayir[i] = harf;
                                }

                            }
                            int a = ayir[2] - 48;
                            int b = ayir[3] - 48;

                            string kelime2 = karar_cb2.SelectedItem.ToString();
                            char[] ayir2 = kelime2.ToCharArray();
                            foreach (char harf in kelime2)
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    ayir2[i] = harf;
                                }

                            }
                            int c = ayir2[2] - 48;
                            int d = ayir2[3] - 48;
                            int deger1 = olustur.degiskenDegerDondur(a, b);
                            int deger2 = olustur.degiskenDegerDondur(c, d);
                            if (deger1 < deger2)
                            {
                                //Kodlar Yazdırılıcak
                            }
                            else
                            {
                                //Kodlar Yazdırılıcak
                            }
                            break;
                        }
                    case 1:
                        {
                            string kelime = karar_cb1.SelectedItem.ToString();
                            char[] ayir = kelime.ToCharArray();
                            foreach (char harf in kelime)
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    ayir[i] = harf;
                                }

                            }
                            int a = ayir[2] - 48;
                            int b = ayir[3] - 48;

                            string kelime2 = karar_cb2.SelectedItem.ToString();
                            char[] ayir2 = kelime2.ToCharArray();
                            foreach (char harf in kelime2)
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    ayir2[i] = harf;
                                }

                            }
                            int c = ayir2[2] - 48;
                            int d = ayir2[3] - 48;
                            int deger1 = olustur.degiskenDegerDondur(a, b);
                            int deger2 = olustur.degiskenDegerDondur(c, d);
                            if (deger1 > deger2)
                            {
                                MessageBox.Show("Kodlar Yazılacak");
                                //Kodlar Yazdırılıcak
                            }
                            else
                            {
                                MessageBox.Show("Kodlar Yazılacak");
                                //Kodlar Yazdırılıcak
                            }
                            break;
                        }

                }
            }
            else
                MessageBox.Show("Eksik Değer Girdiniz");
            karar_lb5.Text = "Döngü Oluşturuldu";
            karar_lb5.ForeColor = Color.Green;
        }
        private void secenekDort()
        {
            if (veriGirisi_cb1.SelectedIndex != -1 && veriGirisi_tx1.Text != "")
            {
                string kelime = veriGirisi_cb1.SelectedItem.ToString();
                char[] ayir = kelime.ToCharArray();
                foreach (char harf in kelime)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        ayir[i] = harf;
                    }

                }
                int a = ayir[2] - 48;
                int b = ayir[3] - 48;
                int deger = Convert.ToInt32(veriGirisi_tx1.Text);
                if (olustur.degiskenDegerDegistir(a, b, deger) == 1)
                {
                    veriGirisi_lb2.ForeColor = Color.Green;
                    veriGirisi_lb2.Text = "pb" + a.ToString() + b.ToString() + " Değeri " + deger + " ile değiştirildi";
                    //Kodlar Yazdırılacak
                }
                else
                {
                    veriGirisi_lb2.ForeColor = Color.Green;
                    veriGirisi_lb2.Text = "pb" + a.ToString() + b.ToString() + " Değeri " + deger + " ile değiştirilemedi";
                }

            }
            else
                MessageBox.Show("Eksik Değer Girdiniz");
        }
        private void secenekBes() { }
        //              Buton İşlemleri
        private void veriGir_Click(object sender, EventArgs e)
        {
            if (islem_tx1.Text == "")
            {
                MessageBox.Show("Lütfen Değer Girin");
            }
            else
            {
                String test = olustur.isim;
                int t = Convert.ToInt32(islem_tx1.Text);
                degiskenler.Add(t);
                islem_cb2.Items.Add(test + degiskenSayisi.ToString());
                islem_cb4.Items.Add(test + degiskenSayisi.ToString());
                olustur.getText(t, test + (degiskenSayisi.ToString()));
                degiskenSayisi++;


            }
            degiskenYazdir();
        }
        private void kaydet_Click(object sender, EventArgs e)
        {
            if (ResimNesnesi.secenek == 0)
            {
                secenekSifir();
            }
            else if (ResimNesnesi.secenek == 1)
            {
                secenekBir();

            }
            else if (ResimNesnesi.secenek == 2)
            {
                secenekIki();
            }
            else if (ResimNesnesi.secenek == 3)
            {
                secenekUc();
            }
            else if (ResimNesnesi.secenek == 4) { secenekDort(); }
            else if (ResimNesnesi.secenek == 5) { secenekBes(); }

            else
            {
                MessageBox.Show("Başla veya Bitire Tıkladınız");
            }

        }
        private void degiskenYazdir()
        {
            try
            {
                label5.Visible = true;
                richTextBox1.Visible = true;
                richTextBox2.Visible = true;
                richTextBox1.Text = islem_cb2.Items[0].ToString() + "=" + degiskenler[0].ToString();
                for (int i = 1; i < degiskenSayisi; i++)
                {
                    richTextBox1.Text += "\n" + islem_cb2.Items[i].ToString() + "=" + degiskenler[i];
                }
                if (islem_cb1.Items.Count != 0)
                {
                    label5.Visible = true;
                    richTextBox2.Text = islem_cb1.Items[0].ToString() + "=" + degiskenIslem[0].ToString();
                    for (int i = 1; i < degiskenIslemSayisi; i++)
                    {
                        richTextBox2.Text += "\n" + islem_cb1.Items[i].ToString() + "=" + degiskenIslem[i];
                    }
                }
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();

            }

        }
        private void calistir_Click(object sender, EventArgs e)
        {
            try
            {

                dizi2 = olustur.diziDondur();
                yazi.WriteStartElement(algoritmaAdi);
                foreach (int a in dizi2)
                {
                    if (a == 1)
                    {
                        yazi.WriteStartElement("veriTanımlama");
                        for (int i = 0; i < degiskenSayisi; i++)
                        {
                            string kelime = olustur.degiskenIsimDondur(i);
                            char[] ayir = kelime.ToCharArray();
                            foreach (char harf in kelime)
                            {
                                for (int k = 0; k < 1; k++)
                                {
                                    ayir[k] = harf;
                                }
                            }
                            int sayi1 = ayir[2] - 48;
                            int sayi2 = ayir[3] - 48;
                            yazi.WriteElementString(olustur.degiskenIsimDondur(i), olustur.degiskenDegerDondur(sayi1, sayi2).ToString());
                        }
                        for (int i = 0; i < degiskenIslemSayisi; i++)
                        {
                            yazi.WriteElementString("b" + islem_cb1.GetItemText(i), degiskenIslem[i].ToString());
                        }
                        yazi.WriteEndElement();
                        yazi.Flush();
                    }
                    else if (a == 2)
                    {
                        yazi.WriteStartElement("döngü");
                        yazi.WriteElementString("tekrarla", dongu_tx1.Text.ToString());
                        yazi.WriteElementString("git", dongu_cb1.SelectedItem.ToString());
                        yazi.WriteEndElement();
                        yazi.Flush();
                    }
                    else if (a == 3)
                    {
                        yazi.WriteStartElement("karar");
                        yazi.WriteElementString("eğer", karar_cb1.SelectedItem.ToString() + karar_cb3.SelectedItem.ToString() + karar_cb2.SelectedItem.ToString());
                        yazi.WriteElementString("true", karar_cb4.SelectedItem.ToString());
                        yazi.WriteElementString("false", karar_cb5.SelectedItem.ToString());
                        yazi.WriteEndElement();
                        yazi.Flush();
                    }
                    else if (a == 4)
                    {
                        yazi.WriteStartElement("veriGüncelle");
                        yazi.WriteElementString("veriAdı", veriGirisi_cb1.SelectedItem.ToString());
                        yazi.WriteElementString("yeniDeger", veriGirisi_tx1.Text);
                        yazi.WriteEndElement();
                        yazi.Flush();
                    }
                    else if (a == 5)
                    {
                        yazi.WriteStartElement("ekranaYazdir");
                        yazi.WriteElementString("sonuç", "Metin");
                        yazi.WriteEndElement();
                        yazi.Flush();
                    }
                    else if (a == 6)
                    {
                        yazi.WriteEndElement();
                        yazi.Close();
                    }

                    button1.Visible = true;
                }
                
            }
            catch (Exception hata)
            {
                //MessageBox.Show(hata.ToString());
            }
        }
        public void temasSaglandi()
        {
            label2.Text = "Temas Sağlandı";
            label2.ForeColor = Color.Green;
            label2.Visible = true;
        }
        public void temasSaglanmadi()
        {
            label2.Visible = false;
        }
        public void calistirBtn()
        {
            calistir.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("kodlar.xml");
        }
    }

}
