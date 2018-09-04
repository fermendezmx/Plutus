using AutoMapper;
using Plutus.Business.Services.Contracts;
using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace Plutus.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        #region Public Methods

        public XHRResponse<List<_Payment>> ReadAll()
        {
            XHRResponse<List<_Payment>> result = new XHRResponse<List<_Payment>>();

            try
            {
                List<Payment> payments = _paymentRepository.GetAll();
                result.Data = Mapper.Map<List<_Payment>>(payments);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to get payments.";
                result.Succeeded = false;
            }

            return result;
        }

        #endregion
    }
}
