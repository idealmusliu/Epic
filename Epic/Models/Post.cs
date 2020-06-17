using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epic.Models;

namespace Epic.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [Display(Name = "Picture")]
        public string PicPath { get; set; }
        public bool isDeleted { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
        public List<Tag> MyTags { get; set; }
        public bool isFavorite { get; set; }
    }

    public class PostVM
    {
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [Display(Name = "Picture")]
        public string PicPath { get; set; }
        public bool isDeleted { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
        public List<Tag> MyTags { get; set; }
        public bool isFavorite { get; set; }
    }
}