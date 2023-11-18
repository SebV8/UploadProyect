namespace WODMaster.BLL.DTO;
public class MembershipModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } // Descripción de la membresía
    public int TotalClassesAllowed { get; set; }
    public decimal Price { get; set; }
    public bool Vigencia { get; set; }

    //public ICollection<Enrollment> Users { get; set; }
}
