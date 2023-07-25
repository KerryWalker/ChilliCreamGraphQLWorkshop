﻿using System.Linq;
using HotChocolate;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.DataLoader;

namespace ConferencePlanner.GraphQL
{
    [ExtendObjectType("Query")]
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();

        public Task<Speaker> GetSpeakerAsync(
    [ID(nameof(Speaker))] int id,
    SpeakerByIdDataLoader dataLoader,
    CancellationToken cancellationToken) =>
    dataLoader.LoadAsync(id, cancellationToken);
    }
}