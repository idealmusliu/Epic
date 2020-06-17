using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Post> MyPosts { get; set; }
    }
}