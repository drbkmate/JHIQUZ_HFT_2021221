using JHIQUZ_HFT_2021221.Endpoint.Services;
using JHIQUZ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Logic
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public BrandController(IBrandLogic logic)
        {
            this.logic = logic;
        }

        // URL: /brand
        [HttpGet]
        public IEnumerable<Brand> ReadAllBrands()
        {
            return logic.ReadAll();
        }

        //URL: /brand/{brandId}
        [HttpGet("{engineId}")]
        public Brand ReadOneBrand([FromRoute] int brandId)
        {
            return logic.ReadOne(brandId);
        }

        // URL: /brand
        [HttpPost]
        public void CreateBrand(Brand brand)
        {
            logic.Create(brand);
            this.hub.Clients.All.SendAsync("BrandCreated", brand);
        }

  
        //URL: /brand/{brandId}
        [HttpDelete("{brandId}")]
        public void DeleteBrand([FromRoute] int brandId)
        {
            var brandToDel = this.logic.ReadOne(brandId);
            logic.Delete(brandId);
            this.hub.Clients.All.SendAsync("BrandDeleted", brandToDel);
        }

        [HttpPut]
        public void UpdateBrand([FromBody] Brand brand)
        {
            logic.Update(brand);
            this.hub.Clients.All.SendAsync("BrandUpdated", brand);
        }
    }
}
