using GymManagmentBLL.ViewModels.SessionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interface
{
    internal interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSession();
        SessionViewModel GetSessionById(int id);
        bool CreateSession(CreateSessionViewModel CreateSession);

        bool UpdateSession(int id, UpdateSessionViewModel UpdateSession);
        UpdateSessionViewModel? UpdateSessionViewModel(int SessionId);
        bool RemoveSession(int id);
    }
}
