﻿using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class CreateDenonciationCommand : IRequest<string>
    {
        public string Id { get; }
        public string InformantFirstName { get; }
        public string InformantLasttName { get; }
        public Address InformantAddress { get; }
        public string SuspectFirstName { get; }
        public string SuspectLasttName { get; }
        public Address SuspectAddress { get; }
        public DateTimeOffset Date { get; }
        public Crime Crime { get;}
        public string? Country { get; }

        public CreateDenonciationCommand(string informantFirstName, string informantLastName, Address informantAddress, string suspectFirstName, string suspectLastName, Address suspectAddress, Crime crime, string country)
        {
            Id = Guid.NewGuid().ToString();
            InformantFirstName = informantFirstName;
            InformantLasttName = informantLastName;
            InformantAddress = informantAddress;
            SuspectFirstName = suspectFirstName;
            SuspectLasttName = suspectLastName;
            SuspectAddress = suspectAddress;
            Date = DateTimeOffset.UtcNow;
            Crime = crime;
            Country = country;
        }
    }
}
