using FluentValidation.TestHelper;
using SignalRDine.BusinessLayer.ValidationRules.BookingValidations;
using SignalRDine.DtoLayer.BookingDto;
using Xunit;

namespace SignalRDine.Test
{
    public class BookingValidationTests
    {
        private readonly CreateBookingValidation _validator = new CreateBookingValidation();

        [Fact]
        public void Name_Surname_Should_Have_Error_When_Shorter_Than_5_Characters()
        {
            var model = new CreateBookingDto { Name = "Ali" };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Mail_Should_Have_Error_When_Invalid_Format()
        {
            var model = new CreateBookingDto { Mail = "denemegail.com" };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Mail);
        }

        [Fact]
        public void Booking_Should_Be_Valid_When_All_Fields_Are_Correct()
        {
            var model = new CreateBookingDto
            {
                Name = "Ahmet Yılmaz",
                Phone = "05551112233",
                Mail = "test@mail.com",
                PersonCount = 2,
                Date = DateTime.Now
            };

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}