using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Exceptions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QuantityMeasurementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityController : ControllerBase
    {
        private IQuantityBL quantityBL;
       
        public QuantityController(IQuantityBL quantityBL)
        {
            this.quantityBL = quantityBL;
        }

        [HttpPost]
        [Route("AddMeasuredQuantity")]
        public IActionResult AddQuantity(QuantityAttributes quantity)
        {
            try
            {
                QuantityAttributes actualQuantity = quantityBL.AddQuantity(quantity);
                
                if (actualQuantity.Result != 0)
                {
                    return Ok(new
                    { 
                        Success = true,
                        Message = "Successful", 
                        Data = actualQuantity 
                    });
                }
                else if (actualQuantity.Operation == " ")
                {
                    return BadRequest(new
                    {
                        Success = false,
                        message = CustomException.ExceptionType.INVALID_FIELD
                    });
                }
                
                else
                {
                    return Ok(new { Success = false, Message = "Failed", Data = actualQuantity });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new 
                { 
                    Success = false, 
                    message = exception.Message 
                });
            }
        }

        [HttpGet]
        [Route("ViewQuantities")]
        public IActionResult  ViewQuantities()
        {
            try
            {
                IEnumerable<QuantityAttributes> quantities = this.quantityBL.ViewQuantities();
                if (quantities != null)
                {
                    return Ok(new 
                    { 
                        Success = true, 
                        Message = "Successfull",
                        Data = quantities
                    });
                }
                else
                {
                    return Ok(new
                    { 
                        Success = false,
                        Message = "Failed",
                        Data = quantities
                    });

                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { Success = false, message = exception.Message });
            }
        }

        [HttpGet]
        [Route("ViewQuantityById/{Id}")]
        public IActionResult ViewQuantityById(int Id)
        {
            try
            {
                //Throw Custom Exception For Invalid Id Field.
                if (Id <= 0)
                {
                    return BadRequest(new
                    { 
                        Success = false,
                        Message = CustomException.ExceptionType.INVALID_FIELD
                    });
                }

               
                QuantityAttributes quantity = this.quantityBL.ViewQuantityById(Id);

                //Returning Response.
                if (quantity != null)
                {
                    return Ok(new 
                    { 
                        Success = true,
                        Message = "Successfull", 
                        Data = quantity
                    });
                }
                else
                {
                    return Ok(new
                    { 
                        Success = false,
                        Message = "Failed",
                        Data = quantity 
                    });

                }
            }
            catch (Exception exception)
            {
                return BadRequest(new 
                { 
                    Success = false,
                    message = exception.Message 
                });
            }
        }

        [HttpDelete]
        [Route("DeleteQuantityById/{Id}")]
        public IActionResult DeleteQuantityById(int Id)
        {
            try
            {
                //Throw Custom Exception For Invalid Id Field.
                if (Id <= 0)
                {
                    return BadRequest(new 
                    { 
                        Success = false,
                        Message = CustomException.ExceptionType.INVALID_FIELD
                    });
                }

               
                QuantityAttributes quantity = this.quantityBL.DeleteQuantityById(Id);

                //Returning Response.
                if (quantity != null)
                {
                    return Ok(new 
                    { 
                        Success = true,
                        Message = "Data Deleted",
                        Data = quantity 
                    });
                }
                else
                {
                    return Ok(new
                    { 
                        Success = false, 
                        Message = "Failed to Delete",
                        Data = quantity 
                    });

                }
            }
            catch (Exception exception)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = exception.Message
                });
            }
        }

        [HttpPost("AddComparision")]
        public IActionResult AddQuantityComparison(QuantityComparision comparison)
        {
            try
            {
                //Throw Custom Exception For Null Field.
                if (comparison == null)
                {
                    return BadRequest(new 
                    { 
                        Success = false,
                        message = CustomException.ExceptionType.EMPTY_FIELD 
                    });
                }

                //Calling Add Comparison From BL.
                QuantityComparision comparison1 = quantityBL.AddQuantityComparison(comparison);

                //Returning Response.
                if (comparison.Result != null)
                {
                    return Ok(new
                    { 
                        Success = true, 
                        Message = "Successful", 
                        Data = comparison1.Result
                    });
                }
                else if ((comparison.firstValueQuantityUnit == " " ||
                        comparison.SecondValueQuantityUnit == " ") || 
                        (comparison.firstValueQuantityUnit == " " &&
                        comparison.SecondValueQuantityUnit == " "))
                {
                    return BadRequest(new {
                        Success = false, 
                        Message = "failed", 
                        Data = CustomException.ExceptionType.INVALID_FIELD
                    });
                }
                else
                {
                    return Ok(new 
                    { 
                        Success = false,
                        Message = "Failed",
                        Data = comparison1
                    });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { Success = false, message = exception.Message });
            }
        }

        [HttpGet("ViewComparisions")]
        public IActionResult ViewQuantityComparisons()
        {
            try
            {
                //Calling GetComparisons From BL To Get All Comparisons Details.
                IEnumerable<QuantityComparision> comparisons = this.quantityBL.ViewQuantityComparisons();

                //Returning Response.
                if (comparisons != null)
                {
                    return Ok(new
                    { 
                        Success = true,
                        Message = "Successfull",
                        Data = comparisons 
                    });
                }
                else
                {
                    return Ok(new
                    { 
                        Success = false,
                        Message = "Failed",
                        Data = comparisons 
                    });

                }
            }
            catch (Exception exception)
            {
                return BadRequest(new 
                { 
                    Success = false,
                    message = exception.Message
                });
            }
        }

        [HttpGet("ViewComparisionById/{Id}")]
        public IActionResult ViewComparisionById(int Id)
        {
            try
            {
                //Throw Custom Exception For Invalid Id Field.
                if (Id <= 0)
                {
                    return BadRequest(new 
                    { 
                        Success = false, 
                        message = CustomException.ExceptionType.INVALID_FIELD
                    });
                }

                //Calling GetCompariosn From BL For Getting Specific Comparison Detail.
                QuantityComparision comparison = this.quantityBL.ViewQuantityComparisonById(Id);

                //Returning Response.
                if (comparison != null)
                {
                    return Ok(new 
                    { 
                        Success = true,
                        Message = "Successfull",
                        Data = comparison 
                    });
                }
                else
                {
                    return Ok(new 
                    { 
                        Success = false, 
                        Message = "Failed", 
                        Data = comparison
                    });

                }
            }
            catch (Exception exception)
            {
                return BadRequest(new
                { 
                    Success = false,
                    message = exception.Message 
                });
            }
        }

        [HttpDelete("DeleteComparisonById/{Id}")]
        public IActionResult DeleteQuantityComparisonById( int Id)
        {
            try
            {
                //Throw Custom Exception For Invalid Id Field.
                if (Id <= 0)
                {
                    return BadRequest(new
                    { 
                        Success = false,
                        Message = CustomException.ExceptionType.INVALID_FIELD 
                    });
                }

                //Calling DeleteCmparison From BL.
                QuantityComparision comparison = this.quantityBL.DeleteQuantityComparisonById(Id);

                //Returning Response.
                if (comparison != null)
                {
                    return Ok(new
                    { 
                        Success = true, 
                        Message = "Successfull", 
                        Data = comparison 
                    });
                }
                else
                {
                    return Ok(new 
                    {
                        Success = false,
                        Message = "Failed",
                        Data = comparison 
                    });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new 
                { 
                    Success = false,
                    message = exception.Message 
                });
            }
        }
    }
}
