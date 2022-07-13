using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P11.Server.DB;
using P11.Shared;


namespace P11.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/Clothe
    public class ClotheController : Controller
    {
        // [HttpGet("getAllClothes")] // api/Clothe/getAllClothes
        // [HttpGet]
        [Route("getAllClothes")] // api/Clothe/getAllClothes
        public List<kala> getAllClothes() => this._provider.GetAllClothes();

        private readonly ClotheProvider _provider;
        public ClotheController(ClotheProvider provider)
        {
            this._provider = provider;
        }
        
        [HttpPost]
        [Route("AddNewClotheToDB")]
        public  async Task<kala> AddNewClotheToDB(kala newClothe)
        {
            await this._provider.AddClothe(newClothe);
            return newClothe;
        }
        [HttpPut("UpdateClothe")]
        public  async Task<kala> updateclothe(kala k)
        {
            await _provider.updateclothes(k);
            return _provider.GetAllClothes().ToList().FirstOrDefault();
        }

        // public async Task<kala> updateclothe(int[] prices)
        // {
        //     await this._provider.updateclothe(prices);
        //     return this._provider.GetAllClothes().ToList().FirstOrDefault();
        // }

        [HttpDelete("DeleteeClothe")]
        // public  async Task<kala> deleteclothe(kala k)
        // {
        //     await _provider.deleteclothe(k);
        //     return k;
        // }

        public async Task<kala> RemoveClothes(int[] ids)
        {
            await this._provider.RemoveClothes(ids);
            return this._provider.GetAllClothes().ToList().FirstOrDefault();
        }

        // [HttpGet("Details/{id}")]
        // public kala Details(int id)
        // {
        //     return _provider.Details(id);
        // }
    }
}

