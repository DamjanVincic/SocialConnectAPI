using AutoMapper;
using SocialConnectAPI.DTOs.Posts;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.MappingProfiles {
    public class PostProfile : Profile {
        public PostProfile() {
            CreateMap<Post, GetPostResponse>();

            CreateMap<CreatePostRequest, Post>();
            CreateMap<Post, CreatePostResponse>();

            CreateMap<UpdatePostRequest, Post>();
            CreateMap<Post, UpdatePostResponse>();
        }
    }
}