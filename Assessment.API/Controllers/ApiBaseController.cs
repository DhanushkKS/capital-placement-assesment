using Microsoft.AspNetCore.Mvc;

namespace Assessment.API.Controllers;
[ApiController]
[Route(BasePath+"[controller]")]
public class ApiBaseController:ControllerBase
{
    private const string BasePath = "api/v1/";
}