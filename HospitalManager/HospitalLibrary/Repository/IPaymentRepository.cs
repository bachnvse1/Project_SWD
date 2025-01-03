﻿using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Repository
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        int GetMaxPaymentId();
    }
}
