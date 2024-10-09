using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using BusinessLayer.Services;
using NLog;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try
            {
                var items = _companyService.GetAllCompanies();
                return await Task.Run(() => _mapper.Map<IEnumerable<CompanyDto>>(items));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            try
            {
                var item = _companyService.GetCompanyByCode(companyCode);
                return await Task.Run(() => _mapper.Map<CompanyDto>(item));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        // POST api/<controller>
        public async Task Post([FromBody] CompanyInfo companyInfo)
        {
            try
            {
                await Task.Run(() => _companyService.SaveCompany(companyInfo));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public async Task Put(int id, [FromBody] CompanyInfo companyInfo)
        {
            try
            {
                await Task.Run(() => _companyService.SaveCompany(companyInfo));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async Task Delete(string id)
        {
            try
            {
                await Task.Run(() => _companyService.DeleteCompany(id));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}