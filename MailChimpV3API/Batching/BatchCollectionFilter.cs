using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailChimpV3API;

namespace MailChimpV3API.Batching
{
    public class BatchCollectionFilter : MailChimpCollectionFilterBase
    {
        public override MailChimpCollectionFilterBase Clone()
        {
            return new BatchCollectionFilter
            {
                Count = Count,
                ExcludeFields = ExcludeFields,
                IncludeFields = IncludeFields,
                Offset = Offset
            };
        }
    }
}
