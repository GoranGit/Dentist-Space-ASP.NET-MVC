using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSpace.Web.Models.Posts;

namespace DentistSpace.Web.Models.Home
{
    public class IndexPageableModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string CurrentUrl { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
