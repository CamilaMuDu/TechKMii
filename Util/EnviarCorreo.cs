using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HambXSLT_CamilaMuñoz
{
    public class EnviarCorreo
    {
        public String CuentaCorreoElectronico = "utnpruebaisw711@gmail.com";
        public String ContrasenaGeneradaGmail = "fhplwjoogyjbpftd";

        public EnviarCorreo()
        {

        }

        public void enviarCorreoGmail(string body, string receptor, string asunto, string adjuntoPdf, string adjuntoXml)
        {
            MailMessage mensaje = new MailMessage();
            mensaje.IsBodyHtml = true;
            mensaje.Subject = asunto;
            mensaje.Body = body;
            mensaje.From = new MailAddress(CuentaCorreoElectronico);
            mensaje.To.Add(receptor);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(CuentaCorreoElectronico, ContrasenaGeneradaGmail);
            smtp.EnableSsl = true;

            // PDF
            if (!string.IsNullOrWhiteSpace(adjuntoPdf) && System.IO.File.Exists(adjuntoPdf))
            {
                Attachment attachmentPdf = new Attachment(adjuntoPdf);
                mensaje.Attachments.Add(attachmentPdf);
            }

            // XML
            if (!string.IsNullOrWhiteSpace(adjuntoXml) && System.IO.File.Exists(adjuntoXml))
            {
                Attachment attachmentXml = new Attachment(adjuntoXml);
                mensaje.Attachments.Add(attachmentXml);
            }

            smtp.Send(mensaje);

            MessageBox.Show("Correo enviado correctamente",
                "Enviar Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
