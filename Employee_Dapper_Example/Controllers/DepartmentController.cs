using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Dapper_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentServices _services;
        public DepartmentController(IDepartmentServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var deptdata = await _services.GetDepartmentDetails();
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartmentDto deptdetail)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                var deptdata = await _services.AddDepartment(deptdetail);
                return StatusCode(StatusCodes.Status201Created, deptdata);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetDepartmentByid/{deptid}")]
        public async Task<IActionResult> GetDept(int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _services.GetDepartmentById(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error :" + ex );
            }
        }

        [HttpDelete]
        [Route("DeleteDepartmentById/{deptid}")]
        public async Task<IActionResult> delete([FromRoute] int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request:" + deptid);
            }
            try
            {
                var deptdata = await _services.DeleteDepartmentById(deptid);
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "deptdata not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> Update([FromBody]DepartmentDto dept)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }
                else
                {
                    var deptdata = await _services.UpdateDepartment(dept);
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
