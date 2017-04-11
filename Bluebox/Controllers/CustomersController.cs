using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bluebox.Models;
using Bluebox.ViewModels;

namespace Bluebox.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //{
            //   new Customer { Id = 1,  Name = "John Smith"},
            //   new Customer { Id = 2, Name = "Mary Williams"}
            //};

           

            return View(customers);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                

                return View("CustomerForm", viewModel);
                
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {

            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
              //{
              //  new Customer { Id = 1,  Name = "John Smith"},
              //  new Customer { Id = 2, Name = "Mary Williams"}
              //};


              //foreach(var customer in customers)
              //{
              //    if (customer.Id == id)
              //        return View(customer);
              //}

              if (customers == null)
                return HttpNotFound();


            return View(customers);
               


        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm", viewModel);

        }
    }
}