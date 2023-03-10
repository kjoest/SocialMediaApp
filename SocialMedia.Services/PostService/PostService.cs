using SocialMedia.Data.PostData;
using SocialMedia.Models.PostModels;
using SocialMedia.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.PostService
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost (PostCreate model, string path)
        {
            var entity = new Post()
            {
                OwnerId = _userId,
                Content = model.PostText,
                CreatedUtc = DateTimeOffset.Now,
                ImagePath = path
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListDetail> GetAllPosts()
        {
           using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(p => p.OwnerId == _userId)
                    .Select(p => new PostListDetail
                    {
                        PostId = p.PostId,
                        PostText = p.Content,
                        ImagePath = p.ImagePath,
                        CreatedUtc = p.CreatedUtc,
                        ModifiedUtc = p.ModifiedUtc,
                    });

                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(p => p.PostId == id && p.OwnerId == _userId);
                return new PostDetail
                {
                    PostId = entity.PostId,
                    PostText = entity.Content,
                    ImagePath = entity.ImagePath,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(p => p.PostId == model.PostId && p.OwnerId == _userId);

                entity.PostId = model.PostId;
                entity.Content = model.PostText;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(p => p.PostId == id && p.OwnerId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
