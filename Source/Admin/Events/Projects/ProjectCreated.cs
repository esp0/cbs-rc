/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Projects
{
    public class ProjectCreated : IEvent 
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid NationalSocietyId { get; }
        public Guid DataOwnerId { get; }
        public int SurveillanceContext { get; }

        public ProjectCreated (Guid id, string name, Guid nationalSocietyId, Guid dataOwnerId, int surveillanceContext) 
        {
            Id = id;
            Name = name;
            NationalSocietyId = nationalSocietyId;
            DataOwnerId = dataOwnerId;
            SurveillanceContext = surveillanceContext;
        }
    }
}