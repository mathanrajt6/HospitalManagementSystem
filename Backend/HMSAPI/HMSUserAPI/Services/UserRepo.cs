using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.Context;
using HMSUserAPI.Models.Error;
using HMSUserAPI.Models.Logger;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Services
{
    public class UserRepo : IRepo<User,int>
    {
        private readonly UserContext _context;
        private readonly ICustomLogger _customLogger;

        public UserRepo(UserContext context,ICustomLogger customLogger)
        {
            _context = context;
            _customLogger = customLogger;
        }

        public async Task<User?> Add(User entity)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                if (_context.Users != null && _context.UserDetails != null && _context.Patients != null && _context.Doctors != null)
                {
                    await _context.Users.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return entity;

                }
                throw new ContextException("Context is empty");
            }
            catch(ContextException ce)
            {
                throw new ContextException(ce.Message);
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                await transaction.RollbackAsync();
            }
            return null;
        }

        public async Task<User?> Delete(User entity)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {

                if (_context.Users != null && _context.UserDetails != null && _context.Patients != null && _context.Doctors != null)
                {
                    _context.Users.Remove(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return entity;
                }
                throw new ContextException(ResponseMsg.Messages[12]);
            }
            catch (ContextException ce)
            {
                throw new ContextException(ce.Message);
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                await transaction.RollbackAsync();
            }
            return null;

        }

        public async Task<User?> Get(int key)
        {
            if (_context.Users != null && _context.UserDetails != null && _context.Patients != null && _context.Doctors != null)
            {
                return await _context.Users.Include(u=>u.UserDetail).ThenInclude(us=>us.Doctor).Include(u=>u.UserDetail).ThenInclude(us=>us.Patient).SingleOrDefaultAsync(u=>u.Id==key);
            }
            throw new ContextException(ResponseMsg.Messages[12]);
        }

        public async Task<List<User>?> GetAll()
        {
            if (_context.Users != null && _context.UserDetails != null && _context.Patients != null && _context.Doctors != null)
            {
                return await _context.Users.Include(u => u.UserDetail).ThenInclude(us => us.Doctor).Include(u => u.UserDetail).ThenInclude(us => us.Patient).ToListAsync();
            }
            throw new ContextException(ResponseMsg.Messages[12]);
        }

        public async Task<User?> Update(User entity)
        {

            var transaction = _context.Database.BeginTransaction();
            try
            {
                if (_context.Users != null && _context.UserDetails != null && _context.Patients != null && _context.Doctors != null)
                {
                    _context.Users.Update(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return entity;
                }
                throw new ContextException(ResponseMsg.Messages[12]);
            }
            catch (ContextException ce)
            {
                throw new ContextException(ce.Message);
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                await transaction.RollbackAsync();
            }
            return null;
        }
    }
}
