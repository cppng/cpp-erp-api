using AutoMapper;
using Erp.Domain.Entities.User;
using Erp.Helper.ViewModel.User;
using Erp.Persistence.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Persistence.Services.User
{
    public class UserDataService
    {
        private readonly IAsyncRepository<UserEntity> _users;
        private readonly IMapper _mapper;
        public UserDataService(IAsyncRepository<UserEntity> users,
            IMapper mapper)
        {
            _users = users ?? throw new ArgumentNullException(nameof(users));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserViewModel>>(await _users.GetAllAsync());
        }
        public async Task<UserViewModel> GetByIdDetails(int id)
        {
            var requests = await _users
                .GetSingleAsync(x => x.Id == id);

            return _mapper.Map<UserEntity, UserViewModel>(requests);
        }
    }
}
