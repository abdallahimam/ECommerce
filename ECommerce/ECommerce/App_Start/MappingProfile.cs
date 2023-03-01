using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			  CreateMap<MarketType, MarketTypeModel>();
			  CreateMap<MarketTypeModel, MarketType>();
		}
	}
}