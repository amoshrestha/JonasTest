using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            var res = _employeeRepository.GetAllEmployee();
            return _mapper.Map<IEnumerable<EmployeeInfo>>(res);
        }

        public void SaveEmployee(EmployeeInfo employee)
        {
            _employeeRepository.SaveEmployee(_mapper.Map<Employee>(employee));
        }
    }
}
