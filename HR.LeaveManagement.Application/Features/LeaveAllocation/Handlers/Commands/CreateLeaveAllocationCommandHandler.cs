﻿using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler :IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.LeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.AddAsync(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
