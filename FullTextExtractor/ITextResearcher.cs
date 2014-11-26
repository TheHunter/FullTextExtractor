using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FullTextExtractor
{
    [ServiceContract(Namespace = "WcfTextSearcher")]
    public interface ITextResearcher
    {
        [OperationContract(Name = "makeFullTextResultByUri")]
        [WebGet(UriTemplate = "/makeFullTextResultByUri?uri={uri}")]
        FullTextResult MakeFullTextResult(string uri);

        [OperationContract(Name = "makeFullTextResultByData")]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "POST")]
        FullTextResult MakeFullTextResult(byte[] data);
    }

}
