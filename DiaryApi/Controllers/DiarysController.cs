using BusinessLayer;
using DataAccessLayer.Metods;
using Microsoft.AspNetCore.Mvc;


namespace DiaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiarysController : ControllerBase
    {
        private readonly IBuiseness _buiseness;
        public DiarysController()
        {
            _buiseness = new BuisenessCodes();
        }
        [HttpGet("get-not-user")]
        public async Task<List<DiarysModel>> GetAllNote(int userId)
        {
            return await _buiseness.GetAllNote(userId);
        }
        [HttpGet("username-id")]
        public async Task<string> UserName(int id)
        {
            return await _buiseness.UserName(id);
        }
        [HttpGet("login-user")]
        public async Task<int> LoginUser(string userName, string password)
        {
            return await _buiseness.LoginUser(userName, password);
        }
        [HttpPut("update-diary-user")]
        public async Task<DiarysModel> UpdateDiary(int id, int userId, string note, string title)
        {
            return await _buiseness.UpdateDiary(id, userId, note, title);
        }
        [HttpPost("post-diary")]
        public async Task<string> PostRead(string note, int userId, string title)
        {
            return await _buiseness.PostRead(note, userId, title);
        }
        [HttpDelete("delete-diary-user")]
        public async Task<DiarysModel> DeleteDiary(int diaryId, int userId)
        {
            return await _buiseness.DeleteDiary(diaryId, userId);
        }

    }
}
