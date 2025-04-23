using ComputergyAPI.DTOs.Payment;

namespace ComputergyAPI.Interfaces
{
    public interface IPayment
    {
        public Task<bool> CreatUpdatePaymentCard(CreatUpdatePaymentCardDTO input);
        public Task<bool> RemovePaymentCard(int CardId);

        public Task<PaymentDTO> GetPaymentCard(int CardId);
        public Task<List<PaymentDTO>> GetAll(int UserId);




    }
}
