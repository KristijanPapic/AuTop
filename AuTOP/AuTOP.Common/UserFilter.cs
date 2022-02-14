using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class UserFilter
    {
        private string searchBy;
        private string searchQuery;

        public UserFilter() { }
        //private Guid? roleId;

        //public UserFilter(string searchBy, string searchUsername)
        //{
        //    SearchBy = searchBy;
        //    SearchUsername = searchUsername;
        //}
        public UserFilter(string searchQuery)
        {
            SearchQuery = searchQuery;
        }

        //public Guid? RoleId { get;set; }

        public string SearchBy { get => searchBy; set => searchBy = value; }
        public string SearchQuery { get => searchQuery; set => searchQuery = value; }
    }
}
