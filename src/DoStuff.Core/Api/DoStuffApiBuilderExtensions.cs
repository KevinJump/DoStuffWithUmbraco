using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoStuff.Core.Api.Configuration;

using Microsoft.Extensions.DependencyInjection;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Api;
internal static class DoStuffApiBuilderExtensions
{
	/// <summary>
	///  Adds API config to services collection
	/// </summary>
	/// <remarks>
	/// Add in Composer / other extension methods.
	/// <code>
	///		buider.AddDoStuffApi();
	/// </code>
	/// </remarks>
	public static IUmbracoBuilder AddDoStuffApi(this IUmbracoBuilder builder)
	{
		builder.Services.ConfigureOptions<DoStuffSwaggerGenOptions>();

		return builder;

	}
}
