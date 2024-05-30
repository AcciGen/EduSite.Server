using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.AuthServise
{
    public interface IAuthServise
    {
        public Task<string> GenerateToken(UserModel user);
    }
}
