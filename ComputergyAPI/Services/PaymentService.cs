using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Discount;
using ComputergyAPI.DTOs.Payment;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail;

namespace ComputergyAPI.Services
{
    public class PaymentService : IPayment
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public PaymentService(ComputergyDbContext dbContext)
        {
            _computergyDbContext = dbContext;
        }
        public async Task<string> CreateUpdatePaymentCard(CreateUpdatePaymentCardDTO input)
        {
            try
            {
                if (input == null)
                    throw new ArgumentNullException(nameof(input));

                if (input.UserId == 0)
                {
                    var newEntity = new PaymentCard
                    {
                        CardHolder = input.CardHolder,
                        CardNumber = input.CardNumber,
                        CVC = input.CVC,
                        ExpirationDate = input.ExpirationDate,
                    };

                    _computergyDbContext.PaymentCards.Add(newEntity);
                    await _computergyDbContext.SaveChangesAsync();

                    return "Payment card created successfully.";
                }
                else
                {
                    var existingEntity = await _computergyDbContext.PaymentCards.FindAsync(input.UserId);
                    if (existingEntity == null)
                        throw new KeyNotFoundException($"Entity with Id {input.UserId} not found.");

                    existingEntity.CardHolder = input.CardHolder;
                    existingEntity.CardNumber = input.CardNumber;
                    existingEntity.CVC = input.CVC;
                    existingEntity.ExpirationDate = input.ExpirationDate;

                    await _computergyDbContext.SaveChangesAsync();

                    return "Payment card updated successfully.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
               
        }

        public async Task<List<CardDTO>> GetAll(int userID)
        {
            try
            {
                if (userID <= 0)
                {
                    throw new Exception("InvalidID");
                }

                var getPayment = _computergyDbContext.PaymentCards.ToList();

                var payment = getPayment.Select(d => new CardDTO
                {
                    CardHolder = d.CardHolder,
                    CardNumber = d.CardNumber,
                    ExpirationDate = d.ExpirationDate,
                    CVC = d.CVC,
                    UserId = d.UserId
                }).ToList();
                return payment;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching payment cards: {ex.Message}");
            }
           
        }


        public async Task<CardDTO> GetPaymentCard(int cardId)
        {
            try
            {
                if (cardId <= 0)
                    throw new ArgumentException("Invalid Card Id", nameof(cardId));

                var card = await _computergyDbContext.PaymentCards
                    .Where(x => x.Id == cardId)
                    .SingleOrDefaultAsync();

                if (card == null)
                    throw new KeyNotFoundException($"Card with Id {cardId} not found.");

                var Card = new CardDTO
                {
                    CardNumber = card.CardNumber,
                    ExpirationDate = card.ExpirationDate,
                    CardHolder = card.CardHolder,
                    CVC = card.CVC,
                    UserId = card.UserId
                };

                return Card;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching payment cards: {ex.Message}");
            }
           
        }

        public async Task<bool> RemovePaymentCard(int cardId)
        {
            try
            {
                if (cardId <= 0)
                    throw new Exception("Invalid ID");

                var card = await _computergyDbContext.PaymentCards
                    .FirstOrDefaultAsync(x => x.Id == cardId);

                if (card == null)
                    throw new KeyNotFoundException($"Payment card with Id {cardId} not found.");

                _computergyDbContext.PaymentCards.Remove(card);
                await _computergyDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

    }
}
