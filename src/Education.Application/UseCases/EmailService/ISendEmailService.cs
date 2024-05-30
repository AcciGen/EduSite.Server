using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.EmailService
{
    public interface ISendEmailService
    {
        public Task SendEmailAsync(EmailModel emailModel);
    }
}
