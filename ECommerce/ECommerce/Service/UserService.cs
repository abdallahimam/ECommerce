using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ECommerce.Service
{
	public class UserService : IUserService
	{
		public readonly IHttpContextAccessor _httpContext;

		public UserService(IHttpContextAccessor httpContext)
		{
			_httpContext = httpContext;
		}

		public string GetUserId()
		{
			if (_httpContext.HttpContext.User != null)
			{
				if (_httpContext.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier) != null)
				{
					return _httpContext.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
				}
			}
			return "";
		}

		internal bool IsAuthenticated()
		{
			return _httpContext.HttpContext.User.Identity.IsAuthenticated;
		}
	}
}