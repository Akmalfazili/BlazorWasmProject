using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using InfrasturctureLayer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrasturctureLayer.Handlers.EmployeeHandlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly AppDbContext appDbContext;
        public GetEmployeeListHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await appDbContext.Employees.AsNoTracking().ToListAsync(cancellationToken:cancellationToken);
        }
    }
}
