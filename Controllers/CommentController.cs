using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialConnectAPI.DataAccess.Comments;
using SocialConnectAPI.DTOs.Comments;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.Controllers {
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentController(ICommentRepository commentRepository, IMapper mapper) {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all comments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GetCommentResponse>> GetComments() {
            List<Comment> comments = commentRepository.GetComments();
            if (comments == null)
                return NotFound();
            return Ok(mapper.Map<List<GetCommentResponse>>(comments));
        }

        /// <summary>
        /// Get a comment by user that created it.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GetCommentResponse>> GetCommentByUserId(int userId) {
            List<Comment> comments = commentRepository.GetCommentsByUserId(userId);
            if (comments == null)
                return NotFound();
            return Ok(mapper.Map<List<GetCommentResponse>>(comments));
        }

        /// <summary>
        /// Create a comment.
        /// </summary>
        /// <param name="comment">Comment to create.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CreateCommentResponse> CreateComment(CreateCommentRequest comment) {
            try {
                Comment createdComment = commentRepository.CreateComment(mapper.Map<Comment>(comment));
                return Ok(mapper.Map<CreateCommentResponse>(createdComment));
            } catch {
                return NotFound();
            }
        }

        /// <summary>
        /// Update a comment.
        /// </summary>
        /// <param name="comment">Comment to update.</param>
        /// <param name="userId">ID of user that created the comment.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UpdateCommentResponse> UpdateComment(UpdateCommentRequest comment, int userId) {
            try {
                Comment? commentDB = commentRepository.GetCommentById(comment.Id);
                if (commentDB == null)
                    return NotFound();
                if (commentDB.UserId != userId)
                    return Unauthorized();
                mapper.Map(comment, commentDB);
                commentRepository.SaveChanges();
                return Ok(mapper.Map<UpdateCommentResponse>(commentDB));
            } catch {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Delete a comment.
        /// </summary>
        /// <param name="id">Comment ID.</param>
        /// <param name="userId">ID of user that created the comment, or user that created the post the comment is on.</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetCommentResponse> DeleteComment(int id, int userId) {
            Comment? comment = commentRepository.GetCommentById(id);
            if (comment == null)
                return NotFound();
            if (userId != comment.UserId && userId != comment.Post.UserId)
                return Unauthorized();
            
            Comment deletedComment = commentRepository.DeleteComment(id);
            return Ok(mapper.Map<GetCommentResponse>(deletedComment));
        }
    }
}