using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DoStuff.Core.RepoPattern.Models;
using DoStuff.Core.RepoPattern.Services;
using Umbraco.Web.WebApi;

namespace DoStuff.Core.Controllers
{

    //~/umbraco/backoffice/api/dostuffapi/getapi

    public class DoStuffApiController : UmbracoAuthorizedApiController
    {
        private MyListService _myListService;

        public DoStuffApiController(MyListService myListService)
        {
            _myListService = myListService;
        }

        /// <summary>
        ///  simple call, used to locate the controller
        ///  when we inject it into the javascript variables.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetApi() => "Hello we are doing stuff.";

        /// <summary>
        /// simple example of using the injected service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MyList> GetLists() => _myListService.GetAll().ToList();

    }

}