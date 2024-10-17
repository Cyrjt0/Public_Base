#pragma warning disable


using System;
using System.Net;

namespace APIs
{
    /// <summary>
    /// Bản thiết kế của bảng Users ( Quản lý tài khoản )
    /// </summary>
    public class Users
    {
        public Guid UserId { get; set; }
        public string UsersAccount { get; set; }
        public string UsersPassword { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string StateIDCard { get; set; }
        public string Email { get; set; }
        public bool IsLock { get; set; }
        public bool IsBlock { get; set; }
        public bool IsActive { get; set; }
        public bool StatusLogin { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }

    public class CreateUser : Users
    {
        public CreateUser
        (
            string usersAccount, 
            string usersPassword,
            string fullName,
            string address,
            string phoneNumber,
            string stateIDCard,
            string email
        )
        {
            UserId = new Guid();
            UsersAccount = usersAccount;
            UsersPassword = usersPassword;
            FullName = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
            StateIDCard = stateIDCard;
            Email = email;
            IsLock = false;
            IsBlock = false;
            IsActive = false;
            CreateTime = DateTime.Now;
        }
    }

    public class UpdateUser : Users
    {
        public UpdateUser
        (
            Guid userId,
            string usersPassword,
            string fullName,
            string address,
            string phoneNumber,
            string stateIDCard,
            string email
        )
        {
            UserId = userId;
            UsersPassword = usersPassword;
            FullName = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
            StateIDCard = stateIDCard;
            Email = email;
            UpdateTime = DateTime.Now;
        }
    }

    public class DeleteUser : Users
    {
        public DeleteUser(Guid userId)
        {
            UserId = userId;
        }
    }

    public class LockUser : Users
    {
        public LockUser(Guid userId)
        {
            UserId = userId;
            IsLock = true;
        }
    }

    public class BlockUser : Users
    {
        public BlockUser(Guid userId)
        {
            UserId = userId;
            IsBlock = true;
        }
    }

    public class ActiveUser : Users
    {
        public ActiveUser(Guid userId)
        {
            UserId = userId;
            IsActive = true;
        }
    }

}
