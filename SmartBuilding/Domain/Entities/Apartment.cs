using Domain.Entities;

public class Apartment
{
    public int Id { get; set; }

    public int HouseCommitteeId { get; set; }
    public HouseCommittee HouseCommittee { get; set; }

    public int BuildingId { get; set; }
    public Building Building { get; set; }

    public int ApartmentNumber { get; set; }

    public ICollection<Resident> Residents { get; set; }
}