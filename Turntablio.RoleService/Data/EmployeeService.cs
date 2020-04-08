﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Turntablio.RoleService.Data.Model;

namespace Turntablio.RoleService.Data
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IHttpClientFactory _clientFactory;
        private readonly EmployeeContext _context;
        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public EmployeeService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<EmployeeModel[]> GetEmplyee()
        {
            string psql = "select * from employee";

            return _context.LoadData<EmployeeModel, dynamic>(psql, new { });


            //var request = new HttpRequestMessage(HttpMethod.Get,
            // "https://role-api.herokuapp.com/api/employees");

            // var client = _clientFactory.CreateClient();
            // var response = await client.SendAsync(request);

            //return null;

        }

        public Task InsertEmployee(EmployeeModel employee)
        {
            string psql = @"insert into Employee(firstName, LastName, Emailaddress, Address, Role)
                            values (@firstName, @LastName, @Emailaddress, @Address, @Role);";

            return _context.SaveData(psql, employee);
        }

        //public async Task<EmployeeModel[]> GetEmplyeeAsync()
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get,
        //   "https://role-api.herokuapp.com/api/employees");

        //    var client = _clientFactory.CreateClient();
        //    var response = await client.SendAsync(request);

        //    return null;

        //}
    }
}
