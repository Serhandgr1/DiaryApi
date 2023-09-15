using DataAccessLayer.Metods;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class DataRepository : IDataRepository
    {

        public async Task<List<DiarysModel>> GetAllNote(int userId)
        {
            using (var db = new DataContext())
            {
                List<DiarysModel> diarysModel = new List<DiarysModel>();
                bool kt = await db.Users.AnyAsync(x => x.Id == userId);
                if (kt) {
                    var data = await db.Diarys.Where(x => x.UserId == userId).ToListAsync();
                    foreach (DiarysModel diarysModel1 in data)
                    {
                        diarysModel.Add(diarysModel1);
                    }
                    return diarysModel;
                }
                return diarysModel;
            }
        }
        public async Task<int> LoginUser(string userName, string password)
        {
            using (var db = new DataContext())
            {
                int id = 0;
                var data =  await db.Users.Where(x => x.UserName == userName && x.Password == password).ToListAsync();
                foreach (UsersModel user in data)
                {
                    return user.Id;
                }
                return id;
            }
        }
        public async Task<string> UserName(int id)
        {
            using (var db = new DataContext())
            {
                UsersModel usersModel = new UsersModel();
                bool kt = await db.Users.AnyAsync(x => x.Id == id);
                if (kt) {
                    var data = await db.Users.FindAsync(id);
                    return data.FirstName;
                }
               else return "User Bulunamadı";

            }
        }
        public async Task<string> PostRead(string note, int userId, string title)
        {
            using (var db = new DataContext())
            {
                DiarysModel diarysModel = new DiarysModel();
                bool kt = await db.Users.AnyAsync(x => x.Id == userId);
                if (kt) 
                {
                    diarysModel.UserId = userId;
                    diarysModel.Note = note;
                    diarysModel.Time = DateTime.Now;
                    diarysModel.Title = title;
                    await db.Diarys.AddAsync(diarysModel);
                    await db.SaveChangesAsync();
                    return "Kayıt Alındı";
                }
              else   return "User Bulunamadı";
            }
        }
        public async Task<DiarysModel> DeleteDiary(int diaryId, int userId)
        {
            using (var db = new DataContext())
            {
                DiarysModel diarys = new DiarysModel();
                bool kt = await db.Users.AnyAsync(x => x.Id == userId);
                bool kt2 = await db.Diarys.AnyAsync(x => x.Id == diaryId);
                if (kt && kt2)
                {
                    diarys.Id = diaryId;
                    diarys.UserId = userId;
                    db.Diarys.Remove(diarys);
                    await db.SaveChangesAsync();
                    return diarys;
                }
                else return diarys;

            }
        }
        public async Task<DiarysModel> UpdateDiary(int id, int userId, string note, string title)
        {
            using (var db = new DataContext())
            {
                DiarysModel Diarys = new DiarysModel();
                bool kt = await db.Users.AnyAsync(x => x.Id == userId);
                bool kt2 = await db.Diarys.AnyAsync(x => x.Id == id);
                if (kt && kt2)
                {
                    Diarys.Id = id;
                    Diarys.UserId = userId;
                    Diarys.Note = note;
                    Diarys.Title = title;
                    Diarys.Time = DateTime.Now;
                    db.Diarys.Update(Diarys);
                    await db.SaveChangesAsync();
                    return Diarys;
                }
                else  return Diarys; 
            }
        }
    }
}
