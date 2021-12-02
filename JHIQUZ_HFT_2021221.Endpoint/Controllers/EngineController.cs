using JHIQUZ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Logic
{
    [Route("[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private IEngineLogic logic;

        public EngineController(IEngineLogic logic)
        {
            this.logic = logic;
        }

        // URL: /engine
        [HttpGet]
        public IEnumerable<Engine> ReadAllEngines()
        {
            return logic.ReadAll();
        }
        //URL: /engine/{engineId}
        [HttpGet("{engineId}")]
        public Engine ReadOneEngine([FromRoute] int engineId)
        {
            return logic.ReadOne(engineId);
        }

        // URL: /engine
        [HttpPost]
        public void CreateEngine(Engine engine)
        {
            logic.Create(engine);
        }

    
        //URL: /engine/{engineId}
        [HttpDelete("{engineId}")]
        public void DeleteEngine([FromRoute] int engineId)
        {
            logic.Delete(engineId);
        }

        [HttpPut]
        public void UpdateEngine([FromBody] Engine engine)
        {
            logic.Update(engine);
        }
    }
}
