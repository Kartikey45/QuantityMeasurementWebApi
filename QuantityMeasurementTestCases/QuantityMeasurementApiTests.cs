using BusinessLayer.Interface;
using QuantityMeasurementWebAPI.Controllers;
using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using RepositoryLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using System.Collections.Generic;
using System.Linq;
using RepositoryLayer.Service;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DBContext;

namespace QuantityMeasurementTestCases
{
    // Class For Test Cases.
    public class QuantityMeasurementApiTests
    {
        // Business Layer class Reference
        readonly QuantityBL _quantityBL;

        //Repository Layer class Reference
        readonly QuantityRL _quantityRl;

        //Declare DbCotextOption variable
        public static DbContextOptions<QuantityMeasurementDBContext> Quantities { get; }

        //Provide Connection string
        public static string connectionString = "Data Source=DESKTOP-IVOPHLI\\SQLEXPRESS;Initial Catalog=MigrationOfQuantity;Integrated Security=True";
    
        //Connection of database using DBCOntextOptionBuilder
        static QuantityMeasurementApiTests()
        {
            Quantities = new DbContextOptionsBuilder<QuantityMeasurementDBContext>().UseSqlServer(connectionString).Options;
        }

        //Constructor for Businesss layer , repository layer and DbContext instances 
        public QuantityMeasurementApiTests()
        {
            var context = new QuantityMeasurementDBContext(Quantities);
            _quantityRl = new QuantityRL(context);
            _quantityBL = new QuantityBL(_quantityRl);
        }

        //Test case for checking viewConversion function
        [Fact]
        public void ViewConversions_WhenCalled_ReturnsOkResult()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.ViewQuantities();

                //assert
                Assert.IsType<OkObjectResult>(okResult);

            }
            catch(Exception exception)
            {
                throw  new Exception(exception.Message);
            }
            
        }

        //Test case for valid ViewCoversionById return okResult
        [Fact]
        public void ViewConversionsById_WhenCalled_ReturnsOkResult()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.ViewQuantityById(12);

                //assert
                Assert.IsType<OkObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }

        //Test case for Invalid ViewCoversionById return BadRequest
        [Fact]
        public void ViewConversionsById_WhenCalled_ReturnsBadRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.ViewQuantityById(-12);

                //assert
                Assert.IsType<BadRequestObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }

        //Test case for giving valid details for the conversion
        [Fact]
        public void AddConversionQuantity_whenCalled_retrunsOkResult()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                var result = new QuantityAttributes
                {
                    Value = 1,
                    Operation = "YardToInch"
                };

                //act
                var okResult = controller.AddQuantityConversion(result);

                //assert
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for giving Invalid details for the conversion return badRequest
        [Fact]
        public void AddConversionQuantity_whenCalled_retrunsBadRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                var result = new QuantityAttributes()
                {
                    Value = 5,
                    Operation = " "
                };

                //act
                var badresponse = controller.AddQuantityConversion(result);

                //assert
                Assert.IsType<BadRequestObjectResult>(badresponse);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for deleting the data by correct specific Id return okResult
        [Fact]
        public void DeleteConversionsById_WhenCalled_ReturnsOkRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.DeleteQuantityById(28);

                //assert
                Assert.IsType<OkObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for deleting the data by Incorrect specific Id return bad request
        [Fact]
        public void DeleteConversionsById_WhenCalled_ReturnsBadRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.DeleteQuantityById(-20);

                //assert
                Assert.IsType<BadRequestObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for cheking ViewQunatityComparision Function
        [Fact]
        public void ViewComparision_WhenCalled_ReturnsOkRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.ViewQuantityComparisons();

                //assert
                Assert.IsType<OkObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for returning ok result when giving valid details
        [Fact]
        public void AddComparision_WhenCalled_ReturnsOkRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                var result = new QuantityComparision
                {
                    firstValue = 12,
                    firstValueQuantityUnit = "Inch",
                    SecondValue = 1,
                    SecondValueQuantityUnit = "Feet"
                };

                //act
                var okResult = controller.AddQuantityComparison(result);

                //assert
                Assert.IsType<OkObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for returning bad request when giving invalid details
        [Fact]
        public void AddComparisionWithoutUnits_WhenCalled_ReturnsBadRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                var result = new QuantityComparision
                {
                    firstValue = 12,
                    firstValueQuantityUnit = " ",
                    SecondValue = 1,
                    SecondValueQuantityUnit = " "
                };

                //act
                var okResult = controller.AddQuantityComparison(result);

                //assert
                Assert.IsType<BadRequestObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for returning ok result  when giving valid ViewComparision Id
        [Fact]
        public void ViewComparisionById_WhenCalled_ReturnsOkRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.ViewComparisionById(23);

                //assert
                Assert.IsType<OkObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for returning bad request  when giving Invalid ViewComparision Id
        [Fact]
        public void ViewComparisionById_WhenCalled_ReturnsBadRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.ViewComparisionById(-23);

                //assert
                Assert.IsType<BadRequestObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for returning ok result  when giving valid deleteComparision Id
        [Fact]
        public void DeleteComparisionById_WhenCalled_ReturnsOkRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.DeleteQuantityComparisonById(25);

                //assert
                Assert.IsType<OkObjectResult>(okResult);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //Test case for returning bad request  when giving invalid deleteComparision Id
        [Fact]
        public void DeleteComparisionById_WhenCalled_ReturnsBadRequest()
        {
            try
            {
                var controller = new QuantityController(_quantityBL);

                //act
                var okResult = controller.DeleteQuantityComparisonById(-24);

                //assert
                Assert.IsType<BadRequestObjectResult>(okResult);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
