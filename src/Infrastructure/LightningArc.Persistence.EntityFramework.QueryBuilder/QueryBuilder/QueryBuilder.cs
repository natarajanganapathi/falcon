namespace LightningArc.QueryBuilder;

public class QueryBuilder<TEntity> where TEntity : class
{
    private string[]? _select;
    private Filter? _filter;
    private Sort[]? _sort;
    private Include[]? _includes;
    private PageContext? _pageContext;

    public static QueryBuilder<TEntity> Empty()
    {
        return new();
    }
    public QueryBuilder<TEntity> Select(string[]? select)
    {
        _select = select;
        return this;
    }
    public QueryBuilder<TEntity> Where(Filter? filter)
    {
        _filter = filter;
        return this;
    }
    public QueryBuilder<TEntity> Sort(Sort[]? sort)
    {
        _sort = sort;
        return this;
    }
    public QueryBuilder<TEntity> Includes(Include[]? includes)
    {
        _includes = includes;
        return this;
    }
    public QueryBuilder<TEntity> PageContext(PageContext? pageContext)
    {
        _pageContext = pageContext;
        return this;
    }
    private IQueryable<TEntity> Build(DbSet<TEntity> dbSet)
    {
        return dbSet.AsQueryable()
                    .AsNoTracking()
                    .ApplyWhere(_filter)
                    .ApplySort(_sort)
                    .ApplyIncludes(_includes)
                    .ApplyPageContext(_pageContext);
    }

    public IQueryable<JObject> BuildProjection(DbSet<TEntity> dbSet)
    {
        return Build(dbSet).ApplyProjection(_select, _includes);
    }
    public IQueryable<TEntity> BuildSelection(DbSet<TEntity> dbSet)
    {
        return Build(dbSet).ApplySelector(_select, _includes);
    }
    public async Task<long> BuildCountAsync(DbSet<TEntity> dbSet, CancellationToken cancellationToken = default)
    {
        return await dbSet.AsQueryable()
             .AsNoTracking()
             .ApplyWhere(_filter)
             .LongCountAsync(cancellationToken);
    }
}