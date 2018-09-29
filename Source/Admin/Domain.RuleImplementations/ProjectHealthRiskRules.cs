/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Domain.Projects;
using Infrastructure.Read.MongoDb;
using Read.HealthRisks;
using Read.Projects;

namespace Domain.RuleImplementations
{

    public class ProjectHealthRiskRules : IProjectHealthRiskRules
    {
        private readonly IProjects _projects;
        private readonly IExtendedReadModelRepositoryFor<HealthRisk> _healthRisks;
        private const int MaxNumberOfHealthRisksForProject = 5;

        public ProjectHealthRiskRules(IProjects projects, IExtendedReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _projects = projects;
            _healthRisks = healthRisks;
        }

        public bool IsWithinNumberOfHealthRisksLimit(Guid projectId)
        {
            var project = _projects.GetById(projectId);
            var numberOfRisks = project.HealthRisks?.Length ?? 0;

            return numberOfRisks < MaxNumberOfHealthRisksForProject;
        }

        public bool IsHealthRiskUniqueWithinProject(Guid healthRiskId, Guid projectId)
        {
            var project = _projects.GetById(projectId);
            return project.HealthRisks?.All(p => p.HealthRiskId != healthRiskId) ?? true;
        }

        public bool IsHealthRiskExisting(Guid healthRiskId)
        {
            return _healthRisks.GetById(healthRiskId) != null;
        }
    }
}