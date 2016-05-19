using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Lists.MergeFields
{
    public interface IMergeFieldManager
    {
        MergeField Get(string listId, string mergeId);

        IEnumerable<MergeField> GetAll(string listId);

        Task<IEnumerable<MergeField>> GetAllAsync(string listId, CancellationToken cancellationToken = default(CancellationToken));

        Task<MergeField> GetAsync(string listId, string mergeId, CancellationToken cancellationToken = default(CancellationToken));

        MergeField Create(string listId, MergeField mergeField);

        Task<MergeField> CreateAsync(string listId, MergeField mergeField, CancellationToken cancellationToken = default(CancellationToken));

        MergeField Edit(MergeField mergeField);

        Task<MergeField> EditAsync(MergeField mergeField, CancellationToken cancellationToken = default(CancellationToken));

        void Delete(string listId, int mergeFieldId);

        Task DeleteAsync(string listId, int mergeFieldId, CancellationToken cancellationToken = default(CancellationToken));
    }
}