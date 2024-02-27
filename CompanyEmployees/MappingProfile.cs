using AutoMapper;
using CompanyEmployees.Entities.Models;
using CompanyEmployees.Shared.DTOs;

namespace CompanyEmployees;

public class MappingProfile: Profile
{
	public MappingProfile()
	{
		CreateMap<Company, CompanyDto>()
			.ForCtorParam("FullAddress",
				opts => opts.MapFrom(x => string.Join(" ", x.Address, x.Country)));
	}
}

