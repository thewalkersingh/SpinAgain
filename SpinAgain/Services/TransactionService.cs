using Microsoft.EntityFrameworkCore;

using SpinAgain.Data;
using SpinAgain.Models;

namespace SpinAgain.Services;

public class TransactionService : ITransactionService
{
    private readonly SpinAgainDbContext _dbContext;

    public TransactionService(SpinAgainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Transaction GetTransactionById(int transactionId)
    {
        return _dbContext.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
    }

    public IEnumerable<Transaction> GetAllTransactions()
    {
        return _dbContext.Transactions.ToList();
    }

    public void CreateTransaction(Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();
    }

    public void UpdateTransaction(Transaction transaction)
    {
        _dbContext.Entry(transaction).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteTransaction(int transactionId)
    {
        var transaction = _dbContext.Transactions.Find(transactionId);
        if (transaction != null)
        {
            _dbContext.Transactions.Remove(transaction);
            _dbContext.SaveChanges();
        }
    }
}
