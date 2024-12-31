using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelperServer.ModelsBL;

namespace TrainingHelperServer.Services
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}
