using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidayPlanner.Models;

public class VacationTypeRepo {
    #region testdata
    private List<VacationType> testdata = new List<VacationType>()
    {
        new VacationType(1, "Ferie"),
        new VacationType(2, "Halve fridage"),
        new VacationType(3, "Privat aftale"),
        new VacationType(4, "Barsel")
    };
    #endregion

    private List<VacationType> _vacationTypes = new List<VacationType>();

    // Constructor to set list to testdata.
    public VacationTypeRepo() 
    {
        _vacationTypes = testdata;
    }

    public void AddVacationType(VacationType vacationType)
    {
        var index = _vacationTypes.FindIndex(i => i.Id == vacationType.Id);

        if (index > -1)
            return;

        _vacationTypes.Add(vacationType);
    }

    public VacationType? GetVacationTypeById(int Id)
    {
        VacationType? internalRequest = _vacationTypes.Find(i => i.Id == Id);

        if (internalRequest == null)
            return null;

        return new VacationType(internalRequest);
    }

    public List<VacationType> GetVacationTypes()
    {
        var newList = new List<VacationType>();
        _vacationTypes.ForEach(i => newList.Add(new VacationType(i)));
        return newList;
    }

    public void RemoveVacationType(VacationType vacationType)
    {
        var index = _vacationTypes.FindIndex(i => i.Id == vacationType.Id);

        if (index == -1)
            return;

        _vacationTypes.RemoveAt(index);   
    }

    public void UpdateVacationType(VacationType vacationType)
    {
        var index = _vacationTypes.FindIndex(i => i.Id == vacationType.Id);

        if (index == -1) {
            AddVacationType(vacationType);
            return;
        }

        _vacationTypes[index] = new VacationType(vacationType);
    }
}