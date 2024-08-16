using TravelDesk.Models;



namespace TravelDeskWebApi.IRepo
{
    public interface ILoginRepo
    {
        public User Login(User loginuser);
    }
}
