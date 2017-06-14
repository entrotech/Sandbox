namespace Sandbox.Web.Data
{
    public class PogFile
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string FileKey { get; set; }
        public string Url { get; set; }

        public int PogId { get; set;}
        public Pog Pog { get; set; }
    }
}