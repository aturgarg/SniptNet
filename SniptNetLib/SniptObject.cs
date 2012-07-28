using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniptNetLib
{
    public class SniptObject
    {
        public string Title { get; set; }

        public string Code { get; set; }

        public string AbsoluteUrl { get; set; }

        public string EmbedUrl { get; set; }

        public string FullAbsoluteUrl { get; set; }

        public string ResourceUri { get; set; }

        // TODO : later covert to datetime if required
        public string CreateDate { get; set; }

        // TODO : later covert to datetime if required
        public string ModifiedDate { get; set; }


        private bool _isPublic = false;
        public bool IsPublic
        {
            get { return _isPublic; }
            set { _isPublic = value; }
        }

        public string Lexer { get; set; }

        public List<string> Tags { get; set; }
    }
}
