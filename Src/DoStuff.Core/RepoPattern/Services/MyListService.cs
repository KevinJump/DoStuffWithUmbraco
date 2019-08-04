using DoStuff.Core.RepoPattern.Models;
using DoStuff.Core.RepoPattern.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Logging;
using Umbraco.Core.Scoping;

namespace DoStuff.Core.RepoPattern.Services
{
    /// <summary>
    ///  inheriting from our base service, means the get/set/delete stuff is done
    /// </summary>
    public class MyListService : DoStuffBaseService<MyList>
    {
        public MyListService(IScopeProvider scopeProvider, IDoStuffRepository<MyList> baseRepository, IProfilingLogger logger) 
            : base(scopeProvider, baseRepository, logger)
        {
        }
    }
}
