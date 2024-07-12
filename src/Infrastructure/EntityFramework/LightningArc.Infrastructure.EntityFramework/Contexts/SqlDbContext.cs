namespace LightningArc.Persistence.EntityFramework.Contexts;

public abstract class SqlDbContext(DbContextOptions sqlOptions) : DbContext(sqlOptions)
{
    private IDbContextTransaction? _currentTransaction;

    protected abstract ISqlDbModelConfiguration ModelConfigProvider { get; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ModelConfigProvider.Configure(modelBuilder);
    }

    public async Task<int> SaveChangesAsync<TId>(TId userId, CancellationToken cancellationToken)
    {
        var entries = ChangeTracker.Entries<IAuditableEntity<TId>>()
                  .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
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
        if (_currentTransaction is not null) return null;
        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);
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
            _currentTransaction?.Dispose();
            _currentTransaction = null;
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
            _currentTransaction?.Dispose();
            _currentTransaction = null;
        }
    }
}
