using SpinAgain.Models;

namespace SpinAgain.Services;

public interface ITransactionService
{
    Transaction GetTransactionById(int transactionId);
    IEnumerable<Transaction> GetAllTransactions();
    void CreateTransaction(Transaction transaction);
    void UpdateTransaction(Transaction transaction);
    void DeleteTransaction(int transactionId);
}
