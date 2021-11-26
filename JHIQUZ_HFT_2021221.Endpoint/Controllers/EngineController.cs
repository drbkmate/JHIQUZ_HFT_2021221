using JHIQUZ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Logic
{
    [Route("[controller")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private IEngineLogic logic;

        public EngineController(IEngineLogic logic)
        {
            this.logic = logic;
        }
        //OK
        // URL: /engine
        [HttpGet]
        public IEnumerable<Engine> ReadAllEngines()
        {
            return logic.ReadAll();
        }

        //
        // URL: /engine
        [HttpPost]
        public void CreateEngine(Engine engine)
        {
            logic.Create(engine);
        }

        //OK    
        //URL: /engine/{carId}
        [HttpDelete("{engineId}")]
        public void DeleteEngine([FromRoute] int engineId)
        {
            logic.Delete(engineId);
        }

        //OK
        [HttpPut]
        public void UpdateEngine([FromBody] Engine engine)
        {
            logic.Update(engine);
        }
    }
}
