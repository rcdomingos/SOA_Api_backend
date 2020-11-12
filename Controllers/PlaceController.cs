using Newtonsoft.Json;
using SOA_backend.Models;
using SOA_backend.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOA_backend.Controllers
{
    [RoutePrefix("api")]
    public class PlaceController : ApiController 
    {
        // GET: api/Place
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [AcceptVerbs("GET")]
        [Route("Place")]
        public IEnumerable<string> ApiGetAllPlaces(int category=0)
        {
    
            PlaceDAO _placeDAO = new PlaceDAO();

            List<Place> listaPlaces = _placeDAO.SelectAllPlaces(out string message, category);

            if (listaPlaces == null) return new string[] { message };

            var placesJson = JsonConvert.SerializeObject(listaPlaces);

            return new string[] { placesJson };

        }

        // GET: api/Place/5
        [AcceptVerbs("GET")]
        [Route("Place/{id}")]
        public string ApiGetPlaceById(string id)
        {
            PlaceDAO placeDAO = new PlaceDAO();

            Place selectedPlace = placeDAO.SelectPlaceById(id, out string message);

            if (selectedPlace == null) return message;

            var placeToJson = JsonConvert.SerializeObject(selectedPlace);

            return placeToJson;
        }

    }
}

