using DoStuff.Core.RepoPattern.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Scoping;

namespace DoStuff.Core.RepoPattern.Services
{
    public abstract class DoStuffBaseService<TModel>
        where TModel : class
    {
        protected readonly IProfilingLogger logger;
        protected IDoStuffRepository<TModel> baseRepository;

        protected IScopeProvider scopeProvider;

        public DoStuffBaseService(
            IScopeProvider scopeProvider,
            IDoStuffRepository<TModel> baseRepository,
            IProfilingLogger logger)
        {
            this.scopeProvider = scopeProvider;
            this.logger = logger;

            this.baseRepository = baseRepository;
        }

        public virtual TModel Get(int id)
        {
            using (scopeProvider.CreateScope(autoComplete: true))
            {
                return baseRepository.Get(id);
            }
        }

        public virtual IEnumerable<TModel> GetAll(params int[] ids)
        {
            using (scopeProvider.CreateScope(autoComplete: true))
            {
                return baseRepository.GetAll(ids);
            }
        }

        public virtual PagedResult<TModel> GetAllPaged(int page, int pageSize, params int[] ids)
        {
            using (scopeProvider.CreateScope(autoComplete: true))
            {
                return baseRepository.GetAllPaged(page, pageSize, ids);
            }
        }


        public virtual TModel Save(TModel item)
        {
            using(scopeProvider.CreateScope(autoComplete: true))
            {
                return baseRepository.Save(item);

            }
        }

        public virtual void Delete(int id)
        {
            using (scopeProvider.CreateScope(autoComplete: true))
            {
                baseRepository.Delete(id);
            }
        }

        public int Count()
        {
            using (scopeProvider.CreateScope(autoComplete: true))
            {
                return baseRepository.Count();
            }
        }
    }
}
