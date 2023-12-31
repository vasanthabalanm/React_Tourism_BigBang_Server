﻿using MakeMyTrip.Models;
using MakeMyTrip.Repository.AgentRegister;
using MakeMyTrip.Repository.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakeMyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelAgentRegisterController : ControllerBase
    {

        private readonly IAgents _agent;

        public TravelAgentRegisterController(IAgents agent)
        {
            _agent = agent;
        }

        [HttpPost("register")]
        public async Task<ActionResult> AddAgent([FromBody] TravelAgent travelAgent)
        {
            try
            {
                return await _agent.AddAgent(travelAgent);
            }
            catch
            {
                // Return a generic error response to the client
                return StatusCode(500, new { Message = "An error occurred while adding a Agent. Please try again later." });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TravelAgent>>> GetAllTravelAgentRequest()
        {
            try
            {
                return await _agent.GetAllTravelAgentRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<List<TravelAgent>>> DeleteTravelAgent(int id)
        {
            try
            {
                return await _agent.DeleteTravelAgent(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
