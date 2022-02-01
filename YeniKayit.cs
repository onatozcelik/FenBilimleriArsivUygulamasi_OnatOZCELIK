using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Neodynamic.SDK.Printing;

namespace BarkodeProjectV2
{
    public partial class YeniKayit : Form
    {
        
        public void KayitYazdir(DataTable dataTable)
        {

            //Define a ThermalLabel object and set unit to inch and label size
            ThermalLabel tLabel = new ThermalLabel(UnitType.Inch, 3, 2);
            tLabel.GapLength = 0.2;

            //Define a couple of TextItem objects for Employee info
            TextItem txt1 = new TextItem(0.1, 0.5, 2.8, 0.3, "");
            //set data field
            txt1.DataField = "ogr_Adi_Soyadi";
            //set font
            txt1.Font.Name = "Arial";
            txt1.Font.Unit = FontUnit.Point;
            txt1.Font.Size = 10;
            txt1.Font.Bold = true;
            //set alignment
            txt1.TextAlignment = TextAlignment.Center;

            TextItem txt2 = new TextItem(0.50, 1.05, 2.8, 0.3, "");
            //set data field
            txt2.DataField = "eabd_Kod";
            //set font
            txt2.Font.Name = "Arial Narrow";
            txt2.Font.Unit = FontUnit.Point;
            txt2.Font.Size = 10;
            txt2.Font.Bold = true;
            //set alignment
            txt2.TextAlignment = TextAlignment.Left;

            TextItem txt3 = new TextItem(0.45, 0.85, 2.8, 0.3, "");
            //set data field
            txt3.DataField = "Mezuniyet_Yili";
            //set font
            txt3.Font.Name = "Arial";
            txt3.Font.Unit = FontUnit.Point;
            txt3.Font.Size = 12;
            txt3.Font.Bold = true;

            //set alignment
            txt3.TextAlignment = TextAlignment.Left;



            //Define a BarcodeItem object for encoding the postal code in USPS Postnet
            BarcodeItem bc = new BarcodeItem(0.1, 0.50, 2.7, 1.0, BarcodeSymbology.Code128, "");
            //set data field

            bc.DataField = "Barkod";
            //set narrow bar width
            bc.BarWidth = 0.01;
            //do not set a quiet zone
            bc.QuietZone = new FrameThickness(0);
            //set barcode alignment
            bc.BarcodeAlignment = BarcodeAlignment.MiddleCenter;

            //hide human readable text
            bc.DisplayCode = true;



            //Add items to ThermalLabel object...
            tLabel.Items.Add(txt1);
            tLabel.Items.Add(txt2);
            tLabel.Items.Add(txt3);
            tLabel.Items.Add(bc);

            //Create data source...



            //set data source...
            tLabel.DataSource = dataTable;

            //Create a WindowsPrintJob object
            using (WindowsPrintJob pj = new WindowsPrintJob())
            {
                //Create PrinterSettings object
                PrinterSettings myPrinter = new PrinterSettings();
                myPrinter.Communication.CommunicationType = CommunicationType.USB;
                myPrinter.Dpi = 203;
                myPrinter.ProgrammingLanguage = ProgrammingLanguage.ZPL;
                myPrinter.PrinterName = "ZDesigner GC420t";

                //Set PrinterSettings to PrintJob
                pj.PrinterSettings = myPrinter;
                //Print ThermalLabel object...
                pj.Print(tLabel);
            }

        }
        private int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(myCombo.GetItemText(obj), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth + SystemInformation.VerticalScrollBarWidth;
        }
        public void DropDownDoldur()
        {
            string query = "SELECT Kod, Anabilimler FROM Anabilim order by Anabilimler asc";
            DataTable anabilim = new DataTable();
            //Datatable doldur sonra datatable'ı combobox source olarak ayarla !!
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            OleDbConnection conn = new OleDbConnection(conString);
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(command);

            da.Fill(anabilim);

            anabilimBox.DataSource = new BindingSource(anabilim, null);
            anabilimBox.DisplayMember = "Anabilimler";
            anabilimBox.ValueMember = "Kod";
            anabilimBox.DropDownWidth = DropDownWidth(anabilimBox);
            string deger = anabilimBox.SelectedValue.ToString();
            kodBox.Text = deger;

            seviyeBox.Items.Add("Yüksek Lisans");
            seviyeBox.Items.Add("Doktora");
            seviyeBox.SelectedIndex = 0;
        }


        public YeniKayit()
        {
            InitializeComponent();
            DropDownDoldur();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deger = anabilimBox.SelectedValue.ToString();
            kodBox.Text = deger;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            string anabilimAdi = yeniAnabilimAd.Text;
            string anabilimKod = yeniAnabilimKod.Text.ToUpper();
            OleDbConnection con = new OleDbConnection(constring);
            OleDbCommand cmd;
            OleDbCommand update;


            update = new OleDbCommand("INSERT INTO Anabilim (Kod,Anabilimler) values(@Kod, @Anabilimler)", con);
            update.Parameters.AddWithValue("@Kod", anabilimKod);
            update.Parameters.AddWithValue("@Anabilimler", anabilimAdi);
            
            con.Open();
            update.ExecuteNonQuery();
            con.Close();

            DropDownDoldur();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";

            OleDbConnection con = new OleDbConnection(constring);
            OleDbCommand cmd;
            
            OleDbCommand update;
            OleDbDataAdapter dr;
            DataTable anabilimDallari = new DataTable();
            
            
            
           
            string ogrAd = adBox.Text.ToUpper();
            string EABD = anabilimBox.Text.ToUpper();
            string Anabilim = anabilimBox.Text;
            int siraNo = 001;
            int eabdNo = 00;
            string mezunYil = mezuniyetBox.Text;
            int yil = Convert.ToInt32(mezunYil) % 100;
            string danisman = danismanBox.Text.ToUpper();
            string anahtarKelimeler = AnahtarKelBox.Text.ToUpper();
            string barcode = "";
            string eabdCode = kodBox.Text;
            string tezAdi = tezAdBox.Text.ToUpper();
            string seviyeKod, seviye;
            seviye = seviyeBox.Text;

           


            if (seviyeBox.SelectedIndex == 0)
            {
                seviyeKod = "YL";
            }
            else
            {
                seviyeKod = "DR";
            }


            //Max Sıra no oluştur
            con.Open();
            DataTable dt = new DataTable();

            cmd = new OleDbCommand("SELECT MAX(siraNo) as SiraNo FROM FbeArsiv where Mezuniyet_Yili= " + mezunYil + "and Seviye= '" + seviyeBox.Text + "'", con);

            dr = new OleDbDataAdapter(cmd);
            dr.Fill(dt);

            OleDbCommand anabilim = new OleDbCommand("Select ID From Anabilim where Anabilimler ='" + Anabilim + "'", con);
            OleDbDataAdapter df = new OleDbDataAdapter(anabilim);
            df.Fill(anabilimDallari);


            con.Close();

            eabdNo = Convert.ToInt32(anabilimDallari.Rows[0][0].ToString());

            if (dt.Rows[0][0] == System.DBNull.Value)
            {
                siraNo = 001;
            }

            if (dt.Rows[0][0] != System.DBNull.Value)
            {
                siraNo = Convert.ToInt32(dt.Rows[0][0]) + 1;
            }

            barcode = seviyeKod + yil + eabdNo.ToString("000") + siraNo.ToString("0000");
            // update = new OleDbCommand("Insert Into FbeArsiv(ogr_Adi_Soyadi,Enst_Anabilim_Dali,Tez_Danismani,Tez_Adi,Anahtar_Kelimeler,Mezuniyet_Yili,Seviye,Barkod,siraNo,eabd_Kod) Values ('" + adBox.Text.ToUpper() + "', '" + anabilimBox.Text.ToUpper() + "', '" + danismanBox.Text.ToUpper() + "', '" + tezAdBox.Text.ToUpper() + "', '" + AnahtarKelBox.Text.ToUpper() + "', " + mezunYil + ", '" + seviyeBox.Text + "', '" + barcode + "', " + siraNo + ", '" + eabdCode + "')", con);
            update = new OleDbCommand("INSERT INTO FbeArsiv (ogr_Adi_Soyadi, Enst_Anabilim_Dali, Tez_Danismani, Tez_Adi, Anahtar_Kelimeler, Mezuniyet_Yili, Seviye, Barkod, siraNo, eabd_Kod) values(@ogr_Adi_Soyadi, @Enst_Anabilim_Dali, @Tez_Danismani, @Tez_Adi, @Anahtar_Kelimeler, @Mezuniyet_Yili, @Seviye, @Barkod, @siraNo, @eabd_Kod)", con);
            update.Parameters.AddWithValue("@ogr_Adi_Soyadi", ogrAd);
            update.Parameters.AddWithValue("@Enst_Anabilim_Dali", EABD);
            update.Parameters.AddWithValue("@Tez_Danismani", danisman);
            update.Parameters.AddWithValue("@Tez_Adi", tezAdi);
            update.Parameters.AddWithValue("@Anahtar_Kelimeler", anahtarKelimeler);
            update.Parameters.AddWithValue("@Mezuniyet_Yili", mezunYil);
            update.Parameters.AddWithValue("@Seviye", seviye);
            update.Parameters.AddWithValue("@Barkod", barcode);
            update.Parameters.AddWithValue("@siraNo", siraNo);
            update.Parameters.AddWithValue("@eabd_Kod", eabdCode);
            con.Open();
            update.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Kaydı Tamamlanan Öğrenci: " + adBox.Text.ToUpper() + " \n Oluşturulan Barkod: " + barcode + "\n Seçilen Anabilim: " + EABD + "(" + eabdCode + ")");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            string ogrAd = adBox.Text.ToUpper();
            string EABD = anabilimBox.Text.ToUpper();
            int siraNo = 001;
            int eabdNo = 00;
            string mezunYil = mezuniyetBox.Text;
            int yil = Convert.ToInt32(mezunYil) % 100;
            string danisman = danismanBox.Text.ToUpper();
            string anahtarKelimeler = AnahtarKelBox.Text.ToUpper();
            string barcode = "";
            string eabdCode = kodBox.Text;
            string tezAdi = tezAdBox.Text.ToUpper();
            string seviyeKod, seviye;
            seviye = seviyeBox.Text;


            if (seviyeBox.SelectedIndex == 0)
            {
                seviyeKod = "YL";
            }
            else
            {
                seviyeKod = "DR";
            }

            OleDbConnection con = new OleDbConnection(constring);
            OleDbCommand cmd;
            OleDbCommand update;
            OleDbDataAdapter dr;

            //Max Sıra no oluştur
            con.Open();
            DataTable dt = new DataTable();

            cmd = new OleDbCommand("SELECT MAX(siraNo) as SiraNo FROM FbeArsiv where Mezuniyet_Yili= " + mezunYil + "and Seviye= '" + seviyeBox.Text + "'", con);

            dr = new OleDbDataAdapter(cmd);
            dr.Fill(dt);

            con.Close();

            if (dt.Rows[0][0] == System.DBNull.Value)
            {
                siraNo = 001;
            }

            if (dt.Rows[0][0] != System.DBNull.Value)
            {
                siraNo = Convert.ToInt32(dt.Rows[0][0]) + 1;
            }

            barcode = seviyeKod + yil + eabdNo.ToString("00") + "00" + siraNo.ToString("000");
            // update = new OleDbCommand("Insert Into FbeArsiv(ogr_Adi_Soyadi,Enst_Anabilim_Dali,Tez_Danismani,Tez_Adi,Anahtar_Kelimeler,Mezuniyet_Yili,Seviye,Barkod,siraNo,eabd_Kod) Values ('" + adBox.Text.ToUpper() + "', '" + anabilimBox.Text.ToUpper() + "', '" + danismanBox.Text.ToUpper() + "', '" + tezAdBox.Text.ToUpper() + "', '" + AnahtarKelBox.Text.ToUpper() + "', " + mezunYil + ", '" + seviyeBox.Text + "', '" + barcode + "', " + siraNo + ", '" + eabdCode + "')", con);
            update = new OleDbCommand("INSERT INTO FbeArsiv (ogr_Adi_Soyadi, Enst_Anabilim_Dali, Tez_Danismani, Tez_Adi, Anahtar_Kelimeler, Mezuniyet_Yili, Seviye, Barkod, siraNo, eabd_Kod) values(@ogr_Adi_Soyadi, @Enst_Anabilim_Dali, @Tez_Danismani, @Tez_Adi, @Anahtar_Kelimeler, @Mezuniyet_Yili, @Seviye, @Barkod, @siraNo, @eabd_Kod)", con);
            update.Parameters.AddWithValue("@ogr_Adi_Soyadi", ogrAd);
            update.Parameters.AddWithValue("@Enst_Anabilim_Dali", EABD);
            update.Parameters.AddWithValue("@Tez_Danismani", danisman);
            update.Parameters.AddWithValue("@Tez_Adi", tezAdi);
            update.Parameters.AddWithValue("@Anahtar_Kelimeler", anahtarKelimeler);
            update.Parameters.AddWithValue("@Mezuniyet_Yili", mezunYil);
            update.Parameters.AddWithValue("@Seviye", seviye);
            update.Parameters.AddWithValue("@Barkod", barcode);
            update.Parameters.AddWithValue("@siraNo", siraNo);
            update.Parameters.AddWithValue("@eabd_Kod", eabdCode);
            con.Open();
            update.ExecuteNonQuery();
            con.Close();

            DataTable ogrenci = new DataTable();
            ogrenci.Columns.Add("ogr_Adi_Soyadi");
            ogrenci.Columns.Add("eabd_Kod");
            ogrenci.Columns.Add("Mezuniyet_Yili");
            ogrenci.Columns.Add("Barkod");

            ogrenci.Rows.Add(ogrAd,eabdCode,mezunYil,barcode);



            KayitYazdir(ogrenci);

            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            OleDbConnection conn = new OleDbConnection(conString);

           string updateKomut = "Update FbeArsiv SET yazdirilmaTarihi = '" + DateTime.Now.ToString() + "' where Barkod = '" + barcode + "' and ogr_Adi_Soyadi = '" + ogrAd + "'";


            con.Open();
            update = new OleDbCommand(updateKomut, con);
            update.ExecuteNonQuery();
            con.Close();



            MessageBox.Show("Kaydı Tamamlanan Öğrenci: " + adBox.Text.ToUpper() + " \n Oluşturulan Barkod: " + barcode + "\n Seçilen Anabilim: " + EABD + "(" + eabdCode + ")");

        }
    }
}
