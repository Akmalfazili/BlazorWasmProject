using ApplicationLayer.Commands;
using ApplicationLayer.DataTransferObject;
using InfrasturctureLayer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfrasturctureLayer.Handlers.EmployeeHandlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ServiceResponse>
    {
        private readonly AppDbContext appDbContext; 
        public CreateEmployeeHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var check = await appDbContext.Employees.FirstOrDefaultAsync(_ => _.Name.ToLower() == request.Employee.Name.ToLower());
            if (check != null)
                return new ServiceResponse(false, "User already exists.");
            appDbContext.Employees.Add(request.Employee);
            await appDbContext.SaveChangesAsync(cancellationToken);
            return new ServiceResponse(true, "User added");
        }
    }
}
