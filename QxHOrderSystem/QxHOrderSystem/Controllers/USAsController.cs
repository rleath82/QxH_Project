using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QxHOrderSystem.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace QxHOrderSystem.Controllers
{
    public class USAsController : Controller
    {
        private readonly OrderContext _context;

        public USAsController(OrderContext context)
        {
            _context = context;
        }

        // GET: USAs
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ItemIdSortParam"] = sortOrder == "itemId" ? "itemId_desc" : "itemId";
            ViewData["ShowCdSortParam"] = String.IsNullOrEmpty(sortOrder) ? "showCd_desc" : "";
            ViewData["ShowCdSortParam"] = String.IsNullOrEmpty(sortOrder) ? "showCd" : "";
            ViewData["PlanSeqSortParam"] = sortOrder == "planSeqId" ? "seqId_desc" : "planSeqId";
            ViewData["NetworkSortParam"] = sortOrder == "networkId" ? "netId_desc" : "networkId";
            ViewData["CompanySortParam"] = sortOrder == "companyid" ? "compId_desc" : "companyid";

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;
            
            
            var items = from i in _context.USA
                        select i;

            if(!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.itemDescription.Contains(searchString) || i.itemId.ToString().Contains(searchString));
            }

            switch(sortOrder)
            {
                case "itemId_desc":
                    items = items.OrderByDescending(i => i.itemId);
                    break;               
                case "showCd_desc":
                    items = items.OrderByDescending(i => i.showCd);
                    break;
                case "showCd":
                    items = items.OrderBy(i => i.showCd);
                    break;
                case "seqId_desc":
                    items = items.OrderByDescending(i => i.planSeqId);
                    break;
                case "planSeqId":
                    items = items.OrderBy(i => i.planSeqId);
                    break;
                case "netId_desc":
                    items = items.OrderByDescending(i => i.networkId);
                    break;
                case "networkId":
                    items = items.OrderBy(i => i.networkId);
                    break;
                case "compId_desc":
                    items = items.OrderByDescending(i => i.companyId);
                    break;
                case "companyId":
                    items = items.OrderBy(i => i.companyId);
                    break;
                default:
                    items = items.OrderBy(i => i.itemId);
                    break;
            }

            int pageSize = 15;

            return View(await PaginatedList<USA>.CreateAsync(items.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await items.AsNoTracking().ToListAsync());
        }

        //[HttpPost]
        public async Task<IActionResult> Order(int id, int InputQty) //Trying to get the InputQty here with the ItemId
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            USA obj = new USA();
            obj.ShowItemId = id;
            obj.InputQty = InputQty;

            string path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();
            string sqlConnectionString = config.GetConnectionString("OrderContext");
            string sql = "OrderItemUpdate";

            var item = await _context.USA
                //.Where(q => q.InputQty == qty)
                .FirstOrDefaultAsync(u => u.ShowItemId == id);

            //if (item.AvaiForSaleQty != 0 && item.AvaiForSaleQty - item.OrderQuantity >= 0)
            //{
                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    try
                    {
                        connection.Open();
                        DynamicParameters parameter = new DynamicParameters();
                        parameter.Add("@ShowItemId", item.ShowItemId, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@CompanyId", item.companyId, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@ItemId", item.itemId, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@PlanSeqId", item.planSeqId, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@ItemDescription", item.itemDescription, DbType.String, ParameterDirection.Input);
                        parameter.Add("@OrderQuantity", item.orderQuantity, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@OrderSldTdy", item.orderSldTdy, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@PlannedMinutesQty", item.plannedMinutesQty, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@ActualMinutesQty", item.actualMinutesQty, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@NetworkId", item.networkId, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@AvaiForSaleQty", item.avaiForSaleQty, DbType.Int32, ParameterDirection.Input);
                        parameter.Add("@ShowDate", item.showDate, DbType.String, ParameterDirection.Input);
                        parameter.Add("@ShowCd", item.showCd, DbType.String, ParameterDirection.Input);
                        parameter.Add("@InputQty", obj.InputQty, DbType.Int32, ParameterDirection.Input); 
                        connection.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                        //return RedirectToAction(nameof(Index));
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    connection.Close();
                }
                return RedirectToAction(nameof(Index));
            
            //else
            //{
            //    ViewBag.Message("Inventory too low for amount ordered.");
            //    return View();
            //}
        }

        // GET: USAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSA = await _context.USA
                .FirstOrDefaultAsync(m => m.itemId == id);
            if (uSA == null)
            {
                return NotFound();
            }

            return View(uSA);
        }

        // GET: USAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: USAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,PlanSeqId,ItemDescription,OrderQuantity,OrderSldTdy,PlannedMinutesQty,ActualMinutesQty,NetworkId,CompanyId,AvaiForSaleQty,ShowDate,ShowCd")] USA uSA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uSA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uSA);
        }

        // GET: USAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSA = await _context.USA.FindAsync(id);
            if (uSA == null)
            {
                return NotFound();
            }
            return View(uSA);
        }

        // POST: USAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,PlanSeqId,ItemDescription,OrderQuantity,OrderSldTdy,PlannedMinutesQty,ActualMinutesQty,NetworkId,CompanyId,AvaiForSaleQty,ShowDate,ShowCd")] USA uSA)
        {
            if (id != uSA.itemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uSA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!USAExists(uSA.itemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(uSA);
        }

        // GET: USAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSA = await _context.USA
                .FirstOrDefaultAsync(m => m.itemId == id);
            if (uSA == null)
            {
                return NotFound();
            }

            return View(uSA);
        }

        // POST: USAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uSA = await _context.USA.FindAsync(id);
            _context.USA.Remove(uSA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool USAExists(int id)
        {
            return _context.USA.Any(e => e.itemId == id);
        }
    }
}
