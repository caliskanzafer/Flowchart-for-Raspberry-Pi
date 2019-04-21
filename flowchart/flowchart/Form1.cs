using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace flowchart
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        /*XmlTextWriter yazi = new XmlTextWriter("kodlar.xml", System.Text.UTF8Encoding.UTF8);*/
        ResimNesnesi olustur = new ResimNesnesi();
        Database db = new Database();
        public int degiskenSayisi = 0;
        ArrayList dizi2 = new ArrayList();
        String algoritmaAdi;
        public static int veri;
        private void Form1_Load(object sender, EventArgs e)
        {
            db.baglan();
            db.veritabaniTemizle();
           /* yazi.Formatting = Formatting.Indented;
            yazi.WriteStartDocument();*/
        }
        //              PictureBox Clickler
        private void basla_Click(object sender, EventArgs e)
        {
            try
            {
                db.nesneEkle();
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
                db.nesneEkle();
                this.Controls.Add(olustur.islem_Olustur());
                ResimNesnesi.secenek = 1;
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
                db.nesneEkle();
                this.Controls.Add(olustur.dongu_Olustur());
                ResimNesnesi.secenek = 2;
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
                db.nesneEkle();
                this.Controls.Add(olustur.karar_Olustur());
                ResimNesnesi.secenek = 3;
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
                db.nesneEkle();
                this.Controls.Add(olustur.veriGirisi_Olustur());
                ResimNesnesi.secenek = 4;
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
                db.nesneEkle();
                this.Controls.Add(olustur.veriYazma_Olustur());
                ResimNesnesi.secenek = 5;
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
                db.nesneEkle();
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
            groupBoxVisible(basla_GroupBox);
            basla_GroupBox.Text = olustur.getIsim();
        }
        public void islem_Guncel()
        {
            groupBoxVisible(islem_GroupBox);
            islem_GroupBox.Text = olustur.getIsim();
        }
        public void dongu_Guncel()
        {
            db.comboBoxNesneGuncelle(dongu_cb1);
            groupBoxVisible(dongu_GroupBox);
            dongu_GroupBox.Text = olustur.getIsim();
        }
        public void karar_Guncel()
        {
            db.comboBoxVeriGuncelle(karar_cb1);
            db.comboBoxVeriGuncelle(karar_cb2);
            db.comboBoxNesneGuncelle(karar_cb4);//true
            db.comboBoxNesneGuncelle(karar_cb5);//false
            groupBoxVisible(karar_GroupBox);
            karar_GroupBox.Text = olustur.getIsim();
        }
        public void veriGirisi_Guncel()
        {
            db.comboBoxVeriGuncelle(veriGirisi_cb1);
            groupBoxVisible(veriGirisi_GroupBox);
            veriGirisi_GroupBox.Text = olustur.getIsim();
        }
        public void veriYazma_Guncel()
        {
            groupBoxVisible(veriYazma_GroupBox);
            this.kaydet.Visible = false;
            veriYazma_GroupBox.Text = olustur.getIsim();
        }

        //              Veri Girişi İşlemleri
        private void secenekSifir()
        {
            algoritmaAdi = basla_tx1.Text;
            db.veritabaniAdi(algoritmaAdi);
            if (algoritmaAdi != "")
            {
                basla_lb2.Text = "Algoritmanızın ismi: " + algoritmaAdi;
                basla_lb2.ForeColor = Color.Green;
            }
        }
        private void secenekBir()
        {
            db.veriHesapla(islem_cb2,islem_cb4,islem_cb3);
            degiskenYazdir();
            islem_lb1.Text = "İşlem Oluşturuldu";
            islem_lb1.ForeColor = Color.Green;

        }
        private void secenekIki()
        {
           
            int tekrar = Convert.ToInt32(dongu_tx1.Text);
            db.veriDonguEkle(dongu_cb1, tekrar);
            dongu_lb3.Text = "Döngü Oluşturuldu";
            dongu_lb3.ForeColor = Color.Green;
        }
        private void secenekUc()
        {
            if (karar_cb1.SelectedIndex != -1 && karar_cb2.SelectedIndex != -1 && karar_cb4.SelectedIndex != -1 && karar_cb5.SelectedIndex != -1 && karar_cb3.SelectedIndex != -1)
            {
                db.veriKarar(karar_cb1,karar_cb2,karar_cb3,karar_cb4,karar_cb5);
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
                int deger = Convert.ToInt32(veriGirisi_tx1.Text);
                db.veriGuncelle(veriGirisi_cb1, deger);

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
                veri = Convert.ToInt32(islem_tx1.Text);
                db.veriEkle();
                db.comboBoxVeriGuncelle(islem_cb2);
                db.comboBoxVeriGuncelle(islem_cb4);
                degiskenSayisi++;
            }
            degiskenYazdir();
        }
        private void kaydet_Click(object sender, EventArgs e)
        {
            if (ResimNesnesi.secenek == 0){
                secenekSifir();
            }
            else if (ResimNesnesi.secenek == 1){
                secenekBir();

            }
            else if (ResimNesnesi.secenek == 2){
                secenekIki();
            }
            else if (ResimNesnesi.secenek == 3){
                secenekUc();
            }
            else if (ResimNesnesi.secenek == 4) { 
                secenekDort(); 
            }
            else if (ResimNesnesi.secenek == 5) { 
                secenekBes(); 
            }
            else{
                MessageBox.Show("Başla veya Bitire Tıkladınız");
            }

        }
        private void degiskenYazdir()
        {
            try
            {
                label4.Visible = true;
                label5.Visible = true;
                richTextBox1.Visible = true;
                richTextBox2.Visible = true;
                
                db.degiskenYazdir(richTextBox1,richTextBox2);
            }
            catch (Exception hata)
            {
                hataMesaji.Visible = true;
                hataMesaji.Text = hata.ToString();

            }

        }
        //XML Oluşturma
      /*  private void calistir_Click(object sender, EventArgs e)
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
        }*/
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
        //XML Dosyasını Açar
        private void xmlAc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("kodlar.xml");
        }
        private void groupBoxVisible(GroupBox gb)
        {
            this.kaydet.Visible = true;
            basla_GroupBox.Visible = false;
            veriYazma_GroupBox.Visible = false;
            islem_GroupBox.Visible = false;
            dongu_GroupBox.Visible = false;
            karar_GroupBox.Visible = false;
            veriGirisi_GroupBox.Visible = false;

            gb.Visible = true;

        }
    }

}
