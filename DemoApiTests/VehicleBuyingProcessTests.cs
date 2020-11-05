using System;
using DemoApi.DataInterface;
using DemoApi.Domain;
using DemoApi.Processor;
using Moq;
using Xunit;

namespace DemoApiTests
{
    public class VehicleBuyingProcessTests
    {
        private CreateLocationRequest _request;
        private Mock<ICreateLocationRepository> _createLocationRepositoryMock;
        private CreateLocationRequestProcessor _processor;

        public VehicleBuyingProcessTests()
        {
            _request = new CreateLocationRequest{ Name = "houston"};
            _createLocationRepositoryMock = new Mock<ICreateLocationRepository>();
            _processor = new CreateLocationRequestProcessor(_createLocationRepositoryMock.Object);
        }
        // [Fact]
        // public void ShouldReturnBuyVehicleResult(){
            
        // }
        [Fact]
        public void ShouldReturnCreateLocationResult(){
            //arrange - request setup in constructor 
            
            //act
            CreateLocationResult result = _processor.createLocation(_request);

            //assert
            Assert.Equal(result.Name, _request.Name);
        }
        //When request is null
        [Fact]
        public void ShouldThrowExceptionWhenRequestIsNull(){
            //arrange - request setup in constructor 

            //Act
            var result = Assert.Throws<ArgumentNullException>(() => _processor.createLocation(null));

            //Assert
            Assert.Equal("locationRequest", result.ParamName);
            
        }
        [Fact]
        public void ShouldSaveLocation(){
            //Arrange
            LocationInserting locationSaved = null;
            //Act
            var result = _processor.createLocation(_request);
            // _createLocationRepositoryMock.Setup(m => m.Save(It.IsAny<LocationInserting>()))
            //     .Callback<LocationInserting>(locInserting => {
            //         locationSaved = locInserting;
            //     });

            _createLocationRepositoryMock.Verify(m => m.Save(It.IsAny<CreateLocationRequest>()), Times.Once);

            //Assert
            Assert.Equal(result.Name, _request.Name);
        }
    }




}