using Elsa.MongoDb.Common;
using Elsa.Workflows.Runtime.Contracts;
using Elsa.Workflows.Runtime.Entities;
using Elsa.Workflows.Runtime.Filters;
using MongoDB.Driver.Linq;

namespace Elsa.MongoDb.Modules.Runtime;

/// <summary>
/// A MongoDb implementation of <see cref="IBookmarkStore"/>.
/// </summary>
public class MongoBookmarkStore : IBookmarkStore
{
    private readonly MongoDbStore<StoredBookmark> _mongoDbStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="MongoBookmarkStore"/> class.
    /// </summary>
    public MongoBookmarkStore(MongoDbStore<StoredBookmark> mongoDbStore)
    {
        _mongoDbStore = mongoDbStore;
    }

    /// <inheritdoc />
    public async ValueTask SaveAsync(StoredBookmark record, CancellationToken cancellationToken = default)
    {
        await _mongoDbStore.SaveAsync(record, s => s.Id, cancellationToken);
    }

    /// <inheritdoc />
    public async ValueTask SaveManyAsync(IEnumerable<StoredBookmark> records, CancellationToken cancellationToken)
    {
        await _mongoDbStore.SaveManyAsync(records, nameof(StoredBookmark.Id), cancellationToken);
    }

    /// <inheritdoc />
    public async ValueTask<IEnumerable<StoredBookmark>> FindManyAsync(BookmarkFilter filter, CancellationToken cancellationToken = default)
    {
        return await _mongoDbStore.FindManyAsync(query => Filter(query, filter), filter.TenantAgnostic, cancellationToken);
    }

    /// <inheritdoc />
    public async ValueTask<long> DeleteAsync(BookmarkFilter filter, CancellationToken cancellationToken = default)
    {
        return await _mongoDbStore.DeleteWhereAsync<string>(query => Filter(query, filter), x => x.Id, filter.TenantAgnostic, cancellationToken);
    }

    private IMongoQueryable<StoredBookmark> Filter(IMongoQueryable<StoredBookmark> queryable, BookmarkFilter filter)
    {
        return (filter.Apply(queryable) as IMongoQueryable<StoredBookmark>)!;
    }
}