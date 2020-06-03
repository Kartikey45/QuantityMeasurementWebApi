using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Exceptions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult ViewQuantities()
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

    }
}
