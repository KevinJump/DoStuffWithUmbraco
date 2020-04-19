using DoStuff.Core.RepoPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Logging;
using Umbraco.Core.Scoping;

namespace DoStuff.Core.RepoPattern.Persistance
{
    public class MyListRepo : DoStuffRepositoryBase<MyList>
    {
        public MyListRepo(IScopeAccessor scopeAccessor, IProfilingLogger logger, DoStuffRepoOptions doStuffRepoOptions) 
            : base(scopeAccessor, logger)
        {
            this.tableName = doStuffRepoOptions.MyListTable;
        }
    }
}
