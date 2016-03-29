namespace TestFramework
{
    public class HomePage : PageBase
    {
        private const string Title = "Arzamas";

        public HomePage()
            : base(Constants.Host, "")
        {
        }

        public override bool IsAt()
        {
            return Browser.Title == Title;
        }
    }
}