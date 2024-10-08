﻿using TravelDesk.Models;


namespace TravelDeskWebApi.IRepo
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAllDepts();

        public Department GetDepartmentById(int id);
        
    }
}
