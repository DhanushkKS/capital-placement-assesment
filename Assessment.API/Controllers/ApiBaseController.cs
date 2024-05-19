using Microsoft.AspNetCore.Mvc;

namespace Assesment.API.Controllers;
[ApiController]
[Route(BasePath+"[controller]")]
public class ApiBaseController:ControllerBase
{
    private const string BasePath = "api/v1/";
}