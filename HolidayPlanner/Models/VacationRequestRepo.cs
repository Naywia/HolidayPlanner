using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidayPlanner.Models;

public class VacationRequestRepo {
    private List<VacationRequest> _vacationRequests = new List<VacationRequest>();
    private VacationTypeRepo _vacationTypeRepo;

    public VacationRequestRepo (VacationTypeRepo vacationTypeRepo) {
        _vacationTypeRepo = vacationTypeRepo;
    }

    public void AddVacationRequest(VacationRequest vacationRequest)
    {
        var index = _vacationRequests.FindIndex(i => i.Id == vacationRequest.Id);

        if (index > -1)
            return;

        _vacationRequests.Add(vacationRequest);
    }

    public void UpdateVacationRequest(VacationRequest vacationRequest)
    {
        var index = _vacationRequests.FindIndex(i => i.Id == vacationRequest.Id);

        if (index == -1) {
            AddVacationRequest(vacationRequest);
            return;
        }

        var newReq = new VacationRequest(vacationRequest);
        _vacationTypeRepo.UpdateVacationType(newReq.Type);
        _vacationRequests[index] = newReq;
    }

    private VacationRequest _NewRequestFull(VacationRequest vacationRequest) {
        var newRequest = new VacationRequest(vacationRequest);
        newRequest.Type = _vacationTypeRepo.GetVacationTypeById(newRequest.Id);

        return newRequest;
    }

    public VacationRequest? GetVacationRequestById(int Id)
    {
        VacationRequest? internalRequest = _vacationRequests.Find(i => i.Id == Id);

        if (internalRequest == null)
            return null;

        return _NewRequestFull(internalRequest);
    }

    public List<VacationRequest> GetVacationRequests()
    {
        var newList = new List<VacationRequest>();
        _vacationRequests.ForEach(i => newList.Add(_NewRequestFull(i)));
        return newList;
    }

    public void RemoveVacationRequest(VacationRequest vacationRequest)
    {
        var index = _vacationRequests.FindIndex(i => i.Id == vacationRequest.Id);

        if (index == -1)
            return;
        
        _vacationRequests.RemoveAt(index);
    }
}