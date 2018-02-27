/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.StaffUser.CommandHandlers;
using Domain.StaffUser.PhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.AspNet;
using Read.StaffUsers;

namespace Web.Controllers
{
    [Route("api/staffusers")]
    public class StaffUserController : BaseController
    {
        private readonly IStaffUsers _users;

        private readonly IStaffUserCommandHandler _staffUserCommandHandler;

        public StaffUserController (
            IStaffUsers users,
            IStaffUserCommandHandler stafffUserCommandHandler
            )
        {
            _users = users;
            _staffUserCommandHandler = stafffUserCommandHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<StaffUser>> GetAllStaffUsers()
        {
            var users = await _users.GetAllAsync();
            return users;
        }

        [HttpPost("add")]
        public void Add([FromBody] AddStaffUser command)
        {
            //TODO: Question: Set DataCollectorId here, in CommandHandler or make the request contain the DataCollectorId?
            command.StaffUserId = Guid.NewGuid();
            _staffUserCommandHandler.Handle(command);
            
        }

        [HttpPost("update")]
        public void Update([FromBody] UpdateStaffUser command)
        {
            // TODO: QUESTION: Maybe have specific Command-model classes for each
            // of the staffuser types to ensure that the correct information is 
            // given?
            _staffUserCommandHandler.Handle(command);
            
        }
        [HttpDelete("delete")]
        public void Delete([FromBody] DeleteStaffUser command)
        {
            _staffUserCommandHandler.Handle(command);
        }
    }
}