using ApplicationLayer.Commands;
using ApplicationLayer.DataTransferObject;
using DomainLayer.Entities;
using InfrasturctureLayer.Data;
using MediatR;

namespace InfrasturctureLayer.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResponse>
    {
        private readonly AppDbContext appDbContext;
        public UpdateEmployeeHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            appDbContext.Update(request.Employee);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }
    }
}
