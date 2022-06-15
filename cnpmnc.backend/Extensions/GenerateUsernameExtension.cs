using cnpmnc.backend.Models;
using cnpmnc.shared.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace cnpmnc.backend.Extensions
{
    public static class GenerateUsernameExtension
    {
        public static string GenerateUsername(IBaseRepository<Account> _teacherRepository)
        {
            var getMaxId = _teacherRepository.Entities.FirstOrDefault(s => s.Id == _teacherRepository.Entities.Max(x => x.Id));
            int newId = 1;
            if (getMaxId != null)
            {
                var Id = _teacherRepository.Entities.Where(s => s.Id == getMaxId.Id).FirstOrDefault().Username.Substring(2, 4);
                newId = Convert.ToInt32(Id) + 1;
                string staffId = "gv" + String.Format("{0:D4}", newId);
                return staffId;
            }
            else
            {
                string staffId = "gv" + String.Format("{0:D4}", newId);
                return staffId;
            }
        }
    }
}

