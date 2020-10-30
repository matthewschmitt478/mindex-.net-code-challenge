using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;   // Needed for getting the employee that will be added into the ReportingStructure.

        public ReportingStructureService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Creates a ReportingStructure at the time of request by the given employee id.
        /// </summary>
        /// <param name="id"> The employee's id that will be used to fill out the ReportingStructure. </param>
        /// <returns> A newly created ReportingStructure with the employee and how many reports they have. </returns>
        public ReportingStructure GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                ReportingStructure reportingStructure = new ReportingStructure();

                // Getting the employee in order to add it to the struture
                var employee = _employeeRepository.GetById(id);

                reportingStructure.Employee = employee;

                int reports = GetDirectReports(employee);

                reportingStructure.NumberOfReports = reports;

                return reportingStructure;
            }

            return null;
        }

        private int GetDirectReports(Employee employee)
        {
            var reportsList = employee.DirectReports;

            int reports = 0;

            if (reportsList != null)
            {
                if (reportsList.Count != 0)
                {
                    foreach (Employee e in reportsList)
                    {
                        reports += 1 + GetDirectReports(e);
                    }
                }
            }

            return reports;
        }
    }
}
