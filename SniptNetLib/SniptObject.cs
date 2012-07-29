using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniptNetLib
{
    /// <summary>
    /// Entity class to handle snipt.net objects
    /// </summary>
    public class SniptObject
    {
        /// <summary>
        /// Gets or sets slug property
        /// This alss acts a filename
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets title property
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets code data property
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets id property
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets key property
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets absolute_url property
        /// </summary>
        public string AbsoluteUrl { get; set; }

        /// <summary>
        /// Gets or sets embed_url property
        /// </summary>
        public string EmbedUrl { get; set; }

        /// <summary>
        /// Gets or sets full_absolute_url property
        /// </summary>
        public string FullAbsoluteUrl { get; set; }

        /// <summary>
        /// Gets or sets resource_uri property
        /// </summary>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets created date property
        /// TODO : later covert to datetime if required
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Gets or sets modified date property
        /// TODO : later covert to datetime if required
        /// </summary>
        public string ModifiedDate { get; set; }

        private bool _isPublic = false;

        /// <summary>
        /// Gets or sets public bool flag property
        /// </summary>
        public bool IsPublic
        {
            get { return _isPublic; }
            set { _isPublic = value; }
        }

        /// <summary>
        /// Gets or sets lexer property
        /// </summary>
        public string Lexer { get; set; }

        /// <summary>
        /// Gets or sets line_count property
        /// </summary>
        public int LineCount { get; set; }

        /// <summary>
        /// Gets or sets tags property
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
