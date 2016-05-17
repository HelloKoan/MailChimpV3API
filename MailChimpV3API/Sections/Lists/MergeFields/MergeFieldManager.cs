using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Lists.MergeFields
{
    public class MergeFieldManager : IMergeFieldManager
    {
        private readonly IMailChimpConnector _connector;

        public MergeFieldManager(IMailChimpConnector connector)
        {
            _connector = connector;
        }

        public IEnumerable<MergeField> GetAll(string listId)
        {
            return GetAllAsync(listId).Result;
        }

        public async Task<IEnumerable<MergeField>> GetAllAsync(string listId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = new MergeFieldsFilter { Count = 100 };

            return await _connector
                .GetAllAsync<MergeField, MergeFieldsCollection>(
                    BuildPath(listId),
                    filter,
                    col => col.MergeFields,
                    cancellationToken);
        }

        public MergeField Get(string listId, string mergeId)
        {
            return GetAsync(listId, mergeId).Result;
        }

        public async Task<MergeField> GetAsync(string listId, string mergeFieldId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = new MergeFieldsFilter();

            return await _connector
                .GetAsync<MergeField>(
                    BuildPath(listId, mergeFieldId),
                    filter,
                    cancellationToken);
        }

        public MergeField Create(string listId, MergeField mergeField)
        {
            return CreateAsync(listId, mergeField).Result;
        }

        public async Task<MergeField> CreateAsync(string listId, MergeField mergeField, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await
                _connector.PostAsync<MergeField>(
                    BuildPath(listId),
                    body: mergeField,
                    cancellationToken: cancellationToken);
        }

        public MergeField Edit(MergeField mergeField)
        {
            return EditAsync(mergeField).Result;
        }

        public async Task<MergeField> EditAsync(MergeField mergeField, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await 
                _connector.PatchAsync<MergeField>(
                    BuildPath(mergeField.ListId, mergeField.Id.ToString()),
                    body: mergeField, 
                    cancellationToken: cancellationToken);
        }

        public void Delete(string listId, int mergeFieldId)
        {
            DeleteAsync(listId, mergeFieldId).Wait();
        }

        public async Task DeleteAsync(string listId, int mergeFieldId, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _connector.DeleteAsync<MergeField>(
                BuildPath(listId, mergeFieldId.ToString()),
                cancellationToken: cancellationToken);
        }

        private static string BuildPath(string listId, string mergeFieldId = "")
        {
            return string.IsNullOrWhiteSpace(mergeFieldId) 
                ? string.Format("lists/{0}/merge-fields", listId) 
                : string.Format("lists/{0}/merge-fields/{1}", listId, mergeFieldId);
        }
    }
}
