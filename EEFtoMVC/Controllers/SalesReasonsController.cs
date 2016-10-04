using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityLibrary;
using BusinessLogic;

namespace EEFtoMVC.Controllers
{
    public class SalesReasonsController : Controller
    {
        BusinessLogicClass BL = new BusinessLogicClass();
        private AdventureWorks2008Entities db = new AdventureWorks2008Entities();

        // GET: SalesReasons
        public ActionResult Index()
        {
            return View(BL.GetAllRecord());
        }

        // GET: SalesReasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReason salesReason = BL.RetrieveSpecificRecordUsingLambda(id);
            if (salesReason == null)
            {
                return HttpNotFound();
            }
            return View(salesReason);
        }

        // GET: SalesReasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesReasonID,Name,ReasonType,ModifiedDate")] SalesReason salesReason)
        {
            if (ModelState.IsValid)
            {
                BL.CreateNewSalesReasonRecord(salesReason);
                //db.SalesReasons.Add(salesReason);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesReason);
        }

        // GET: SalesReasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReason salesReason = BL.RetrieveSpecificRecordUsingLambda(id);
            if (salesReason == null)
            {
                return HttpNotFound();
            }
            return View(salesReason);
        }

        // POST: SalesReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesReason salesReason)
        {
            if (ModelState.IsValid)
            {
                BL.UpdateSalesReasonRecord(salesReason);
                //db.Entry(salesReason).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesReason);
        }

        // GET: SalesReasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReason salesReason = BL.RetrieveSpecificRecordUsingLambda(id);
            if (salesReason == null)
            {
                return HttpNotFound();
            }
            return View(salesReason);
        }

        // POST: SalesReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BL.DeleteSalesReasonRecord(id);
            //SalesReason salesReason = db.SalesReasons.Find(id);
            //db.SalesReasons.Remove(salesReason);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
