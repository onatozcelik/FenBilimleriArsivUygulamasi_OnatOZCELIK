using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neodynamic.SDK.Printing;
using System.Data.OleDb;


namespace BarkodeProjectV2
{
    public partial class YazdirmaArayuz : Form
    {

        public static string FbeConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Database\\FbeArchiveAc.accdb";
      
        
        public void TumVeriGetir()
        {
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            OleDbConnection conn = new OleDbConnection(conString);
            string kayit = "SELECT * FROM FbeArsiv order by Mezuniyet_Yili desc";
            conn.Open();
            OleDbCommand komut = new OleDbCommand(kayit, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataTable dt = new DataTable();
            dt.Columns.Add("Seç", typeof(bool));
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = false;
            conn.Close();
            for (int i = 1; i <= 11; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
            }

            dataGridView1.Columns[1].HeaderText = "Öğrenci Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Anabilim Dalı";
            dataGridView1.Columns[3].HeaderText = "Tez Danışmanı";
            dataGridView1.Columns[4].HeaderText = "Tez Adı";
            dataGridView1.Columns[5].HeaderText = "Anahtar Kelimeler";
            dataGridView1.Columns[6].HeaderText = "Mezuniyet Yılı";
            dataGridView1.Columns[7].HeaderText = "Seviye";
            dataGridView1.Columns[8].HeaderText = "Barkod";
            dataGridView1.Columns[9].HeaderText = "Sıra Numarası";
            dataGridView1.Columns[10].HeaderText = "Anabilim Kodu";
            dataGridView1.Columns[11].HeaderText = "Yazdırılma Tarihi";
            label12.Text = Convert.ToString(dataGridView1.RowCount - 1);

        }
        public void VeriGetir()
        {
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            OleDbConnection conn = new OleDbConnection(conString);
            string kayit = "SELECT * FROM FbeArsiv where Mezuniyet_Yili = 0 ";
            conn.Open();
            OleDbCommand komut = new OleDbCommand(kayit, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataTable dt = new DataTable();
            dt.Columns.Add("Seç", typeof(bool));
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = false;
            conn.Close();
            for (int i = 1; i <= 11; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
            }

            dataGridView1.Columns[1].HeaderText = "Öğrenci Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Anabilim Dalı";
            dataGridView1.Columns[3].HeaderText = "Tez Danışmanı";
            dataGridView1.Columns[4].HeaderText = "Tez Adı";
            dataGridView1.Columns[5].HeaderText = "Anahtar Kelimeler";
            dataGridView1.Columns[6].HeaderText = "Mezuniyet Yılı";
            dataGridView1.Columns[7].HeaderText = "Seviye";
            dataGridView1.Columns[8].HeaderText = "Barkod";
            dataGridView1.Columns[9].HeaderText = "Sıra Numarası";
            dataGridView1.Columns[10].HeaderText = "Anabilim Kodu";
            dataGridView1.Columns[11].HeaderText = "Yazdırılma Tarihi";

        }
        public void timePickerAyarla()
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker1.Value = new DateTime(1980, 01, 01);
            dateTimePicker2.Value = new DateTime(1981, 12, 31);

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
             seviyeBox.Items.Add("Yüksek Lisans");
            seviyeBox.Items.Add("Doktora");
            seviyeBox.SelectedIndex = 0;
            

            
        }

        public DataTable GetDataTable() //---------------->Seçilen kayıtları datatable'a atamak için yazılan fonksiyon
        {
            DataTable dtLocalC = new DataTable();
            dtLocalC.Columns.Add("ogr_Adi_Soyadi");
            dtLocalC.Columns.Add("eabd_Kod");
            dtLocalC.Columns.Add("Mezuniyet_Yili");
            dtLocalC.Columns.Add("Barkod");
            int i = 0;

            DataRow drLocal = null;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                bool secenekler = dataGridView1.Rows[i].Cells[0].Value == DBNull.Value ? false : Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                if (secenekler == true)
                {
                    drLocal = dtLocalC.NewRow();
                    drLocal["ogr_Adi_Soyadi"] = dr.Cells["ogr_Adi_Soyadi"].Value;
                    drLocal["eabd_Kod"] = dr.Cells["eabd_Kod"].Value;
                    drLocal["Mezuniyet_Yili"] = dr.Cells["Mezuniyet_Yili"].Value;
                    drLocal["Barkod"] = dr.Cells["Barkod"].Value;
                    dtLocalC.Rows.Add(drLocal);

                }

                i++;
            }

            return dtLocalC;
        }

        public YazdirmaArayuz()
        {
            InitializeComponent();
            DropDownDoldur();
            timePickerAyarla();
            VeriGetir();

        }

        private void printBtn_Click(object sender, EventArgs e)
        {

            string dateFirst = dateTimePicker1.Value.Year.ToString();
            string dateLast = dateTimePicker2.Value.Year.ToString();
            string updateKomut;
            string barkod,ad;
            int i = 0;

            OleDbConnection con = new OleDbConnection(FbeConnString);
            OleDbCommand update;
            DataTable ogrenci = GetDataTable();

            


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
            tLabel.DataSource = ogrenci;

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






            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //bool secenek = dataGridView1.Rows[i].Cells[0].Value == DBNull.Value ? false : (bool)dataGridView1.Rows[i].Cells[0].Value;
                bool secenek = dataGridView1.Rows[i].Cells[0].Value == DBNull.Value ? false : Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);


                if (secenek == true)
                {
                    //Yazdırma İşlemi Burada Yapılacak
                   
                    barkod = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    ad = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    


                    updateKomut = "Update FbeArsiv SET yazdirilmaTarihi = '" + DateTime.Now.ToString() + "' where Barkod = '" + barkod.ToUpper() + "' and ogr_Adi_Soyadi = '"+ad.ToUpper()+"'";


                    con.Open();
                    update = new OleDbCommand(updateKomut, con);
                    update.ExecuteNonQuery();
                    con.Close();




                    dataGridView1.Rows[i].Cells[0].Value = false;

                }


                i++;




            }









        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            string araQuery;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            string dateFirst = dateTimePicker1.Value.Year.ToString();
            string dateLast = dateTimePicker2.Value.Year.ToString();

            if (barkodBox.Text != "")
            {
                araQuery = "SELECT * FROM FbeArsiv where Barkod ='" + barkodBox.Text.ToUpper() + "'";
            }

            else
            {

                if (dateLast != "1981")
                {
                    araQuery = "SELECT * FROM FbeArsiv where ogr_Adi_Soyadi like '" + adBox.Text.ToUpper() + "%' and Enst_Anabilim_Dali like '%" + anabilimBox.Text.ToUpper() + "%' and Tez_Danismani like '%" + danismanBox.Text.ToUpper() + "%' and Tez_Adi like '%" + tezAdBox.Text.ToUpper() + "%' and Anahtar_Kelimeler like '%" + AnahtarKelBox.Text.ToUpper() + "%' and Seviye = '" + seviyeBox.Text + "'and Barkod like '%" + barkodBox.Text.ToUpper() +
                        "%'and Mezuniyet_Yili between " + dateFirst + " and " + dateLast + " order by Mezuniyet_Yili Desc ";

                }

                else
                {
                    araQuery = "SELECT * FROM FbeArsiv where ogr_Adi_Soyadi like '" + adBox.Text.ToUpper() + "%' and Enst_Anabilim_Dali like '%" + anabilimBox.Text.ToUpper() + "%' and Tez_Danismani like '%" + danismanBox.Text.ToUpper() + "%' and Tez_Adi like '%" + tezAdBox.Text.ToUpper() + "%' and Anahtar_Kelimeler like '%" + AnahtarKelBox.Text.ToUpper() + "%' and Seviye = '" + seviyeBox.Text + "'and  Mezuniyet_Yili like '%" +
               mezuniyetBox.Text.ToUpper() + "%' and Barkod like '%" + barkodBox.Text.ToUpper() + "%' order by Mezuniyet_Yili Desc ";
                }

            }

            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            OleDbConnection conn = new OleDbConnection(conString);
            conn.Open();
            OleDbCommand komut = new OleDbCommand(araQuery, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataTable dt = new DataTable();
            dt.Columns.Add("Seç", typeof(bool));
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = false;
            conn.Close();
            for (int i = 1; i <= 11; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
            }

            dataGridView1.Columns[1].HeaderText = "Öğrenci Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Anabilim Dalı";
            dataGridView1.Columns[3].HeaderText = "Tez Danışmanı";
            dataGridView1.Columns[4].HeaderText = "Tez Adı";
            dataGridView1.Columns[5].HeaderText = "Anahtar Kelimeler";
            dataGridView1.Columns[6].HeaderText = "Mezuniyet Yılı";
            dataGridView1.Columns[7].HeaderText = "Seviye";
            dataGridView1.Columns[8].HeaderText = "Barkod";
            dataGridView1.Columns[9].HeaderText = "Sıra Numarası";
            dataGridView1.Columns[10].HeaderText = "Anabilim Kodu";
            dataGridView1.Columns[11].HeaderText = "Yazdırılma Tarihi";
            label12.Text = Convert.ToString(dataGridView1.RowCount - 1);

            if (dataGridView1.RowCount - 1 == 0)
            {
                MessageBox.Show("Kayıt Bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void selectAllbtn_Click(object sender, EventArgs e)
        {
            int i = 0;

            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {

                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    dataGridView1.Rows[i].Cells[0].Value = true;

                    i++;
                }



            }
        }

        private void cancelSelectbtn_Click(object sender, EventArgs e)
        {
            int i = 0;

            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {


                dataGridView1.Rows[i].Cells[0].Value = false;
                i++;



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database\\FbeArchiveAc.accdb";
            OleDbConnection con = new OleDbConnection(conString);
            DataTable silinecekler = GetDataTable();
            int i = 0;

            foreach (DataRow row in silinecekler.Rows)
            {
                //bool secenek = dataGridView1.Rows[i].Cells[0].Value == DBNull.Value ? false : (bool)dataGridView1.Rows[i].Cells[0].Value;
                bool secenek = dataGridView1.Rows[i].Cells[0].Value == DBNull.Value ? false : Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);

                string ad;
                string barkod;
                string mezuniyetYili;
                string eabdCode;
                
                    //Yazdırma İşlemi Burada Yapılacak

                    barkod =silinecekler.Rows[i]["Barkod"].ToString();
                    ad = silinecekler.Rows[i]["ogr_Adi_Soyadi"].ToString();
                mezuniyetYili = silinecekler.Rows[i]["Mezuniyet_Yili"].ToString();
                eabdCode = silinecekler.Rows[i]["eabd_Kod"].ToString();



                string updateKomut = "DELETE FROM FbeArsiv where ogr_Adi_Soyadi = '" + ad + "' and Barkod = '" + barkod.ToUpper() + "' and Mezuniyet_Yili = " + mezuniyetYili + " and  eabd_Kod = '"+eabdCode+"'";


                   con.Open();
                   OleDbCommand update = new OleDbCommand(updateKomut, con);
                   update.ExecuteNonQuery();
                   con.Close();




                    dataGridView1.Rows[i].Cells[0].Value = false;

                i++;
            }

            MessageBox.Show("Kayıtlar Başarıyla Silindi", "İşlem Başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Controls.Clear();
            this.InitializeComponent();
            timePickerAyarla();
            DropDownDoldur();
            VeriGetir();



        }

        private void barkodBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbtn_Click(this, new EventArgs());
                barkodBox.Clear();
            }
        }

        private void allDatabtn_Click(object sender, EventArgs e)
        {
            TumVeriGetir();
        }
    }
}
