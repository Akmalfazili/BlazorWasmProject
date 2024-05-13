using ApplicationLayer.DataTransferObject;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands
{
    public class CreateEmployeeCommand : IRequest<ServiceResponse>
    {
        public Employee? Employee { get; set; }
    }
}
