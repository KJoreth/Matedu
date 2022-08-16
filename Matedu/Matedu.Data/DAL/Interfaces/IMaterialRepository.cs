﻿namespace Matedu.Data.DAL.Interfaces
{
    public interface IMaterialRepository : IBaseRepository<Material>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<bool> AnyByTtileAsync(string title);
        Task<List<Material>> GetAllByTypeIdAsync(int typeId);
        Task<Material> GetSingleAsNoTrackingByIdAsync(int id);
        Task<Material> GetSingleWithAllFieldsByIdAsync(int id);
    }
}