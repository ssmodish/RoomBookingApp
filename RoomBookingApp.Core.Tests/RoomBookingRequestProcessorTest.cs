using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            // Arrange - AKA Mock data 
            var bookingRequest = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2021, 10, 20)
            };

            var processor = new RoomBookingRequestProcessor();


            // Act
            RoomBookingResult result = processor.BookRoom(bookingRequest);

            // Assert - Xunit built in package
            //Assert.NotNull(result);
            //Assert.Equal(bookingRequest.FullName, result.FullName);
            //Assert.Equal(bookingRequest.Email, result.Email);
            //Assert.Equal(bookingRequest.Date, result.Date);

            // Assert using Shouldly package
            result.ShouldNotBeNull();
            result.FullName.ShouldBe(bookingRequest.FullName);
            result.Email.ShouldBe(bookingRequest.Email);
            result.Date.ShouldBe(bookingRequest.Date);



        }
    }
}
