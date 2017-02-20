using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using itextsharp.pdfa.iTextSharp;

namespace Dental_Management_System
{
    public partial class PaymentModu : Form
    {
        public PaymentModu()
        {
            InitializeComponent();
        }

        private void PaymentModu_Load(object sender, EventArgs e)
        {
            Visitdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void exporttopdf_button_Click(object sender, EventArgs e)
        {
            string DocAddress = Properties.Settings.Default["DocAddress"].ToString();
            string DocNumber = Properties.Settings.Default["DocNumber"].ToString();
            string DoctorName = Properties.Settings.Default["DoctorName"].ToString();
            string DoctorOfficeName = Properties.Settings.Default["DocOfficeName"].ToString();

            string savePDF = string.Empty;

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = savePDF;
            saveFile.Filter = "PDF (*.pdf)|*.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                savePDF = saveFile.FileName;

            }


            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.A4);
                PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(savePDF, FileMode.Create));

                doc.Open();

                Paragraph header = new Paragraph(DoctorOfficeName, FontFactory.GetFont(FontFactory.HELVETICA, 18, iTextSharp.text.Font.BOLD));
                header.Alignment = Element.ALIGN_CENTER;

                Paragraph header1 = new Paragraph("Doctor name: " + DoctorName, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                header1.Alignment = Element.ALIGN_CENTER;

                Paragraph header2 = new Paragraph("Address:" , FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                header2.Alignment = Element.ALIGN_CENTER;

                Paragraph header3 = new Paragraph(DocAddress, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                header3.Alignment = Element.ALIGN_CENTER;

                Paragraph header4 = new Paragraph("Tel no. " + DocNumber, FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                header4.Alignment = Element.ALIGN_CENTER;

                Paragraph NewLine = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                NewLine.Alignment = Element.ALIGN_CENTER;


                doc.Add(header);
                doc.Add(NewLine);
                doc.Add(header1);
                doc.Add(header2);
                doc.Add(header3);
                doc.Add(header4);

                MessageBox.Show("PDF filed saved " + "\n" + saveFile.FileName, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                doc.Close();
                this.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
