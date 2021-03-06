﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace flowchart
{
    class ResimNesnesi
    {
        public static int secenek = 0;
        public String isim;
        public static String isim2;
        public int a = 1;
        bool surukleme = false;
        Point ilkKonum;
        List<Point> degiskenKonum = new List<Point>();
        List<string> degisken = new List<string>();
        ArrayList dizi = new ArrayList();
        public ArrayList diziDondur()
        {
            return dizi;
        }
        public String getIsim2(){
            return isim2;
        }
        private void isimDondur(String isim)
        {
            isim2 = isim;
        }
        public String getIsim()
        {
            return this.isim;
        }
        public PictureBox basla_Olustur()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(112, 25);
            pb.Name = "pb" + (a++).ToString();
            pb.ImageLocation = @"..\..\images\basla.png";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = 0;
            pb.Click += new EventHandler(this.basla_Olustur_Click);
            pb.MouseDown += new MouseEventHandler(this.picturebox_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.picturebox_MouseMove);
            pb.MouseUp += new MouseEventHandler(this.picturebox_MouseUp);
            pb.MouseClick += new MouseEventHandler(this.dondur);
            degiskenKonum.Add(pb.Location);
            degisken.Add(pb.Name);
            dizi.Add(pb.Tag);
            return pb;
        }
        public PictureBox islem_Olustur()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(112, 112);
            pb.Name = "pb" + (a++).ToString();
            pb.ImageLocation = @"..\..\images\islem.png";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = 1;
            pb.Click += new EventHandler(this.islem_Olustur_Click);
            pb.MouseDown += new MouseEventHandler(this.picturebox_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.picturebox_MouseMove);
            pb.MouseUp += new MouseEventHandler(this.picturebox_MouseUp);
            pb.MouseClick += new MouseEventHandler(this.dondur);
            degiskenKonum.Add(pb.Location);
            degisken.Add(pb.Name);
            isim = pb.Name;
            return pb;
        }
        public PictureBox dongu_Olustur()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(112, 198);
            pb.Name = "pb" + (a++).ToString();
            pb.ImageLocation = @"..\..\images\dongu.png";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = 2;
            pb.Click += new EventHandler(this.dongu_Olustur_Click);
            pb.MouseDown += new MouseEventHandler(this.picturebox_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.picturebox_MouseMove);
            pb.MouseUp += new MouseEventHandler(this.picturebox_MouseUp);
            pb.MouseClick += new MouseEventHandler(this.dondur);
            degiskenKonum.Add(pb.Location);
            degisken.Add(pb.Name);
            isim = pb.Name;
            return pb;
        }
        public PictureBox karar_Olustur()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(112, 282);
            pb.Name = "pb" + (a++).ToString();
            pb.ImageLocation = @"..\..\images\karar.png";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = 3;
            pb.Click += new EventHandler(this.karar_Olustur_Click);
            pb.MouseDown += new MouseEventHandler(this.picturebox_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.picturebox_MouseMove);
            pb.MouseUp += new MouseEventHandler(this.picturebox_MouseUp);
            pb.MouseClick += new MouseEventHandler(this.dondur);
            degiskenKonum.Add(pb.Location);
            degisken.Add(pb.Name);
            isim = pb.Name;
            return pb;
        }
        public PictureBox veriGirisi_Olustur()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(112, 370);
            pb.Name = "pb" + (a++).ToString();
            pb.ImageLocation = @"..\..\images\veriGirisi.png";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = 4;
            pb.Click += new EventHandler(this.veriGirisi_Olustur_Click);
            pb.MouseDown += new MouseEventHandler(this.picturebox_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.picturebox_MouseMove);
            pb.MouseUp += new MouseEventHandler(this.picturebox_MouseUp);
            pb.MouseClick += new MouseEventHandler(this.dondur);
            degiskenKonum.Add(pb.Location);
            degisken.Add(pb.Name);
            isim = pb.Name;
            return pb;
        }
        public PictureBox veriYazma_Olustur()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(112, 450);
            pb.Name = "pb" + (a++).ToString();
            pb.ImageLocation = @"..\..\images\veriYazma.png";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = 5;
            pb.Click += new EventHandler(this.veriYazma_Olustur_Click);
            pb.MouseDown += new MouseEventHandler(this.picturebox_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.picturebox_MouseMove);
            pb.MouseUp += new MouseEventHandler(this.picturebox_MouseUp);
            pb.MouseClick += new MouseEventHandler(this.dondur);
            degiskenKonum.Add(pb.Location);
            degisken.Add(pb.Name);
            isim = pb.Name;
            return pb;
        }
        public PictureBox bitir_Olustur()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(112, 540);
            pb.Name = "pb" + (a++).ToString();
            pb.ImageLocation = @"..\..\images\bitir.png";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = 6;
            pb.MouseDown += new MouseEventHandler(this.picturebox_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.picturebox_MouseMove);
            pb.MouseUp += new MouseEventHandler(this.picturebox_MouseUp);
            pb.MouseClick += new MouseEventHandler(this.dondur);
            degiskenKonum.Add(pb.Location);
            degisken.Add(pb.Name);
            return pb;
        }
        private void dondur(object sender, MouseEventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            isim = pcb.Name;
            yazdirVeTemas(pcb);


        }
        private void basla_Olustur_Click(object sender, EventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.basla_Guncel();
            secenek = 0;
        }

        private void islem_Olustur_Click(object sender, EventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.islem_Guncel();
            secenek = 1;
            isimDondur(pcb.Name.ToString());


        }
        private void dongu_Olustur_Click(object sender, EventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.dongu_Guncel();
            secenek = 2;
        }
        private void karar_Olustur_Click(object sender, EventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.karar_Guncel();
            secenek = 3;
        }
        private void veriGirisi_Olustur_Click(object sender, EventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.veriGirisi_Guncel();
            secenek = 4;
        }
        private void veriYazma_Olustur_Click(object sender, EventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.veriYazma_Guncel();
            secenek = 5;
        }
        private void picturebox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            surukleme = true;
            ilkKonum = e.Location;
        }
        private void picturebox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            if (surukleme == true)
            {
                Point yeniKonum = pcb.Location;
                yeniKonum.X += e.X - ilkKonum.X;
                yeniKonum.Y += e.Y - ilkKonum.Y;
                pcb.Location = yeniKonum;
                for (int i = 0; i < a - 1; i++)
                {
                    if (degisken[i] == pcb.Name)
                    {
                        degiskenKonum[i] = pcb.Location;
                    }
                }
            }
        }
        private void picturebox_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pcb = sender as PictureBox;
            surukleme = false;
        }
        //XML Oluştur,yazı yazar
        private void yazdirVeTemas(PictureBox pcb)
        {
            //Temas
            for (int k = 0; k < a - 1; k++)
            {
                if ((pcb.Location.X >= degiskenKonum[k].X && pcb.Location.X < degiskenKonum[k].X + 110 || pcb.Location.X <= degiskenKonum[k].X && pcb.Location.X > degiskenKonum[k].X - 100) && pcb.Location.Y > degiskenKonum[k].Y && pcb.Location.Y < degiskenKonum[k].Y + 50)
                {
                    Form1 form1 = (Form1)Application.OpenForms["Form1"];
                    form1.temasSaglandi();
                    k = a - 1;
                    int dc = dizi.Count, bitis = 0;
                    if (dc == 0)
                    {
                        MessageBox.Show("Başla Kontrolü Oluştur");
                    }
                    else
                    {
                        for (int j = 0; j < dizi.Count; j++)
                        {
                            bitis = j;
                        }
                        if (Convert.ToInt32(pcb.Tag) == Convert.ToInt32(dizi[dc - 1]))
                        {
                            //Bir önceki kutu ile taglar aynıysa Arrayliste eklemiyor
                        }
                        else
                        {
                            dizi.Add(pcb.Tag);
                        }
                        if (6 == Convert.ToInt32(dizi[bitis]))
                        {
                            object o = 6;
                            dizi.Add(o);
                            MessageBox.Show("Algoritma Durduruldu");
                            Form1 form = (Form1)Application.OpenForms["Form1"];
                            form.calistirBtn();
                        }
                    }

                }
                else
                {
                    Form1 form1 = (Form1)Application.OpenForms["Form1"];
                    form1.temasSaglanmadi();
                }
            }
        }
    }
}
