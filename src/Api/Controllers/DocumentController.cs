using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMongoCollection<Document> _collection;
        private readonly MongoConnectionAppSettings _settings;
        private readonly string CollectionName = "Documents";
        public DocumentController(IOptions<MongoConnectionAppSettings> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Document>(CollectionName);
        }

        [HttpGet("getDocument/id")]
        public async Task<IActionResult> GetDocument(string id)
        {
            var result = await _collection.Find<Document>(c => c.Id == id).FirstOrDefaultAsync();
            return Ok(result);
        }

        [HttpPost("postDocument")]
        public async Task<IActionResult> PostDocument(Document doc)
        {
            await _collection.InsertOneAsync(doc);
            return Ok(doc);
        }
    }
}
