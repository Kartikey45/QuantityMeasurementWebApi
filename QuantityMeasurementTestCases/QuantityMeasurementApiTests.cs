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
    public class QuantityMeasurementApiTests
    {
        readonly QuantityBL _quantityBL;
        readonly QuantityRL _quantityRl;
        private readonly IConfiguration _configuration;

        public static DbContextOptions<QuantityMeasurementDBContext> Quantities { get; }

        public static string connectionString = "Data Source=DESKTOP-IVOPHLI\\SQLEXPRESS;Initial Catalog=MigrationOfQuantity;Integrated Security=True";
    
        static QuantityMeasurementApiTests()
        {
            Quantities = new DbContextOptionsBuilder<QuantityMeasurementDBContext>().UseSqlServer(connectionString).Options;
        }

        public QuantityMeasurementApiTests()
        {
            var context = new QuantityMeasurementDBContext(Quantities);
            _quantityRl = new QuantityRL(context);
            _quantityBL = new QuantityBL(_quantityRl);
        }

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
                var okResult = controller.AddQuantity(result);

                //assert
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

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
                var badresponse = controller.AddQuantity(result);

                //assert
                Assert.IsType<BadRequestObjectResult>(badresponse);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

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
