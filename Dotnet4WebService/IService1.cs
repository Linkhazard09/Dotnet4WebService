using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dotnet4WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
        string InsertUser(string Last_Name,string Given_Name,string Middle_Name, string Suffix, string Email_Address, string Username, string Password);


        [OperationContract]
        bool AccountAuthenticate(string Username, string Password);

        [OperationContract]
        string UpdateAccount(string Username, string NewUsername, string NewPassword);

        [OperationContract]
        void GetUsertInfo(string Username, out string Last_Name, out string Given_Name, out string Middle_Name, out string Suffix, out string Email_Address);

        [OperationContract]
        void UpdateSpamCounter(string Username, int SpamCounter);

        [OperationContract]
       void GuidesGet(out List<string>Guide_Name, out List<string> Plant_Name);

        [OperationContract]
        void GuidesGetContent(string GName, string PName, out string Guide_Content, out string Video_URL);

        [OperationContract]
        void GetFeedbacks(string Guide_Name, string Plant_Name,out List<string> Username, out List<string> Date, out List<string> Time, out List<string> Feedback_Content, out List<string> Rating);

        [OperationContract]
        void FeedbackInsert(string Username, string Guide_Name, string Plant_Name, string Date, string Time, string Feedback_Content, int Rating);

        [OperationContract]
        void GuideGetByPlant(string Plant_Name,out List<string> Guide_Name,out List<string> Plant_Names);

        [OperationContract]
        void GetForumsAll(out List<string> Username, out List<string> Date, out List<string> Headline, out List<string> Time);

        [OperationContract]
        void GetForumContent(string Username, string Headline, out string ForumContent, out string Date, out string Time);

        [OperationContract]
        void GetComments(string Headline, string Poster,out List<string> CommentPoster, out List<string> Date, out List<string> Time, out List<string> Content);

        [OperationContract]
        void InsertComment(string Poster,string Commenter, string Headline, string Comment_Content, string Date, string Time);

        [OperationContract]
        void InsertPhoto(byte[] Image, string Poster, string Headline);

        [OperationContract]
        byte[] GetPhoto(string Poster, string Headline);

        [OperationContract]
        void InsertForum(string Username, string Headline, string Date, string Time, string Forum_Content);

        [OperationContract]
        int GetSpamCounter(string Username);






        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Dotnet4WebService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
