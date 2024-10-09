using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using BusinessLayer.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            try
            {
                var items = _employeeService.GetAllEmployee();
                throw new Exception();
                //return await Task.Run(() => _mapper.Map<IEnumerable<EmployeeDto>>(items));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task Post([FromBody] EmployeeInfo employeeInfo)
        {
            try
            {
                await Task.Run(() => _employeeService.SaveEmployee(employeeInfo));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}