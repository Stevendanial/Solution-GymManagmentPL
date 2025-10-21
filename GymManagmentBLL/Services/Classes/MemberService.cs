using AutoMapper;
using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.MemberViewModels;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;

//using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CreateMember(CreateMemberViewModel CreateMember)
        {
            try
            {
                var EmailExist = _unitOfWork.GetRepository<Member>().GetAll(m => m.Email == CreateMember.Email).Any();
                var PhoneExist = _unitOfWork.GetRepository<Member>().GetAll(m => m.Phone == CreateMember.Phone).Any();
                if (EmailExist || PhoneExist) return false;
                var member = new Member
                {
                    Name = CreateMember.Name,
                    Email = CreateMember.Email,
                    Phone = CreateMember.Phone,
                    DateofBirth = CreateMember.DateOfBirth,
                    Address = new Address
                    {
                        BuilderNumber = CreateMember.BuildingNumber,
                        City = CreateMember.City,
                        Street = CreateMember.Street

                    },
                    HealthRecord = new HealthRecord()
                    {
                        Height = CreateMember.HealthRecord.Height,
                        Weight = CreateMember.HealthRecord.Weight,
                        BloodType = CreateMember.HealthRecord.BloodType,


                    }
                };
                _unitOfWork.GetRepository<Member>().Add(member);
                return _unitOfWork.SaveChange() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveMember(int Memberid)
        {
            try
            {
                var member = _unitOfWork.GetRepository<Member>().GetById(Memberid);
                if (member == null) return false;

                var SessionIDs = _unitOfWork.GetRepository<MemberSession>()
                    .GetAll(m => m.Id == Memberid).Select(x => x.SessionID);

                var ActiveMemberSessions = _unitOfWork.GetRepository<Session>()
                    .GetAll(ms => SessionIDs.Contains(ms.Id)&& ms.StartTime>DateTime.Now).Any();


                if (ActiveMemberSessions)return false;

                var memberShips = _unitOfWork.GetRepository<MemberShip>()
                    .GetAll(m => m.MemberID == Memberid);

                if(memberShips.Any())
                {
                    foreach (var memberShip in memberShips)
                    {
                        _unitOfWork.GetRepository<MemberShip>().Delete(memberShip);
                    }
                }

                _unitOfWork.GetRepository<Member>().Delete(member);
                return _unitOfWork.SaveChange() > 0;



            }
            catch {
            return false;
            }
           
        }

        public IEnumerable<MemberViewModel> GetAllMember()
        {
            var member=_unitOfWork.GetRepository<Member>().GetAll();
            if (member == null || !member.Any()) return [];


            var memberViewModel = _mapper.Map<IEnumerable<Member>,IEnumerable<MemberViewModel>>(member);
            return memberViewModel;
        }

        public MemberViewModel? GetMemberDetails(int Memberid)
        {
           var member= _unitOfWork.GetRepository<Member>().GetById(Memberid);
            if (member == null) return null;
            var memberViewModel = _mapper.Map<Member, MemberViewModel>(member);
           
            var ActiveMembership = _unitOfWork.GetRepository<MemberShip>().GetAll(m => m.MemberID == Memberid && m.Status=="Active").FirstOrDefault();
         
            if (ActiveMembership is not null)
            {
                memberViewModel.MemberShipStartDate = ActiveMembership.CreatedAt.ToShortDateString();
                memberViewModel.MemberShipEndDate = ActiveMembership.EndDate.ToShortDateString();
                
                var plan= _unitOfWork.GetRepository<Plan>().GetById(ActiveMembership.planID);
                memberViewModel.PlaneName = plan?.Name;
            }
            return memberViewModel;


        }

        public MemberToUpdateViewModel? GetMemberForUpdate(int Memberid)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(Memberid);
            if (member == null) return null;
            return new MemberToUpdateViewModel()
            {
                Phone = member.Phone,
                Name = member.Name,
                ///photo = member.photo,
                BuildingNumber = member.Address.BuilderNumber,
                City = member.Address.City,
                Street = member.Address.Street,
            };
        }

        public HealthRecordViewModel? GetMemberHealthRecord(int Memberid)
        {
            var memberHealthRecord = _unitOfWork.GetRepository<Member>().GetById(Memberid);
            if (memberHealthRecord == null) return null;

            var healthRecordViewModel = _mapper.Map<HealthRecord, HealthRecordViewModel>(memberHealthRecord.HealthRecord);
            
            return healthRecordViewModel;
        }

        public bool UpdateMemberDetails(int Memberid, MemberToUpdateViewModel updateMember)
        {
            try { 
            var emailExists = _unitOfWork.GetRepository<Member>()
                .GetAll(x => x.Email == updateMember.Email && x.Id != Memberid).Any();


            var phoneExists = _unitOfWork.GetRepository<Member>()
                .GetAll(x => x.Phone == updateMember.Phone && x.Id != Memberid).Any();

                if (emailExists || phoneExists) return false;
                var member = _unitOfWork.GetRepository<Member>().GetById(Memberid);
                if(member == null) return false;
                member.phone = updateMember.Phone;
                member.Email=updateMember.Email;
                member.Name = updateMember.Name;
                member.Address.BuilderNumber = updateMember.BuildingNumber;
                member.Address.Street = updateMember.Street;
                member.Address.City = updateMember.City;
                member.UpdatedAt=DateTime.Now;

                _unitOfWork.GetRepository<Member>().Update(member);
                return _unitOfWork.SaveChange() > 0;
            } catch {
                return false;
            }
        }
            
        #region helper

        private bool IsEmailExists(String email)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(x=>x.Email==email).Any();


        }

        private bool IsPhoneExists(String phone)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(x => x.Email == phone).Any();

        }
        #endregion
    }
}
