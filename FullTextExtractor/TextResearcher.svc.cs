using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using TikaOnDotNet;

namespace FullTextExtractor
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode =
        AspNetCompatibilityRequirementsMode.Allowed)]
    public class TextResearcher
        : ITextResearcher
    {

        private readonly ITextExtractor extractor;

        public TextResearcher(ITextExtractor txtExtractor)
        {
            this.extractor = txtExtractor;
        }
        
        public FullTextResult MakeFullTextResult(string uri)
        {
            try
            {
                var res = this.extractor.Extract(new Uri(uri));
                return new FullTextResult
                {
                    ContentType = res.ContentType,
                    Metadata = res.Metadata,
                    Text = res.Text,
                    Status = StatusResult.Successfully
                };
            }
            catch (Exception ex)
            {
                return new FullTextResult
                {
                    Status = StatusResult.Unsuccessfully,
                    Error = ex
                };
            }
        }

        public FullTextResult MakeFullTextResult(byte[] data)
        {
            try
            {
                var res = this.extractor.Extract(data);
                return new FullTextResult
                {
                    ContentType = res.ContentType,
                    Metadata = res.Metadata,
                    Text = res.Text,
                    Status = StatusResult.Successfully
                };
            }
            catch (Exception ex)
            {
                return new FullTextResult
                {
                    Status = StatusResult.Unsuccessfully,
                    Error = ex
                };
            }
        }
    }
}
