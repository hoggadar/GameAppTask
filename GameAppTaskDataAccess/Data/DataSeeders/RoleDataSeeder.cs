﻿using GameAppTaskDataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace GameAppTaskDataAccess.Data.DataSeeders
{
    public class RoleDataSeeder
    {
        private static readonly string[] RoleNames = { "Admin", "User" };
        private readonly RoleManager<RoleModel> _roleManager;
        
        public RoleDataSeeder(RoleManager<RoleModel> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            foreach (var role in RoleNames)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new RoleModel { Name = role });
                }
            }
        }
    }
}
