using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidayPlanner.Models;

public class TeamRepo
{
    List<Team> teams = new ();


    public void Add(Team team)
    {
        teams.Add(team);
    }
    
    public List<Team> GetAll()
    {
        return teams;
    }
    
    public Team? GetByID(int id)
    {
        return teams.Find(t => t.ID == id);
    }

    public void Update(Team team)
    {
        throw new NotImplementedException();
    }
    
    public void Remove(Team team)
    {
        teams.Remove(team);
    }
}