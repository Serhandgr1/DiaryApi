using DataAccessLayer;
using DataAccessLayer.Metods;


namespace BusinessLayer
{
    public class BuisenessCodes : IBuiseness
    {
        private readonly IDataRepository _dataRepository;
        public BuisenessCodes()
        {
            _dataRepository = new DataRepository();
        }
        public async Task<string> PostRead(string note, int userId, string title)
        {
            if (userId > 0 && note!="" && title!="")
            { return await _dataRepository.PostRead(note, userId, title); }
            else return "UserId 1 den küçük olamaz ayrıca başlık ve not boş olamaz";
          
        }

        public async Task<List<DiarysModel>> GetAllNote(int userId)
        {
            if (userId > 0) return await _dataRepository.GetAllNote(userId);
            else return new List<DiarysModel>();

        }

        public async Task<DiarysModel> DeleteDiary(int diaryId, int userId)
        {
            if (userId > 0 && diaryId>0) { return await _dataRepository.DeleteDiary(diaryId, userId); }
            else return new DiarysModel();
        }

        public async Task<DiarysModel> UpdateDiary(int id, int userId, string note, string title)
        {
            if (userId > 0 && id > 0 && note != "" && title != "")
            { return await _dataRepository.UpdateDiary(id, userId, note, title);}
            else return new DiarysModel();  
        }

        public async Task<int> LoginUser(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password)) { return await _dataRepository.LoginUser(userName, password); }
            else { return 0; }
        }

        public async Task<string> UserName(int id)
        {
            if (id > 0) { return await _dataRepository.UserName(id); }
            else return "UserId 1 den küçük olamaz";

        }
    }

}
