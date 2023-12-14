using Avalonia.Markup.Xaml.MarkupExtensions;
using HolidayPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        VacationTypeRepo vacationTypeRepo = MainViewModel.vacationTypeRepo;

        List<Employee> testdata = new List<Employee>() {
            new Employee(1, "oln@unit-it.dk", "oln", "ThisIsMyPassword", 13.4,
                new ObservableCollection<VacationRequest>() {
                    new(2, new DateTime(2023, 5, 6, 8, 0, 0), new DateTime(2023, 5, 8, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Jeg er ked af det", VacationRequestState.Rejected),
                    new(1, new DateTime(2023, 8, 8, 8, 0, 0), new DateTime(2023, 8, 26, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Sommerferie", VacationRequestState.Approved),
                    new(2, new DateTime(2024, 3, 16, 7, 30, 0), new DateTime(2024, 5, 13, 15, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Laaang ferie"),
                    new(3, new DateTime(2023, 6, 18, 8, 0, 0), new DateTime(2023, 6, 28, 17, 0, 0), vacationTypeRepo.GetVacationTypeById(3), "Begravelse", VacationRequestState.Approved)
                }
            ),
            new Employee(2, "dml@unit-it.dk", "dml", "password", 5.2,
                new ObservableCollection<VacationRequest>() {
                    new(1, new DateTime(2023, 8, 8, 8, 0, 0), new DateTime(2023, 8, 26, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Sommerferie", VacationRequestState.Approved),
                    new(1, new DateTime(2024, 12, 22, 8, 0, 0), new DateTime(2025, 1, 12, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1)),
                    new(5, new DateTime(2024, 1, 14, 8, 0, 0), new DateTime(2024, 3, 5, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Jeg har brug for ferie.", VacationRequestState.Rejected),
                    new(4, new DateTime(2024, 1, 9, 9, 0, 0), new DateTime(2024, 1, 27, 18, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Min kone siger at vi skal på skitur.")
                }
            ),
            new Employee(2, "alk@unit-it.dk", "alk", "password123", 8.7,
                new ObservableCollection<VacationRequest>() {
                    new(1, new DateTime(2023, 8, 8, 8, 0, 0), new DateTime(2023, 8, 26, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Sommerferie", VacationRequestState.Approved),
                    new(1, new DateTime(2023, 10, 3, 8, 0, 0), new DateTime(2023, 10, 25, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Efterårsferie", VacationRequestState.Approved),
                    new(1, new DateTime(2024, 1, 15, 8, 0, 0), new DateTime(2024, 1, 17, 16, 0, 0), vacationTypeRepo.GetVacationTypeById(3), "Aftalt med chef", VacationRequestState.Approved),
                    new(4, new DateTime(2024, 1, 25, 9, 0, 0), new DateTime(2024, 1, 27, 18, 0, 0), vacationTypeRepo.GetVacationTypeById(1), "Aftale med chef")
                }
            )
        };

        #endregion

        _employees = testdata;
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

    public ObservableCollection<VacationRequest> GetEmployeeVacationRequests(int Id)
    {
        Employee employee = _employees.Find(i => i.Id == Id);

        if (employee == null)
            return null;

        return employee.VacationRequests;
    }

    public void Remove(Employee employee)
    {
        var index = _employees.FindIndex(i => i.Id == employee.Id);

        if (index == -1)
            return;

        _employees.RemoveAt(index);
    }
}
