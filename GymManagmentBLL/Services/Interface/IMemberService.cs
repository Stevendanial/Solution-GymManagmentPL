using GymManagmentBLL.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interface
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetAllMember();
        bool CreateMember(CreateMemberViewModel CreateMember);
        MemberViewModel? GetMemberDetails(int Memberid);

        HealthRecordViewModel? GetMemberHealthRecord(int Memberid);
        bool UpdateMemberDetails(int Memberid, MemberToUpdateViewModel updateMember);
        MemberToUpdateViewModel? GetMemberForUpdate(int Memberid);
        bool RemoveMember(int Memberid);

    }
}
