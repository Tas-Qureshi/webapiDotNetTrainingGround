using Microsoft.AspNetCore.Mvc;
using webapiDotNetTrainingGround.Models;

[ApiController]
[Route("/api/[Controller]")]
public class DevelopersController : ControllerBase
{
    private readonly Db _db;

    public DevelopersController(Db db)
    {
        _db = db;
    }

    [HttpGet]
    public List<DeveloperResponse> GetAllDevelopers()
    {

        List<DeveloperResponse> dr = new List<DeveloperResponse>();
        foreach (var item in _db.Developers)
        {
            var tempDr = new DeveloperResponse()
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email
            };
            dr.Add(tempDr);
        }

        return dr;
    }
    //[HttpGet("id")]
    [HttpGet("{id}")]
    public DeveloperResponse? GetDeveloperById(int id)
    {
        var tempData = _db.Developers.Find(d => d.Id == id);
        var tempDr = new DeveloperResponse()
        {
            Id = tempData.Id,
            Name = tempData.Name,
            Email = tempData.Email
        };
        return tempDr;
    }

    [HttpPost]
    public IActionResult CreateNewDeveloper(CreateDeveloperRequest request)
    {
        var nextId = _db.Developers.Count + 1;

        var newDev = new Developer()
        {
            Id = nextId,
            Name = request.Name,
            Email = request.Email
        };
        _db.Developers.Add(newDev);

        return CreatedAtAction(nameof(GetDeveloperById), new { id = nextId }, newDev);
    }

    //[HttpGet("id/address/Name/email")]
    //[HttpGet("{id}/address/{addressId}/{street}")]//
    //public Developer? GetData(int id, string name, string emaail)
    //{
    //return _db.Find(d => d.Name == name);
    //}

}
