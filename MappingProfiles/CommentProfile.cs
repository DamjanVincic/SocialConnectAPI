using AutoMapper;
using SocialConnectAPI.DTOs.Comments;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.MappingProfiles {
    public class CommentProfile : Profile {
        public CommentProfile() {
            CreateMap<Comment, GetCommentResponse>();

            CreateMap<CreateCommentRequest, Comment>();
            CreateMap<Comment, CreateCommentResponse>();

            CreateMap<UpdateCommentRequest, Comment>();
            CreateMap<Comment, UpdateCommentResponse>();
        }
    }
}