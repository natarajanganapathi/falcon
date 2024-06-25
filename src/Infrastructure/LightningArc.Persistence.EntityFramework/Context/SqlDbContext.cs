namespace LightningArc.Persistence.EntityFramework.Context;

public abstract class SqlDbContext : DbContext
{
    private IDbContextTransaction? _currentTransaction;

    protected abstract ISqlDbModelConfiguration ModelConfigProvider { get; }
    protected SqlDbContext(DbContextOptions sqlOptions) : base(sqlOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ModelConfigProvider.Configure(modelBuilder);
    }
    public async Task<int> SaveChangesAsync<TId>(TId userId, CancellationToken cancellationToken)
    {
        var entries = ChangeTracker.Entries()
                  .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified) && x.Entity is IAuditableEntity<TId>);
        var dateTime = DateTime.UtcNow;
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(IAuditableEntity<TId>.CreatedAtUtc)).CurrentValue = dateTime;
                entry.Property(nameof(IAuditableEntity<TId>.CreatedByUserId)).CurrentValue = userId;
            }
            entry.Property(nameof(IAuditableEntity<TId>.ModifiedAtUtc)).CurrentValue = dateTime;
            entry.Property(nameof(IAuditableEntity<TId>.ModifiedByUserId)).CurrentValue = userId;
        }
        return await SaveChangesAsync(cancellationToken);
    }
    public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;
    public bool HasActiveTransaction => _currentTransaction is not null;

    public async Task<IDbContextTransaction?> BeginTransactionAsync()
    {
        if (_currentTransaction is null) return null;
        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction is null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}
