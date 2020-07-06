using System.Net.Mail;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VarunWebsite.Models;
using System.Net;
using Microsoft.Ajax.Utilities;

namespace VarunWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Experiences()
        {
            return View();
        }

        public ActionResult Photos()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(MailModel vm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage(vm.Email, "varun.wadhwa19@gmail.com");

                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message + "\n\n\n This message came from your personal website and was sent by: " + vm.Email;

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential("varun.wadhwa19@gmail.com", "qzaqmxjbmzvgiqgj");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);


                    ModelState.Clear();

                    String successResponse = "Hi, your form has been submitted successfully. Thank you!";
                    Response.Write("<script>alert('" + successResponse + "')</script>");


                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    String failResponse = "There has been an issue with server connection, and the error is: " + ex.Message;
                    Response.Write("<script>alert('" + failResponse + "')</script>");
                }
            }
            else
            {
                String failResponse = "Your form cannot be submitted. Please make sure all fields are filled in.";
                Response.Write("<script>alert('" + failResponse + "')</script>");
            }

            return View();
        }

    }
}






