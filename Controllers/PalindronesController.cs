using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Controllers
{
    [Route("api/[controller]")]
    public class PalindronesController : Controller
    {
        private IPalindronesData _palindronesData;

        private static string[] Summaries = new[]
{
            "A Santa at Nasa",
            "Anna",
            "Avid diva",
            "Amore, Roma",
            "Wet stew",
            "I risk cold as main is tidal. As not one to delay burden, I don’t set it on “hot”. A foot made free pie race losses runnier. As draw won pull, eye won nose. Vile hero saw order it was in – even a moron saw it – no, witnessed it: Llama drops – ark riots. Evil P.M. in a sorer opus enacts all laws but worst arose. Grab a nosey llama – nil lesser good, same nicer omen.",
            "I did, did I?"
        };

        public PalindronesController(IPalindronesData palindronesData)
        {
            _palindronesData = palindronesData;
        }

        private static List<string> Palindrones = new List<string>(Summaries);

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()    
        {
            return _palindronesData.Get().AsEnumerable();
        }

        // GET api/values/5
        [HttpGet("{value}")]
        public IEnumerable<string> StartWith(string value)
        {
            return Palindrones.Where(x => x.StartsWith(value));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]JObject payload)
        {
            if (payload.HasValues && _palindronesData.Get().Where(x => x == payload["palindrone"].Value<string>()).FirstOrDefault() == null)
            {

                _palindronesData.Add(payload["palindrone"].Value<string>());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
