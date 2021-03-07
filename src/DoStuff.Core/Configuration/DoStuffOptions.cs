namespace DoStuff.Core.Configuration
{
    /// <summary>
    ///  Options class, this represents the options stored in the appsettings.json file
    /// </summary>
    public class DoStuffOptions
    {
        /// <summary>
        ///  the name of the section
        /// </summary>
        public static string DoStuffSection = "DoStuff";

        public int MagicNumber { get; set; } = 10;
    }
}
