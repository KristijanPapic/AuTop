﻿using AuTOP.Model;
using AuTOP.Repository.Common;
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

        public ReactionService(IReactionRepository reactionRepository)
        {
            this.ReactionRepository = reactionRepository;
        }
        protected IReactionRepository ReactionRepository { get; set; }



        public async Task<double> GetLikes()
        {
            return await ReactionRepository.GetLikes();
        }

        public async Task<bool> PostAsync(Reaction reaction)
        {
            return await ReactionRepository.PostAsync(reaction);
        }



    }
}
