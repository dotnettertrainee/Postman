using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsletterClass;
using MvcApplicationFootballplayer.Models;
using MvcApplicationFootballplayer.Data;
using System.Configuration;
using System.Net.Mail;

namespace MvcApplicationFootballplayer.Controllers
{
    public class HomeController : Controller
    {
        #region Main Sites
        public ActionResult Index()
        {
            ViewBag.Title = "Welcome to FootDBall";
            ViewBag.Message = "Thanks for using FootDBall";
            ViewBag.Name = "ASFAJSKL";

            return View();
        }

        public int siker(int one, int two){
            int siker = one + two;
            Console.WriteLine("Sike!");
            return siker;
        }

        public String concatinator(string one, string two)
        {
            string concated = String.Concat(one, two);

            return concated;
        }

        public void viewTeams()
        {
            var entites = new Entities();
        }

        public static String reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

        [HttpGet]
        public ActionResult YourDB()
        {
            ViewBag.Message = "YourDB";

            PlayerView view = new PlayerView();

            Entities db = new Entities();

            view.Name = getPlayerName();

            return View(view);
        }
        #endregion
        
        private String getPlayerName()
        {
            Entities db = new Entities();

            return db.Player.FirstOrDefault().Name;
        }

        [HttpPost]
        public ActionResult YourDB(TeamListView view)
        {
            ViewBag.Message = "YourDB";

            Entities db = new Entities();

            var teamListView = new TeamListView();

            var teamNames = db.Team.ToList();
            #region test
            /* http://stackoverflow.com/questions/25279547/how-to-display-database-records-in-asp-net-mvc-view 
            using (db)
            {
                
            }
            */
            #endregion

            #region emailSend
            string Body = System.IO.File.ReadAllText("C:\\Users\\shariffdeena\\Documents\\Visual Studio 2013\\Projects\\Postman\\Email Template\\index.html");
            
            var List = db.Player.ToList();

            string newsletterEmailHost = ConfigurationManager.AppSettings["newsletterEmailHost"].ToString();
            string newsletterEmailFrom = ConfigurationManager.AppSettings["newsletterEmailFrom"].ToString();
            string newsletterEmailFromName = ConfigurationManager.AppSettings["newsletterEmailFromName"].ToString();
            string newsletterEmailSubject = ConfigurationManager.AppSettings["newsletterEmailSubject"].ToString();

            SmtpClient smtpClient = new SmtpClient(newsletterEmailHost);
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(newsletterEmailFrom, newsletterEmailFromName);
            mailMessage.To.Add(new MailAddress("akeel.shariffdeen@futurecom.ch"));
            mailMessage.Subject = newsletterEmailSubject;
            mailMessage.IsBodyHtml = true;
            /**  This obviously cannot work though **/
            string content = "";
            
            foreach (var s in List)
            {
                content += s.Name+" "+s.Firstname+"<br>";
            }

            Body = Body.Replace("#dummytext#", content);
            
            mailMessage.Body = Body;

            smtpClient.Send(mailMessage);
            mailMessage.Dispose();
            smtpClient.Dispose();
            #endregion

            return View();
        }
        
        [HttpGet]
        public ActionResult TeamPlayers()
        {
            ViewBag.Message = "YourDB";

            var view = new TeamPlayerListView();

            var db = new Entities();

            var currentTeam = db.Team.FirstOrDefault();

            view.team = currentTeam;

            view.playerList = (from p in db.Player
                               join po in db.Position on p.ID equals po.PlayerIDFK
                               where po.TeamIDFK == currentTeam.ID
                               select p).ToList();

            return View(view);
        }

        public ActionResult TeamView(TeamPlayerListView view)
        {
            var db = new Entities();
            
            var listOfTeam = db.Team.ToList();

            //variable currentTeam actually not needed
            var currentTeam = db.Team.FirstOrDefault();
            view.team = currentTeam;

            view.teamList = listOfTeam;
            
            return View(view);
        }

        public ActionResult CreateTeam(PlayerView view)
        {
            Entities db = new Entities();
            
            var player = new Player();
            player.Name = view.Name;
            player.Firstname = view.Firstname;
            player.Primary_Nationality = view.Primary_Nationality;
            player.Birthdate = view.Birthdate;
            player.Market_Value = view.Market_Value;
            
            //db.SaveChanges();
            return View(view);
        }
    }
}