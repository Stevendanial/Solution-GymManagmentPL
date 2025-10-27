using GymManagmentBLL.ViewModels.SessionViewModels;
using GymManagmentBLL.ViewModels.TrainerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interface
{
    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSession();
        SessionViewModel GetSessionById(int id);
        bool CreateSession(CreateSessionViewModel CreateSession);

        bool UpdateSession(int id, UpdateSessionViewModel UpdateSession);
        UpdateSessionViewModel? UpdateSessionViewModel(int SessionId);
        bool RemoveSession(int id);

        IEnumerable<TrainerSelectViewModel> GetTrainerForDropDown();
        IEnumerable<CategorySelectViewModel> GetCategoryForDropDown();

    }
}
