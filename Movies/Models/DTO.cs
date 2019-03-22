using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class FileRequestDTO
    {
        public HttpPostedFileBase FileExcel { get; set; }
        //public string ListName { get; set; }
        //public int[] ColumnsNumber { get; set; }
        //public int TopRowNumber { get; set; }
    }

    public class InitialMoviesDataDTO
    {
        public List<Film> Films { get; set; }
        public int SearchCount { get; set; }
        public IEnumerable<IEnumerable<string>> SearchResultsList { get; set; }
    }

}