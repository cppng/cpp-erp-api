using AutoMapper;
using Erp.Domain.Entities.User;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;

namespace Helper_Layer.Mapper;

public class MappingProfiles: Profile
{
    public MappingProfiles() {
        CreateMap<NewUserRequestCommand, ApplicationUser>().ReverseMap();
        CreateMap<NewUserRequestDto, NewUserRequestCommand>().ReverseMap();
        CreateMap<ApplicationUser, UserResponseDto>().ReverseMap();

        CreateMap<EmpBasicUpdateCommand, EmpBasicUpdateRequestDto>().ReverseMap();
        CreateMap<EmpContactUpdateCommand, EmpContactUpdateRequestDto>().ReverseMap();
        CreateMap<EmpNokUpdateCommand, EmpNokUpdateRequestDto>().ReverseMap();
        CreateMap<EmpDetailsUpdateCommand, EmpDetailsUpdateRequestDto>().ReverseMap();
        CreateMap<EmpSalaryUpdateCommand, EmpSalaryUpdateRequestDto>().ReverseMap();
        CreateMap<EmpStatutoryUpdateCommand, EmpStatutoryUpdateRequestDto>().ReverseMap();
    }
}
