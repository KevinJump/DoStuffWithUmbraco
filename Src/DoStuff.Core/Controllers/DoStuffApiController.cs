using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoStuff.Core.Configuration;
using DoStuff.Core.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Umbraco.Cms.Web.BackOffice.Controllers;

namespace DoStuff.Core.Controllers
{
    public class DoStuffApiController : UmbracoAuthorizedApiController
    {
        private readonly DoStuffOptions _options;
        private readonly DoStuffService _doStuffService;

        public DoStuffApiController(IOptions<DoStuffOptions> options,
            DoStuffService doStuffService)
        {
            _options = options.Value;
            _doStuffService = doStuffService;
        }

        [HttpGet]
        public int GetMagicNumber() => _options.MagicNumber;

        [HttpGet]
        // /umbraco/backoffice/api/dostuffapi/IsBiggerThanMagic?number=x
        public bool IsBiggerThanMagic(int number)
            => _doStuffService.IsHigherThanMagicNumber(number);
    }
}
