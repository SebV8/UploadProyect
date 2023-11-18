namespace WODMaster.DAL.Entities;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    // Otras propiedades del usuario
    public ICollection<Enrollment> Memberships { get; set; }

}
