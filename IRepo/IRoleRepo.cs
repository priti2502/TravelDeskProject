﻿using TravelDesk.Models;


namespace TravelDeskWebApi.IRepo
{
    public interface IRoleRepo
    {
        public List<Role> GetAllRoles();

        public Role GetRoleById(int id);
    }
}
