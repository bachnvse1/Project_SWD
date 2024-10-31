using HospitalLibrary.DataAccess;
using HospitalLibrary.Repository;

namespace HospitalLibrary.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }



        public int GenerateNextPaymentId()
        {
           
            int maxPaymentId = _paymentRepository.GetMaxPaymentId();
           
                return maxPaymentId + 1;
        }

        public void CreatePayment(Payment payment)
        {
            payment.PaymentId = GenerateNextPaymentId(); // Set the new PaymentId
            payment.TransactionTime = DateTime.Now;
            payment.CreatedAt = DateTime.Now;
            _paymentRepository.AddPayment(payment);
        }
    }
}
