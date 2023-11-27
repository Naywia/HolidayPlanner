using System;
using System.Collections.Generic;

namespace HolidayPlanner.Models;

public class Team
{
    public Int32 ID { get; set; }
    public String Name { get; set; }
    public Int32 MinimumAttendance { get; set; }
    public List<Employee> Members { get; set; }
    public List<Team> IncludedTeams { get; set; }

    public VacationDay GetVacationsForDay(DateOnly date)
    {
        throw new NotImplementedException();
    }
    
    public void GetVacationsForDay(DateTime dateInWeek)
    {
        throw new NotImplementedException();
    }
}