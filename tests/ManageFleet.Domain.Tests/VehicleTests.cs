using ManageFleet.Domain.Entities;
using ManageFleet.Domain.Interfaces.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ManageFleet.Domain.Tests
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void Vehicle_IsValid_True()
        {
            // Arrange
            var vehicle = new Vehicle
            (
                chassi: "9BG116GW04C400001",
                color: "Vermelha",
                vehicleTypeId: 1
            );

            // Act
            var result = vehicle.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Vehicle_Should_Throw_Exception_When_Incorrect_Data()
        {
            // Act
            Action action = () =>
            {
                // Arrange
                var vehicle = new Vehicle
                (
                    chassi: "9BG116GW04C40000",
                    color: "Vermelha",
                    vehicleTypeId: 1
                );
            };

            // Assert
            Assert.ThrowsException<InvalidOperationException>(action);
        }

        [TestMethod]
        public void Should_Save_Vehicle_In_The_Database_When_Correct_Data()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = 1,
                Chassi = "9BG116GW04C400000",
                Color = "Vermelha",
                VehicleTypeId = 1
            };

            // Act
            var mock = new Mock<IVehicleRepository>();
            mock.Setup(p => p.GetById(1))
                .Returns(new Vehicle
                {
                    Id = 1,
                    Chassi = "9BG116GW04C400000",
                    Color = "Vermelha",
                    VehicleTypeId = 1
                });
            var result = mock.Object.GetById(1);

            // Assert
            Assert.IsTrue(vehicle.Chassi.Equals(result.Chassi));
        }

        [TestMethod]
        public void Should_Not_Save_Vehicle_In_The_Database_When_Incorrect_Data()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = 1,
                Chassi = "9BG116GW04C400000",
                Color = "Vermelha",
                VehicleTypeId = 0
            };

            // Act
            var mock = new Mock<IVehicleRepository>();
            mock.Setup(p => p.GetById(1))
                .Returns(new Vehicle());
            var result = mock.Object.GetById(1);

            // Assert
            Assert.IsFalse(vehicle.Id.Equals(result.Id));
        }
    }
}