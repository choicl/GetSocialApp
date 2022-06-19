﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSocial.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        private PostInteraction()
        {
        }
        public Guid InteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }

        //Factory method
        public static PostInteraction CreatePostInteraction(Guid postId, InteractionType interactionType)
        {
            return new PostInteraction
            {
                PostId = postId,
                InteractionType = interactionType
            };
        }
    }
}
