namespace HolidayPlanner.Models
{
    public class VacationType
    {
        public int Id {get; private set;}
        public string Name {get; set;}

        public VacationType (int Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }

        public VacationType (VacationType oldVacationType) {
            this.Id = oldVacationType.Id;
            this.Name = new string(oldVacationType.Name);
        }
    }
}
