using System.Collections.Generic;

namespace HolidayPlanner.Models;

public class Employee {
    public int Id {get; private set;}
    public string Email {get; set;}
    public string Username {get; set;}
    public string Password { get; private set; }
    public double AvailableVacationDays {get; set;}
    public List<VacationRequest> VacationRequests {get; private set;}

    public Employee (int Id, string Email, string Username, string Password, double AvailableVacationDays, List<VacationRequest> VacationRequests) {
        this.Id = Id;
        this.Email = Email;
        this.Username = Username;
        this.Password = Password;
        this.AvailableVacationDays = AvailableVacationDays;
        this.VacationRequests = VacationRequests;
    }

    public Employee (Employee oldEmployee) {
        this.Id = oldEmployee.Id;
        this.Email = new string(oldEmployee.Email);
        this.Username = new string(oldEmployee.Username);
        this.Password = new string(oldEmployee.Password);
        this.AvailableVacationDays = oldEmployee.AvailableVacationDays;
        this.VacationRequests = oldEmployee.VacationRequests;
    }
}