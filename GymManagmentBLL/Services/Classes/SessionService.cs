using AutoMapper;
using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.SessionViewModels;
using GymManagmentBLL.ViewModels.TrainerViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GymManagmentBLL.Services.Classes
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CreateSession(CreateSessionViewModel createSession)
        {
            try { 
            if (!IsCatogoryExists(createSession.CategoryId))return false;
            if (!IsTrainerExists(createSession.TrainerId))return false;
            if (!ISValidDataRange(createSession.StartDate, createSession.EndDate))return false;

            var mepperSession = _mapper.Map<CreateSessionViewModel, Session>(createSession);
                _unitOfWork.sessionRepository.Add(mepperSession);
               return _unitOfWork.SaveChange()>0;

            }
            catch { 
            return false;
            }
        }

        public IEnumerable<SessionViewModel> GetAllSession()
        {
            var sessions = _unitOfWork.sessionRepository.GetAlltSessionsWithAllTrainerAndCatogry();

            if (sessions == null || !sessions.Any()) return [];

            var MapperSssion = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(sessions);
            return MapperSssion;
        }

        public SessionViewModel GetSessionById(int id)
        {
            var session = _unitOfWork.sessionRepository.GetById(id);
            if (session == null) return null!;
            var MapperSssion = _mapper.Map<Session, SessionViewModel>(session);
            return MapperSssion;
        }

        public bool RemoveSession(int id)
        {
            try { 
            var session = _unitOfWork.sessionRepository.GetById(id);
                if (!IsSessionAvailableForRemoving(session!)) return false;
                _unitOfWork.sessionRepository.Delete(session!);
                return _unitOfWork.SaveChange() > 0;

            }
            catch { return false; }
        }

        public bool UpdateSession(int id, UpdateSessionViewModel UpdateSession)
        {
          try{  var session = _unitOfWork.sessionRepository.GetById(id);
            if (!IsSessionAvailableForUpdateing(session!)) return false;
            if (!IsTrainerExists(UpdateSession.TrainerId)) return false;
            if (!ISValidDataRange(UpdateSession.StartDate, UpdateSession.EndDate)) return false;
             _mapper.Map(UpdateSession, session);
            session!.UpdatedAt = DateTime.Now;
            return _unitOfWork.SaveChange() > 0;
        }
            catch
            {
                return false;
            }
        }

        public UpdateSessionViewModel? UpdateSessionViewModel(int SessionId)
        {
            var Session =_unitOfWork.sessionRepository.GetById(SessionId);
            if (!IsSessionAvailableForUpdateing(Session!)) return null;
            return _mapper.Map<Session, UpdateSessionViewModel>(Session!);
        }
      
        
        
        #region Helpers
        private bool IsTrainerExists(int trainerID)
        {
            return _unitOfWork.GetRepository<Trainer>().GetById(trainerID) is not null;

        }


        private bool IsCatogoryExists(int catogoryID)
        {
            return _unitOfWork.GetRepository<Category>().GetById(catogoryID) is not null;

        }
        private bool ISValidDataRange(DateTime start, DateTime end)
        {
            return start < end && start > DateTime.Now;
        }


        private bool IsSessionAvailableForUpdateing(Session session)
        {
            if (session == null) return false;
            if (session.EndTime<DateTime.Now) return false;
            if(session.StartTime <= DateTime.Now) return false;

            var HasActiveBooking = _unitOfWork.sessionRepository
                .GetCountOfBookedSlots(session.Id) > 0;
            if (HasActiveBooking) return false;
            return true;


        }

        private bool IsSessionAvailableForRemoving(Session session)
        {
            if (session == null) return false;
            if (session.StartTime > DateTime.Now) return false;
            if (session.StartTime <= DateTime.Now&&session.EndTime >DateTime.Now) return false;

            var HasActiveBooking = _unitOfWork.sessionRepository
                .GetCountOfBookedSlots(session.Id) > 0;
            if (HasActiveBooking) return false;
            return true;


        }

        public IEnumerable<TrainerSelectViewModel> GetTrainerForDropDown()
        {
            var trainer=_unitOfWork.GetRepository<Trainer>().GetAll();
            return _mapper.Map<IEnumerable<TrainerSelectViewModel>>(trainer);
        }

        public IEnumerable<CategorySelectViewModel> GetCategoryForDropDown()
        {

            var Category = _unitOfWork.GetRepository<Category>().GetAll();
            return _mapper.Map<IEnumerable<CategorySelectViewModel>>(Category);
        }



        #endregion
    }
}
