using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace flowchart
{
    class Database
    {
        ResimNesnesi olustur = new ResimNesnesi();
        OleDbConnection con;
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        int nesneSayisi = 0,veriSayisi=1;
        public void baglan() {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.Oledb.12.0;Data Source=..\..\database\flowchart.accdb");
        }
        public void veritabaniAdi(string algoritmaAdi) {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("insert into algoritmaAdi(adi) values ('"+algoritmaAdi+"')");
            cmd.ExecuteScalar();
            con.Close();
        }
        public void veritabaniTemizle()
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Delete from veriler";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from islemler";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from nesneler";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from algoritmaAdi";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from donguler";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from kararlar";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void nesneEkle() {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("insert into nesneler(nesneAdi) values ('pb"+(nesneSayisi++)+"')");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void veriEkle() {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("insert into veriler(sahipNesne,veriAdi,veriDeger) values ('" + olustur.getIsim2() + "','s" + (veriSayisi++) + "','"+Form1.veri+"')");
            cmd.ExecuteNonQuery();  
            con.Close(); 
        }
        public void comboBoxVeriGuncelle(ComboBox cb) {
            cb.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from veriler";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr["veriAdi"]);
            }
            dr.Close();
            con.Close();


        }
        public void comboBoxNesneGuncelle(ComboBox cb) {
            cb.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from nesneler";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr["nesneAdi"]);
            }
            dr.Close();
            con.Close();
            
        }
        public void veriHesapla(ComboBox cb1, ComboBox cb2,ComboBox cb3) {
            string cb1_Item = cb1.SelectedItem.ToString();
            string cb2_Item = cb2.SelectedItem.ToString();
            string cb3_Item = cb3.SelectedItem.ToString();
            int s1;
            int s2;
            int s3;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("select veriDeger from veriler where veriAdi='"+cb1_Item+"'");
            s1 = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = ("select veriDeger from veriler where veriAdi='" + cb2_Item + "'");
            s2 = Convert.ToInt32(cmd.ExecuteScalar());
            if (cb3.SelectedItem.ToString() == "+")
            {
                s3 = s1+s2;
            }
            else if (cb3.SelectedItem.ToString() == "-") {
                s3 = s1 - s2;
            }
            else if (cb3.SelectedItem.ToString() == "*") {
                s3 = s1 * s2;
            }
            else if (cb3.SelectedItem.ToString() == "/") {
                s3 = s1 / s2;
            }
            else
            {
                s3 = Convert.ToInt32("NULL");
            }

            cmd.CommandText = ("insert into islemler(veriAdi_1,veriDeger_1,veriAdi_2,veriDeger_2,operator,sonuc)"+
                "values"+
                "('"+cb1_Item+"','"+s1+"','"+cb2_Item+"','"+s2+"','"+cb3_Item+"','"+s3+"')");
            cmd.ExecuteScalar();
            con.Close();
        }
        public void veriDonguEkle(ComboBox cb,int tekrar) {
            string a = cb.SelectedItem.ToString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("insert into donguler(nesneAdi,tekrarSayisi) values ('"+a+"','"+tekrar+"')");
            cmd.ExecuteScalar();
            con.Close();
        }
        public void veriKarar(ComboBox deger1,ComboBox deger2,ComboBox karar,ComboBox dogru,ComboBox yanlis) {
            string secim = karar.SelectedItem.ToString();
            string string_deger1 = deger1.SelectedItem.ToString();
            string string_deger2 = deger2.SelectedItem.ToString();
            string git_dogru = dogru.SelectedItem.ToString();
            string git_yanlis = yanlis.SelectedItem.ToString();

            int int_deger1;
            int int_deger2;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("select veriDeger from veriler where veriAdi='" + string_deger1 + "'");
            int_deger1 = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = ("select veriDeger from veriler where veriAdi='" + string_deger2 + "'");
            int_deger2 = Convert.ToInt32(cmd.ExecuteScalar());

            if (secim == "<")
            {
                if(int_deger1 < int_deger2){
                    veriKarar_veritabaniEkle(string_deger1,int_deger1,string_deger2,int_deger2,secim,git_dogru,"doğru");
                }
                else{
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_yanlis,"yanlış");
                }
            }
            else if (secim == ">")
            {
                if (int_deger1 > int_deger2)
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_dogru,"doğru");
                }
                else
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_yanlis,"yanlış");
                }
            }
            else if (secim == "<=")
            {
                if (int_deger1 <= int_deger2)
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_dogru,"doğru");
                }
                else
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_yanlis,"yanlış");
                }
            }
            else if (secim == ">=")
            {
                if (int_deger1 >= int_deger2)
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_dogru,"doğru");
                }
                else
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_yanlis,"yanlış");
                }
            }
            else if (secim == "==")
            {
                if (int_deger1 == int_deger2)
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_dogru,"doğru");
                }
                else
                {
                    veriKarar_veritabaniEkle(string_deger1, int_deger1, string_deger2, int_deger2, secim, git_yanlis,"yanlış");
                }
            }
            else
            {
                MessageBox.Show("DB veriKarar hatası");
            }
            con.Close();
        }
        private void veriKarar_veritabaniEkle(string string_deger1,int int_deger1,string string_deger2,int int_deger2,string secim,string git_deger,string sonuc) { 
            cmd.Connection = con;
            cmd.CommandText = ("insert into kararlar(veriAdi_1,veriDeger_1,veriAdi_2,veriDeger_2,operator,git,sonuc)" +
                        "values" +
                        "('" + string_deger1 + "','" + int_deger1 + "','" + string_deger2 + "','" + int_deger2 + "','" + secim + "','" + git_deger + "','"+sonuc+"')");
            cmd.ExecuteScalar();
        }
        public void veriGuncelle(ComboBox veriAdi,int veriDeger)
        {
            string string_veriAdi = veriAdi.SelectedItem.ToString();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("update veriler set veriDeger='"+veriDeger+"' where veriAdi='"+string_veriAdi+"'");
            cmd.ExecuteScalar();
            con.Close();
        }
        public void degiskenYazdir(RichTextBox veriler,RichTextBox sonuclar)
        {
            veriler.Clear();
            sonuclar.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("select veriAdi,veriDeger from veriler");
            dr = cmd.ExecuteReader();
            while(dr.Read()){
                veriler.Text += (dr["veriAdi"]+"="+dr["veriDeger"]+"\n");
            }
            dr.Close();
            cmd.CommandText = ("select veriAdi_1,veriAdi_2,operator,sonuc from islemler");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sonuclar.Text += (dr["veriAdi_1"].ToString()+dr["operator"] + dr["veriAdi_2"]+"="+dr["sonuc"]+"\n");
            }
            dr.Close();
            con.Close(); 
        }
    }
}
