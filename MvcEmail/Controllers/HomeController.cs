using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEmail.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MvcEmail.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Contact(EmailFormModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress("anamol.anoj@gmail.com"));  // replace with valid value 
        //        message.From = new MailAddress("saanlamjung@gmail.com");  // replace with valid value
        //        message.Subject = "Your email subject";
        //        message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //        message.IsBodyHtml = true;

        //        using (var smtp = new SmtpClient())
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                UserName = "saanlamjung@gmail.com",  // replace with valid value
        //                Password = "dilli123"  // replace with valid value
        //            };
        //            smtp.Credentials = credential;
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            await smtp.SendMailAsync(message);
        //            return RedirectToAction("Sent");
        //        }
        //    }
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(EmailFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Gmail Address from where you send the mail
                    var fromAddress = "exploreitnepal@gmail.com";
                    // any address where the email will be sending
                    var toAddress = "ravkdl@gmail.com";
                    //Password of your gmail address
                    // Passing the values and make a email formate to display
                    //string subject = txtSubject.Text.Trim();
                    //string body = "From: " + txtName.Text + "\n";
                    //body += "Email: " + txtEmail.Text + "\n";
                    //body += "Subject: " + txtSubject.Text + "\n";
                    //body += "Feedback: \n" + txtComments.Text + "\n";
                    // smtp settings
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    string subject = "Subject should be cool..";
                    var smtp = new System.Net.Mail.SmtpClient();
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(fromAddress, "hariharravi");
                        smtp.Timeout = 20000;
                    }
                    // Passing values to smtp object
                    smtp.Send(fromAddress, toAddress, subject, string.Format(body, model.FromName, model.FromEmail, model.Message));
                    //lblMessage.ForeColor = System.Drawing.Color.Blue;
                    //lblMessage.Text = "Thank you for contacting us";
                    //txtSubject.Text = string.Empty;
                    //txtName.Focus();

                    //txtName.Enabled = false;
                    //txtEmail.Enabled = false;
                    //txtComments.Enabled = false;
                    //txtSubject.Enabled = false;
                    //Button1.Enabled = false;
                    //txtName.Text = string.Empty;
                    //txtEmail.Text = string.Empty;
                    //txtComments.Text = string.Empty;

                }
               
            }
            catch (Exception ex)
            {
                // Log the exception information to 
                // database table or event viewer
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "There is an unkwon problem. Please try later";
            }
            return View("Sent");
        }



        public ActionResult Sent()
        {
            return View();
        }
    }
}