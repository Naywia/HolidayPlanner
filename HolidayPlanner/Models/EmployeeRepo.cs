using Avalonia.Markup.Xaml.MarkupExtensions;
using System;
using System.Collections.Generic;
using System.Reactive;

namespace HolidayPlanner.Models;

public class EmployeeRepo
{
    private List<Employee> _employees = new List<Employee>();
    private VacationRequestRepo _vacationRequestRepo;


    public EmployeeRepo(VacationRequestRepo vacationRequestRepo)
    {
        _vacationRequestRepo = vacationRequestRepo;

        #region testdata
        VacationTypeRepo vacationTypeRepo = new VacationTypeRepo();

        List<Employee> testdata = new List<Employee>() {
            new Employee(1, "oln@unit-it.dk", "oln", "ThisIsMyPassword", 13.4,
                new List<VacationRequest>() {
                    new VacationRequest(1, new DateTime(2022, 8, 8, 8, 0, 0), new DateTime(2022, 8, 26, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Sommerferie", VacationRequestState.Approved)
                }
            ),
            new Employee(2, "dml@unit-it.dk", "dml", "password", 5.2,
                new List<VacationRequest>() {
                    new VacationRequest(1, new DateTime(2023, 12, 22, 8, 0, 0), new DateTime(2024, 1, 12, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1))
                }
            )
        };

        #endregion
    }

    public void AddEmployee(Employee employee)
    {
        var index = _employees.FindIndex(i => i.Id == employee.Id);

        if (index != -1)
            return;

        var newEmployee = new Employee(employee);
        _employees.Add(newEmployee);
    }

    public void UpdateEmployee(Employee employee)
    {
        var index = _employees.FindIndex(i => i.Id == employee.Id);

        if (index == -1)
        {
            AddEmployee(employee);
            return;
        }

        var newEmployee = new Employee(employee);
        employee.VacationRequests.ForEach(i => _vacationRequestRepo.UpdateVacationRequest(i));
        _employees[index] = newEmployee;
    }

    private Employee _newEmployee(Employee employee)
    {
        var newEmployee = new Employee(employee);
        newEmployee.VacationRequests.Clear();
        employee.VacationRequests.ForEach(
            e => newEmployee.VacationRequests.Add(_vacationRequestRepo.GetVacationRequestById(e.Id))
        );
        return newEmployee;
    }

    public List<Employee> GetEmployees()
    {
        var newList = new List<Employee>();
        _employees.ForEach(i => newList.Add(_newEmployee(i)));
        return newList;
    }

    public Employee? GetEmployeeById(int Id)
    {
        var interalEmployee = _employees.Find(i => i.Id == Id);

        if (interalEmployee == null)
            return null;

        return _newEmployee(interalEmployee);
    }

    public Employee? GetEmployeeByUsername(string Username)
    {
        var interalEmployee = _employees.Find(i => i.Username == Username);

        if (interalEmployee == null)
            return null;

        return _newEmployee(interalEmployee);
    }

    public Employee? GetEmployeeByEmail(string Email)
    {
        var interalEmployee = _employees.Find(i => i.Email == Email);

        if (interalEmployee == null)
            return null;

        return _newEmployee(interalEmployee);
    }

    public void Remove(Employee employee)
    {
        var index = _employees.FindIndex(i => i.Id == employee.Id);

        if (index == -1)
            return;

        _employees.RemoveAt(index);
    }
}