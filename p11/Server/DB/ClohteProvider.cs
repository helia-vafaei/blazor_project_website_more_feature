using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P11.Server.Controllers;
using P11.Shared;
using Microsoft.EntityFrameworkCore;


namespace P11.Server.DB
{
    public class ClotheProvider
    {
        //*********************Yek object az class ClotheDBContext
        private readonly ClotheDBContext _context;
        private readonly ILogger _logger;
        public ClotheProvider(ClotheDBContext context, ILoggerFactory loggerFactory)
        {
            this._context = context;
            this._logger = loggerFactory.CreateLogger("ClotheProvider");
        }
        public async Task AddClothe(kala clothe)
        {
            // var LastClothe = this._context.Clothes.ToArray().LastOrDefault();
            // var LastId = this._context.Clothes.Select( c => c.ID).Max();
            // var newID = 0;
            // if(!(LastClothe is null))
            //     newID = LastId+ 1;
            // clothe.ID = newID;

            // await _context.Clothes.AddAsync(clothe);
            // await _context.SaveChangesAsync();
            await _context.Clothes.AddAsync(clothe);
            await _context.SaveChangesAsync();
        }
        public List<kala> GetAllClothes()
            => this._context.Clothes.ToList();

        public async Task updateclothes(kala k)
        {
            _context.Clothes.Update(k);
            await _context.SaveChangesAsync();
        }

        // public async Task RemoveClothes(kala k)
        // {
        //     _context.Clothes.Remove(k);
        //     await _context.SaveChangesAsync();
        // }

        public async Task RemoveClothes(int[] ids)
        {
            var k = this._context.Clothes.ToList();
            var d = k.Where(arg => ids.Contains(arg.ID));
            foreach(var i in d)
            {
                this._context.Clothes.Remove(i);
            }
            await this._context.SaveChangesAsync();
        }
        // public kala Details(int id)
        // {
        //     return _context.Clothes.First(t=> t.ID == id);
        // }

    }
}