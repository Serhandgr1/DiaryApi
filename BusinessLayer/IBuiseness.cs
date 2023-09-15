using DataAccessLayer.Metods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBuiseness
    {
        Task<string> PostRead(string note, int userId, string title);
        Task<List<DiarysModel>> GetAllNote(int userId);
        Task<DiarysModel> DeleteDiary(int diaryId, int userId);
        Task<DiarysModel> UpdateDiary(int id, int userId, string note, string title);
        Task<int> LoginUser(string userName, string password);
        Task<string> UserName(int id);
    }
}
