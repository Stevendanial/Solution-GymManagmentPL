using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Entities
{
    internal class Category: BaseEntity
    {
        public string CatogaryName { get; set; } = null!;

        public ICollection<Session> Sessions { get; set; } = null!;

    }
}
