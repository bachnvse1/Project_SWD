using HospitalLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HospitalLibrary.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DBContext _context;

        public PaymentRepository(DBContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }
        public int GetMaxPaymentId()
        {
            
            return _context.Payments.Max(p => p.PaymentId);
        }
    
    }
}
