using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullTextExtractor
{
    /// <summary>
    /// 
    /// </summary>
    public class FullTextResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }
    }
}