﻿using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Exceptions;
using ContactsBook.Application.Features.Address.Commands.CreateAddress;

namespace ContactsBook.Application.Features.Contact.Commands.CreateContact
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(
            IMapper mapper,
            IContactRepository contactRepository,
            IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _addressRepository = addressRepository;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateContactCommandValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (!validationResult.IsValid)
            //    throw new BadRequestException("Invalid person data", validationResult);

            var address = new Domain.Address(request.Country, request.City, request.Street, request.Number);
            var contact = await _contactRepository.GetAsync(request.ContactId);

            if (contact is null)
                throw new NotFoundException(nameof(Contact), request.ContactId);

            contact.AddAddress(address);

            var createdPerson = await _contactRepository.UpdateAsync(contact);

            return createdPerson.Id;
        }
    }
}
