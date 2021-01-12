using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SistemaEducativo.Email
{
    public class Mail
    {
        public static string Subjet { get; set; }
        public static string EmailTo { get; set; }
        public static string Body { get; set; }
    }
    public class GestorCorreo
    {
        static MailMessage msg = new MailMessage();
        static SmtpClient sc = new SmtpClient();
        //SmtpClient sc = new SmtpClient("smtp.gmail.com");
        public GestorCorreo()
        {
            msg.From = new MailAddress("pruebasistemaeducativo@gmail.com","Sistema Educativo");
            sc.Credentials = new NetworkCredential("pruebasistemaeducativo@gmail.com", "prueba123,");
            sc.Host = "smtp.gmail.com";
            sc.Port = 25;
            sc.EnableSsl = true;
        }
        public void EnviarCorreo(Mail Mail)
        {
            
            msg.To.Add(Mail.EmailTo);
            msg.Subject = Mail.Subjet;
            msg.IsBodyHtml = true;
            msg.Body = Mail.Body;
            sc.Send(msg);
        }

        public static void EmailCuentaNueva(string Correo, string contrasena)
        {
            Mail Mail = new Mail();
            Mail.EmailTo = Correo;
            Mail.Subjet = "Creación Cuenta Sistema Educativo";
            Mail.Body = "<body>" +
            "<h1>Bienvenido al Sistema Educativo</h1>"+
            "<p>Usuario:"+Correo+"</p>"+
            "<p>Contraseña:" + contrasena + "</p>" +
            "<p>recuerde que al ingresar por primera vez tiene que cambiar la contraseña asignada</p>"+
            "<p><img src='https://localhost:44358/resourse/imagenes/Logo.jpg'> Sistema Educativo</p>" +
            "<small>Derechos reservados © " + DateTime.Now.Year.ToString() + "</small>" +
            "</body>";
            GestorCorreo gestor = new GestorCorreo();
            gestor.EnviarCorreo(Mail);
        }
        public static void EmailCambioContrasena(string Correo)
        {
            Mail Mail = new Mail();
            Mail.EmailTo = Correo;
            Mail.Subjet = "Notificación Sistema Educativo";
            Mail.Body = "<body>" +
            "<h1>Cambio Contraseña</h1>" +
            "<p>El Sistema Educativo notifica el cambio de contraseña</p>" +
            "<p><img src='https://localhost:44358/resourse/imagenes/Logo.jpg'> Sistema Educativo</p>" +
            "<small>Derechos reservados © " + DateTime.Now.Year.ToString() + "</small>" +
            "</body>";
            GestorCorreo gestor = new GestorCorreo();
            gestor.EnviarCorreo(Mail);
        }
    }

}

//string body =
//    "<body>" +
//    "<h1>Hola</h1>" +
//    "<p>Este es un correo de prueba</p>" +
//    "</body>";
//SmtpClient Smtp = new SmtpClient("smtp.gmail.com",587);
//Smtp.Credentials = new NetworkCredential("cjsarasty@gmail.com", "Carlos123,");
//Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
//Smtp.EnableSsl = true;
//Smtp.UseDefaultCredentials = false;
//MailMessage mail = new MailMessage();
//mail.From = new MailAddress("cjsarasty@gmail.com", "Prueba Nombre");
//mail.To.Add(new MailAddress("cjcs.cadenasarasty8@gmail.com"));
//mail.Subject = "Mensaje de Bienvenida";
//mail.IsBodyHtml = true;
//mail.Body = body;
//Smtp.Send(mail);