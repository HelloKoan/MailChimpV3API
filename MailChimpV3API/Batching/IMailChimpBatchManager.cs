using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Batching
{
    public interface IMailChimpBatchManager
    {
        BatchOperationResponse Get(string batchOperationId);

        IEnumerable<BatchOperationResponse> GetAll();

        BatchOperationResponse PostBatchOperations(IEnumerable<BatchOperation> operations);

        Task<BatchOperationResponse> GetAsync(string batchOperationId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<BatchOperationResponse>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<BatchOperationResponse> PostBatchOperationsAsync(IEnumerable<BatchOperation> operations, CancellationToken cancellationToken = default(CancellationToken));
    }
}