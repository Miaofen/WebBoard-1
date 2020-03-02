using System;
using System.Collections.Generic;

namespace WebBoard.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BoardTitle
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Memo { get; set; }
    }
}
