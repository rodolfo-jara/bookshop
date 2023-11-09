using AutoMapper;
using Bookshop.Services.CuponAPI.Data;
using Bookshop.Services.CuponAPI.Models;
using Bookshop.Services.CuponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Services.CuponAPI.Controllers
{
    [Route("api/cupon")]
    [ApiController]
    [Authorize]
    public class CuponAPIController : ControllerBase
    {
        //INYECCION DE DEPENDENCIA
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CuponAPIController(AppDbContext db, IMapper mapper)
        {
             _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        //LISTAR LOS CUPONES
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Cupon> objList = _db.Cupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CuponDto>>(objList);
                
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messaje = ex.Message;

            }
            return _response;
        }
        //BUSCAR CUPON ID
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Cupon obj = _db.Cupons.First(u=>u.CuponId==id);
                _response.Result  = _mapper.Map<CuponDto>(obj);
               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messaje = ex.Message;
            }
            return _response;
        }

        //BUSCAR POR CDIGO DE CUPON
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Cupon obj = _db.Cupons.First(u => u.CodigoCupon.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CuponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messaje = ex.Message;
            }
            return _response;
        }


        // PARA AGREGAR UN CUPON NUEVO
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] CuponDto cuponDto)
        {
            try
            {
                Cupon obj = _mapper.Map<Cupon>(cuponDto);
                _db.Cupons.Add(obj);
                _db.SaveChanges();


                var options = new Stripe.CouponCreateOptions
                {
                    AmountOff = (long)(cuponDto.Descuento * 100),
                    Name = cuponDto.CodigoCupon,
                    Currency = "usd",
                    Id = cuponDto.CodigoCupon,
                };
                var service = new Stripe.CouponService();
                service.Create(options);


                _response.Result = _mapper.Map<CuponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messaje = ex.Message;
            }
            return _response;
        }


        // PARA ACTUALIZAR UN CUPON NUEVO
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto put([FromBody] CuponDto cuponDto)
        {
            try
            {
                Cupon obj = _mapper.Map<Cupon>(cuponDto);
                _db.Cupons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CuponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messaje = ex.Message;
            }
            return _response;
        }


        // PARA ELIMINAR UN CUPON NUEVO
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Cupon obj = _db.Cupons.First(u => u.CuponId == id);
                _db.Cupons.Remove(obj);
                _db.SaveChanges();

                
                var service = new Stripe.CouponService();
                service.Delete(obj.CodigoCupon);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messaje = ex.Message;
            }
            return _response;
        }
    }
}
