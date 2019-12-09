using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkiLand.Web.Models.AccountViewModels
{
    public class AccountBreadcrump
    {
        public AccountBreadcrump(string title)
        {
            Title = title;
        }
        public string Title { get; set; }
    }
}
