using AuTOP.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Service
{
    public class ReactionService : IReactionService
    {

        public ReactionService(IReactionService reactionRepository)
        {
            this.ReactionRepository = reactionRepository;
        }
        protected IReactionService ReactionRepository { get; set; }



        public async Task<int> GetLikes()
        {
            return await ReactionRepository.GetLikes();
        }

        public async Task<int> GetDislikes()
        {
            return await ReactionRepository.GetDislikes();
        }
    }
}
