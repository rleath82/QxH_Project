using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QxHAPI.Models;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;

namespace CouchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchandisesController : ControllerBase
    {
        private readonly IBucketProvider _bucketProvider;

        public MerchandisesController(IBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;
        }

        [HttpGet]
        [Route("/api/getusa")]
        public IActionResult GetUSA()
        {
            var bucket = _bucketProvider.GetBucket("MerchUSA");
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `MerchUSA` g
                        WHERE g.companyId = 0;";
            var query = QueryRequest.Create(n1ql);
            var results = bucket.Query<Merchandise>(query);
            return Ok(results.Rows);
        }

        [HttpGet]
        [Route("/api/geteur")]
        public IActionResult GetEUR()
        {
            var bucket = _bucketProvider.GetBucket("MerchEUR");
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `MerchEUR` g
                        WHERE g.companyId = 1;";
            var query = QueryRequest.Create(n1ql);
            var results = bucket.Query<Merchandise>(query);
            return Ok(results.Rows);
        }

        [HttpGet]
        [Route("/api/getjpn")]
        public IActionResult GetJPN()
        {
            var bucket = _bucketProvider.GetBucket("MerchJPN");
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `MerchJPN` g
                        WHERE g.companyId = 2;";
            var query = QueryRequest.Create(n1ql);
            var results = bucket.Query<Merchandise>(query);
            return Ok(results.Rows);
        }
    }
}
