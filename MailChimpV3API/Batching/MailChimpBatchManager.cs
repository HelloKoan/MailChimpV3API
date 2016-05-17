using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimpV3API.Batching
{
    public class MailChimpBatchManager : IMailChimpBatchManager
    {
        private readonly IMailChimpConnector _connector;

        public MailChimpBatchManager(IMailChimpConnector connector)
        {
            _connector = connector;
        }

        public BatchOperationResponse Get(string batchOperationId)
        {
            return GetAsync(batchOperationId).Result;
        }

        public async Task<BatchOperationResponse> GetAsync(string batchOperationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = new BatchCollectionFilter();

            return await
                _connector.GetAsync<BatchOperationResponse>(
                    string.Format("batches/{0}", batchOperationId),
                    filter,
                    cancellationToken);
        }

        public IEnumerable<BatchOperationResponse> GetAll()
        {
            return GetAllAsync().Result;
        }

        public async Task<IEnumerable<BatchOperationResponse>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = new BatchCollectionFilter();

            return await
                _connector.GetAllAsync<BatchOperationResponse, BatchOperationResultCollection>(
                    "batches",
                    filter,
                    col => col.Batches,
                    cancellationToken);
        }

        public BatchOperationResponse PostBatchOperations(IEnumerable<BatchOperation> operations)
        {
            return PostBatchOperationsAsync(operations).Result;
        }

        public async Task<BatchOperationResponse> PostBatchOperationsAsync(IEnumerable<BatchOperation> operations, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await
                _connector.PostAsync<BatchOperationResponse>(
                    "batches",
                    null,
                    new OperationsWrapper { Operations = operations },
                    cancellationToken);
        }

        internal class OperationsWrapper
        {
            [JsonProperty("operations")]
            public IEnumerable<BatchOperation> Operations { get; set; }
        }
    }
}
