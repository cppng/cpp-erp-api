using Dapper;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using Erp.Persistence.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Dapper.Hr.Employee.NewEmployee;

public class NewEmployeeInfraService : INewEmployeeInfraService
{
    private readonly IDapperService _dapperService;
    private DynamicParameters _dbParams;

    public NewEmployeeInfraService(IDapperService dapperService)
    {
        _dapperService = dapperService ?? throw new ArgumentNullException(nameof(dapperService));
    }

    public async Task<NewEmployeeBaseResponseDto> CreateEmployee(NewEmployeeCommand request, CancellationToken ct)
    {
        try
        {

            var slug = Guid.NewGuid().ToString();

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: slug, direction: ParameterDirection.Input);
            _dbParams.Add("FirstName", dbType: DbType.String, value: request.FirstName, direction: ParameterDirection.Input);
            _dbParams.Add("MiddleName", dbType: DbType.String, value: request.MiddleName, direction: ParameterDirection.Input);
            _dbParams.Add("LastName", dbType: DbType.String, value: request.LastName, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<NewEmployeeResponseDto>("proc_HR_CreateNewEmployee", _dbParams, commandType: CommandType.StoredProcedure));

            return new NewEmployeeBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new NewEmployeeBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }
}
