using Dapper;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using Erp.Persistence.Dapper;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Dapper.Hr.EmpPayElement;

public class EmpPayElemInfraService: IEmpPayElemInfraService
{
    private readonly IDapperService _dapperService;
    private DynamicParameters _dbParams;

    public EmpPayElemInfraService(IDapperService dapperService)
    {
        _dapperService = dapperService ?? throw new ArgumentNullException(nameof(dapperService));
    }

   public async Task<EmpPayElemBaseResponseDto> SavePayElem(EmpPayElemCommand request, CancellationToken ct)
   {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("Id", dbType: DbType.Int32, value: request.Id, direction: ParameterDirection.Input);
            _dbParams.Add("EmployeeSlug", dbType: DbType.String, value: request.EmployeeSlug, direction: ParameterDirection.Input);
            _dbParams.Add("EntryType", dbType: DbType.String, value: request.EntryType, direction: ParameterDirection.Input);
            _dbParams.Add("ElementCode", dbType: DbType.String, value: request.ElementCode, direction: ParameterDirection.Input);
            _dbParams.Add("Name", dbType: DbType.String, value: request.Name, direction: ParameterDirection.Input);
            _dbParams.Add("Amount", dbType: DbType.Decimal, value: request.Amount, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpPayElemResponseDto>("proc_HR_Save_Employee_Pay_Element", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpPayElemBaseResponseDto
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
            return new EmpPayElemBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

}
