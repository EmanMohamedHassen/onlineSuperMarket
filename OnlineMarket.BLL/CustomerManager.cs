using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMaeket.DAL;
using OnlineMaeket.DAL.ViewModels;

namespace OnlineMarket.BLL
{
   public class CustomerManager
    {
        private static CustomerManager instance;
        public static CustomerManager Instance { get { return instance; } }
        static CustomerManager()
        {
            instance = new CustomerManager();
        }
        private OnlineMarketEntities1 db = new OnlineMarketEntities1();

        public dynamic GetCustomers()
        {
            try
            {
                List<CustomerVM> customer = db.Customers.Select(s => new CustomerVM
                {
                    customer_id = s.customer_id,
                    customer_name = s.customer_name,
                    customer_address = s.customer_address,
                    phone_number = s.phone_number,
                    isAdmin = s.isAdmin,
                    
                    
                }).ToList();
                if (customer == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return customer;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic GetCustomerById(int customerId)
        {
            try
            {
                var customer = db.Customers.Where(s => s.customer_id == customerId).FirstOrDefault();
                if (customer != null)
                {
                    return new CustomerVM
                    {
                        customer_id = customer.customer_id,
                        customer_name = customer.customer_name,
                        customer_address = customer.customer_address,
                        phone_number = customer.phone_number,
                        isAdmin = customer.isAdmin
                    };
                }
                else
                {
                    return new
                    {
                        Id = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Message = ex.Message
                };
            }
        }
        public dynamic GetCustomerByPhoneNo(int phoneNo)
        {
            try
            {
                var customer = db.Customers.Where(e => e.phone_number == phoneNo).Select(s => new CustomerVM
                {
                    customer_id = s.customer_id,
                    customer_name = s.customer_name,
                    customer_address = s.customer_address,
                    phone_number = s.phone_number,
                    isAdmin = s.isAdmin
                }).ToList();
                return customer;
            }

            catch (Exception ex)
            {
                return new
                {
                    Message = ex.Message
                };
            }
        }
        public dynamic GetCustomerByIsAdmin(bool isAdmin)
        {
            try
            {
                var customer = db.Customers.Where(e => e.isAdmin == isAdmin).Select(s => new CustomerVM
                {
                    customer_id = s.customer_id,
                    customer_name = s.customer_name,
                    customer_address = s.customer_address,
                    phone_number = s.phone_number,
                    isAdmin = s.isAdmin
                }).ToList();
                return customer;
            }

            catch (Exception ex)
            {
                return new
                {
                    Message = ex.Message
                };
            }
        }
        public dynamic PostCustomer(CustomerVM s)
        {
            var customer = db.Customers.Add(new Customer
            {

                customer_name = s.customer_name,
                customer_address = s.customer_address,
                phone_number = s.phone_number,
                isAdmin = s.isAdmin,
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                customerId = customer.customer_id
            };
        }
        public dynamic PutCustomer(CustomerVM s)
        {
            var customer = db.Customers.Find(s.customer_id);

            customer.customer_id = s.customer_id;
            customer.customer_name = s.customer_name;
            customer.customer_address = s.customer_address;
            customer.phone_number = s.phone_number;
            customer.isAdmin = s.isAdmin;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic DeleteCustomer(int customerId)
        {
            var customer = db.Customers.Where(s => s.customer_id == customerId).FirstOrDefault();
            db.Customers.Remove(customer);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}

