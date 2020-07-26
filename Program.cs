using LIKE_BOT.Clients;

namespace LIKE_BOT
{
    class MainClass
    {
        static Twitter twitterBot;
        public static void Main(string[] args)
        {
            twitterBot = new Twitter("[user]","[pass]","[search]");
        }
    }
}
