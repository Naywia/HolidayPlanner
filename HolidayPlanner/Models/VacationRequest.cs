using System;
using System.IO;

namespace HolidayPlanner.Models;

public class VacationRequest {
    public int Id {get; private set;}
    public DateTime StartDateTime {get; set;}
    public DateTime EndDateTime {get; set;}
    public VacationType Type {get; set;}
    public string Message {get; set;}
    public VacationRequestState RequestStatus {get; set;}

    public VacationRequest (int Id, DateTime StartDateTime, DateTime EndDateTime, VacationType Type, string Message = "No Message", VacationRequestState RequestStatus = VacationRequestState.AwaitingApproval) {
        this.Id = Id;

        if (StartDateTime.CompareTo(EndDateTime) >= 0) 
            throw new InvalidDataException($"StartDateTime ({StartDateTime}) has to be before EndDateTime ({EndDateTime})");

        this.StartDateTime = StartDateTime;
        this.EndDateTime = EndDateTime;
        this.Type = Type;
        this.Message = Message;
        this.RequestStatus = RequestStatus;
    }

    public VacationRequest (VacationRequest oldRequest) {
        this.Id = oldRequest.Id;
        this.StartDateTime = oldRequest.StartDateTime;
        this.EndDateTime = oldRequest.EndDateTime;
        this.Type = new VacationType(oldRequest.Type);
        this.Message = new string(oldRequest.Message);
        this.RequestStatus = oldRequest.RequestStatus;
    }
}