using ApplicationLayer.Commands;
using ApplicationLayer.DataTransferObject;
using InfrasturctureLayer.Data;
using MediatR;

namespace InfrasturctureLayer.Handlers.EmployeeHandlers
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdCommand, ServiceResponse>
    {
        private readonly AppDbContext appDbContext;
        public DeleteEmployeeByIdHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var employee = await appDbContext.Employees.FindAsync(request.Id);
            if (employee == null)
                return new ServiceResponse(false, "User not found");

            appDbContext.Employees.Remove(employee);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "User deleted");
        }
    }
}
