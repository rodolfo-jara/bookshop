using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Bookshop.Web.Controllers
{
    public class CuponController : Controller
    {
        //INYECCION DE DEPENDENCIA
        private readonly ICuponService _cuponService;
        public CuponController(ICuponService cuponService)
        {
            _cuponService = cuponService;
        }

        //listado de todos los cupones
        public async Task<IActionResult> CuponIndex()
        {
            List<CuponDto>? list = new();
            ResponseDto? response = await _cuponService.GetAllCuponAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CuponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }


        //PARA AGREGAR UN CUPON
        public async Task<IActionResult> CrearCupon()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearCupon(CuponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _cuponService.CreateCuponAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["Success"] = "Cupon Creado con exito";
                    return RedirectToAction(nameof(CuponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        //para eliminar un cupon

        //VER LOS DATOS DEL CUPON QUE QUEREMOS ELIMINAR
        public async Task<IActionResult> EliminarCupon(int cuponId)
        {
            ResponseDto? response = await _cuponService.GetCuponByIdAsync(cuponId);

            if (response != null && response.IsSuccess)
            {
                CuponDto? moel = JsonConvert.DeserializeObject<CuponDto>(Convert.ToString(response.Result));
                return View(moel);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }
        //METODO DEELIMINAR EL CUPON
        [HttpPost]
        public async Task<IActionResult> EliminarCupon(CuponDto cuponDto)
        {
            ResponseDto? response = await _cuponService.DeleteCuponAsync(cuponDto.CuponId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cupon Eliminado con exito";
                return RedirectToAction(nameof(CuponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(cuponDto);
        }
    }
}
