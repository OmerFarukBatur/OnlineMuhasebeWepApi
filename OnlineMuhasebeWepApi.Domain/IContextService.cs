using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Domain
{
    public interface IContextService
    {
        DbContext CreateDbContext(string companyId);
    }
}
