using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Bookshop.Web.Controllers
{
    public class ProductController : Controller
    {
        //INYECCION DE DEPENDENCIA
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        //listado de todos los productos
        
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? list = new();
            ResponseDto? response = await _productService.GetAllProductAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }


        //PARA AGREGAR UN PRODUCTO
        public async Task<IActionResult> CrearProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearProduct(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.CreateProductAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["Success"] = "Producto Creado con exito";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        //para eliminar un producto

        //VER LOS DATOS DEL 
        public async Task<IActionResult> EliminarProduct(int productId)
        {
            ResponseDto? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDto? moel = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(moel);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }
        //METODO DEELIMINAR 
        //

        [HttpPost]
        public async Task<IActionResult> EliminarProduct(ProductDto productDto)
        {
            ResponseDto? response = await _productService.DeleteProductAsync(productDto.ProductId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Producto Eliminado con exito";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(productDto);
        }



        //para editar un producto

        //VER LOS DATOS DEL 
        public async Task<IActionResult> ProductEdidt(int productId)
        {
            ResponseDto? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDto? moel = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(moel);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }
        //METODO DEELIMINAR 
        //

        [HttpPost]
        public async Task<IActionResult> ProductEdidt(ProductDto productDto)
        {
            if(ModelState.IsValid)
            { 
            ResponseDto? response = await _productService.UpdateProductAsync(productDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Producto Actualizado con exito";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            }
            return View(productDto);
        }
    }
}
