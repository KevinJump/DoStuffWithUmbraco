namespace DoStuff.Core.RepoPattern.Persistance
{
    public class DoStuffRepoOptions
    {
        /// <summary>
        /// used the options design pattern to pass configuration via DI.
        /// </summary>
        public DoStuffRepoOptions()
        {
            MyListTable = DoStuff.Tables.MySimpleTable;
        }

        public string MyListTable { get; set; }
    }
}
