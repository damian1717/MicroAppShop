using System;

namespace MicroApp.Api.Queries.Documents
{
    public class BrowseDocumentsByExternalId
    {
        public Guid[] Ids { get; set; }
        public BrowseDocumentsByExternalId(Guid[] ids)
        {
            Ids = ids;
        }
    }
}
