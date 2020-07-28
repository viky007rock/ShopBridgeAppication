using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.Services.Interface;
using ShopBridge.API.ViewModel;

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private IHostingEnvironment _hostingEnvironment;
        public InventoryController(IInventoryService inventoryService, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult getAllInventory()
        {
            try
            {
                var lstInventory = _inventoryService.getAllInventories();
                return Ok(lstInventory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getInventoryById(int id)
        {
            try
            {
                var objInventory = _inventoryService.getInventoryById(id);
                return Ok(objInventory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult createInventory(InventoryViewModel objInventoryVM)
        {
            try
            {
                var result = _inventoryService.createProduct(objInventoryVM);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult updateInventory(int id, InventoryViewModel objInventoryVM)
        {
            try
            {
                var result = _inventoryService.updateProduct(objInventoryVM, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete(("{id}"))]
        public IActionResult deleteInventory(int id)
        {
            try
            {
                var result = _inventoryService.deleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("file/upload")]
        public IActionResult uploadPicture()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { fileName = fileName });
                }
                else
                {
                    return BadRequest("FileIsPresent");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }

}
