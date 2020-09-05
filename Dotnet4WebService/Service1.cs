using Dotnet4WebService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dotnet4WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
       public string InsertUser(string Last_Name, string Given_Name, string Middle_Name, string Suffix, string Email_Address, string Username, string Password)
        {
            Person p = new Person();
            Account ac = new Account();

            try
            {
                p.InsertPerson(Last_Name, Given_Name, Middle_Name, p.SuffixGetID(Suffix), Email_Address);
            }
            catch
            {
                return "Error in registration, please check whether the Email Address has already been registered before";
            }


           
                ac.AccountInsert(Username, Password, "User", p.PersonGetID(Email_Address));
         


            return "Registration Successful!";





        }

        public bool AccountAuthenticate(string Username, string Password)
        {
            Account ac = new Account();
            string Uname, Pword, Role;
            int PID, SPC;
            int AID = ac.AccountGetID(Username);
            ac.AccountGetInfo(AID, out Uname, out Pword, out Role, out PID, out SPC);
            if (Pword == Password)
                return true;
            else 
                return false;




        }

        public string UpdateAccount(string Username, string NewUsername, string NewPassword)
        {
            Account ac = new Account();
            int AID = ac.AccountGetID(Username);

            try
            {
                ac.AccountUpdate(NewUsername, NewPassword, "User", AID);
            }
            catch
            {
                return "Error in changing account details!, Username might have already been taken!";
            }



            return "Account information updated!";
        }

        public void GetUsertInfo(string Username, out string Last_Name, out string Given_Name, out string Middle_Name, out string Suffix, out string Email_Address)
        {
            int AID, PID, SPC;
            string Uname, Pword, Role;


            Account ac = new Account();
            Person p = new Person();


           AID = ac.AccountGetID(Username);
            ac.AccountGetInfo(AID, out Uname, out Pword, out Role, out PID, out SPC);
            p.PersonGet(PID, out Last_Name, out Given_Name, out Middle_Name, out Suffix, out Email_Address);








        }

        public void UpdateSpamCounter(string Username, int SpamCounter)
        {
            Account ac = new Account();
            int AID = ac.AccountGetID(Username);
            ac.AccountUpdateSpamCounter(AID, SpamCounter);




        }

        public void GuidesGet(out List<string> Guide_Name,out List<string> Plant_Name)
        {
           
            Guide g = new Guide();
            g.GuideGetAll(out Guide_Name, out Plant_Name);
          
        
        
        
        
        }

        public void GuidesGetContent(string GName, string PName,out string Guide_Content,out string Video_URL)
        {
            Guide g = new Guide();
            int GID =  g.GuideGetID(GName, PName);
            g.GuideGet(GID,out string Pn,out Guide_Content,out Video_URL);


        }

        public void GetFeedbacks(string Guide_Name, string Plant_Name,out List<string> Username, out List<string> Date, out List<string> Time, out List<string> Feedback_Content, out List<string> Rating)
        {
            Username = new List<string>();
            Date = new List<string>();
            Time = new List<string>();
            Feedback_Content = new List<string>();
            Rating = new List<string>();
            Feedback f = new Feedback();
            Guide g = new Guide();
            int GID =  g.GuideGetID(Guide_Name, Plant_Name);
            f.FeedbackGetAll(GID, out Username, out Date, out Time, out Feedback_Content, out Rating);

        
        
        }

        public void FeedbackInsert(string Username, string Guide_Name, string Plant_Name, string Date, string Time,string Feedback_Content, int Rating)
        {
            Guide G = new Guide();
            Feedback f = new Feedback();
            Account a = new Account();
            int AID = a.AccountGetID(Username);
            int GID = G.GuideGetID(Guide_Name,Plant_Name);
            f.FeedbackInsert(Date,Time,Feedback_Content,AID,GID,Rating);



        }

        public void GuideGetByPlant(string Plant_Name, out List<string> Guide_Name, out List<string> Plant_Names)
        {

            Guide g = new Guide();
            g.GuideGetByPlant(Plant_Name, out Guide_Name, out Plant_Names);








        }
        public void GetForumsAll(out List<string> Username, out List<string> Date, out List<string> Headline, out List<string> Time)
        {
            Forum f = new Forum();
            f.ForumGetHeader(out Username, out Date, out Headline, out Time);
        
        
        
        
        }

        public void GetForumContent(string Username, string Headline, out string ForumContent, out string Date,out string Time)
        {
            Forum f = new Forum();
            Account a = new Account();
            int AID = a.AccountGetID(Username);
            int FID = f.ForumGetID(Headline, AID);
            f.ForumGet(FID, out ForumContent, out Date, out Time);






        }


        public void GetComments(string Headline, string Poster, out List<string> CommentPoster, out List<string> Date, out List<string> Time, out List<string> Content)
        {
            Forum f = new Forum();
            Comment c = new Comment();
            Account a = new Account();
            int PID = a.AccountGetID(Poster);
            int FID = f.ForumGetID(Headline, PID);
            c.CommentGetForForum(FID, out CommentPoster, out Date, out Time, out Content);
            int x = 0;
            x++;


        }


        public void InsertComment(string Poster,string Commenter, string Headline,string Comment_Content,string Date, string Time)
        {
            Comment c = new Comment();
            Forum f = new Forum();
            Account a = new Account();
            int PID = a.AccountGetID(Poster);
            int CID = a.AccountGetID(Commenter);
            int FID = f.ForumGetID(Headline, PID );


            c.CommentInsert(Date, Time, Comment_Content, CID , FID);




        }



        public void InsertPhoto(byte[] Image, string Poster, string Headline)
        {
            Photo p = new Photo();
            Forum f = new Forum();
            Account a = new Account();
            int AID = a.AccountGetID(Poster);
            int FID = f.ForumGetID(Headline, AID);
            p.InsertPhoto(Image, FID);





        }

       public byte[] GetPhoto(string Poster, string Headline)
        {
            byte[] Img;
            Photo p = new Photo();
            Forum f = new Forum();
            Account a = new Account();
            int AID = a.AccountGetID(Poster);
            int FID = f.ForumGetID(Headline, AID);
            p.GetPhoto(out Img, FID);

            return Img;







        }

         public void InsertForum(string Username,string Headline, string Date, string Time,string Forum_Content)
        {
            Account a = new Account();
            Forum f = new Forum();
            int AID = a.AccountGetID(Username);
            f.ForumInsert(Headline, Forum_Content, Date, Time, AID);








        }


        public int GetSpamCounter(string Username)
        {
            Account a = new Account();
            int AID = a.AccountGetID(Username);
            return a.AccountGetSpamCounter(AID);
        
        
        }




    }
}
