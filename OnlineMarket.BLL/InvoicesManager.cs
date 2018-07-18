using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMaeket.DAL;
using OnlineMaeket.DAL.ViewModels;

namespace OnlineMarket.BLL
{
   public class InvoicesManager
    {
        private static InvoicesManager instance;
        public static InvoicesManager Instance { get { return instance; } }
        static InvoicesManager()
        {
            instance = new InvoicesManager();
        }
        private OnlineMarketEntities1 db = new OnlineMarketEntities1();

        public dynamic GetInvoices()
        {
            try
            {
                List<InvoicesVM> invoice = db.Invoices.Select(s => new InvoicesVM
                {
                    InvoicesId = s.InvoicesId,
                    customerId = s.customerId,
                    Products = s.Products,
                    Date = s.Date,
                    isCash = s.isCash,


                }).ToList();
                if (invoice == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return invoice;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic GetInvoicesById(int invoiceId)
        {
            try
            {
                List<InvoicesVM> invoice = db.Invoices.Where(e => e.InvoicesId == invoiceId).Select(s => new InvoicesVM
                {
                    InvoicesId = s.InvoicesId,
                    customerId = s.customerId,
                    Products = s.Products,
                    Date = s.Date,
                    isCash = s.isCash,


                }).ToList();
                if (invoice == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return invoice;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic GetInvoicesByCustomerId(int CustomerId)
        {
            try
            {
                List<InvoicesVM> invoice = db.Invoices.Where(e => e.customerId == CustomerId).Select(s => new InvoicesVM
                {
                    InvoicesId = s.InvoicesId,
                    customerId = s.customerId,
                    Products = s.Products,
                    Date = s.Date,
                    isCash = s.isCash,


                }).ToList();
                if (invoice == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return invoice;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic GetInvoicesByDate(DateTime date)
        {
            try
            {
                List<InvoicesVM> invoice = db.Invoices.Where(e => e.Date == date).Select(s => new InvoicesVM
                {
                    InvoicesId = s.InvoicesId,
                    customerId = s.customerId,
                    Products = s.Products,
                    Date = s.Date,
                    isCash = s.isCash,


                }).ToList();
                if (invoice == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return invoice;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic PostInvoice(InvoicesVM s)
        {
            var invoice = db.Invoices.Add(new Invoice
            {

                customerId = s.customerId,
                Products = s.Products,
                Date = s.Date,
                isCash = s.isCash,
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                invoiceId = invoice.InvoicesId
            };
        }
        public dynamic PutInvoice(InvoicesVM s)
        {
            var invoice = db.Invoices.Find(s.InvoicesId);

            invoice.InvoicesId= s.InvoicesId;
            invoice.customerId = s.customerId;
            invoice.Products = s.Products;
            invoice.Date = s.Date;
            invoice.isCash = s.isCash;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic DeleteInvoice(int invoiceId)
        {
            var invoice = db.Invoices.Where(s => s.InvoicesId == invoiceId).FirstOrDefault();
            db.Invoices.Remove(invoice);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
