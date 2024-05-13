using ApplicationLayer.DataTransferObject;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands
{
    public class UpdateEmployeeCommand : IRequest<ServiceResponse>
    {
        public Employee? Employee { get; set; }
    }
}
