﻿namespace Application.Features.Verbs.Queries.GetVerbById;

public record GetVerbByIdDto
{
    public string Id { get; set; } = null!;
    public string PresentTense { get; set; } = null!;
    public string DisplayForm { get; set; } = null!;
}