using BusinessObjects.DTOs.PayOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {
        private readonly PayOS _payOS;
        private readonly IBookingService _bookingService;

        public CheckoutsController(PayOS payOS, IBookingService bookingService)
        {
            _payOS = payOS;
            _bookingService = bookingService;

        }
        [HttpPost("/create-payment-link")]
        public async Task<IActionResult> Checkout([FromBody] CreatePaymentLinkRequest request)
        {
            try
            {
                var booking = _bookingService.GetBooking(request.bookingId);
                //int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                ItemData item = new ItemData(booking.Description, 1, Convert.ToInt32(booking.Amount * 1000));
                List<ItemData> items = new List<ItemData> { item };
                PaymentData paymentData = new PaymentData(booking.BookingId, Convert.ToInt32(booking.Amount * 1000), "Thanh toan ma Booking " + booking.BookingId, items, request.cancelUrl, request.returnUrl);

                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                return Ok(new { url = createPayment.checkoutUrl });
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(500, new { message = "An error occurred", error = exception.Message });
            }
        }
        
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] int orderId)
        {
            try
            {
                PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInformation(orderId);
                return Ok(new Response(0, "Ok", paymentLinkInformation));
            }
            catch (System.Exception exception)
            {

                Console.WriteLine(exception);
                return Ok(new Response(-1, exception.Message, null));
            }

        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> CancelOrder([FromRoute] int orderId)
        {
            try
            {
                PaymentLinkInformation paymentLinkInformation = await _payOS.cancelPaymentLink(orderId);
                return Ok(new Response(0, "Ok", paymentLinkInformation));
            }
            catch (System.Exception exception)
            {

                Console.WriteLine(exception);
                return Ok(new Response(-1, exception.Message, null));
            }

        }

        [HttpPost("confirm-webhook")]
        public async Task<IActionResult> ConfirmWebhook(ConfirmWebhook body)
        {
            try
            {
                await _payOS.confirmWebhook(body.webhook_url);
                return Ok(new Response(0, "Ok", null));
            }
            catch (System.Exception exception)
            {

                Console.WriteLine(exception);
                return Ok(new Response(-1, "fail", null));
            }

        }
    }
}
