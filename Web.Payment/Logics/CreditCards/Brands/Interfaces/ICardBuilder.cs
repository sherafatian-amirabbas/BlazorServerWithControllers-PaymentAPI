using Web.Payment.Models;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.CreditCards.Brands.interfaces
{
    public interface ICardBuilder<T>
    {
        T Create(ICreditCard card);
    }
}
