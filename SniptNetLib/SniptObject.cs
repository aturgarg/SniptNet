using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniptNetLib
{
    /// <summary>
    /// 
    /// </summary>
    public class SniptObject
    {
        /// <summary>
        /// 
        /// This alos acts a filename
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AbsoluteUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmbedUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FullAbsoluteUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ResourceUri { get; set; }

        /// <summary>
        /// 
        /// TODO : later covert to datetime if required
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// 
        /// TODO : later covert to datetime if required
        /// </summary>
        public string ModifiedDate { get; set; }

        private bool _isPublic = false;

        /// <summary>
        /// 
        /// </summary>
        public bool IsPublic
        {
            get { return _isPublic; }
            set { _isPublic = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Lexer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LineCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
