using AutoMapper;
using DTOs.Users;
using SocialConnectAPI.DTOs.Users;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.MappingProfiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, GetUserResponse>();
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UpdateUserResponse>();
        }
    }
}