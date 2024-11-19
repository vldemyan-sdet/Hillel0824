using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenBudgeteer.Core.Data.Entities;
using OpenBudgeteer.Core.Data.Entities.Models;

namespace OpenBudgeteer.Core.Data.Initialization;

public class DemoDataGenerator
{
    private readonly DbContextOptions<DatabaseContext> _dbContextOptions;

    public DemoDataGenerator(DbContextOptions<DatabaseContext> dbContextOptions)
    {
        _dbContextOptions = dbContextOptions;
    }

    public void GenerateDemoData()
    {
        if (!IsDatabaseEmpty()) return;
        
        using var dbContext = new DatabaseContext(_dbContextOptions);
        
        // Create Accounts
        var accountChecking = new Account()
        {
            Id = Guid.Empty,
            Name = "Checking account",
            IsActive = 1
        };
        var accountSavings = new Account()
        {
            Id = Guid.Empty,
            Name = "Savings account",
            IsActive = 1
        };
        dbContext.Account.AddRange(new []{ accountChecking, accountSavings });
        dbContext.SaveChanges();
        
        // Create Buckets Groups
        var bucketGroupRegularExpenses = new BucketGroup()
        {
            Id = Guid.Empty,
            Name = "Regular Expenses",
            Position = 1
        };
        var bucketGroupSavings = new BucketGroup()
        {
            Id = Guid.Empty,
            Name = "Long Term Savings",
            Position = 2
        };
        dbContext.BucketGroup.AddRange(new []{ bucketGroupRegularExpenses, bucketGroupSavings });
        dbContext.SaveChanges();
        
        // Create Buckets
        var firstOfThisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var firstOfPreviousMonth = firstOfThisMonth.AddMonths(-1);
        var bucketRent = new Bucket()
        {
            Id = Guid.Empty,
            BucketGroupId = bucketGroupRegularExpenses.Id,
            Name = "Rent",
            ValidFrom = firstOfPreviousMonth,
            ColorCode = "IndianRed",
            TextColorCode = "White"
        };
        var bucketHealthInsurance = new Bucket()
        {
            Id = Guid.Empty,
            BucketGroupId = bucketGroupRegularExpenses.Id,
            Name = "Health Insurance",
            ValidFrom = firstOfPreviousMonth,
            ColorCode = "IndianRed",
            TextColorCode = "White"
        };
        var bucketGroceries = new Bucket()
        {
            Id = Guid.Empty,
            BucketGroupId = bucketGroupRegularExpenses.Id,
            Name = "Groceries",
            ValidFrom = firstOfPreviousMonth,
            ColorCode = "DarkOliveGreen",
            TextColorCode = "White"
        };
        var bucketCarFuel = new Bucket()
        {
            Id = Guid.Empty,
            BucketGroupId = bucketGroupRegularExpenses.Id,
            Name = "Car Fuel",
            ValidFrom = firstOfPreviousMonth,
            ColorCode = "DarkOliveGreen",
            TextColorCode = "White"
        };
        var bucketVacationTrip = new Bucket()
        {
            Id = Guid.Empty,
            BucketGroupId = bucketGroupSavings.Id,
            Name = "Vacation Trip",
            ValidFrom = firstOfThisMonth,
            ColorCode = "Goldenrod",
            TextColorCode = "Black"
        };
        var bucketReserves = new Bucket()
        {
            Id = Guid.Empty,
            BucketGroupId = bucketGroupSavings.Id,
            Name = "Reserves",
            ValidFrom = firstOfPreviousMonth,
            ColorCode = "Orange",
            TextColorCode = "Black"
        };
        dbContext.Bucket.AddRange(new []
        {
            bucketRent, bucketHealthInsurance, bucketGroceries, bucketCarFuel,
            bucketVacationTrip, bucketReserves
        });
        dbContext.SaveChanges();
        
        // Create Bucket Versions
        var bucketVersionRent = new BucketVersion()
        {
            Id = Guid.Empty,
            BucketId = bucketRent.Id,
            BucketType = 2,
            BucketTypeXParam = 1,
            BucketTypeYParam = 400,
            BucketTypeZParam = DateTime.MinValue,
            ValidFrom = bucketRent.ValidFrom,
            Version = 1
        };
        var bucketVersionHealthInsurance = new BucketVersion()
        {
            Id = Guid.Empty,
            BucketId = bucketHealthInsurance.Id,
            BucketType = 3,
            BucketTypeXParam = 3,
            BucketTypeYParam = 150,
            BucketTypeZParam = bucketHealthInsurance.ValidFrom.AddMonths(2),
            ValidFrom = bucketHealthInsurance.ValidFrom,
            Version = 1
        };
        var bucketVersionGroceries = new BucketVersion()
        {
            Id = Guid.Empty,
            BucketId = bucketGroceries.Id,
            BucketType = 2,
            BucketTypeXParam = 1,
            BucketTypeYParam = 300,
            BucketTypeZParam = DateTime.MinValue,
            ValidFrom = bucketGroceries.ValidFrom,
            Version = 1
        };
        var bucketVersionCarFuel = new BucketVersion()
        {
            Id = Guid.Empty,
            BucketId = bucketCarFuel.Id,
            BucketType = 2,
            BucketTypeXParam = 1,
            BucketTypeYParam = 100,
            BucketTypeZParam = DateTime.MinValue,
            ValidFrom = bucketCarFuel.ValidFrom,
            Version = 1
        };
        var bucketVersionVacationTrip = new BucketVersion()
        {
            Id = Guid.Empty,
            BucketId = bucketVacationTrip.Id,
            BucketType = 4,
            BucketTypeXParam = 0,
            BucketTypeYParam = 600,
            BucketTypeZParam = bucketVacationTrip.ValidFrom.AddMonths(5),
            ValidFrom = bucketVacationTrip.ValidFrom,
            Version = 1
        };
        var bucketVersionReserves = new BucketVersion()
        {
            Id = Guid.Empty,
            BucketId = bucketReserves.Id,
            BucketType = 1,
            BucketTypeXParam = 0,
            BucketTypeYParam = 0,
            BucketTypeZParam = DateTime.MinValue,
            ValidFrom = bucketReserves.ValidFrom,
            Version = 1
        };
        dbContext.BucketVersion.AddRange(new []
        {
            bucketVersionRent, bucketVersionHealthInsurance, bucketVersionGroceries, bucketVersionCarFuel,
            bucketVersionVacationTrip, bucketVersionReserves
        });
        dbContext.SaveChanges();
        
        // Create Bank Transactions
        var transactionOpeningCheckingAccount = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1),
            AccountId = accountChecking.Id,
            Memo = "Opening Transaction",
            Amount = new decimal(1500.35)
        };
        var transactionSalary = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28).AddMonths(-1),
            AccountId = accountChecking.Id,
            Memo = "Salary",
            Amount = new decimal(2300.57)
        };
        var transactionRent1 = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10).AddMonths(-1),
            AccountId = accountChecking.Id,
            Memo = "Rent",
            Amount = -400
        };
        var transactionRent2 = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10),
            AccountId = accountChecking.Id,
            Memo = "Rent",
            Amount = -400
        };
        var transactionGroceries1 = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 4).AddMonths(-1),
            AccountId = accountChecking.Id,
            Memo = "Supermarket",
            Amount = new decimal(-23.87)
        };
        var transactionGroceries2 = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 11).AddMonths(-1),
            AccountId = accountChecking.Id,
            Memo = "Supermarket",
            Amount = new decimal(-40.34)
        };
        var transactionGroceries3 = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 2),
            AccountId = accountChecking.Id,
            Memo = "Supermarket",
            Amount = new decimal(-10.50)
        };
        var transactionSplit = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25).AddMonths(-1),
            AccountId = accountChecking.Id,
            Memo = "Weekend shopping",
            Amount = new decimal(-170.51)
        };
        var transactionTransfer1 = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 29).AddMonths(-1),
            AccountId = accountChecking.Id,
            Memo = "Bank Transfer",
            Amount = -1500
        };
        var transactionTransfer2 = new BankTransaction()
        {
            Id = Guid.Empty,
            TransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 29).AddMonths(-1),
            AccountId = accountSavings.Id,
            Memo = "Bank Transfer",
            Amount = 1500
        };
        dbContext.BankTransaction.AddRange(new []
        {
            transactionOpeningCheckingAccount, transactionSalary,
            transactionRent1, transactionRent2,
            transactionGroceries1, transactionGroceries2, transactionGroceries3,
            transactionSplit, transactionTransfer1, transactionTransfer2
        });
        dbContext.SaveChanges();
        
        // Create BucketMovements
        var movementRent1 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfPreviousMonth,
            BucketId = bucketRent.Id,
            Amount = 400
        };
        var movementRent2 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfThisMonth,
            BucketId = bucketRent.Id,
            Amount = 400
        };
        var movementInsurance1 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfPreviousMonth,
            BucketId = bucketHealthInsurance.Id,
            Amount = 50
        };
        var movementInsurance2 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfThisMonth,
            BucketId = bucketHealthInsurance.Id,
            Amount = 50
        };
        var movementGroceries1 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfPreviousMonth,
            BucketId = bucketGroceries.Id,
            Amount = 300
        };
        var movementGroceries2 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfThisMonth,
            BucketId = bucketGroceries.Id,
            Amount = 300
        };
        var movementCarFuel1 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfPreviousMonth,
            BucketId = bucketCarFuel.Id,
            Amount = 100
        };
        var movementCarFuel2 = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfThisMonth,
            BucketId = bucketCarFuel.Id,
            Amount = 100
        };
        var movementVacationTrip = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = firstOfThisMonth,
            BucketId = bucketVacationTrip.Id,
            Amount = 100
        };
        var movementReserves = new BucketMovement()
        {
            Id = Guid.Empty,
            MovementDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28).AddMonths(-1),
            BucketId = bucketReserves.Id,
            Amount = 1000
        };
        dbContext.BucketMovement.AddRange(new []
        {
            movementRent1, movementInsurance1, movementGroceries1, movementCarFuel1, movementVacationTrip, movementReserves,
            movementRent2, movementInsurance2, movementGroceries2, movementCarFuel2
        });
        dbContext.SaveChanges();
        
        // Create BudgetedTransactions
        var budgetedTransactionOpeningCheckingAccount = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionOpeningCheckingAccount.Id,
            BucketId = new Guid("00000000-0000-0000-0000-000000000001"),
            Amount = transactionOpeningCheckingAccount.Amount
        };
        var budgetedTransactionSalary = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionSalary.Id,
            BucketId = new Guid("00000000-0000-0000-0000-000000000001"),
            Amount = transactionSalary.Amount
        };
        var budgetedTransactionRent1 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionRent1.Id,
            BucketId = bucketRent.Id,
            Amount = transactionRent1.Amount
        };
        var budgetedTransactionRent2 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionRent2.Id,
            BucketId = bucketRent.Id,
            Amount = transactionRent2.Amount
        };
        var budgetedTransactionGroceries1 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionGroceries1.Id,
            BucketId = bucketGroceries.Id,
            Amount = transactionGroceries1.Amount
        };
        var budgetedTransactionGroceries2 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionGroceries2.Id,
            BucketId = bucketGroceries.Id,
            Amount = transactionGroceries2.Amount
        };
        var budgetedTransactionGroceries3 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionGroceries3.Id,
            BucketId = bucketGroceries.Id,
            Amount = transactionGroceries3.Amount
        };
        var budgetedTransactionSplit1 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionSplit.Id,
            BucketId = bucketCarFuel.Id,
            Amount = new decimal(-90.86) 
        };
        var budgetedTransactionSplit2 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionSplit.Id,
            BucketId = bucketGroceries.Id,
            Amount = transactionSplit.Amount - budgetedTransactionSplit1.Amount
        };
        var budgetedTransactionTransfer1 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionTransfer1.Id,
            BucketId = new Guid("00000000-0000-0000-0000-000000000002"),
            Amount = transactionTransfer1.Amount
        };
        var budgetedTransactionTransfer2 = new BudgetedTransaction()
        {
            Id = Guid.Empty,
            TransactionId = transactionTransfer2.Id,
            BucketId = new Guid("00000000-0000-0000-0000-000000000002"),
            Amount = transactionTransfer2.Amount
        };
        dbContext.BudgetedTransaction.AddRange(new []
        {
            budgetedTransactionOpeningCheckingAccount, budgetedTransactionSalary, budgetedTransactionRent1,
            budgetedTransactionRent2, budgetedTransactionGroceries1, budgetedTransactionGroceries2,
            budgetedTransactionGroceries3, budgetedTransactionSplit1, budgetedTransactionSplit2,
            budgetedTransactionTransfer1, budgetedTransactionTransfer2
        });
        dbContext.SaveChanges();
    }
    
    private bool IsDatabaseEmpty()
    {
        using var dbContext = new DatabaseContext(_dbContextOptions);
        if (dbContext.Account.Any()) return false;
        if (dbContext.Bucket.Any(i => i.BucketGroupId != new Guid("00000000-0000-0000-0000-000000000001"))) return false;
        if (dbContext.BankTransaction.Any()) return false;
        if (dbContext.BucketMovement.Any()) return false;
        if (dbContext.BudgetedTransaction.Any()) return false;
            
        return true;
    }
}