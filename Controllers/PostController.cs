using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialConnectAPI.DataAccess.Posts;
using SocialConnectAPI.DTOs.Posts;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.Controllers {
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase {
        private IPostRepository postRepository;
        private IMapper mapper;

        public PostController (IPostRepository postRepository, IMapper mapper) {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all posts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GetPostResponse>> GetPosts() {
            List<Post> posts = postRepository.GetPosts();
            if (posts == null)
                return NotFound();
            return Ok(mapper.Map<List<GetPostResponse>>(posts));
        }

        /// <summary>
        /// Get a post by ID.
        /// </summary>
        /// <param name="id">Post ID.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetPostResponse> GetPostById(int id) {
            Post? post = postRepository.GetPostById(id);
            if (post == null)
                return NotFound();
            return Ok(mapper.Map<GetPostResponse>(post));
        }

        /// <summary>
        /// Get a list of posts by tag.
        /// </summary>
        /// <param name="tag">Tag to search for.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GetPostResponse>> GetPostsByTag(string tag) {
            List<Post> posts = postRepository.GetPostsByTag(tag);
            if (posts == null)
                return NotFound();
            return Ok(mapper.Map<List<GetPostResponse>>(posts));
        }

        /// <summary>
        /// Create a post.
        /// </summary>
        /// <param name="post">Post to create.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CreatePostResponse> CreatePost(CreatePostRequest post) {
            try {
                var createdPost = postRepository.CreatePost(mapper.Map<Post>(post));
                return Created($"api/posts/{createdPost.Id}", mapper.Map<CreatePostResponse>(createdPost));
            } catch {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update a post.
        /// </summary>
        /// <param name="post">Post to update.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UpdatePostResponse> UpdatePost(UpdatePostRequest post) {
            try {
                Post? postDB = postRepository.GetPostById(post.Id);
                if (postDB == null)
                    return NotFound();
                if (postDB.UserId != post.UserId)
                    return Unauthorized();
                
                mapper.Map(post, postDB);
                postRepository.SaveChanges();
                return Ok(mapper.Map<UpdatePostResponse>(postDB));
            } catch {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Delete a post.
        /// </summary>
        /// <param name="id">Post ID.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetPostResponse> DeletePost(int id) {
            try {
                Post post = postRepository.DeletePost(id);
                return Ok(mapper.Map<GetPostResponse>(post));
            } catch {
                return NotFound();
            }
        }

        /// <summary>
        /// Archive a post.
        /// </summary>
        /// <param name="id">Post ID.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("archive/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetPostResponse> ArchivePost(int id) {
            try {
                Post post = postRepository.ArchivePost(id);
                return Ok(mapper.Map<GetPostResponse>(post));
            } catch {
                return NotFound();
            }
        }

        /// <summary>
        /// Get top posts.
        /// </summary>
        /// <param name="number">Number of posts to get.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("top")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GetPostResponse>> GetTopPosts(int number) {
            List<Post> posts = postRepository.GetNumberOfPosts(number);
            if (posts == null)
                return NotFound();
            return Ok(mapper.Map<List<GetPostResponse>>(posts));
        }

        /// <summary>
        /// Like a post.
        /// </summary>
        /// <param name="postId">ID of post to like.</param>
        /// <param name="userId">ID of user to like the post.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("like")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult LikePost(int postId, int userId) {
            try {
                postRepository.LikePost(postId, userId);
                return Ok();
            } catch {
                return NotFound();
            }
        }
    }
}