using ComputergyAPI.DTOs.Payment;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class PaymentServece : IPayment
    {
        public Task<bool> CreatUpdatePaymentCard(CreatUpdatePaymentCardDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentDTO>> GetAll(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> GetPaymentCard(int CardId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePaymentCard(int CardId)
        {
            throw new NotImplementedException();
        }
    }
}
