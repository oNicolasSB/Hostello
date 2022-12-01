using hostello.Data;

namespace hostello.Controllers;

public class CategoriaController
{
    private readonly AppDbContext _db;

    public CategoriaController(AppDbContext db)
    {
        _db = db;
    }
}