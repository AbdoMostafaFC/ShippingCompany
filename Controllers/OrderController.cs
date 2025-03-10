﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShippingCompany.DTOs;
using ShippingCompany.Models;
using ShippingCompany.StaticDataSeeding;

namespace ShippingCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext Context)
        {
            _context = Context;
        }

        [HttpPost]
        [Authorize(Roles ="SuperAdmin,Admin")]
        public async Task<IActionResult> CreateOrder([FromForm] OrderDto orderDto)
        {
            if (orderDto.ProductIamge == null || orderDto.ProductIamge.Length == 0)
            {
                return BadRequest("Image file is required.");
            }

            
            var fileName = Guid.NewGuid() + Path.GetExtension(orderDto.ProductIamge.FileName);

           
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

          
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath)!);

         
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await orderDto.ProductIamge.CopyToAsync(stream);
            }

            
            Order order = new Order();
            order.ProducImage = $"/images/{fileName}";
            order.SenderName = orderDto.SenderName;
            order.SenderPhone = orderDto.SenderPhone;
            order.SenderResidenceNumber = orderDto.SenderResidenceNumber;
            order.SenderCity = orderDto.SenderCity;
            order.ReciverPhone = orderDto.ReciverPhone;
            order.ReciverCity = orderDto.ReciverCity;
            order.ReciverName = orderDto.ReciverName;
            order.ReciverRegion = orderDto.ReciverRegion;
            order.ReciverStreet = orderDto.ReciverStreet;

            
            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new {id=order.Id},order);
        }

        [HttpGet]
        [Authorize(Roles ="SuperAdmin")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.orders.Include(o=>o.Items).ToListAsync();

           
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            var response = orders.Select(order => new
            {
                order.Id,
                order.SenderName,
                order.SenderPhone,
                order.SenderCity,
                order.SenderResidenceNumber,
                order.ReciverName,
                order.ReciverPhone,
                order.ReciverCity,
                order.ReciverRegion,
                order.ReciverStreet,
               Items= order.Items.Select(o=>new
               {
                   o.Id,
                   o.ItemName,
                   o.NumberItem,
                   o.Wieght,
                   o.CostOfWieght,
                   o.Note,

               }),
                ProductImageUrl = string.IsNullOrEmpty(order.ProducImage)
                    ? null
                    : $"{baseUrl}/{order.ProducImage}"
            });
            return Ok(response);
        }
                
              

        
        [Authorize(Roles = "SuperAdmin")]

        [HttpGet("ById")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.orders.Include(O=>O.Items).SingleOrDefault(order => order.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

             //   order.ProducImage = $"{baseUrl}/{order.ProducImage}";
                var Response = new
                {
                    SenderPhone = order.SenderPhone,
                    SenderCity = order.SenderCity,
                    SenderResidenceNumber = order.SenderResidenceNumber,
                    SenderName = order.SenderName,
                    ReciverPhone = order.ReciverPhone,
                    ReciverStreet = order.ReciverStreet,
                    ReciverRegion = order.ReciverRegion,
                    ReciverCity = order.ReciverCity,
                    ReciverName = order.ReciverName,
                    ProducImage = $"{baseUrl}/{order.ProducImage}",
                    Items=order.Items.Select(o=>new
                    {
                        o.Id,
                        o.ItemName,
                        o.NumberItem,
                        o.Wieght,
                        o.CostOfWieght,
                        o.Note,
                    })

                };

                return Ok(Response);
            }



        }
        [Authorize(Roles = "SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> Update(int? id, UpdatedOrderDto updatedOrderDto)
        {
            var Order = _context.orders.FirstOrDefault(order => order.Id == id);
            if (Order == null || id == null)
                return NotFound();
            Order.SenderName = updatedOrderDto.SenderName;
            Order.SenderPhone = updatedOrderDto.SenderPhone;
            Order.SenderResidenceNumber = updatedOrderDto.SenderResidenceNumber;
            Order.SenderCity = updatedOrderDto.SenderCity;
            Order.ReciverName = updatedOrderDto.ReciverName;
            Order.ReciverPhone = updatedOrderDto.ReciverPhone;
            Order.ReciverCity = updatedOrderDto.ReciverCity;
            Order.ReciverRegion = updatedOrderDto.ReciverRegion;
            Order.ReciverStreet = updatedOrderDto.ReciverStreet;
            if (updatedOrderDto.ProductIamge == null || updatedOrderDto.ProductIamge.Length == 0)
            {
                _context.orders.Update(Order);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(updatedOrderDto.ProductIamge.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath)!);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await updatedOrderDto.ProductIamge.CopyToAsync(stream);
                }

              
                Order.ProducImage = $"/images/{fileName}";

                _context.orders.Update(Order);
                await _context.SaveChangesAsync();
                return NoContent();
            }

        }
        [HttpDelete]
        [Authorize(Roles = "SuperAdmin")]

        public async Task<IActionResult> Delete(int id)
        {

            var Order = _context.orders.FirstOrDefault(x => x.Id == id);
            if (Order == null)
            {
                return NotFound();
            }

            
            if (!string.IsNullOrEmpty(Order.ProducImage))
            {
                
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Order.ProducImage.TrimStart('/'));

             
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            
            _context.orders.Remove(Order);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Authorize]
        [HttpPost("GenerateOtp{orderId:int}")]
        public async Task<IActionResult> GenerateOtp(int orderId)
        {
        
            var order = await _context.orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }
            var OrderCode=_context.ordersCode.FirstOrDefault(x => x.OrderId == orderId);

            if(OrderCode !=null)
            {
                return Ok(new { OrderId = orderId, OTP=OrderCode.Code });

            }
           
            var otp = new Random().Next(100000, 999999).ToString();

           
            var orderCode = new OrderCode
            {
                Code = otp,
                OrderId = orderId,
                Order = order
            };
           
          
            _context.ordersCode.Add(orderCode);
            await _context.SaveChangesAsync();

            
            return Ok(new { OrderId = orderId, OTP = otp });
        }
        [HttpPost("ConfirmOrder")]
        public  IActionResult ConfirmOrder([FromForm]Confirm confirm)
        {


            var Order =_context.orders.FirstOrDefault(O=>O.Id==confirm.OrderId);

            if(Order!=null)
            {
                var or=_context.ordersCode.Where(O=>O.OrderId == confirm.OrderId).FirstOrDefault();
                if(or.Code==confirm.Code)
                {
                    Order.Status=OrderStatus.ConfirmedStatus;
                }
            }

            return Ok("Confirmed");

        }

        [HttpPost("AddItem{OrderId:int}")]
        public async Task<IActionResult> AddItem(int OrderId,[FromForm]OrderItemDTO orderItemDTO)
        {

            Order? Order = await _context.orders.FindAsync(OrderId);
            if (Order == null) {

                return NotFound("Order Not Found");

            }
            OrderItem orderItem = new OrderItem {
                ItemName = orderItemDTO.ItemName,
                OrderId = OrderId,
                CostOfWieght = orderItemDTO.CostOfWieght,
                Wieght = orderItemDTO.Wieght,
                Note = orderItemDTO.Note,
                NumberItem = orderItemDTO.NumberItem,
            };


            Order.Items.Add(orderItem);
           await _context.orderItems.AddAsync(orderItem);
          await  _context.SaveChangesAsync();

            return Created();

        }
    }
}
